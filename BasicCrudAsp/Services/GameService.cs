using BasicCrudAsp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCrudAsp.Services
{
    public class GameService
    {
        private readonly IMongoCollection<Game> _games;

        public GameService(IBasicCrudMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _games = database.GetCollection<Game>(settings.GamesCollectionName);
        }

        public List<Game> GetAll() => _games.Find(g => true).ToList();
        public Game Get(string id) => _games.Find<Game>(g => g.Id == id).FirstOrDefault();
        public Game Add(Game game)
        {
            _games.InsertOne(game);
            return game;

        }

        public void Delete(string id)
        {
            var game = Get(id);
            if (game is not null) //is usa a função Equals
                _games.DeleteOne(g => g.Id == id);
        }

        public void Update(Game game)
        {
            _games.ReplaceOne(g => g.Id == game.Id, game);
        }




    }
}
