using System;
using System.Linq;
using System.Reflection;
using DbUp;

namespace AppData
{
  class Program
  {
    static int Main(string[] args)
    {
      var connectionString = Environment.GetEnvironmentVariable("DbConnectionString");
      EnsureDatabase.For.SqlDatabase(connectionString);

      var upgrader = DeployChanges.To
        .SqlDatabase(connectionString)
        .JournalToSqlTable("dbo", "ScriptHistory")
        .WithScriptsFromFileSystem("./scripts")
        .LogToConsole()
        .Build();

      var result = upgrader.PerformUpgrade();

      if (!result.Successful)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(result.Error);
        Console.ResetColor();

        // #if DEBUG
        //   Console.ReadLine();
        // #endif

        return -1;
      }

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Success!");
      Console.ResetColor();

      return 0;
    }
  }
}
