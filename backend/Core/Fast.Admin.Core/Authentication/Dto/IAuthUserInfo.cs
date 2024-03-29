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

using Fast.Admin.Core.Enum.Common;

namespace Fast.Admin.Core.Authentication.Dto;

/// <summary>
/// <see cref="IAuthUserInfo"/> 授权用户信息
/// </summary>
public interface IAuthUserInfo
{
    /// <summary>
    /// 租户Id
    /// </summary>
    long TenantId { get; set; }

    /// <summary>
    /// 租户编号
    /// </summary>
    string TenantNo { get; set; }

    /// <summary>
    /// 用户Id
    /// </summary>
    long UserId { get; set; }

    /// <summary>
    /// 用户账号
    /// </summary>
    string Account { get; set; }

    /// <summary>
    /// 用户工号
    /// </summary>
    string JobNumber { get; set; }

    /// <summary>
    /// 用户名称
    /// </summary>
    string UserName { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    string NickName { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    string Avatar { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    DateTime? Birthday { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    GenderEnum Sex { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    string Email { get; set; }

    /// <summary>
    /// 手机
    /// </summary>
    string Mobile { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    string Tel { get; set; }

    /// <summary>
    /// 部门Id
    /// </summary>
    long DepartmentId { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    string DepartmentName { get; set; }

    /// <summary>
    /// 是否超级管理员
    /// </summary>
    bool IsSuperAdmin { get; set; }

    /// <summary>
    /// 是否系统管理员
    /// </summary>
    bool IsSystemAdmin { get; set; }

    /// <summary>
    /// 最后登录设备
    /// </summary>
    string LastLoginDevice { get; set; }

    /// <summary>
    /// 最后登录操作系统（版本）
    /// </summary>
    string LastLoginOS { get; set; }

    /// <summary>
    /// 最后登录浏览器（版本）
    /// </summary>
    string LastLoginBrowser { get; set; }

    /// <summary>
    /// 最后登录省份
    /// </summary>
    string LastLoginProvince { get; set; }

    /// <summary>
    /// 最后登录城市
    /// </summary>
    string LastLoginCity { get; set; }

    /// <summary>
    /// 最后登录Ip
    /// </summary>
    string LastLoginIp { get; set; }

    /// <summary>
    /// 最后登录时间
    /// </summary>
    DateTime? LastLoginTime { get; set; }

    /// <summary>
    /// App 运行环境
    /// </summary>
    AppEnvironmentEnum AppEnvironment { get; set; }

    /// <summary>
    /// App来源
    /// </summary>
    string AppOrigin { get; set; }

    /// <summary>
    /// 角色Id集合
    /// </summary>
    List<long> RoleIdList { get; set; }

    /// <summary>
    /// 角色名称集合
    /// </summary>
    List<string> RoleNameList { get; set; }

    /// <summary>
    /// 菜单编码集合
    /// </summary>
    List<string> MenuCodeList { get; set; }

    /// <summary>
    /// 按钮编码集合
    /// </summary>
    List<string> ButtonCodeList { get; set; }
}