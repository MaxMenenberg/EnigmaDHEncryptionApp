using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrimeParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string primeFile = "primes1.txt";
            int[] primes = new int[1000000];
            int[] primesSmallList = new int[3000];
            int count = 0;
            using (StreamReader sr = new StreamReader(primeFile)) {
                while (!sr.EndOfStream) {
                   
                    string tempLine = sr.ReadLine();
                    string[] tempLineItems = tempLine.Split(new char[] {' '});

                    List<string> tempLineItems2 = new List<string>();
                    for (int n = 0; n < tempLineItems.Length; n++) {
                        if (tempLineItems[n] != "") {
                            tempLineItems2.Add(tempLineItems[n]);
                        }
                    }

                    for (int n = 0; n < tempLineItems2.Count - 1; n++) {
                        string tempItem = tempLineItems2[n];
                        int tempItemInt = Convert.ToInt32(tempItem);
                        primes[count] = tempItemInt;
                        count++;
                    }

                   
                
                }

            }

            for (int n = 2000; n < 5000; n++) {
                primesSmallList[n-2000] = primes[n];

            }
            using (StreamWriter sw = new StreamWriter("primes.txt")) {
                for (int n = 0; n < primesSmallList.Length; n++) {
                    sw.WriteLine(primesSmallList[n].ToString());
                }
            }


            int b = 1;
        }
    }
}
