using System;
using System.IO;
using EInfrastructure.Core.Interface.IOC;
using EInfrastructure.Core.Interface.Storage;
using EInfrastructure.Core.Interface.Storage.Param;

namespace EInfrastructure.Core.UCloud.Storage
{
    /// <summary>
    /// UCloud存储实现类
    /// </summary>
    public class StorageProvider : BaseStorageProvider, IStorageService, ISingleInstance
    {
        /// <summary>
        /// UCloud存储实现类
        /// </summary>
        public StorageProvider()
        {
        }

        #region 根据文件流上传

        /// <summary>
        /// 根据文件流上传
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool UploadStream(UploadByStreamParam param)
        {
            return base.UploadFile(param.Stream, param.Key, Path.GetExtension(param.Key));
        }

        #endregion

        #region 根据文件上传

        /// <summary>
        /// 根据文件上传
        /// </summary>
        /// <param name="param">文件上传配置</param>
        /// <returns></returns>
        public bool UploadFile(UploadByFormFileParam param)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region 得到上传文件策略信息

        /// <summary>
        /// 得到上传文件策略信息
        /// </summary>
        /// <param name="opsParam">上传信息</param>
        public string GetUploadCredentials(UploadPersistentOpsParam opsParam)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region 得到上传文件策略信息

        /// <summary>
        /// 得到上传文件策略信息
        /// </summary>
        /// <param name="opsParam">上传信息</param>
        /// <param name="func"></param>
        public string GetUploadCredentials(UploadPersistentOpsParam opsParam, Func<string> func)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}