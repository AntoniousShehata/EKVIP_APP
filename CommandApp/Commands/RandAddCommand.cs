using CommandApp;

namespace CommandApp.Commands
{
    public class RandAddCommand : ICommand
    {
        private int randomNumber;

        public RandAddCommand()
        {
            var SelectRandom = new Random();
            randomNumber = SelectRandom.Next(1, 11);
        }

        public int Execute(int current) => current + randomNumber;

        public int Undo(int current) => current - randomNumber;
    }
}
