using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RLSApi.Data;
using RLSApi.Net.Requests;
using RLSApi;
using RLSApi.Net.Models;

namespace RocketLeagueStatChecker
{
    public partial class Main_Form : Form
    {
        private static Player_Name_Platform entry;
        private static Player player;

        public static async Task Run()
        {
            string key = "XEP0KTXPOXCLW0MOJN6GYBSQ1A1QPCLC";
            var client = new RLSClient(key);
            if (entry.platform == 1)
            {
                player = await client.GetPlayerAsync(RlsPlatform.Steam, entry.name);
            }
            else if (entry.platform == 2)
            {
                player = await client.GetPlayerAsync(RlsPlatform.Ps4, entry.name);
            }
            else
            {
                player = await client.GetPlayerAsync(RlsPlatform.Xbox, entry.name);
            }
        }

        public Main_Form()
        {
            InitializeComponent();
            entry = new Player_Name_Platform();
            seasonBox.SelectedIndex = seasonBox.Items.Count - 1;
        }

        //Season select
        private void seasonBox_ItemChanged(object sender, EventArgs e)
        {
            string item = seasonBox.SelectedItem.ToString();

            Run().GetAwaiter().GetResult();

            //Season 1
            if (item == "Season 1")
            {
                var seasonplayer = player.RankedSeasons.FirstOrDefault(x => x.Key == RlsSeason.One);

                if (seasonplayer.Value != null)
                {
                    test_DELETELATER.Text = "Season1";
                }
                else
                {
                    entry.Error("The Player you entered does not exist or hasn't played in Season 1!");
                }
            }

            //Season 2
            if (item == "Season 2")
            {
                var seasonplayer = player.RankedSeasons.FirstOrDefault(x => x.Key == RlsSeason.Six);

                if (seasonplayer.Value != null)
                {
                    test_DELETELATER.Text = "Season2";
                }
                else
                {
                    entry.Error("The Player you entered does not exist or hasn't played in Season 2!");
                }
            }

            //Season 3
            if (item == "Season 3")
            {
                var seasonplayer = player.RankedSeasons.FirstOrDefault(x => x.Key == RlsSeason.Six);

                if (seasonplayer.Value != null)
                {
                    test_DELETELATER.Text = "Season3";
                }
                else
                {
                    entry.Error("The Player you entered does not existor hasn't played in Season 3!");
                }
            }

            //Season 4
            if (item == "Season 4")
            {
                var seasonplayer = player.RankedSeasons.FirstOrDefault(x => x.Key == RlsSeason.Six);

                if (seasonplayer.Value != null)
                {
                    test_DELETELATER.Text = "Season4";
                }
                else
                {
                    entry.Error("The Player you entered does not exist or hasn't played in Season 4!");
                }
            }

            //Season 5
            if (item == "Season 5")
            {
                var seasonplayer = player.RankedSeasons.FirstOrDefault(x => x.Key == RlsSeason.Six);

                if (seasonplayer.Value != null)
                {
                    test_DELETELATER.Text = "Season5";
                }
                else
                {
                    entry.Error("The Player you entered does not exist or hasn't played in Season 5!");
                }
            }

            //Season 6
            if (item == "Season 6")
            {
                var seasonplayer = player.RankedSeasons.FirstOrDefault(x => x.Key == RlsSeason.Six);

                if (seasonplayer.Value != null)
                {
                    test_DELETELATER.Text = "Season6";
                }
                else
                {
                    entry.Error("The Player you entered does not exist or hasn't played in Season 6!");
                }
            }

        }
    }

}