using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EnigmaClassTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Hello World!!!";

            EnigmaMachine x = new EnigmaMachine(20, 4, 60);

            string cypherText = x.enigmaEncrypt(message);

            Debug.WriteLine("Original Message: " + message);
            Debug.WriteLine("Encypyted Message: " + cypherText);

            EnigmaMachine y = new EnigmaMachine(20, 4, 60);

            string decryptedText = y.enigmaEncrypt(cypherText);
            Debug.WriteLine("Encrypyted Message: " + cypherText);
            Debug.WriteLine("Message After Decryption: " + decryptedText);

        }
    }
}
