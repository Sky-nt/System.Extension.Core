﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace EInfrastructure.Core.Configuration.Internal.Common
{
    /// <summary>
    /// 唯一方法实现
    /// </summary>
    internal static class UniqueCommon
    {
        #region 重写HashCode方法

        /// <summary>
        /// 重写HashCode方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static int GetHashCode(this string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        #endregion
    }
}
