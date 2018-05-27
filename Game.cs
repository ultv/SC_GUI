using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace CS_GUI
{
    [DataContract]
    class Game
    {
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public Player[] Players { get; set; }
        [DataMember]
        public string NameVictory { get; set; }
        [DataMember]
        public int HowStep { get; set; }
        [DataMember]
        public int [] Steps { get; set; }
 
        public int NowPlaying { get; set; }
        public bool PrevX { get; set; }
        public bool Repeat { get; set; }
        public Matrix GameField { get; set; }        

        public delegate void Stop(string message);
        public event Stop StopGame;    

        public Game(Form1 form, Panel panel, int size)
        {            
            HowStep = 0;
            PrevX = false;
            Date = DateTime.Now.ToString();
            Player player1 = new Player();
            Player player2 = new Player();
            Players = new Player[] { player1, player2 };
            GameField = new Matrix(form, panel, size);            
            Steps = new int [GameField.Size * GameField.Size];
            Repeat = false;
            NameVictory = "Ничья";                        

            StopGame += ShowResult;
            StopGame += form.NoVictory;
        }       

        public void IncStep()
        {
            HowStep++;

            if ((HowStep == (GameField.Size * GameField.Size)) && (NameVictory == "Ничья"))
            {
                StopGame("Нет победителя.");
            }
        }

        public void ShowResult(string message)
        {
            MessageBox.Show(message);
        }

        public void ChangePlaying()
        {            
            if (NowPlaying == 0)
            {
                NowPlaying = 1;
            }
            else
            {
                NowPlaying = 0;
            }
        }

        // Запись истории.
        public void SaveJSON()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Game));

            //if (!FileIsLocked("Game.json", FileAccess.ReadWrite))
            //{
            //     using (FileStream fs = new FileStream("Game.json", FileMode.Create))
            //    {
            //        jsonFormatter.WriteObject(fs, this);
            ///    }
            ///// Не выведет, т.к. сохранение происходит по закрытию формы.
            ///    MessageBox.Show("Файл с историей заблокирован. Данные сохранятся в новом файле.");
            //  }
            //  else
            //  {


            string name1 = Players[0].Name;
            string name2 = Players[1].Name;
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToLongTimeString();
            time = time.Replace(":", "..");

            using (FileStream fs = new FileStream($"{name1} VS {name2} {date} {time}.json", FileMode.OpenOrCreate))
           
                {
                    jsonFormatter.WriteObject(fs, this);
                }
          //  }
        }

        // Загрузка списка игроков с параметрами.
        public Game LoadJSON(string path)
        {
            Game game;

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Game));

                game = (Game)jsonFormatter.ReadObject(fs);
            }

            return game;
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

    }
}
