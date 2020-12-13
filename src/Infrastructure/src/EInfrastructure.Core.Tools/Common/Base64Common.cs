// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EInfrastructure.Core.Tools.Common
{
    /// <summary>
    /// base64 coding scheme
    /// </summary>
    public class Base64Common
    {
        private static IDictionary<string, string> Mappings =
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"data:image/jpeg;base64", "image/jpeg"},
                {"data:image/png;base64", "image/png"},
                {"data:image/gif;base64", "image/gif"},
                {"data:image/x-icon;base64", "image/x-icon"},
                {"data:text/css;base64", "text/css"},
                {"data:text/javascript;base64", "application/x-javascript"},
                {"data:text/html;base64", "text/html"},
            };

        #region reset data

        /// <summary>
        /// reset data
        /// </summary>
        public static void Reset()
        {
            Mappings = new Dictionary<string, string>();
        }

        #endregion

        #region Set base64 coding scheme

        /// <summary>
        /// Set base64 coding scheme
        /// </summary>
        /// <param name="maps"></param>
        public static void Set(Dictionary<string, string> maps)
        {
            Mappings = maps;
        }

        #endregion

        #region Get Base64 Coding Scheme

        /// <summary>
        /// Get Base64 Coding Scheme
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, string> Get()
        {
            return Mappings;
        }

        #endregion

        #region Add coding Scheme

        /// <summary>
        /// Add coding Scheme
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="isReplace">The default to replace</param>
        public static void Add(Dictionary<string, string> maps, bool isReplace = true)
        {
            foreach (var map in maps)
            {
                if (isReplace && Mappings.All(x => x.Key == map.Key))
                {
                    Mappings.Remove(map.Key);
                }

                Mappings.Add(map);
            }
        }

        #endregion

        #region GetBaseEncoding

        /// <summary>
        /// 得到文件base编码信息
        /// </summary>
        /// <param name="contentType">文件类型</param>
        /// <returns></returns>
        public static string GetBaseEncoding(string contentType)
        {
            return Mappings.Where(x => x.Value == contentType).Select(x => x.Key).FirstOrDefault();
        }

        #endregion

        #region base64编码与解码

        #region base64编码

        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string EncodeBase64(string param)
        {
            return EncodeBase64(param, Encoding.UTF8);
        }

        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="param"></param>
        /// <param name="encoding">编码方式</param>
        /// <returns></returns>
        public static string EncodeBase64(string param, Encoding encoding)
        {
            return param.ConvertToByteArray(encoding).ConvertToBase64();
        }

        #endregion

        #region base64解码

        /// <summary>
        /// base64解码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string DecodeBase64(string param)
        {
            return DecodeBase64(param, Encoding.UTF8);
        }

        /// <summary>
        /// base64解码
        /// </summary>
        /// <param name="param"></param>
        /// <param name="encoding">编码方式</param>
        /// <returns></returns>
        public static string DecodeBase64(string param, Encoding encoding)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(param);
            try
            {
                decode = encoding.GetString(bytes);
            }
            catch
            {
                decode = param;
            }

            return decode;
        }

        #endregion

        #endregion
    }
}
