﻿using Fast.Core.AdminFactory.EnumFactory;
using Fast.SqlSugar.Tenant.AttributeFilter;
using Fast.SqlSugar.Tenant.BaseModel;

namespace Fast.Core.AdminFactory.ModelFactory.Sys;

/// <summary>
/// 系统模块表Model类
/// </summary>
[SugarTable("Sys_Module", "系统模块表")]
[SugarDbType]
public class SysModuleModel : BaseEntity
{
    /// <summary>
    /// 名称
    /// </summary>
    [SugarColumn(ColumnDescription = "名称", ColumnDataType = "Nvarchar(50)", IsNullable = false)]
    public string Name { get; set; }

    /// <summary>
    /// 颜色
    /// </summary>
    [SugarColumn(ColumnDescription = "颜色", ColumnDataType = "Nvarchar(50)", IsNullable = false)]
    public string Color { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    [SugarColumn(ColumnDescription = "图标", ColumnDataType = "Nvarchar(50)", IsNullable = false)]
    public string Icon { get; set; }

    /// <summary>
    /// 查看类型
    /// </summary>
    [SugarColumn(ColumnDescription = "查看类型", IsNullable = false)]
    public ModuleViewTypeEnum ViewType { get; set; }

    /// <summary>
    /// 是否为系统模块
    /// </summary>
    [SugarColumn(ColumnDescription = "是否为系统模块", IsNullable = false)]
    public YesOrNotEnum IsSystem { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序", IsNullable = false)]
    public int Sort { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public CommonStatusEnum Status { get; set; }
}