using System;
namespace ConsoleApp1
{
	public class UTCDate
	{
		private DateTime m_Date;
		public DateTime Date { set { m_Date = value; } }

		public UTCDate(String strDate)
		{
			strDate = strDate+"Z";
			m_Date = DateTime.Parse(strDate).ToUniversalTime();
		}

		public UTCDate()
		{
			// TODO Auto-generated constructor stub
		}

		private TimeSpan UTCToTimeStamp()
		{
			DateTime ZEROTIME = new DateTime(2011,1,1,0,0,0);
			TimeSpan interval = new TimeSpan(this.m_Date.Ticks - ZEROTIME.Ticks);
			return interval;
		}

		public GTCDate UTCDateToGTCDate()
		{
			GTCDate lDate = new GTCDate(); 
			long lTimestamp = (long)(this.UTCToTimeStamp().TotalMilliseconds);
			lDate.Year = (int)(Math.Floor((double)(lTimestamp / 34725600000L))) + Utils.UTC_TO_GTC_YEAR;
			lTimestamp = lTimestamp % 34725600000L;
			int days = (int)Math.Floor((double)(lTimestamp / 93600000));
			lTimestamp = lTimestamp % 93600000;
			lDate.Timestamp = (int)Math.Floor((double)(lTimestamp / 1000));
			lDate.Hour = (int)Math.Floor((double)(lTimestamp / 3600000));
			int lMin = (int)(lTimestamp % 3600000);
			lDate.Minute = (int)Math.Floor((double)(lMin / 60000));
			lDate.Second = (int)Math.Floor((double)(lMin % 60000 / 1000));

            lDate.Days = (int)(days + 1);

			if (lDate.Year < Utils.UTC_TO_GTC_YEAR)
			{
				lDate.Days = lDate.Days + 371;
				if (lDate.Hour < 0)
				{
					lDate.Hour = lDate.Hour + 26;
				}
				if (lDate.Minute < 0)
				{
					lDate.Minute = lDate.Minute + 60;
				}
				if (lDate.Second < 0)
				{
					lDate.Second = lDate.Second + 60;
				}
				if (lDate.Timestamp < 0)
				{
					lDate.Timestamp = lDate.Timestamp + 93600;
				}
			}

			return lDate;
		}

		public string getUTCTimeString()
		{
			string str = m_Date.ToString("r");
			return str;
		}
	}
}
