using System;
using System.Linq;
using System.Windows.Forms;

namespace RocketLeagueStatChecker
{
    public partial class Player_Name_Platform : Form
    {
        public String name;
        public int platform;

        public Player_Name_Platform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Check if Name is entered and platform checked
            if (player_name.Text.Count() > 0)
            {
                if (checkedListBox1.CheckedItems.Count == 1)
                {

                    if (checkedListBox1.GetItemChecked(0) == false)
                    {
                        if (checkedListBox1.GetItemChecked(1) == false)
                        {
                            platform = 3;
                            name = player_name.Text;
                        }
                        else
                        {
                            platform = 2;
                            name = player_name.Text;
                        }
                    }
                    else
                    {
                        long id = 0;
                        if (long.TryParse(player_name.Text, out id))
                        {
                            platform = 1;
                            name = id.ToString();
                        }
                        else
                        {
                            Error("Please make sure to use your SteamID instead of your name!");
                        }
                    }
                    Form Main = new Main_Form();
                    Main.Show();
                    //Close();
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
    }
}