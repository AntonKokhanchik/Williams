using System;
using System.Runtime.Serialization;

namespace Williams
{
	[Serializable]
	internal class MyException : Exception
	{
		string m;
		Exception ie;
		public MyException()
		{
		}

		public MyException(string message) : base(message)
		{
			m = message;
		}

		public MyException(string message, Exception innerException) : base(message, innerException)
		{
			m = message;
			ie = innerException;
		}
	}
}