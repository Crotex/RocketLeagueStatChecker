using System;
using System.Linq;
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

        public Player_Name_Platform()
        {
            InitializeComponent();
            bar = progressBar1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 3;
            //Check if Name is entered and platform checked
            if (player_name.Text.Count() > 0)
            {
                if (checkedListBox1.CheckedItems.Count == 1)
                {

                    if (checkedListBox1.GetItemChecked(0) == false)
                    {
                        if (checkedListBox1.GetItemChecked(1) == false)
                        {
                            getRanks(RlsPlatform.Xbox, false);
                        }
                        else
                        {
                            getRanks(RlsPlatform.Ps4, false);
                        }
                    }
                    else
                    {
                        id = 0;
                        if (long.TryParse(player_name.Text, out id))
                        {
                            getRanks(RlsPlatform.Steam, true);
                        }
                        else
                        {
                            Error("Please make sure to use your SteamID64 instead of your name! (steamidfinder.com)");
                        }
                    }
                }
                else
                {
                    Error("Please make sure to select a platform first!");
                }
            }
            else
            {
                Error("Please make sure to enter your gametag first!");
            }
        }

        //only 1 Item Checked check
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
        private async void getRanks(RlsPlatform platform, bool Steam)

        {
            plat = platform;
            if (Steam)
            {
                name = id.ToString();
            }
            else
            {
                name = player_name.Text;
            }
            bar.Value = 1;

            player = await getPlayer();

            bar.Value = 3;
            player_set = true;
            openMain();
            this.Hide();
        }

        //Get the player out of the Information entered above
        private async Task<Player> getPlayer()
        {
            client = new RLSClient(config.key);

            bar.Value = 2;

            player = await client.GetPlayerAsync(plat, name);
            return player;

        }
    }
}