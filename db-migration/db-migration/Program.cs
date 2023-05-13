using System.Reflection;
using DbUp;


var connectionString = "Server = 127.0.0.1; Database = TodoList; Uid = root; Pwd = 0000;";

var upgrader =
    DeployChanges.To
        .MySqlDatabase(connectionString)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .LogToConsole()
        .Build();

//EnsureDatabase.For.SqlDatabase(connectionString);

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;