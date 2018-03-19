using System;
using System.Collections.Generic;
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
        public State state;

        public ElsieFour()
        {
            this.key = GenerateKey();
            state = new State(this.key);
        }
        public ElsieFour(string tKey)
        {
            this.key = ConvertStringToKey(tKey);
            state = new State(this.key);
        }
        public ElsieFour(int[] k)
        {
            this.key = k;
            state = new State(this.key);
        }

        public int[] GenerateKey()
        {
            key = new int[36];
            int[] temp = new int[36];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            HashSet<int> uniquePos = new HashSet<int>();
            while(uniquePos.Count != 36)
            {
                byte[] bytes = new byte[4];
                crypto.GetNonZeroBytes(bytes);
                int rand = Math.Abs(BitConverter.ToInt32(bytes, 0)) % 36;
                uniquePos.Add(rand);
            }
            for(int i = 0; i < 36; i++)
            {
                temp[i] = uniquePos.ElementAt(i);
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
            if (input.ToCharArray().Distinct().Count() != 36)
            {
                throw new Exception("Input contains non-unique characters");
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
