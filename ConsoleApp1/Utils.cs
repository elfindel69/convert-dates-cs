using System;
namespace ConsoleApp1
{
	public static class Utils
	{
		 public const int GTC_TO_MIG_YEAR = 10000;
		 public const int UTC_TO_GTC_YEAR = 10211;

		public static string compDoubleZero(int number)
		{
			string res = number.ToString();
			if (number < 10)
			{
				res = "00" + number;
			}
			else if (number >= 10 && number < 100)
			{
				res = "0" + number;
			}
			return res;
		}

		public static string compFiveZeros(int number)
		{
			string res = number.ToString();
			if (number < 10)
			{
				res = "0000" + number;
			}
			else if (number >= 10 && number < 100)
			{
				res = "000" + number;
			}
			else if (number >= 100 && number < 1000)
			{
				res = "00" + number;
			}
			else if (number >= 1000 && number < 10000)
			{
				res = "0" + number;

			}
			return res;
		}

		public static string compZero(int nombre)
		{
			return nombre < 10 ? "0" + nombre : nombre.ToString();
		}

	}
}
