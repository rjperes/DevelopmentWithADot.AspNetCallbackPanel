using System;

namespace DevelopmentWithADot.AspNetCallbackPanel
{
	[Serializable]
	public sealed class CallbackEventArgs : EventArgs
	{
		public CallbackEventArgs(String parameter)
		{
			this.Parameter = parameter;
		}

		public String Parameter { get; private set; }
	}
}
