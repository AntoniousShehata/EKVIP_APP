using System;
using CommandApp.Commands; 

namespace CommandApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1 || !int.TryParse(args[0], out int initialResult))
            {
                Console.WriteLine("Please enter a valid integer.");
                return;
            }

            var context = new CommandContext(initialResult);

            while (true)
            {
                Console.Write("Enter command: ");
                string input = Console.ReadLine().ToLower().Trim();

                ICommand command = input switch
                {
                    "increment" => new IncrementCommand(),
                    "decrement" => new DecrementCommand(),
                    "double" => new DoubleCommand(),
                    "randadd" => new RandAddCommand(),
                    "undo" => null, 
                    _ => null
                };

                if (command == null && input == "undo")
                {
                    if (context.UndoLastCommand())
                    {
                        Console.WriteLine($"After undo the current result now: {context.Result}");
                    }
                    else
                    {
                        Console.WriteLine("can not undo as result is empty");
                    }
                }
   
                else if (command != null)
                {
                    context.ApplyCommand(command);
                    Console.WriteLine($"Result is: {context.Result}");
                }
                else
                {
                    Console.WriteLine("wrong command. Please choose one valid command from(Increment/Decrement/Double/RandAdd/Undo).");
                }
            }
        }
    }
}
