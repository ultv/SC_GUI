using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    public class Selector
    {
        private readonly IDBProvider dbprovider;
        public string message;

        public Selector(IDBProvider dbp)
        {
            dbprovider = dbp;
        }

        public void SelectPlayerById(int id)
        {
            if(dbprovider != null)
            {
                Player player = dbprovider.GetPlayerById(id);
                message = $"Проверяется фейковый игрок по имени: {player.Name}";                
                MessageBox.Show(message);
            }
        }

    }
}
