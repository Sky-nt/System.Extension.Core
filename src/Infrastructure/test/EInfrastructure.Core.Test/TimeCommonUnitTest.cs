// Copyright (c) zhenlei520 All rights reserved.

using System;
using System.Linq;
using System.Threading;
using EInfrastructure.Core.Configuration.Enumerations;
using EInfrastructure.Core.Test.Base;
using EInfrastructure.Core.Tools;
using EInfrastructure.Core.Tools.Common;
using EInfrastructure.Core.Tools.Configuration;
using EInfrastructure.Core.Tools.Enumerations;
using Xunit;

namespace EInfrastructure.Core.Test
{
    public class TimeCommonUnitTest : BaseUnitTest
    {
        [Theory]
        [InlineData("2019-07-29 14:00", '-', "2019-07-29")]
        [InlineData("", '/', null)]
        public void GetFormatDate(string time, char separator, string result)
        {
            DateTime dateTime = time.ConvertToDateTime(default(DateTime));
            // Check.True(dateTime.GetFormatDate( separator) == result, "检查错误");
        }

        [Theory]
        [InlineData(70, 2, true)]
        [InlineData(70, 1, false)]
        [InlineData(70, 2, false)]
        public void SecondToMinute(int second, int min, bool isCelling)
        {
            Check.True(
                TimeCommon.SecondToMinute(second, isCelling ? RectificationType.Celling : RectificationType.Floor) ==
                min, "转换有误");
        }

        [Fact]
        public void GetRandomTime()
        {
            var s=DateTime.Parse("2020-12-26").IsInSameWeek(DateTime.Parse("2020-12-20"),Nationality.China);
            var s2 =DateTime.Parse("2020-12-21").IsInSameWeek(DateTime.Parse("2020-12-27"),Nationality.China);
            DateTime dateTime = DateTime.Now.GetRandomTime( DateTime.Now.AddDays(100));
            var result = dateTime.FormatDate(FormatDateType.One);
        }

        [Theory]
        [InlineData(2019, 1, "2019-01-01", "2019-01-31")]
        [InlineData(2019, 2, "2019-02-01", "2019-02-28")]
        [InlineData(2019, 12, "2019-12-01", "2019-12-31")]
        [InlineData(2000, 2, "2000-02-01", "2000-02-29")]
        public void ReturnDateFormat(int year, int month, string firstDay, string lastDay)
        {
            string firstDay2 = TimeCommon.GetSpecifyMonthFirstDay(year, month).FormatDate(FormatDateType.Zero);
            string lastDay2 = TimeCommon.GetSpecifyMonthLastDay(year, month).FormatDate(FormatDateType.Zero);
            Check.True(firstDay == firstDay2, "方法有误");
            Check.True(lastDay == lastDay2, "方法有误");
        }

        [Theory]
        [InlineData("1994-11-09", "[狗]甲戌1994 十月初七")]
        public void ConvertToLunar(string dateTime, string dateTime2)
        {
            string result = dateTime.ConvertToDateTime(default(DateTime)).ConvertToLunar();
            Check.True(result == dateTime2, "方法异常");
        }

        [Theory]
        [InlineData("1994-11-09", "[狗]甲戌1994")]
        public void GetYear(string dateTime, string dateTime2)
        {
            string result = dateTime.ConvertToDateTime(default(DateTime)).GetYear();
            Check.True(result == dateTime2, "方法异常");
        }

        [Theory]
        [InlineData("1994-11-09", "十月")]
        public void GetMonth(string dateTime, string dateTime2)
        {
            string result = dateTime.ConvertToDateTime(default(DateTime)).GetMonth();
            Check.True(result == dateTime2, "方法异常");
        }

        [Theory]
        [InlineData("1994-11-09", "初七")]
        public void GetDay(string dateTime, string dateTime2)
        {
            string result = dateTime.ConvertToDateTime(default(DateTime)).GetDay();
            Check.True(result == dateTime2, "方法异常");
        }

        [Theory]
        [InlineData("2019-07-07", "小暑")]
        public void GetSolarTerm(string dateTime, string dateTime2)
        {
            string result = dateTime.ConvertToDateTime(default(DateTime)).GetSolarTerm();
            Check.True(result == dateTime2, "方法异常");
        }

        [Theory]
        [InlineData("2019-01-01", "元宵")]
        [InlineData("2019-10-01", "国庆节")]
        public void GetHoliday(string dateTime, string dateTime2)
        {
            string result = dateTime.ConvertToDateTime(default(DateTime)).GetHoliday();
            Check.True(result == dateTime2, "方法异常");
        }

        [Theory]
        [InlineData("2019-02-05", "春节")]
        public void GetChinaHoliday(string dateTime, string dateTime2)
        {
            string result = dateTime.ConvertToDateTime(default(DateTime)).GetChinaHoliday();
            Check.True(result == dateTime2, "方法异常");
        }


        [Theory]
        [InlineData("2019-02-05", "2019-03-11")]
        public void GetLunarYearDate(string dateTime, string dateTime2)
        {
            DateTime result = dateTime.ConvertToDateTime(default(DateTime)).GetLunarYearDate();
            Check.True(result.FormatDate(FormatDateType.Zero) == dateTime2, "方法异常");
        }

        [Theory]
        [InlineData("2019-03-11", "2019-02-05")]
        public void GetSunYearDate(string dateTime, string dateTime2)
        {
            DateTime result = dateTime.ConvertToDateTime(default(DateTime)).GetSunYearDate();
            Check.True(result.FormatDate(FormatDateType.Zero) == dateTime2, "方法异常");
        }


        [Fact]
        public void ToUnixTimestamp()
        {
            long test = DateTime.Now.ToUnixTimestamp(TimestampType.Millisecond);
        }

        [Fact]
        public void UnixTimeStampToDateTime()
        {
            long time = DateTime.Now.ToUnixTimestamp(TimestampType.Millisecond);
            long time2 = DateTime.Now.ToUnixTimestamp(TimestampType.Second);

            var time3 = Extensions.UnixTimeStampToDateTime(time);
            var time4 = Extensions.UnixTimeStampToDateTime(time2);
        }

        [Theory]
        [InlineData("2019-07-29", 1)]
        public void GetDayName(string date, int dateStr)
        {
            var weekName = Week.GetAll<Week>().Where(x => x.Id == dateStr).Select(x => x.Name);
            Week time = DateTime.Parse(date).GetDayName();
            Check.True(time == weekName, "方法异常");
        }

        [Theory]
        [InlineData("2019-12-9")]
        [InlineData("2019-12-14")]
        [InlineData("2019-12-15")]
        [InlineData("2019-12-18")]
        [InlineData("2019-1-18")]
        [InlineData("2019-2-18")]
        public void Get(string time)
        {
            var result = Extensions.Get(DateTime.Parse(time), TimeType.StartWeek);
            result = Extensions.Get(DateTime.Parse(time), TimeType.EndWeek);
            result = Extensions.Get(DateTime.Parse(time), TimeType.StartQuarter);
            result = Extensions.Get(DateTime.Parse(time), TimeType.EndQuarter);
        }

        /// <summary>
        ///
        /// </summary>
        [Fact]
        public void GetTotalTime()
        {
            Assert.True( DateTime.Parse("2020-11-26").GetHoliday()=="感恩节");
            var str = new TimeElapsed(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine($"i：{i}");
                }
                Thread.Sleep(1000);
            }).ToString();
        }
    }
}
