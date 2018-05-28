using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ComponentModel.DataAnnotations.Schema;


namespace CS_GUI
{
    // Содержит количество побед в текущей игре и во всех играх.    
    [DataContract]
    public class Player
    {
        public int PlayerId { get; set; }
        [DataMember]
        public string Name { get; set; }                
        [DataMember]
        public int TotalVic { get; set; }

        [NotMapped]
        public int CurVic { get; set; }
        [NotMapped]
        public Brain Brains { get; set; }

        public Player() { }

        public Player(string name)
        {
            Name = name;
        }
        
    }

}
