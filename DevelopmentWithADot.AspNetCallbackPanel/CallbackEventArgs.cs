using System;

namespace DevelopmentWithADot.AspNetCallbackPanel
{
	[Serializable]
	public class CallbackEventArgs : EventArgs
	{
		public CallbackEventArgs(String parameter)
		{
			this.Parameter = parameter;
		}

		public String Parameter { get; private set; }
	}
}
