﻿using System;
using EInfrastructure.Core.Interface.Storage.Param;

namespace EInfrastructure.Core.Interface.Storage
{
    /// <summary>
    /// 文件存储
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// 根据文件流上传
        /// </summary>
        /// <param name="param">文件流上传配置</param>
        /// <returns></returns>
        bool UploadStream(UploadByStreamParam param);

        /// <summary>
        /// 根据文件上传
        /// </summary>
        /// <param name="param">文件上传配置</param>
        /// <returns></returns>
        bool UploadFile(UploadByFormFileParam param);

        /// <summary>
        /// 得到上传文件策略信息
        /// </summary>
        /// <param name="opsParam">上传信息</param>
        /// <param name="func"></param>
        string GetUploadCredentials(UploadPersistentOpsParam opsParam, Func<string> func);
    }
}