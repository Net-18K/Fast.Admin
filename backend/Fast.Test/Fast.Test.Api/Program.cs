using Fast.CorsAccessor.Extensions;
using Fast.DependencyInjection.Extensions;
using Fast.Logging.Extensions;
using Fast.Mapster.Extensions;
using Fast.NET.Core.Extensions;
using Fast.Serialization.Extensions;
using Fast.SpecificationProcessor.DataValidation.Extensions;
using Fast.SpecificationProcessor.DynamicApplication.Extensions;
using Fast.SpecificationProcessor.FriendlyException.Extensions;
using Fast.SpecificationProcessor.SpecificationDocument.Extensions;
using Fast.SpecificationProcessor.UnifyResult.Extensions;
using Fast.Test.Api;

var builder = WebApplication.CreateBuilder(args).Initialize();

// Customize the console log output template.
builder.Logging.AddConsoleFormatter(options => { options.DateFormat = "yyyy-MM-dd HH:mm:ss"; });

// 日志
builder.AddLogging();

// 跨域配置
builder.Services.AddCorsAccessor(builder.Configuration);

// GZIP 压缩
builder.Services.AddGzipBrotliCompression();

// JSON 序列化配置
builder.Services.AddJsonOptions();

// 注册全局依赖注入
builder.Services.AddDependencyInjection();

// 添加对象映射
builder.Services.AddObjectMapper();

builder.Services.AddControllers();

// 动态 API
builder.Services.AddDynamicApiControllers();

// 数据验证
builder.Services.AddDataValidation();

// 友好异常
builder.Services.AddFriendlyException();

// 规范返回
builder.Services.AddUnifyResult<RESTfulResultProvider>();

// 文档
builder.AddSpecificationDocuments();

//builder.Services.AddSqlSugar();

// Add event bus.
//builder.Services.AddEventBus(options =>
//{
//    // 创建连接工厂
//    var factory = App.GetConfig<ConnectionFactory>("RabbitMQConnection");

//    // 创建默认内存通道事件源对象
//    var mqEventSourceStorer = new RabbitMQEventSourceStorer(factory, "WMS.Event.Bus", 3000);

//    // 替换默认事件总线存储器
//    options.ReplaceStorer(serviceProvider => mqEventSourceStorer);

//    // 注册事件总线重试服务
//    options.AddFallbackPolicy<EventFallbackPolicy>();
//});
//builder.Services.AddEventBus();

var app = builder.Build();

// Mandatory Https.
app.UseHttpsRedirection();

// 日志中间件
app.UseLogging();

// 跨域中间件
app.UseCorsAccessor();

// 依赖注入中间件
app.UseDependencyInjection();

// Enable compression.
//app.UseResponseCompression();

// Add the status code interception middleware.
app.UseUnifyResultStatusCodes();


app.UseStaticFiles();

app.UseRouting();

// Here, the default address is/API if no argument is entered, and/directory if string.empty is entered. If any string is entered, the/arbitrary string directory.
app.UseSpecificationDocuments();

app.MapControllers();

app.Run();