using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopManagement
{
    internal class Encryption
    {
        public string encrypt(string str, string kk)
        {
            int[] key = new int[kk.Length];
            for (int i = 0; i < kk.Length; i++)
            {

                key[i] = (int)(kk[i] % 48);
            }

            int j = 0;
            string msg = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (j == key.Length) { j = 0; }
                char ch = (char)(str[i] + key[j]);
                msg += Convert.ToString(ch);
                j++;

            }

            return msg;
        }
        public string decrpyt(string str, string kk)
        {
            int[] key = new int[kk.Length];
            for (int i = 0; i < kk.Length; i++)
            {

                key[i] = (int)(kk[i] % 48);
            }
            int j = 0;
            string msg = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (j == key.Length) { j = 0; }
                char ch = (char)(str[i] - key[j]);
                msg += Convert.ToString(ch);
                j++;
            }

            return msg;

        }
    }
}
