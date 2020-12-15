﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using EInfrastructure.Core.Tools.Component;
using EInfrastructure.Core.Tools.Internal;

namespace EInfrastructure.Core.Tools
{
    /// <summary>
    /// 校验类
    /// </summary>
    public partial class Extensions
    {
        #region 初始化校验

        private static IRegexConfigurationsProvider _regexConfigurations;
        private static ICollection<IMobileRegexConfigurationsProvider> _mobileRegexConfigurations;

        /// <summary>
        /// 初始化校验
        /// </summary>
        static void InitValidate()
        {
            _regexConfigurations = new RegexConfigurationsValidateDefaultProvider();
            _mobileRegexConfigurations = ServiceProvider.GetServiceProvider()
                .GetServices<IMobileRegexConfigurationsProvider>().ToList();
        }

        #endregion

        #region 是否为Double类型

        /// <summary>
        /// 是否为Double类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDouble(this object expression)
        {
            return expression.ConvertToDouble() != null;
        }

        #endregion

        #region 是否为Decimal类型

        /// <summary>
        /// 是否为Decimal类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDecimal(this object expression)
        {
            return expression.ConvertToDecimal() != null;
        }

        #endregion

        #region 是否为Long类型

        /// <summary>
        /// 是否为Long类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsLong(this object expression)
        {
            return expression.ConvertToLong() != null;
        }

        #endregion

        #region 是否为Int类型

        /// <summary>
        /// 是否为Int类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsInt(this object expression)
        {
            return expression.ConvertToInt() != null;
        }

        #endregion

        #region 是否为Short类型

        /// <summary>
        /// 是否为Short类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsShort(this object expression)
        {
            return expression.ConvertToShort() != null;
        }

        #endregion

        #region 是否为Guid类型

        /// <summary>
        /// 是否为Guid类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsGuid(this object expression)
        {
            return expression.ConvertToGuid() != null;
        }

        #endregion

        #region 是否为Char类型

        /// <summary>
        /// 是否为Char类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsChar(this object expression)
        {
            return expression.ConvertToChar() != null;
        }

        #endregion

        #region 是否为Float类型

        /// <summary>
        /// 是否为Float类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsFloat(this object expression)
        {
            return expression.ConvertToFloat() != null;
        }

        #endregion

        #region 是否为DateTime类型

        /// <summary>
        /// 是否为DateTime类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDateTime(this object expression)
        {
            return expression.ConvertToDateTime() != null;
        }

        #endregion

        #region 是否为Byte类型

        /// <summary>
        /// 是否为Byte类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsByte(this object expression)
        {
            return expression.ConvertToByte() != null;
        }

        #endregion

        #region 是否为SByte类型

        /// <summary>
        /// 是否为SByte类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsSByte(this object expression)
        {
            return expression.ConvertToSByte() != null;
        }

        #endregion

        #region 是否为Bool类型

        /// <summary>
        /// 是否为Bool类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsBool(this object expression)
        {
            return expression.ConvertToBool() != null;
        }

        #endregion

        #region 设置正则表达式配置驱动（不建议更换默认配置）

        /// <summary>
        /// 设置正则表达式配置驱动（不建议更换默认配置）
        /// </summary>
        /// <param name="regexConfigurations"></param>
        public static void SetRegexConfigurations(IRegexConfigurationsProvider regexConfigurations)
        {
            _regexConfigurations = regexConfigurations ?? throw new ArgumentNullException(nameof(regexConfigurations));
        }

        #endregion

        #region 得到正则表达式配置驱动

        /// <summary>
        /// 得到正则表达式配置驱动
        /// </summary>
        /// <returns></returns>
        public static IRegexConfigurationsProvider GetRegexConfigurations()
        {
            return _regexConfigurations;
        }

        #endregion

        #region 刷新手机号验证

        /// <summary>
        /// 刷新手机号验证
        /// </summary>
        /// <param name="regexConfigurationses"></param>
        public static void RefreshMobileRegexConfigurations(
            ICollection<IMobileRegexConfigurationsProvider> regexConfigurationses)
        {
            _mobileRegexConfigurations = regexConfigurationses ?? new List<IMobileRegexConfigurationsProvider>();
        }

        #endregion
    }
}