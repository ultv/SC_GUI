using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace CS_GUI
{
    // Содержит количество побед в текущей игре и во всех играх.    
    [DataContract]
    public class Player
    {
        [DataMember]
        public string Name { get; set; }                
        [DataMember]
        public int TotalVic { get; set; }
        public int CurVic { get; set; }

        public Player() { }

        public Player(string name)
        {
            Name = name;
        }
        
    }

}
