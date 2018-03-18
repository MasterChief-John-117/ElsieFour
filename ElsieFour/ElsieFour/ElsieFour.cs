using System;
using System.Linq;
using System.Security.Cryptography;

namespace ElsieFour
{
    public class ElsieFour
    {
        private static char[] Alphabet
        {
            get
            {
                return "#_23456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            }
        }
        private int[] key;

        public ElsieFour()
        {
            this.key = GenerateKey();
        }
        public ElsieFour(int[] k)
        {
            this.key = k;
        }

        public int[] GenerateKey()
        {
            key = new int[36];
            int[] temp = new int[36];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            for (int i = 0; i < 36; i++)
            {
                byte[] bytes = new byte[4];
                crypto.GetNonZeroBytes(bytes);
                int rand = Math.Abs(BitConverter.ToInt32(bytes, 0)) % 36;
                temp[i] = rand;
            }
            return temp;
        }

        public string ConvertKeyToString()
        {
            char[] tkey = new char[36];
            for(int i = 0; i < 36; i++)
            {
                tkey[i] = Alphabet[key[i]];
            }
            return string.Join("", tkey);
        }

        public int[] ConvertStringToKey(string input)
        {
            if (input.Length != 36)
            {
                throw new Exception("Input is not in the correct format");
            }
            int[] temp = new int[36];
            for (int i = 0; i < 36; i++)
            {
                if (!Alphabet.Contains(input[i]))
                {
                    throw new Exception("Input contains illegal characters");
                }
                char curr = input[i]; ;
                for(int j = 0; j < 36; j++)
                {
                    if(curr == Alphabet[j])
                    {
                        temp[i] = j;
                    }
                }
            }
            return temp;
        }
    }
}
