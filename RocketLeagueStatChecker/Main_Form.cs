using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using RLSApi.Data;
using RLSApi.Net.Requests;
using RLSApi;
using RLSApi.Net.Models;

namespace RocketLeagueStatChecker
{
    public partial class Main_Form : Form
    {
        public static RlsSeason s = new RlsSeason();
        public Player player;

        private bool season_set = false;

        public Main_Form()
        {
            InitializeComponent();
        }

        //Form Load
        private void Main_Form_Load(object sender, EventArgs e)
        {
            seasonBox.SelectedIndex = seasonBox.Items.Count - 1;
            setSeason();
        }

        //Season selected
        private void seasonBox_ItemChanged(object sender, EventArgs e)
        {
            setSeason();

            if (season_set && Player_Name_Platform.player_set)
            {
                player = Player_Name_Platform.player;

                var playerSeason = player.RankedSeasons.FirstOrDefault(x => x.Key == s);

                if (playerSeason.Value != null)
                {
                    MessageBox.Show("Player: " + player.DisplayName);
                    foreach (var playerRank in playerSeason.Value)
                    {
                        MessageBox.Show(playerRank.Key + ": " + playerRank.Value.RankPoints + " rating");
                    }
                }
                else
                {
                    MessageBox.Show("The player " + player.DisplayName + "(" + player.Platform + ")" + "didn't play in Season " + s.ToString().ToLower());
                }
            }
        }

        //Get and set the selected Season
        private void setSeason()
        {
            string item = seasonBox.SelectedItem.ToString();

            if (item == "Season 1")
            {
                season_set = true;
                s = RlsSeason.One;
            }

            if (item == "Season 2")
            {
                season_set = true;
                s = RlsSeason.Two;
            }

            if (item == "Season 3")
            {
                season_set = true;
                s = RlsSeason.Three;
            }

            if (item == "Season 4")
            {
                season_set = true;
                s = RlsSeason.Four;
            }

            if (item == "Season 5")
            {
                season_set = true;
                s = RlsSeason.Five;
            }

            if (item == "Season 6")
            {
                season_set = true;
                s = RlsSeason.Six;
            }
        }
    }
}