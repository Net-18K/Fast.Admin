﻿using Fast.NET.Core.AdminFactory.BaseModelFactory.Const;
using Fast.NET.Core.AdminFactory.ModelFactory.Tenant;
using Microsoft.Extensions.Configuration;

namespace Fast.NET.Core;

/// <summary>
/// 通用上下文
/// </summary>
public static class GlobalContext
{
    /// <summary>
    /// 当前租户Id
    /// </summary>
    public static long TenantId => (User?.FindFirst(ClaimConst.TENANT_ID)?.Value).ParseToLong();

    /// <summary>
    /// 任务调度租户Id
    /// </summary>
    public static long ScheduledTenantId => HttpContext == null ? 0 : HttpContext.Request.Headers["TenantId"].ParseToLong();

    /// <summary>
    /// 支付回调租户Id
    /// </summary>
    public static long PayTenantId { get; set; }

    /// <summary>
    /// 当前用户Id
    /// </summary>
    public static long UserId => (User?.FindFirst(ClaimConst.CLAINM_USERID)?.Value).ParseToLong();

    /// <summary>
    /// 当前用户账号
    /// </summary>
    public static string UserAccount => (User?.FindFirst(ClaimConst.CLAINM_ACCOUNT)?.Value).ParseToString();

    /// <summary>
    /// 当前用户名称
    /// </summary>
    public static string UserName => (User?.FindFirst(ClaimConst.CLAINM_NAME)?.Value).ParseToString();

    /// <summary>
    /// 是否超级管理员
    /// </summary>
    public static bool IsSuperAdmin
    {
        get
        {
            if (User == null)
                return false;
            return User.FindFirst(ClaimConst.CLAINM_SUPERADMIN)?.Value == AdminTypeEnum.SuperAdmin.GetHashCode().ParseToString();
        }
    }

    ///// <summary>
    ///// 当前用户信息
    ///// </summary>
    //public static SysUserModel UserModelInfo =>
    //    GetService<ISqlSugarRepository<SysUserModel>>().FirstOrDefault(f => f.Id == UserId);

    ///// <summary>
    ///// 检测用户是否存在
    ///// </summary>
    ///// <param name="userId"></param>
    ///// <returns></returns>
    //public static async Task<SysUserModel> CheckUserAsync(long userId)
    //{
    //    var user = await GetService<ISqlSugarRepository<SysUserModel>>().FirstOrDefaultAsync(u => u.Id == userId);
    //    return user ?? throw Oops.Bah(ErrorCodeEnum.D1002);
    //}

    ///// <summary>
    ///// 获取用户员工信息
    ///// </summary>
    ///// <param name="userId"></param>
    ///// <returns></returns>
    //public static async Task<SysEmpModel> GetUserEmpInfo(long userId)
    //{
    //    var emp = await GetService<ISqlSugarRepository<SysEmpModel>>().FirstOrDefaultAsync(u => u.Id == userId);
    //    return emp ?? throw Oops.Bah(ErrorCodeEnum.D1002);
    //}

    /// <summary>
    /// 数据库配置信息
    /// </summary>
    public static ConnectionDto ConnectionInfo { get; set; }

    /// <summary>
    /// 租户库Db Info
    /// </summary>
    public static SysTenantDataBaseModel TenantDbInfo { get; set; }

    /// <summary>
    /// 设置配置文件
    /// </summary>
    public static void SetConfigInfo()
    {
        ConnectionInfo = Configuration.GetSection("ConnectionStrings").Get<ConnectionDto>();
    }

    /// <summary>
    /// 获取租户Id
    /// </summary>
    /// <param name="isThrow">是否抛出错误</param>
    /// <returns></returns>
    public static long GetTenantId(bool isThrow = true)
    {
        if (!TenantId.IsNullOrZero())
        {
            return TenantId;
        }

        if (!ScheduledTenantId.IsNullOrZero())
        {
            return ScheduledTenantId;
        }

        if (!PayTenantId.IsNullOrZero())
        {
            return PayTenantId;
        }

        if (isThrow)
            throw Oops.Oh("租户系统异常！");

        return 0;
    }
}

/// <summary>
/// 数据库Dto
/// </summary>
public class ConnectionDto
{
    /// <summary>
    /// 连接Id
    /// </summary>
    public string ConnectionId { get; set; }

    /// <summary>
    /// 连接字符串
    /// </summary>
    public string Connection { get; set; }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public DbType DbType { get; set; }
}