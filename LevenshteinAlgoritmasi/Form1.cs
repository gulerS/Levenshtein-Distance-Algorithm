using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace LevenshteinAlgoritmasi
{
    public partial class Form1 : MetroForm
    {
        public readonly List<string> KelimeBankasi;
        public Form1()
        {
            InitializeComponent();
            KelimeBankasi = new List<string>() { "aa", "cronom", "internet", "software", "google", "yahoo","monster","msi","lenovo","ibm","microsoft","apple","android"};
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

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            string aranan = metroTextBox1.Text;
            IEnumerable<string> tmp = BenzerleriniBul(aranan.ToLower());
            if (tmp != null && tmp.Count<string>() > 0)
            {
                htmlLabel1.Text = @"Bunu mu demek istediniz?  ";
                foreach (string a in tmp)
                    htmlLabel1.Text +=@"<b style=color:blue>"+ a + @",</b> ";
            }
            else
                htmlLabel1.Text = @"<b style=color:red>Öneri bulunamadı</b> ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
