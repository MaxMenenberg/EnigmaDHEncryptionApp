using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace RotorMaker
{
    class Program
    { 
        static void Main(string[] args)
        {

            int N = 94;
            int[] r1 = new int[N];
            int[] r2 = new int[N];
            int[] r3 = new int[N];
            int[] reflector = new int[N];

            for (int n = 0; n < r1.Length; n++) {
                r1[n] = n;
                r2[n] = n;
                r3[n] = n;
                reflector[n] = n;
            }

            System.Random rng = new System.Random();
            for (int n = 0; n < 1000; n++) {
                int randA = rng.Next(N);
                int randB = rng.Next(N);

                int temp = r1[randA];
                r1[randA] = r1[randB];
                r1[randB] = temp;
            }

            for (int n = 0; n < 1000; n++)
            {
                int randA = rng.Next(N);
                int randB = rng.Next(N);

                int temp = r2[randA];
                r2[randA] = r2[randB];
                r2[randB] = temp;
            }

            for (int n = 0; n < 1000; n++)
            {
                int randA = rng.Next(N);
                int randB = rng.Next(N);

                int temp = r3[randA];
                r3[randA] = r3[randB];
                r3[randB] = temp;
            }

            List<int> alreadySwappedElements = new List<int>();

            for (int n = 0; n < 50000; n++) {
                int randA = rng.Next(N);
                int randB = rng.Next(N);

                if (alreadySwappedElements.Contains(randA) | alreadySwappedElements.Contains(randB))
                {
                    //Do nothing
                }
                else {
                    //Swap
                    int temp = reflector[randA];
                    reflector[randA] = reflector[randB];
                    reflector[randB] = temp;

                    alreadySwappedElements.Add(randA);
                    alreadySwappedElements.Add(randB);
                }
            }

            string r1File = "rotor1.csv";
            string r2File = "rotor2.csv";
            string r3File = "rotor3.csv";
            string stringReflectorFile = "reflector.csv";

            using (StreamWriter sr = new StreamWriter(r1File)) {
                sr.Write(string.Join(",", r1));
            }

            using (StreamWriter sr = new StreamWriter(r2File))
            {
                sr.Write(string.Join(",", r2));
            }

            using (StreamWriter sr = new StreamWriter(r3File))
            {
                sr.Write(string.Join(",", r3));
            }

            using (StreamWriter sr = new StreamWriter(stringReflectorFile))
            {
                sr.Write(string.Join(",", reflector));
            }

        }
    }
}
