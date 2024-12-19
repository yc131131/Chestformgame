using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P230611988.Classes
{
    internal class GameHistory
    {
        private Stack<GameState> _history;

        public GameHistory(GameState initialState)
        {
            _history = new Stack<GameState>();
            _history.Push(initialState);
        }

        public void RecordState(GameState state)
        {
            _history.Push(state);
        }

        public GameState Undo()
        {
            if (_history.Count > 1)
            {
                _history.Pop();
            }
            return _history.Peek();
        }
    }
}
