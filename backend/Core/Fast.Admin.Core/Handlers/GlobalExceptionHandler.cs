﻿// Apache开源许可证
//
// 版权所有 © 2018-2024 1.8K仔
//
// 特此免费授予获得本软件及其相关文档文件（以下简称“软件”）副本的任何人以处理本软件的权利，
// 包括但不限于使用、复制、修改、合并、发布、分发、再许可、销售软件的副本，
// 以及允许拥有软件副本的个人进行上述行为，但须遵守以下条件：
//
// 在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，
// 无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Fast.UnifyResult;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Fast.Admin.Core.Handlers;

/// <summary>
/// <see cref="GlobalExceptionHandler"/> 全局异常处理
/// </summary>
public class GlobalExceptionHandler : IGlobalExceptionHandler
{
    private readonly ILogger<IGlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<IGlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>异常拦截</summary>
    /// <param name="context"><see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" /></param>
    /// <param name="isUserFriendlyException"><see cref="T:System.Boolean" /> 是否友好异常</param>
    /// <param name="isValidationException"><see cref="T:System.Boolean" /> 是否验证异常</param>
    /// <returns></returns>
    public async Task OnExceptionAsync(ExceptionContext context, bool isUserFriendlyException, bool isValidationException)
    {
        // 判断是否为验证异常
        if (!isValidationException)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
        }

        await Task.CompletedTask;
    }
}