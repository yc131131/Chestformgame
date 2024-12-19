using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P230611988.Classes
{
    internal class GameState
    {
        public List<Actor> actors { get; set; }
        public GameHistory History { get; set; }

        public GameState(List<Actor> actors, GameHistory history)
        {
            actors = new List<Actor>(actors);  // 复制角色列表
            History = history;
        }
    }
}
