using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevenshteinAlgoritmasi
{
    public partial class Form1 : Form
    {
        public readonly List<string> KelimeBankasi;
        public Form1()
        {
            InitializeComponent();
            KelimeBankasi = new List<string>() { "aa", "cronom", "internet", "software", "google", "yahoo","monster","msi","lenovo","ibm"};
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        public IEnumerable<string> BenzerleriniBul(string arananKelime)
        {
            IEnumerable<string> tmp;

            tmp = KelimeBankasi.Where(s => (arananKelime.ToLower().FindLevenshteinDistance(s) <= UzunluguSinirla(s.Length, s)));

            return tmp;
        }
        private int UzunluguSinirla(int kelimeUzunlugu, string s)
        {
            if (kelimeUzunlugu <= 3)
                return 1;
            return (kelimeUzunlugu / 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox1.Text;
            IEnumerable<string> tmp = BenzerleriniBul(aranan.ToLower());
            if (tmp != null && tmp.Count<string>() > 0)
            {
                label1.Text = @"Bunu mu demek istediniz? ";
                foreach (string a in tmp)
                    label1.Text += a + @" ";
            }
            else
                label1.Text = "Öneri Bulunamadı";
        }



        


    }
}
