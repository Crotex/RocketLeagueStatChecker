using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using RLSApi;
using RLSApi.Data;
using RLSApi.Net.Models;
using RLSApi.Net.Requests;

namespace RocketLeagueStatChecker
{
    public partial class Player_Name_Platform : Form
    {
        public String name;
        public int platform;
        public RlsPlatform plat;
        public static Player player;
        public static bool player_set = false;

        private ProgressBar bar;
        private long id;
        private RLSClient client;
        private string savedPlayer;
        private bool Steam, platform_set = false;

        public Player_Name_Platform()
        {
            InitializeComponent();
            bar = progressBar1;
            progressBar1.Maximum = 3;
            try
            {
                TextReader tr = new StreamReader("SavedPlayers.txt");
                savedPlayer = tr.ReadLine();
                int.TryParse(tr.ReadLine(), out platform);
                tr.Close();
            }
            catch (FileNotFoundException e)
            {
                ;
            }
            if (savedPlayer != null)
            {
                player_name.Text = savedPlayer;

                if (platform == 0)
                {
                    plat = RlsPlatform.Steam;
                    Steam = true;
                }
                if (platform == 1)
                {
                    plat = RlsPlatform.Ps4;
                    Steam = false;
                }
                if (platform == 2)
                {
                    plat = RlsPlatform.Xbox;
                    Steam = false;
                }

                platform_set = true;
                name = player_name.Text;
                getPlayerInformation(plat, Steam);
            }
        }

        //"Done" Button Clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //Check if Name is entered and platform checked
            if (player_name.Text != "Enter your name (or SteamID64)")
            {
                if (checkedListBox1.CheckedItems.Count == 1)
                {

                    if (checkedListBox1.GetItemChecked(0) == false)
                    {
                        if (checkedListBox1.GetItemChecked(1) == false)
                        {
                            platform = 2;
                            savePlayer();
                            getPlayerInformation(RlsPlatform.Xbox, false);
                        }
                        else
                        {
                            platform = 1;
                            savePlayer();
                            getPlayerInformation(RlsPlatform.Ps4, false);
                        }
                    }
                    else
                    {
                        id = 0;
                        if (long.TryParse(player_name.Text, out id))
                        {
                            platform = 0;
                            savePlayer();
                            getPlayerInformation(RlsPlatform.Steam, true);
                        }
                        else
                        {
                            Error("Please make sure to use your SteamID64 instead of your name if you're using Steam! (steamidfinder.com)");
                        }
                    }
                }
                else
                {
                    Error("Please make sure to select the platform you play on!");
                }
            }
            else
            {
                Error("Please make sure to enter your gametag / SteamID64 first!");
            }
        }

        //only 1 Item Checked at a time
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (e.Index != i)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }

        //Error Message
        public void Error(String message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Open Main_Form
        private static void openMain()
        {
            Main_Form form = new Main_Form();
            form.Show();
        }

        //Speicify the player
        private async void getPlayerInformation(RlsPlatform platform, bool Steam2)
        {
            if (!platform_set)
            {
                plat = platform;
            }

            bar.Visible = true;
            button1.Visible = false;

            bar.Value = 1;

            try
            {
                player = await getPlayerTask();
            }
            catch (Exception e)
            {
                Error(e.Message);
                Close();
                return;
            }

            bar.Value = 3;
            player_set = true;
            openMain();
            this.Hide();
        }

        //Get the player out of the Information entered above
        private async Task<Player> getPlayerTask()
        {
            client = new RLSClient(config.key);

            name = player_name.Text;

            bar.Value = 2;

            player = await client.GetPlayerAsync(plat, name);
            return player;

        }

        //Save Player to file and automatically start with him on next start
        private void savePlayer()
        {
            if (savePlayerBox.Checked)
            {
                TextWriter tw = new StreamWriter("SavedPlayers.txt");
                tw.Write(player_name.Text + "\n");
                tw.Write(platform.ToString());
                tw.Close();
            }
        }
    }
}