using CommandApp;

namespace CommandApp.Commands
{
    public class DoubleCommand : ICommand
    {
        public int Execute(int current) => current * 2;

        public int Undo(int current) => current / 2;
    }
}
