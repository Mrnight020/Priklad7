using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hodina25._9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(textBox1.Text);
                

                string[] radky = File.ReadAllLines("cisla.txt");
                int cislo = int.Parse(radky[4]);
                long umocnenecislo = 1;
                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        checked { umocnenecislo *= cislo; }
                    }
                    MessageBox.Show("mocnina : " + umocnenecislo);
                }
                catch(ArithmeticException ex)
                {
                    MessageBox.Show("Preteceni pri umocnovani !!!");
                }

                double cislo2 = Convert.ToDouble(cislo);

                // ošetření dělení 0, podíl pátého realneho čísla a celeho čísla n.
                try { MessageBox.Show("podil celeho cisla : " + checked(cislo / n)); }
                catch (DivideByZeroException ex)
                {
                    MessageBox.Show("DivideByZeroException. " + ex.Message);
                }
                if (n != 0)
                {
                    cislo2 = cislo2 / n;
                    MessageBox.Show("realny podil : " + cislo2);
                }
                else MessageBox.Show("n neodopovida !!!!");

                //soucet a přetečení
                StreamReader precti = new StreamReader("cisla.txt");
                int soucet = 0;
                try
                {
                    while (!precti.EndOfStream)
                    {
                        checked { soucet += Convert.ToInt32(precti.ReadLine()); }
                    }
                    MessageBox.Show("Součet vsech cisel : " + soucet);
                }
                catch (ArithmeticException ex)
                {
                    MessageBox.Show("Preteceni pri souctu !!!");
                }
                precti.Close();

            }
            catch (FormatException ex)
            {
                MessageBox.Show("FormatException. " + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("OverflowException. " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("FileNotFoundException. " + ex.Message);
            }
            catch(IndexOutOfRangeException ex)
            {
                MessageBox.Show("pate cislo neexistuje :-)");
            }

        }
    }
}
