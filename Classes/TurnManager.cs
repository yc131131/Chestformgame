﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P230611988.Classes
{

    public enum TurnPhase
    {
        PlayerTurn,
        AllyTurn,
        EnemyTurn
    }

    internal class TurnManager
    {
        private int turn;

        

        public TurnPhase _currentPhase;
        private List<Actor> _actors;
        private GameHistory _gameHistory;
        private Aboard _aboard;



        public TurnManager(List<Actor> actors, GameHistory gameHistory,  Aboard aboard)
        {
            _actors = actors;
            _gameHistory = gameHistory;
            _currentPhase = TurnPhase.PlayerTurn;
            _aboard = aboard;
        }

        public void NextTurn()
        {
            switch (_currentPhase)
            {
                case TurnPhase.PlayerTurn:
                    _currentPhase = TurnPhase.AllyTurn;
                    break;
                case TurnPhase.AllyTurn:
                    _currentPhase = TurnPhase.EnemyTurn;
                    break;
                case TurnPhase.EnemyTurn:
                    _currentPhase = TurnPhase.PlayerTurn;
                    break;
            }
            //UpdateGameUI
            _aboard.StartTurnMessageEffect(_currentPhase);
            
        }
    }
}
