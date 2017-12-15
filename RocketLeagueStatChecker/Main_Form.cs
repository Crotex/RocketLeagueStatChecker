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
        public static RlsPlatform plat;
        public static RlsSeason s = new RlsSeason();

        private bool season_set = false;
        private bool platform_set = false;

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

        //Season select
        private void seasonBox_ItemChanged(object sender, EventArgs e)
        {
            setSeason();
            setPlatform();

            if (season_set && platform_set)
            {
                GetRanks.getRanks(null);
            }
        }

        //Check and set the selected Season
        private void setSeason()
        {
            //Get selected season
            string item = seasonBox.SelectedItem.ToString();

            //Season set to 1
            if (item == "Season 1")
            {
                season_set = true;
                s = RlsSeason.One;
            }

            //Season set to 2
            if (item == "Season 2")
            {
                season_set = true;
                s = RlsSeason.Two;
            }

            //Season set to 3
            if (item == "Season 3")
            {
                season_set = true;
                s = RlsSeason.Three;
            }

            //Season set to 4
            if (item == "Season 4")
            {
                season_set = true;
                s = RlsSeason.Four;
            }

            //Season set to 5
            if (item == "Season 5")
            {
                season_set = true;
                s = RlsSeason.Five;
            }

            //Season set to 6
            if (item == "Season 6")
            {
                season_set = true;
                s = RlsSeason.Six;
            }
        }

        //Check and set the selected platform
        private void setPlatform()
        {
            //Platform = Steam
            if (Player_Name_Platform.platform == 1)
            {
                plat = RlsPlatform.Steam;
                platform_set = true;
            }

            //Platform = PS4
            if (Player_Name_Platform.platform == 2)
            {
                plat = RlsPlatform.Ps4;
                platform_set = true;
            }

            //Platform = XBOX
            if (Player_Name_Platform.platform == 3)
            {
                plat = RlsPlatform.Xbox;
                platform_set = true;
            }
        }
    }
}