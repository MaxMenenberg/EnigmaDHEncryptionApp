using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaClassTester
{
    class EnigmaMachine
    {
        int[] rotor1 = new int[] {32,10,20,90,29,89,35,91,26,71,16,77,39,63,24,27,7,33,69,42,
            65,75,67,37,83,19,88,85,1,49,34,82,3,6,13,92,28,76,18,61,73,45,81,30,14,72,11,21,
            0,84,22,17,44,15,43,59,31,56,50,23,8,46,80,38,54,57,79,66,53,68,51,74,41,58,5,47,9,
            78,62,52,4,55,36,64,93,60,87,86,2,48,25,70,40,12};

        int[] rotor2 = new int[] { 78,39,16,15,70,59,46,47,63,66,73,79,58,89,38,51,45,91,88,
            12,33,1,72,13,62,56,9,55,92,82,83,24,90,40,77,25,53,48,81,42,10,11,30,18,52,19,14,
            75,22,67,31,85,8,4,50,87,74,6,61,68,29,34,32,21,36,64,35,41,84,86,3,49,71,93,65,54,
            43,69,20,26,2,57,27,7,0,37,23,76,44,5,60,80,17,28};

        int[] rotor3 = new int[] { 56,63,29,75,86,0,45,28,40,15,57,21,82,34,5,50,71,25,31,49,
            64,35,74,20,54,53,36,79,3,58,30,14,52,37,8,4,92,47,48,66,91,44,65,90,18,16,61,7,32,
            62,42,60,11,87,76,33,12,6,55,39,24,59,22,83,1,81,38,89,69,73,77,9,19,80,26,27,10,85,
            88,70,51,23,93,72,67,68,2,43,84,78,17,46,13,41};

        int[] reflector = new int[] {
            55,14,28,3,4,86,31,7,9,8,10,11,12,13,1,15,19,17,18,16,78,74,22,43,24,25,38,27,2,
            76,40,6,62,33,37,35,36,34,26,39,30,71,42,23,44,70,46,47,48,88,91,67,66,89,54,0,59,
            57,58,56,60,61,32,63,64,65,52,51,92,69,45,41,79,73,21,75,29,77,20,72,80,81,82,83,84,
            85,5,87,49,53,90,50,68,93};

        int rotorSize = 94;

        public EnigmaMachine(int s1, int s2, int s3) {

            for (int n = 0; n < s1; n++) {
                shift(rotor1);
            }

            for (int n = 0; n < s2; n++)
            {
                shift(rotor2);
            }

            for (int n = 0; n < s3; n++)
            {
                shift(rotor3);
            }

        }


        //Shift the elements in a rotor 1 position
        public void shift(int[] x) {
            int lastElement = x[x.Length - 1];
            for (int n = x.Length - 2; n >= 0;  n--) {
                x[n+1] = x[n];
            }
            x[0] = lastElement;
        }

        //Convert string to ASCII array. 
        public int[] string2ASCII(string s) {
            char[] symbols = s.ToCharArray();
            int[] retVal = new int[symbols.Length];

            for (int n = 0; n < retVal.Length; n++) {
                retVal[n] = (int)symbols[n] - 32;
            }
            return retVal;
        }

        //Convert ASCII array to string. 
        public string ASCII2string(int[] x) {

            char[] symbols = new char[x.Length];

            for (int n = 0; n < x.Length; n++) {
                symbols[n] = (char)(x[n] + 32);
            }

            string retval = new string(symbols);
            return retval;
        
        }

        //Pass an encoded value through a rotor
        public int rotorMap(int[] rotor, int x) {
            return rotor[x];        
        }

        //Pass an encoded value through a rotor in reverse
        public int rotorMapInverse(int[] rotor, int x) {

            int retval = 0;
            for (int n = 0; n < rotor.Length; n++) {
                if (rotor[n] == x) {
                    retval = n;
                    break;
                }
            }
            return retval;
        
        }


        public string enigmaEncrypt(string message) {

            //Convert message to ASCII array
            int[] ASCIImessage = string2ASCII(message);

            //An array for the ASCII cypher text
            int[] ASCIIcypherMessage = new int[ASCIImessage.Length];

            int rotor1ShiftCount = 0;
            int rotor2ShiftCount = 0;
            int rotor3ShiftCount = 0;

            //Now one by one process each letter
            for (int n = 0; n < ASCIImessage.Length; n++) {

                //Pass through the first rotor
                int r1Out = rotorMap(rotor1, ASCIImessage[n]);
                int r2Out = rotorMap(rotor2, r1Out);
                int r3Out = rotorMap(rotor3, r2Out);

                //Pass through the reflector
                int reflectOut = rotorMap(reflector, r3Out);

                //Pass through the rotors in reverse
                int r3OutInverse = rotorMapInverse(rotor3, reflectOut);
                int r2OutInverse = rotorMapInverse(rotor2, r3OutInverse);
                ASCIIcypherMessage[n] = rotorMapInverse(rotor1, r2OutInverse);

                shift(rotor1);
                rotor1ShiftCount++;

                if (rotor1ShiftCount > rotorSize) {
                    rotor1ShiftCount = 0;
                    shift(rotor2);
                    rotor2ShiftCount++;
                }

                if (rotor2ShiftCount > rotorSize) {
                    rotor2ShiftCount = 0;
                    shift(rotor3);
                    rotor3ShiftCount++;
                }

            }

            //Convert the cypher text ascii array to a string
            string cypherText = ASCII2string(ASCIIcypherMessage);
            return cypherText;


        }



    }
}
