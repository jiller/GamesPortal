using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AcmeGames.Data
{
    public class Database
    {
        private static readonly Random                locRandom    = new Random();

        private static IEnumerable<Game>              locGames     = new List<Game>();
        private static IEnumerable<GameKey>           locKeys      = new List<GameKey>();
        private static IEnumerable<Ownership>         locOwnership = new List<Ownership>();
        private static IEnumerable<User>              locUsers     = new List<User>();
        
        private static IDictionary<Type, IEnumerable> tables       = new Dictionary<Type, IEnumerable>();
        
        public Database()
        {
            locGames     = JsonConvert.DeserializeObject<IEnumerable<Game>>(File.ReadAllText(@"Data\Files\games.json"));
            locKeys      = JsonConvert.DeserializeObject<IEnumerable<GameKey>>(File.ReadAllText(@"Data\Files\keys.json"));
            locUsers     = JsonConvert.DeserializeObject<IEnumerable<User>>(File.ReadAllText(@"Data\Files\users.json"));
            locOwnership = JsonConvert.DeserializeObject<IEnumerable<Ownership>>(File.ReadAllText(@"Data\Files\ownership.json"));

            tables       = new Dictionary<Type, IEnumerable>
            {
                {typeof(Game), locGames},
                {typeof(GameKey), locKeys},
                {typeof(Ownership), locOwnership},
                {typeof(User), locUsers}
            };
        }
        
        public Task<IEnumerable<Game>> Games => PrivGetData(locGames);
        public Task<IEnumerable<GameKey>> GameKeys => PrivGetData(locKeys);
        public Task<IEnumerable<Ownership>> Ownerships => PrivGetData(locOwnership);
        public Task<IEnumerable<User>> Users => PrivGetData(locUsers);

        public Task<IEnumerable<T>> Get<T>(Expression<Func<T, bool>> predicate)
        {
            if (tables.TryGetValue(typeof(T), out var dataSource))
            {
                return PrivGetData(dataSource.OfType<T>().Where(predicate.Compile()));
            }
            
            throw new ArgumentOutOfRangeException($"Unknown type '{typeof(T)}'");
        }
        
        public Task Submit()
        {
            // TODO : Flush changes to the files
            return Task.CompletedTask;
        }
        
        // NOTE: This accessor function must be used to access the data.
        private Task<IEnumerable<T>> PrivGetData<T>(IEnumerable<T>  aDataSource)
        {
            var delay = locRandom.Next(150, 1000);
            Thread.Sleep(TimeSpan.FromMilliseconds(delay));

            return Task.FromResult(aDataSource);
        }
    }
}
