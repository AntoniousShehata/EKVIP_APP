using System;
using System.Collections.Generic;

namespace CommandApp
{
    public class CommandContext
    {
        public int Result { get; private set; }

        private Stack<ICommand> History;

        public CommandContext(int initialResult)
        {
            Result = initialResult;
            History = new Stack<ICommand>();
        }

        public void ApplyCommand(ICommand command)
        {
            Result = command.Execute(Result);
            History.Push(command);
        }

        public bool UndoLastCommand()
        {
            if (History.Count > 0)
            {
                var lastCommand = History.Pop();
                Result = lastCommand.Undo(Result);
                return true;
            }
            return false;
        }
    }
}
