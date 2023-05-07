using minimal_api.Model;
using minimal_api.Router;
using minimal_api.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TodoDatabaseSettings>(builder.Configuration.GetSection("TodoDatabase"));
builder.Services.AddSingleton<TodoService>();
builder.Services.AddCors();
WebApplication app = builder.Build();

app.UseCors();

app.MapGroup("/todoitems").MapTodoItemsGroup();

app.Run();
