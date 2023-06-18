using System;

namespace ConsoleApp1
{
	public class GTCDate
	{
		private int m_Year = 0;
		public int Year { get { return m_Year; } set { m_Year = value; } }
		private int m_Timestamp = 0;
		public int Timestamp { get { return m_Timestamp; } set { m_Timestamp = value; } }
		private int m_Hour = 0;
		public int Hour { get { return m_Hour; } set { m_Hour = value; } }
		private int m_Minute = 0;
		public int Minute { get { return m_Minute; } set { m_Minute = value; } }
		private int m_Second = 0;
		public int Second { get { return m_Second; } set { m_Second = value; } }
		private int m_Days = 1;
		public int Days {get { return m_Days; } set {m_Days = value ; } }
		private string m_Type = "GTC";

		private string daysToGTCDate()
		{
			string[] lMonths = { "Geylet", "Lyutet", "Daylet", "Elet", "Veylet", "Kreset", "Heylet", "Teylet", "Ruyet", "Listopat", "Aylet", "Beylet" };
			string[] lWeek = { "Niedila", "Poniedilek", "Wtorek", "Sroda", "Czwartek", "Pietek", "Sobota" };
			int days = this.m_Days > 0 ? this.m_Days : 1;
			int dayOfWeek = (int)(days % 7);
			string lMonth = "0";
			if (days <= 31)
			{
				lMonth = lMonths[0];
			}
			else if (days >= 32 && days <= 61)
			{
				lMonth = lMonths[1];
				days = days - 31;
			}
			else if (days >= 62 && days <= 92)
			{
				lMonth = lMonths[2];
				days = days - 61;
			}
			else if (days >= 93 && days <= 123)
			{
				lMonth = lMonths[3];
				days = days - 92;
			}
			else if (days >= 124 && days <= 154)
			{
				lMonth = lMonths[4];
				days = days - 123;
			}
			else if (days >= 155 && days <= 185)
			{
				lMonth = lMonths[5];
				days = days - 154;
			}
			else if (days >= 186 && days <= 216)
			{
				lMonth = lMonths[6];
				days = days - 185;
			}
			else if (days >= 217 && days <= 247)
			{
				lMonth = lMonths[7];
				days = days - 216;
			}
			else if (days >= 248 && days <= 278)
			{
				lMonth = lMonths[8];
				days = days - 247;
			}
			else if (days >= 279 && days <= 309)
			{
				lMonth = lMonths[9];
				days = days - 278;
			}
			else if (days >= 310 && days <= 340)
			{
				lMonth = lMonths[10];
				days = days - 309;
			}
			else if (days >= 341 && days <= 371)
			{
				lMonth = lMonths[11];
				days = days - 340;
			}

			return lWeek[dayOfWeek] + ' ' + days + ' ' + lMonth;
		}

		public String getGTCTimeString()
		{
			return this.daysToGTCDate() + ' ' + this.m_Year + " à " + Utils.compZero(this.m_Hour) + ":" + Utils.compZero(this.m_Minute) + ":" + Utils.compZero(this.m_Second) + " " + this.m_Type;
		}

		public String GTCDateToTC()
		{
			return this.m_Year + Utils.GTC_TO_MIG_YEAR + "" + Utils.compDoubleZero(this.m_Days) + '.' + Utils.compFiveZeros(this.m_Timestamp);
		}

		public void TimeStringToGTCDate(String time)
		{
			String[] timeArray = time.Split("T");
			String[] dateArray = timeArray[0].Split("-");

			int month = int.Parse(dateArray[1]);
			int[] monthsArray = { 0, 31, 61, 92, 123, 154, 185, 216, 247, 278, 309, 340 };

			String[] hourArray = timeArray[1].Split(":");

			GTCDate date = new GTCDate();
			date.m_Year = int.Parse(dateArray[0]);
			int day = int.Parse(dateArray[2]);
			int offset = monthsArray[month - 1];
			date.m_Days = day + offset;

			date.m_Hour = int.Parse(hourArray[0]);
			date.m_Minute = int.Parse(hourArray[1]);
			if (hourArray.Length == 3)
			{
				date.m_Second = int.Parse(hourArray[2]);
			}
			else if (hourArray.Length == 2)
			{
				date.m_Second = 0;
			}

			int offsetHour = date.m_Hour * 3600;
			int offsetMin = date.m_Minute * 60;
			date.m_Timestamp = offsetHour + offsetMin + date.m_Second;
			copy(date);
		}

