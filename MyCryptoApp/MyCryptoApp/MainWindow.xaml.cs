using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace MyCryptoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string plainText, cypherText;
        int r1Setting, r2Setting, r3Setting;
        uint[] primes = new uint[3000];
        uint mod, g, privateKey, publicKey, RpublicKey, ssKey;

      

        private void GenerateSecretKeyButton_Click(object sender, RoutedEventArgs e)
        {
            mod = (uint)Convert.ToInt32(modulusTextBox.Text);
            g = (uint)Convert.ToInt32(baseTextBox.Text);

            RpublicKey = (uint)Convert.ToInt32(recPulicKeyTextBox.Text);
            privateKey = (uint)Convert.ToInt32(privateKeyTextBox.Text);
            ssKey = modExp(RpublicKey, privateKey, mod);
            sharedSecretKeyTextBox.Text = ssKey.ToString();

            int sskLength = countDigits(ssKey);
            char[] sskString = ssKey.ToString().ToCharArray();
            string r1, r2, r3;
            if (sskLength == 5)
            {
                r1 = sskString[0].ToString() + sskString[2].ToString();
                r2 = sskString[2].ToString() + sskString[1].ToString();
                r3 = sskString[4].ToString() + sskString[4].ToString();
            }
            else if (sskLength == 4) {
                r1 = sskString[1].ToString() + sskString[1].ToString();
                r2 = sskString[0].ToString() + sskString[2].ToString();
                r3 = sskString[3].ToString() + sskString[3].ToString();
            }

            else if (sskLength == 3)
            {
                r1 = sskString[0].ToString() + sskString[1].ToString();
                r2 = sskString[2].ToString() + sskString[1].ToString();
                r3 = sskString[0].ToString() + sskString[2].ToString();
            }

            else if (sskLength == 2)
            {
                r1 = sskString[1].ToString() + sskString[1].ToString();
                r2 = sskString[0].ToString() + sskString[1].ToString();
                r3 = sskString[0].ToString() + sskString[0].ToString();
            }

            else{
                r1 = sskString[0].ToString() + '1'.ToString();
                r2 = sskString[2].ToString() + '5'.ToString();
                r3 = sskString[0].ToString() + '7'.ToString();
            }

            r1TextBox.Text = r1;
            r2TextBox.Text = r2;
            r3TextBox.Text = r3;

            R1SettingTextBox.Text = r1;
            R2SettingTextBox.Text = r2;
            R3SettingTextBox.Text = r3;


        }


        private void GeneratePublicKeyButton_Click(object sender, RoutedEventArgs e)
        {
            mod = (uint)Convert.ToInt32(modulusTextBox.Text);
            g = (uint)Convert.ToInt32(baseTextBox.Text);

            privateKey = (uint)Convert.ToInt32(privateKeyTextBox.Text);
            publicKey = modExp(g, privateKey, mod);
            publicKeyTextBox.Text = publicKey.ToString();
        }


        private void GenerateModButton_Click(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();
            int randomIndex = rng.Next(0, 3000);

            mod = primes[randomIndex];

            g = (uint)rng.Next(2, (int)Math.Floor((Math.Pow(2, 32) - 1) / (mod - 1)));

            modulusTextBox.Text = mod.ToString();
            baseTextBox.Text = g.ToString();
        }

   

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            r1Setting = parseTextBoxString(R1SettingTextBox.Text);
            r2Setting = parseTextBoxString(R2SettingTextBox.Text);
            r3Setting = parseTextBoxString(R3SettingTextBox.Text);

            plainText = PlainTextBox.Text;
            CypherTextBox.Clear();

            EnigmaMachine x = new EnigmaMachine(r1Setting, r2Setting, r3Setting);

            cypherText = x.enigmaEncrypt(plainText);
            CypherTextBox.Text = cypherText;


        }

        public MainWindow()
        {
            InitializeComponent();
            loadPrimes();
        }

        public int parseTextBoxString(string s) {
            return Int32.Parse(s);
        }

        public void loadPrimes() {
            int count = 0;
            using (StreamReader sr = new StreamReader("primes.txt"))
            {
                while(!sr.EndOfStream){
                    primes[count] = (uint)Convert.ToInt32(sr.ReadLine());
                    count++;
                }

            }
        
        }

        // y = a^b mod(p)
        public static uint modExp(uint a, uint b, uint p)
        {
            uint y = 1;
            for (int n = 0; n < b; n++)
            {
                y = (y * a) % p;
            }

            return y;
        }

        public int countDigits(uint x) {
            string temp = x.ToString();
            return temp.Length;
        }

    }
}
