﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EInfrastructure.Core.Configuration.Ioc.Plugs.Storage.Params.Storage;
using FluentValidation;

namespace EInfrastructure.Core.QiNiu.Storage.Validator.Storage
{
    /// <summary>
    ///
    /// </summary>
    internal class GetVisitUrlParamValidator:AbstractValidator<GetVisitUrlParam>
    {
        /// <summary>
        ///
        /// </summary>
        public GetVisitUrlParamValidator()
        {
            RuleFor(x => x.Key).Must(x => !string.IsNullOrEmpty(x)).WithMessage("请输入文件key");
            RuleFor(x => x.Expire).GreaterThan(0).WithMessage("过期时间必须大于0");
        }
    }
}
