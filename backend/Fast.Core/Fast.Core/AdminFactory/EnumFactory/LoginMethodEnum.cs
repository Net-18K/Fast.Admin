﻿using System.ComponentModel;

namespace Fast.Core.AdminFactory.EnumFactory;

/// <summary>
/// 登录方式枚举
/// </summary>
[FastEnum("登录方式枚举")]
public enum LoginMethodEnum
{
    /// <summary>
    /// 账号
    /// </summary>
    [Description("账号")]
    Account = 1,

    /// <summary>
    /// 邮箱
    /// </summary>
    [Description("邮箱")]
    Email = 2,

    /// <summary>
    /// 手机号
    /// </summary>
    [Description("手机号")]
    Phone = 3
}