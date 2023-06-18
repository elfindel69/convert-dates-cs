namespace ConsoleApp1
{
	public class MyDiv
	{
		private int m_quot = 0;
		public int Quot { get {return m_quot; } }
		private int m_rest = 0;
		public int Rest { get { return m_rest;  } }
		public MyDiv div(int x, int y)
		{
			this.m_rest = x % y;
			this.m_quot = (x - this.m_rest) / y;
			return this;

		}
	}
}
