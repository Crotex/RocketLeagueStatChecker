using System;
using System.Linq;
using System.Windows.Forms;

namespace RocketLeagueStatChecker
{
    public partial class Player_Name_Platform : Form
    {
        public static String name;
        public static int platform;

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
                            openMain();
                        }
                        else
                        {
                            platform = 2;
                            name = player_name.Text;
                            openMain();
                        }
                    }
                    else
                    {
                        long id = 0;
                        if (long.TryParse(player_name.Text, out id))
                        {
                            platform = 1;
                            name = id.ToString();
                            openMain();
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
        private void openMain()
        {
            Form form = new Main_Form();
            form.Show();
        }
    }
}