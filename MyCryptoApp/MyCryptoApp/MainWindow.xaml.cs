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

namespace MyCryptoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string plainText, cypherText;
        int r1Setting, r2Setting, r3Setting;

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
        }

        public int parseTextBoxString(string s) {
            return Int32.Parse(s);
        }
    }
}