		private int[] daysToUTCDate(int days)
		{
			days = days > 0 ? days : 1;
			int lMonth = 0;
			if (days <= 31)
			{
				lMonth = 1;
			}
			else if (days >= 32 && days <= 59)
			{
				lMonth = 2;
				days = days - 31;
			}
			else if (days >= 62 && days <= 90)
			{
				lMonth = 3;
				days = days - 59;
			}
			else if (days >= 91 && days <= 120)
			{
				lMonth = 4;
				days = days - 90;
			}
			else if (days >= 121 && days <= 151)
			{
				lMonth = 5;
				days = days - 120;
			}
			else if (days >= 152 && days <= 181)
			{
				lMonth = 6;
				days = days - 151;
			}
			else if (days >= 182 && days <= 212)
			{
				lMonth = 7;
				days = days - 181;
			}
			else if (days >= 213 && days <= 243)
			{
				lMonth = 8;
				days = days - 212;
			}
			else if (days >= 244 && days <= 272)
			{
				lMonth = 9;
				days = days - 243;
			}
			else if (days >= 273 && days <= 303)
			{
				lMonth = 10;
				days = days - 272;
			}
			else if (days >= 304 && days <= 333)
			{
				lMonth = 11;
				days = days - 303;
			}
			else if (days >= 334 && days <= 365)
			{
				lMonth = 12;
				days = days - 333;
			}

			return new int[] { days, lMonth };
		}
		public UTCDate GTCDateToUTCDate()
		{
			int UTCYear = this.m_Year - Utils.UTC_TO_GTC_YEAR;
			int offsetYear = UTCYear * 34725600;
			int offsetDays = this.m_Days * 93600;
			long GTCTimestamp = 0;
			if (this.m_Year >= 10211)
			{
				offsetDays -= 93600;
				GTCTimestamp = (offsetYear + offsetDays + this.m_Timestamp) * 1000;
			}
			else
			{
				offsetYear += 34725600;
				offsetDays -= 34725600;
				long offsetSec = 0;
				if (this.m_Timestamp > 0)
				{
					offsetSec = 93600 - this.m_Timestamp;
				}
				GTCTimestamp = (offsetYear + offsetDays + offsetSec) * 1000;
				if (GTCTimestamp > 0)
				{
					GTCTimestamp *= -1;
				}
			}
			long UTCTimestamp = 1293840000000L;
			
			UTCDate date = new UTCDate();

			//Timestamp (millis) to date
			long lTimeStamp = 0L;
			if (UTCYear >= 0)
			{
				lTimeStamp = GTCTimestamp;
			} else
			{
				lTimeStamp = UTCTimestamp + GTCTimestamp;
			}
			int lYear = (int)(Math.Floor((double)(lTimeStamp / 31536000000L)));
			lTimeStamp = lTimeStamp % 31536000000L;
			int days = (int)Math.Floor((double)(lTimeStamp / 86400000));

			lTimeStamp = lTimeStamp % 86400000;
			int lHour = (int)Math.Floor((double)(lTimeStamp / 3600000));
			int lMin = (int)(lTimeStamp % 3600000);
			lMin = (int)Math.Floor((double)(lMin / 60000));
			int lSecond = (int)Math.Floor((double)(lMin % 60000 / 1000));

			int[] tabDays = daysToUTCDate(days);
			lYear += 2011;
			date.Date =new DateTime(lYear, tabDays[1],tabDays[0],lHour, lMin, lSecond);

			return date;
		}

		public void TimeCodeToGTCDate(String time)
		{
			String[] timeArray = time.Split(".");
			String dateCode = timeArray[0];
			String seconds = timeArray[1];
			GTCDate dateGTC = new GTCDate();
			int yearMIG = int.Parse(dateCode.Substring(0, 5));
			dateGTC.m_Year = yearMIG - Utils.GTC_TO_MIG_YEAR;
			String strDays = dateCode.Substring(5);
			dateGTC.m_Days = int.Parse(strDays);
			dateGTC.m_Timestamp = int.Parse(seconds);
			MyDiv div1 = new MyDiv();
			div1 = div1.div(dateGTC.m_Timestamp, 3600);
			dateGTC.m_Hour = div1.Quot;
			MyDiv div2 = new MyDiv();
			div2 = div2.div(div1.Rest, 60);
			dateGTC.m_Minute = div2.Quot;
			dateGTC.m_Second = div2.Rest;
			copy(dateGTC);
		}

		private void copy(GTCDate date)
		{
			this.Days = date.Days;
			this.Hour = date.Hour;
			this.Minute = date.Minute;
			this.Second = date.Second;
			this.Timestamp = date.Timestamp;
			this.Year = date.Year;
		}

	}
}
