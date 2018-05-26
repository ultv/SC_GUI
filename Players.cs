using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace CS_GUI
{
    [DataContract]
    class Players //: Player
    {
        [DataMember]
        public List<Player> PlayerS { get; set;}

        public Players()
        {
            PlayerS = new List<Player>();
        }

        // Запись истории.
        public void SaveJSON()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Players));

            if (!FileIsLocked("Players.json", FileAccess.ReadWrite))
            {
                using (FileStream fs = new FileStream("Players.json", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, this);
                }
                // Не выведет, т.к. сохранение происходит по закрытию формы.
                //MessageBox.Show("Файл со списком игроков заблокирован. Данные сохранятся в новом файле.");
            }
            else
            {
                using (FileStream fs = new FileStream(DateTime.Now.ToFileTime() + "Players.json", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, this);
                }
            }
        }

        // Загрузка списка игроков с параметрами.
        public Players LoadJSON()
        {
            Players players;

            //if (!FileIsNotFound("Players.json", FileAccess.ReadWrite))
            //{


                using (FileStream fs = new FileStream("Players.json", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Players));

                    players = (Players)jsonFormatter.ReadObject(fs);
                }
            
                
                
                //}
            //else return null;

            return players;
        }


        // Возвращает истину если файл заблокирован.
        protected bool FileIsLocked(string path, FileAccess access)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, access);
                fs.Close();
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Возвращает истину если файл ненайден.
        protected bool FileIsNotFound(string path, FileAccess access)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, access);
                fs.Close();
                return false;
            }
            catch (FileNotFoundException)
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
