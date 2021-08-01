using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        public void CreateCommand(Command cmd)
        {

        }
        public void DeleteCommand(Command cmd)
        {

        }
        public void UpdateCommand(Command cmd)
        {

        }
        public bool SaveChanges() { return true; }
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command {
                    Id = 0 , HowTo = "How to make eggs?",
                    CommandLine = "Boil eggs in hot pan with water",
                    Platform = "Pan"
                },
                new Command {
                    Id = 1, HowTo = "How to make bacon", CommandLine = "Place bacon on a hot pan",Platform = "griddle"
                }
            };
            return commands;
        }
        public Command GetCommandById(int id)
        {
            return new Command
            {
                Id = 0,
                HowTo = "How to make eggs?",
                CommandLine = "Boil eggs in hot pan with water",
                Platform = "Pan"
            };
        }
    }
}