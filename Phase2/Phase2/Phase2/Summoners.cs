using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase2
{
    class Summoners
    {
        public string Name { get; set; }

        public int Level { get; set; }
        public static List<Summoners> GetSummoners()
        {
            var summonersList = new List<Summoners>();
            summonersList.Add(new Summoners
            {
                Name = "Aayush Dahal",
                Level = 30
            });

            summonersList.Add(new Summoners
            {
                Name = "Abhay Dhakal",
                Level = 50
            });
            return summonersList;
        }
    }
}
