using RLSApi.Data;
using RLSApi.Net.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using System.Globalization;
using System.Threading.Tasks;

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
            playerName.Text = "Player: " + player.DisplayName + ", Platform: " + Player_Name_Platform.plat;
            updateLabel.Text = "Last Update: " + DateTime.Now.ToString("HH:mm");
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

            if(item == "Season 7")
            {
                season_set = true;
                s = RlsSeason.Seven;
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
                        setRank(playerRank.Key.ToString(), (int)playerRank.Value.Tier);
                        setInfo(playerRank.Key.ToString(), (int)playerRank.Value.Division + 1, playerRank.Value.RankPoints, (int)playerRank.Value.MatchesPlayed);
                    }
                }
            }
        }

        //Set the ranks
        private void setRank(string playlist, int tier)
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

        //Set text of the labels displaying division and rating
        private void setInfo(string playlist, int div, int rating, int matches)
        {
            if (playlist == "Duel")
            {
                if (div != 0)
                {
                    DuelInfo.Text = "Division " + convertDiv(div) + "\n" + rating + " Rating \n\n" + matches + " Matches";
                }
            }
            if (playlist == "Doubles")
            {
                if (div != 0)
                {
                    DoublesInfo.Text = "Division " + convertDiv(div) + "\n" + rating + " Rating \n\n" + matches + " Matches";
                }
            }
            if (playlist == "SoloStandard")
            {
                if (div != 0)
                {
                    Solo3sInfo.Text = "Division " + convertDiv(div) + "\n" + rating + " Rating \n\n" + matches + " Matches";
                }
            }
            if (playlist == "Standard")
            {
                if (div != 0)
                {
                    StandardInfo.Text = "Division " + convertDiv(div) + "\n" + rating + " Rating \n\n" + matches + " Matches";
                }
            }
        }

        //Restyle div from int to String
        private String convertDiv(int division)
        {
            string div = "";
            if (division == 1)
            {
                div = "I";
            }

            if (division == 2)
            {
                div = "II";
            }

            if (division == 3)
            {
                div = "III";
            }

            if (division == 4)
            {
                div = "IV";
            }

            if (division == 5)
            {
                div = "V";
            }

            return div;
        }

        //return to main form and delete SavedPlayer file
        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete("SavedPlayer.txt");
            Application.Restart();
        }

        //Open link on banner Click
        private void BannerBox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://rocketleaguestats.com");
        }

        //Update Player Ranks
        private async void update_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            progressBar1.Value = 1;
            await Player_Name_Platform.getPlayerTask();
            progressBar1.Value = 2;
            setSeason();
            updateLabel.Text = "Last Update: " + DateTime.Now.ToString("HH:mm");
            progressBar1.Hide();
        }
    }
}