using System;
using System.Web.UI;

namespace DevelopmentWithADot.AspNetCallbackPanel.Test
{
	public partial class Default : Page
	{
		protected void OnCallback(Object sender, CallbackEventArgs e)
		{
			this.time.Text = DateTime.Now.ToString();
		}
	}
}