// Apache开源许可证
//
// 版权所有 © 2018-2023 1.8K仔
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

using Fast.JwtBearer.Utils;
using Fast.NET;
using Fast.SpecificationProcessor.UnifyResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Fast.JwtBearer.Handlers;

/// <summary>
/// 授权策略执行程序
/// </summary>
[InternalSuppressSniffer]
public abstract class AppAuthorizationHandler : IAuthorizationHandler
{
    /// <summary>Makes a decision if authorization is allowed.</summary>
    /// <param name="context">The authorization information.</param>
    public async Task HandleAsync(AuthorizationHandlerContext context)
    {
        var httpContext = context.Resource as DefaultHttpContext;

        // 判断是否授权
        if (context.User.Identity?.IsAuthenticated == true)
        {
            // 禁止使用刷新 Token 进行单独校验
            if (JwtCryptoUtil.RefreshTokenClaims.All(a => context.User.Claims.Any(c => c.Type == a)))
            {
                context.Fail();
            }
            else
            {
                // 获取所有未成功验证的需求
                var pendingRequirements = context.PendingRequirements;

                // 获取 JWT 处理类
                var jwtBearerProvider = httpContext?.RequestServices.GetService<IJwtBearerProvider>();

                if (jwtBearerProvider != null)
                {
                    if (await jwtBearerProvider.AuthorizeHandle(context))
                    {
                        // 权限检测
                        foreach (var requirement in pendingRequirements)
                        {
                            if (await jwtBearerProvider.PermissionHandle(context, requirement))
                            {
                                context.Succeed(requirement);
                            }
                            else
                            {
                                // 授权失败，403
                                context.Fail();
                            }
                        }
                    }
                    else
                    {
                        // 授权失败，401
                        context.Fail();
                    }
                }
                else
                {
                    foreach (var requirement in pendingRequirements)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
        }
        else
        {
            httpContext?.SignOutToSwagger();
        }
    }

    /// <summary>
    /// 授权处理
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    protected async Task AuthorizeHandleAsync(AuthorizationHandlerContext context)
    {
        // 获取 HttpContext 上下文
        var httpContext = context.Resource as DefaultHttpContext;

        // 获取所有未成功验证的需求
        var pendingRequirements = context.PendingRequirements;

        // 调用子类管道
        var pipeline = await PipelineAsync(context, httpContext);
        if (pipeline)
        {
            // 通过授权验证
            foreach (var requirement in pendingRequirements)
            {
                // 验证策略管道
                var policyPipeline = await PolicyPipelineAsync(context, httpContext, requirement);
                if (policyPipeline)
                    context.Succeed(requirement);
                else
                    context.Fail();
            }
        }
        else
        {
            context.Fail();
        }
    }

    /// <summary>
    /// 验证管道
    /// </summary>
    /// <param name="context"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public async Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
    {
        return await Task.FromResult(true);
    }

    /// <summary>
    /// 策略验证管道
    /// </summary>
    /// <param name="context"></param>
    /// <param name="httpContext"></param>
    /// <param name="requirement"></param>
    /// <returns></returns>
    public async Task<bool> PolicyPipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext,
        IAuthorizationRequirement requirement)
    {
        return await Task.FromResult(true);
    }
}