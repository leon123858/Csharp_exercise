using Dapper;
using MySql.Data.MySqlClient;
using System.Diagnostics;

public class TodoItem
{
    public string? Id { get; set; }
    public string Name { get; set; } = "";
    public bool IsComplete { get; set; } = false;

    TodoItem(string id, string name, bool isComplete)
    {
        Id = id;
        Name = name;
        IsComplete = isComplete;
    }

    public TodoItem(string name, bool isComplete, bool? randomId = false)
    {
        if (randomId == true)
        {
            Guid myUUId = Guid.NewGuid();
            string convertedUUID = myUUId.ToString();
            Id = convertedUUID;
        }
        Name = name;
        IsComplete = isComplete;
    }
}

public class TodoItemRepository
{
    /// <summary>
    /// 連線字串 //預設連到 3306
    /// </summary>
    private readonly string _connectString =
        @"Server=127.0.0.1;Database=TodoList;Uid=root;Pwd=0000;";

    /// <summary>
    /// /// 產生列表
    /// </summary>
    /// <returns></returns>
    public async Task<TodoItem[]> GetList()
    {
        using (var conn = new MySqlConnection(_connectString))
        {
            var result = (
                await conn.QueryAsync<TodoItem>("SELECT * FROM TodoItem")
            ).ToArray<TodoItem>();
            if (result == null)
            {
                return Array.Empty<TodoItem>();
            }
            return result;
        }
    }

    public async Task<TodoItem> Get(string name)
    {
        var command = "SELECT * FROM TodoItem Where Name = @Name Limit 1";

        var parameters = new DynamicParameters();
        parameters.Add("Name", name);

        using (var conn = new MySqlConnection(_connectString))
        {
            var result = await conn.QueryFirstOrDefaultAsync<TodoItem>(command, parameters);
            return result;
        }
    }

    public async Task<int> Create(TodoItem todoItem)
    {
        var sql =
            @"
        INSERT INTO TodoItem 
        (
            Id
           ,Name
           ,IsComplete
        ) 
        VALUES 
        (
            @Id
           ,@Name
           ,@IsComplete
        );
        
        SELECT @@IDENTITY;";

        var parameters = new DynamicParameters();
        parameters.Add("Id", todoItem.Id);
        parameters.Add("Name", todoItem.Name);
        parameters.Add("IsComplete", todoItem.IsComplete);

        using (var conn = new MySqlConnection(_connectString))
        {
            return await conn.ExecuteAsync(sql, todoItem);
        }
    }

    public async Task<int> Update(TodoItem parameter)
    {
        var sql =
            @"
        UPDATE TodoItem
        SET 
             IsComplete = @IsComplete
        WHERE 
            Name = @Name
        ";

        var parameters = new DynamicParameters();
        parameters.Add("Name", parameter.Name);
        parameters.Add("IsComplete", parameter.IsComplete);

        using (var conn = new MySqlConnection(_connectString))
        {
            return await conn.ExecuteAsync(sql, parameters);
        }
    }

    public async Task<int> Delete(string id)
    {
        var sql =
            @"
        DELETE FROM TodoItem
        WHERE Id = @id
        ";

        var parameters = new DynamicParameters();
        parameters.Add("id", id);

        using (var conn = new MySqlConnection(_connectString))
        {
            return await conn.ExecuteAsync(sql, parameters);
        }
    }
}
