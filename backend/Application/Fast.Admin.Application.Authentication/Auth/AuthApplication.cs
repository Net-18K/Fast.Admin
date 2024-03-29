﻿using Fast.Admin.Service.Authentication.Auth;
using Fast.Admin.Service.Authentication.Auth.Dto;
using Fast.JwtBearer.Attributes;

namespace Fast.Admin.Application.Authentication.Auth;

/// <summary>
/// <see cref="AuthApplication"/> 授权
/// </summary>
[ApiDescriptionSettings(ApiGroupConst.Auth, Name = "auth", Order = 101)]
public class AuthApplication : IDynamicApplication
{
    private readonly IAuthService _authService;

    public AuthApplication(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// 获取登录用户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("/getLoginUserInfo"), ApiInfo("获取登录用户信息", HttpRequestActionEnum.Auth), SkipPermission]
    public async Task<GetLoginUserInfoOutput> GetLoginUserInfo()
    {
        return await _authService.GetLoginUserInfo();
    }
}