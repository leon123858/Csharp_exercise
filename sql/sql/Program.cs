var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

TodoItemRepository _repository = new TodoItemRepository();

app.MapGet("/todolist", async () => await _repository.GetList());
app.MapGet("/todolist/{name}", async (string name) => await _repository.Get(name));
app.MapGet(
    "/todolist/complete/{name}",
    async (string name) => await _repository.Update(new TodoItem(name, true))
);
app.MapGet(
    "/todolist/incomplete/{name}",
    async (string name) => await _repository.Update(new TodoItem(name, false))
);
app.MapGet(
    "/todolist/create/{name}",
    async (string name) => await _repository.Create(new TodoItem(name, false, true))
);
app.MapGet("/todolist/remove/{id}", async (string id) => await _repository.Delete(id));

app.Run();
