using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Player
    {
        public int ID { get; set; }
        public string UserName { get; set; }

        public static Player[] players = new Player[20];

        public Player(int id, string userName)
        {
            this.ID = id;
            this.UserName = userName;

        }

        public void AddPlayer(Player p)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == null)
                {
                    players[i] = p;
                    break;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("You can't add any more players");

                }
            }
        }
    }
}
