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
            string message = "aaaaaaaaaaaaaaaaaaaaaaaaa";

            int s1 = 20;
            int s2 = 4;
            int s3 = 60;

            EnigmaMachine x = new EnigmaMachine(s1, s2, s3);

            string cypherText = x.enigmaEncrypt(message);

            Debug.WriteLine("Original Message: " + message);
            Debug.WriteLine("Encypyted Message: " + cypherText);

            EnigmaMachine y = new EnigmaMachine(s1, s2, s3);

            string decryptedText = y.enigmaEncrypt(cypherText);
            Debug.WriteLine("Encrypyted Message: " + cypherText);
            Debug.WriteLine("Message After Decryption: " + decryptedText);

        }
    }
}
