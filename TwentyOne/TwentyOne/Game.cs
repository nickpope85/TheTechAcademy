using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public abstract class Game //-- abstract classes cannot be instantiated into an object || also know as a Base class
    {
        private List<Player> _players = new List<Player>();
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();

        public List<Player> Players { get { return _players; } set { _players = value; } }

        public List<string> Name { get; set; }
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } }


        public abstract void Play(); //<-- abstract methods cannot exist anywhere besides an abstract class

        public virtual void ListPlayers() //<-- virtual methods only inside abstract classes
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
