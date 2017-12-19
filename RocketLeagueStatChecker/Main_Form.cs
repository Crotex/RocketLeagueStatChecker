using System;
using System.Resources;
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
            seasonBox.SelectedIndex = seasonBox.Items.Count - 1;
            setSeason();
        }

        //Season selected
        private void seasonBox_ItemChanged(object sender, EventArgs e)
        {
            //Clear PictureBoxes
            DuelRankIcon.Image = null;
            DoublesRankIcon.Image = null;
            SoloStandardRankIcon.Image = null;
            StandardRankIcon.Image = null;

            setSeason();
        }

        //Get and set the selected Season
        private void setSeason()
        {
            string item = seasonBox.SelectedItem.ToString();

            if (item == "Season 2")
            {
                season_set = true;
                s = RlsSeason.Two;
                getRanksFromSeason(s);
            }

            if (item == "Season 3")
            {
                season_set = true;
                s = RlsSeason.Three;
                getRanksFromSeason(s);
            }

            if (item == "Season 4")
            {
                season_set = true;
                s = RlsSeason.Four;
                getRanksFromSeason(s);
            }

            if (item == "Season 5")
            {
                season_set = true;
                s = RlsSeason.Five;
                getRanksFromSeason(s);
            }

            if (item == "Season 6")
            {
                season_set = true;
                s = RlsSeason.Six;
                getRanksFromSeason(s);
            }
        }

        //Get the ranks from the selected season
        private void getRanksFromSeason(RlsSeason s)
        {
            if (season_set && Player_Name_Platform.player_set)
            {
                player = Player_Name_Platform.player;

                var playerSeason = player.RankedSeasons.FirstOrDefault(x => x.Key == s);

                if (playerSeason.Value != null)
                {
                    foreach (var playerRank in playerSeason.Value)
                    {
                        setRank(playerRank.Key.ToString(), (int)playerRank.Value.Tier, (int)playerRank.Value.Division, playerRank.Value.RankPoints);
                    }
                }
            }
        }

        //Set the ranks
        private void setRank(string playlist, int tier, int division, int rating)
        {
            if (tier == 0) //unranked
            {
                setIMG(playlist, "unranked");
            }
            else
            {

                if (s == RlsSeason.Three || s == RlsSeason.Two) //Old Images, max tier = 15
                {
                    for (int i = 1; i <= 15; i++)
                    {
                        if (i == tier)
                        {
                            setIMG(playlist, "old_" + tier.ToString());
                        }
                    }
                }
                else //New Images, max tier = 19
                {
                    for (int i = 1; i <= 19; i++)
                    {
                        if (i == tier)
                        {
                            setIMG(playlist, "_" + tier.ToString());
                        }
                    }
                }
            }
        }

        //Set the images of the Ranks
        private void setIMG(string playlist, string img)
        {
            ResourceManager rm = RocketLeagueStatChecker.Properties.Resources.ResourceManager;
            Bitmap bitmap = (Bitmap)rm.GetObject(img);

            if (playlist == "Duel")
            {
                DuelRankIcon.Image = bitmap;
            }

            if (playlist == "Doubles")
            {
                DoublesRankIcon.Image = bitmap;
            }

            if (playlist == "SoloStandard")
            {
                SoloStandardRankIcon.Image = bitmap;
            }

            if (playlist == "Standard")
            {
                StandardRankIcon.Image = bitmap;
            }
        }

        //Close application once the window is closed
        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}