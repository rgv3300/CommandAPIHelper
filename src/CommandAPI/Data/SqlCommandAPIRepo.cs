using CommandAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.CommandItems.ToList();
        }
        public Command GetCommandById(int id)
        {
            return _context.CommandItems.FirstOrDefault(p => p.Id == id);
        }
        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new System.ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Add(cmd);
        }
        public void UpdateCommand(Command cmd)
        {

        }
        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Remove(cmd);
        }
    }
}