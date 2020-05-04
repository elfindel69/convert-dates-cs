using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			ConsoleKeyInfo saisie;
			string timeUTC = "2011-01-01T12:00:00";
			string timeGTC = "10211-01-01T12:00:00";
			string timeTMC = "20211001.43200";
			do
			{
				Console.WriteLine("Welcome to Date converter!");
				Console.WriteLine("menu: ");
				Console.WriteLine("1. convert UTC Date (format yyyy-mm-ddThh:mm:ss)");
				Console.WriteLine("2. convert GTC Date (format yyyy-mm-ddThh:mm)");
				Console.WriteLine("3. convert TimeCode (format yyyydays.secs)");

				string strChoice = Console.ReadLine();
				int.TryParse(strChoice, out int choice);
				//UTC
				if (choice == 1)
				{
					Console.WriteLine("enter UTC Date (format yyyy-mm-ddThh:mm:ss):");
					timeUTC = Console.ReadLine();
					UTCDate date1 = new UTCDate(timeUTC);
					GTCDate date2 = date1.UTCDateToGTCDate();
					affDates(date1.getUTCTimeString(), date2.getGTCTimeString(), date2.GTCDateToTC());
					//GTC
				}
				else if (choice == 2)
				{
					Console.WriteLine("enter GTC Date (format yyyy-mm-ddThh:mm):");
					timeGTC = Console.ReadLine();
					GTCDate date2 = new GTCDate();
					date2.TimeStringToGTCDate(timeGTC);
					UTCDate date1 = date2.GTCDateToUTCDate();
					affDates(date1.getUTCTimeString(), date2.getGTCTimeString(), date2.GTCDateToTC());
					//TimeCode
				}
				else if (choice == 3)
				{
					Console.WriteLine("enter TimeCode (format yyyydays.secs):");
					timeTMC = Console.ReadLine();
					GTCDate date2 = new GTCDate();
					date2.TimeCodeToGTCDate(timeTMC);
					UTCDate date1 = date2.GTCDateToUTCDate();
					affDates(date1.getUTCTimeString(), date2.getGTCTimeString(), timeTMC);
				}
				else
				{
					Console.WriteLine("wrong answer :( ");
				}
				Console.WriteLine("exit? y/n ");
				saisie = Console.ReadKey(true);

			} while (saisie.Key != ConsoleKey.Y);
        }

		private static void affDates(string dateUTC, string dateGTC, string dateTMC)
		{
			Console.WriteLine("UTC Date: " + dateUTC);
			Console.WriteLine("GTC Date: " + dateGTC);
			Console.WriteLine("TimeCode: " + dateTMC);

		}

	}
}
