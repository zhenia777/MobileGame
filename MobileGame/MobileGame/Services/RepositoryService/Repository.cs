using MobileGame.Domain;
using MobileGame.Domain.Entity;
using MobileGame.Helpers;
using MobileGame.Services.AndroidDbPathService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileGame.Services.RepositoryService
{
    internal class Repository : IRepository
    {
        private readonly IPath path;
        public Repository(IPath path)
        {
            this.path = path;
        }
        public void Add(GameResult gameResult)
        {
            using (ApplicationContext db = new(path.GetDatabasePath(Constants.DATABASE_FILENAME)))
            {
                db.GameResults.Add(gameResult);
            }
        }

        public List<GameResult> GetAll()
        {
            using (ApplicationContext db = new(path.GetDatabasePath(Constants.DATABASE_FILENAME)))
            {
                return db.GameResults.ToList();
            }
        }
    }
}
