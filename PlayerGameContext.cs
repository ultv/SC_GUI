using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CS_GUI
{
    class PlayerGameContext : DbContext
    {
        public DbSet<Player> PlayersEF { get; set; }
        public DbSet<Game> GameEF { get; set; }
        
    }
}
