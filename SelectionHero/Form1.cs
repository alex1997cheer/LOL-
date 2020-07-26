using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dm;
namespace SelectionHero
{

    public partial class Form1 : Form 
    {
        dmsoft DM;
        Dictionary<string, List<int>> Hero;
        //Hero
        public Form1()
        {
            Hero = new Dictionary<string, List<int>>() {
                { "亚索", new List<int>(){ (int)Keys.Y, (int)Keys.A, (int)Keys.S, (int)Keys.U, (int)Keys.O, (int)Keys.Space }},
                { "卡牌大师", new List<int>(){ (int)Keys.K, (int)Keys.A, (int)Keys.P, (int)Keys.A, (int)Keys.I, (int)Keys.D, (int)Keys.A, (int)Keys.S, (int)Keys.H, (int)Keys.I, (int)Keys.Space}}
            };
            DM = new dmsoft();
            DM.SetPath(@"C:\Users\Administrator\Desktop\AutomationSelectHere\Image");
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {            
            string HeroName = comboBox1.Text.ToString();
            var LoLClient = DM.FindWindow("", "League of Legends");            
            DM.BindWindow(LoLClient, "gdi", "windows3", "normal", 1);
            DM.MoveTo(860, 97);
            DM.LeftClick();
            DM.Capture(0, 0, 2000, 2000, "1.bmp");
            int isExsit = -1;
            //Enter hero name X Y;
            int x=784, y=100;
            object x1, y2;
            while(true)
            {
                isExsit = DM.FindPic(0, 0, 2000, 2000, "Icon.bmp", "000000", 0.9, 0, out x1, out y2);
                if (isExsit >= 0)
                {
                    DM.MoveTo(860, 97);
                    Thread.Sleep(300);
                    DM.LeftClick();
                    Thread.Sleep(300);
                    foreach (int key in Hero[HeroName])
                    {
                        DM.KeyPress(key);
                    }                    
                    DM.MoveTo(370, 163);
                    Thread.Sleep(500);
                    DM.LeftClick();
                }
            }
        }
    }
}
