// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EInfrastructure.Core.Configuration.Enumerations.SeedWork;

namespace EInfrastructure.Core.Configuration.Enumerations
{
    /// <summary>
    /// 性别
    /// </summary>
    public class Gender : Enumeration
    {
        /// <summary>
        /// 未知
        /// </summary>
        public static Gender Unknow = new Gender(1, "未知");

        /// <summary>
        /// 男
        /// </summary>
        public static Gender Boy = new Gender(2, "男");

        /// <summary>
        /// 女
        /// </summary>
        public static Gender Girl = new Gender(3, "女");

        public Gender()
        {

        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name">描述</param>
        public Gender(int id, string name) : base(id, name)
        {
        }
    }
}
