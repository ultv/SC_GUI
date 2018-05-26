using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CS_GUI
{
    // Содержит количество побед в текущей игре и во всех играх.    
    public class Player
    {        
        public string Name { get; set; }        
        public int CurVic { get; set; }       
        public int TotalVic { get; set; }

        public Player() { }

        public Player(string name)
        {
            Name = name;
        }
        
    }

}
