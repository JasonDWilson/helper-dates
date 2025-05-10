using System;

namespace jwpro.DateHelper.Exceptions
{
	public class NotSupportedSpecialDateException : Exception
	{
		public NotSupportedSpecialDateException()
		{
		}

		public NotSupportedSpecialDateException(string message) : base(message)
		{
		}

		public NotSupportedSpecialDateException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
