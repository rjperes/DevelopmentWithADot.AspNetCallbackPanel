using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevelopmentWithADot.AspNetCallbackPanel
{
	public class CallbackPanel : Panel, INamingContainer, ICallbackEventHandler
	{
		public CallbackPanel()
		{
			this.OnAfterCallback = String.Empty;
			this.OnCallbackError = String.Empty;
			this.SendAllData = true;
		}

		public event EventHandler<CallbackEventArgs> Callback;

		[DefaultValue("")]
		public String OnAfterCallback { get; set; }

		[DefaultValue("")]
		public String OnCallbackError { get; set; }

		[DefaultValue(true)]
		public Boolean SendAllData { get; set; }

		protected override void OnInit(EventArgs e)
		{
			var sm = ScriptManager.GetCurrent(this.Page);
			var reference = this.Page.ClientScript.GetCallbackEventReference(this, "arg", String.Format("function(result, context){{ document.getElementById('{0}').innerHTML = result; {1} }}", this.ClientID, (String.IsNullOrWhiteSpace(this.OnAfterCallback) == false) ? String.Concat(this.OnAfterCallback, "(result, context);") : String.Empty), "context", String.Format("function(error, context){{ {0} }}", (String.IsNullOrWhiteSpace(this.OnCallbackError) == false ? String.Concat(this.OnCallbackError, "(error, context)") : String.Empty)), true);
			var script = String.Concat("\ndocument.getElementById('", this.ClientID, "').callback = function(arg, context){", ((this.SendAllData == true) ? "__theFormPostCollection.length = 0; __theFormPostData = '';  WebForm_InitCallback(); " : String.Empty), reference, ";};\n");

			if (sm != null)
			{
				this.Page.ClientScript.RegisterStartupScript(this.GetType(), String.Concat("callback", this.ClientID), String.Format("Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function() {{ {0} }});\n", script), true);
			}
			else
			{
				this.Page.ClientScript.RegisterStartupScript(this.GetType(), String.Concat("callback", this.ClientID), script, true);
			}

			base.OnInit(e);
		}

		protected virtual void OnCallback(CallbackEventArgs e)
		{
			var handler = this.Callback;

			if (handler != null)
			{
				handler(this, e);
			}
		}

		#region ICallbackEventHandler Members
		String ICallbackEventHandler.GetCallbackResult()
		{
			var builder = new StringBuilder();

			using (var writer = new StringWriter(builder))
			using (var htmlWriter = new HtmlTextWriter(writer))
			{
				this.Render(new HtmlTextWriter(writer));

				return (builder.ToString());
			}
		}

		void ICallbackEventHandler.RaiseCallbackEvent(String eventArgument)
		{
			this.OnCallback(new CallbackEventArgs(eventArgument));
		}
		#endregion
	}
}
