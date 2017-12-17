using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using RLSApi;
using RLSApi.Data;
using RLSApi.Net.Models;
using RLSApi.Net.Requests;

namespace RocketLeagueStatChecker
{
    public partial class Player_Name_Platform : Form
    {
        public static String name;
        public static int platform;
        public static RlsPlatform plat;
        public static Player player;
        public static bool player_set = false;

        private static ProgressBar bar;
        private static long id;

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
                            Error("Please make sure to use your SteamID instead of your name!");
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
            Form form = new Main_Form();
            form.Show();
        }

        //Get Player
        public static async Task Run()
        {
            var apiKey = "IQB8PMF8N605UKX7K698FTWWV99J2G9M";
            var client = new RLSClient(apiKey);
            bar.Value = 2;

            player = await client.GetPlayerAsync(plat, name);
            bar.Value = 3;

            player_set = true;
            openMain();
        }

        private void getRanks(RlsPlatform platform, bool Steam)
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
            Run().GetAwaiter().GetResult();
        }
    }
}