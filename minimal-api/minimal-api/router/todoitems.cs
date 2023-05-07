using minimal_api.Services;

namespace minimal_api.Router
{
    public static class TodoItemsGroup
    {
        public static RouteGroupBuilder MapTodoItemsGroup(this RouteGroupBuilder group)
        {
            group.MapGet(
                "",
                async (TodoService _todoService) => await _todoService.GetAsync(false)
            );

            group.MapGet(
                "/complete",
                async (TodoService _todoService) => await _todoService.GetAsync(true)
            );

            group.MapGet(
                "/{id}",
                async (string id, TodoService _todoService) =>
                {
                    var item = await _todoService.GetAsync(id);

                    if (item is null)
                    {
                        return exceptionResult(404, "Not match id");
                    }

                    return item;
                }
            );

            group.MapGet(
                "/create/{name}",
                async (string name, TodoService _todoService) =>
                    await _todoService.CreateAsync(new Model.TodoItem(name))
            );

            group.MapGet(
                "/complete/{name}",
                async (string name, TodoService _todoService) =>
                    await _todoService.UpdateAsync(name, new Model.TodoItem(name).setComplete())
            );

            group.MapGet(
                "/delete/{name}",
                async (string name, TodoService _todoService) =>
                    await _todoService.RemoveAsync(name)
            );

            return group;
        }

        private static object exceptionResult(int num, string msg)
        {
            Result result = new Result(num, msg);
            return result;
        }
    }
}
