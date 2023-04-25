using MobileGame.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileGame.Services.RepositoryService
{
    internal interface IRepository
    {
        void Add(GameResult gameResult);
        List<GameResult> GetAll();
    }
}
