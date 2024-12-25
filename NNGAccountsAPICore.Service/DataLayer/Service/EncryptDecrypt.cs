using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Common
{
    public static class EncryptDecrypt
    {
		public static string Encrypt(string str)
		{
			string? encr = null;
			if (str == "")
			{
				encr = "ÄÆ8¼";
				return encr;
			}
			else
			{
				for (int i = 0; i < str.Length; i++)
				{
					char ch = Convert.ToChar(str.Substring(i, 1));
					int num = ch + 169;
					char enchar = (char)num;
					encr = encr + enchar.ToString();
				}
			}

			return encr;
		}
		public static string Decrypt(string str)
		{
			string? decr = null;
			if (str == "ÄÆ8¼")
			{
				decr = "";
				return decr;
			}
			else
			{
				for (int i = 0; i < str.Length; i++)
				{
					char ch = Convert.ToChar(str.Substring(i, 1));
					int num = ch - 169;
					char dechar = (char)num;
					decr = decr + dechar.ToString();
				}
			}
			return decr;
		}
	}
}
