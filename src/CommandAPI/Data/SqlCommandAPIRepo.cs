using CommandAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CommandAPI.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;
        public SqlCommandAPIRepo(CommandContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
            return true;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.CommandItems.ToList();
        }
        public Command GetCommandById(int id)
        {
            return _context.CommandItems.FirstOrDefault(p => p.Id == id);
        }
        public void CreateCommand(Command cmd) { }
        public void UpdateCommand(Command cmd) { }
        public void DeleteCommand(Command cmd) { }
    }
}