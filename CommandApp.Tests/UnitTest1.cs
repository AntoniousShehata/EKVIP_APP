using CommandApp.Commands;
using Xunit;

namespace CommandApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IncrementCommand_IncrementValueBy1()
        {
            var incrementCommand = new IncrementCommand();
            int initialValue = 5;

            int result = incrementCommand.Execute(initialValue);

            Assert.Equal(6, result); 
        }

        [Fact]
        public void Undo_IncrementCommand_DecrementValueBy1()
        {
            var incrementCommand = new IncrementCommand();
            int initialValue = 5;

            int resultAfterExecute = incrementCommand.Execute(initialValue);
            int resultAfterUndo = incrementCommand.Undo(resultAfterExecute);

            Assert.Equal(5, resultAfterUndo);
        }

        [Fact]
        public void DecrementCommand_DecrementValueBy1()
        {
            var decrementCommand = new DecrementCommand();
            int initialValue = 5;

            int result = decrementCommand.Execute(initialValue);

            Assert.Equal(4, result);
        }

        [Fact]
        public void undo_DecrementCommand_IncrementValueBy1()
        {
            var decrementCommand = new DecrementCommand();
            int initialValue = 5;

            int resultAfterExecute = decrementCommand.Execute(initialValue);
            int resultAfterUndo = decrementCommand.Undo(resultAfterExecute);

            Assert.Equal(5, resultAfterUndo);
        }

        [Fact]
        public void DoubleCommand_DoubleValue()
        {
            var doubleCommand = new DoubleCommand();
            int initialValue = 5;

            int result = doubleCommand.Execute(initialValue);

            Assert.Equal(10, result);
        }

        [Fact]
        public void Undo_DoubleCommand_HalfValue()
        {
            var doubleCommand = new DoubleCommand();
            int initialValue = 5;

            int resultAfterExecute = doubleCommand.Execute(initialValue);
            int resultAfterUndo = doubleCommand.Undo(resultAfterExecute);

            Assert.Equal(5, resultAfterUndo);
        }

        [Fact]
        public void RandAddCommand_AddRandomValue()
        {
            var randAddCommand = new RandAddCommand();
            int initialValue = 5;

            int result = randAddCommand.Execute(initialValue);

            Assert.True(result != initialValue);
        }

        [Fact]
        public void Undo_RandAddCommand_SubtractAddedValue()
        {
            var randAddCommand = new RandAddCommand();
            int initialValue = 5;

            int resultAfterExecute = randAddCommand.Execute(initialValue);
            int resultAfterUndo = randAddCommand.Undo(resultAfterExecute);

            Assert.Equal(initialValue, resultAfterUndo); 
        }
        
    }
}