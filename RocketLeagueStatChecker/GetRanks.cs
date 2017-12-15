using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLSApi.Data;
using RLSApi.Net.Requests;
using RLSApi;
using RLSApi.Net.Models;

namespace RocketLeagueStatChecker
{
    public class GetRanks
    {
        public static void getRanks(string[] args) => Run().GetAwaiter().GetResult();

        public static async Task Run()
        {
            //Set up client
            var client = new RLSClient("IQB8PMF8N605UKX7K698FTWWV99J2G9M");

            //create player
            var player = await client.GetPlayerAsync(Main_Form.plat, Player_Name_Platform.name);

            //Bind player to season
            var playerSeasonSix = player.RankedSeasons.FirstOrDefault(x => x.Key == Main_Form.s);

            //Check if player played that season
            if (playerSeasonSix.Value != null)
            {
                foreach (var playerRank in playerSeasonSix.Value)
                {

                }
            }
        }
    }
}