using CommandApp;

namespace CommandApp.Commands
{
    public class IncrementCommand : ICommand
    {
        public int Execute(int current) => current + 1;
        public int Undo(int current) => current - 1;
    }
}
