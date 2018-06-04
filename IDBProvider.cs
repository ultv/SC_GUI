using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_GUI
{
    public interface IDBProvider
    {
        Player GetPlayerById(int id);
    }
}
