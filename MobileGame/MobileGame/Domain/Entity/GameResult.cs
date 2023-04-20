using MobileGame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileGame.Domain.Entity
{
    internal class GameResult : PlayResultModel
    {
        public GameResult()
        {
            
        }
        public GameResult(int score, int sec, int min)
        {
            Score = score;
            Seconds = sec;
            Minutes = min;
        }
        public int Id { get; set; }
    }
}
