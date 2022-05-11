using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinamikOyun
{
    public partial class Form1 : Form
    {
        int[,] arr2d;
        int pos;
        private void Tikla(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;
            string[] degerler = _btn.Name.Split('_');
            int i = Convert.ToInt32(degerler[1]);
            int j = Convert.ToInt32(degerler[2]);

            if (arr2d[i, j] == 0)
            {
                pos++;
                foreach (Button _secilen in this.Controls.OfType<Button>())
                {
                    degerler = _secilen.Name.Split('_');
                    int s_i = Convert.ToInt32(degerler[1]);
                    int s_j = Convert.ToInt32(degerler[2]);
                    if (s_j == pos)
                        _secilen.Enabled = true;
                    else
                        _secilen.Enabled = false;
                }

                label1.Text = "Seviye: " + (pos + 1).ToString();
            }
            else
            {
                foreach (Button _secilen in this.Controls.OfType<Button>())
                {
                    degerler = _secilen.Name.Split('_');
                    int s_i = Convert.ToInt32(degerler[1]);
                    int s_j = Convert.ToInt32(degerler[2]);
                    _secilen.Enabled = false;
                }

                label2.Text = "Game Over!!!";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = 4, y = 10;
            arr2d = new int[x, y];
            pos = 0;

            Random rnd = new Random();
            int secim;

            for (int i = 0; i < y; i++)
            {
                secim = rnd.Next(0, x);
                arr2d[secim, i] = 1;
            }

            int sayi = 1;
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    Button btn = new Button();
                    btn.Location = new System.Drawing.Point(10 + i * 55, 10 + j * 55);
                    btn.Name = "BTN_" + i.ToString() + "_" + j.ToString();
                    btn.Size = new System.Drawing.Size(50, 50);
                    btn.Text = sayi.ToString(); //+ arr2d[i, j].ToString();
                    btn.Click += new System.EventHandler(Tikla);
                    this.Controls.Add(btn);
                    sayi++;

                    if (j != 0)
                        btn.Enabled = false;
                }

            }
        }
    }
}
