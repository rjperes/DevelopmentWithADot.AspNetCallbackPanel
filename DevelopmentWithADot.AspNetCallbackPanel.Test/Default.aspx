﻿<%@ Page Language="C#" CodeBehind="Default.aspx.cs" Inherits="DevelopmentWithADot.AspNetCallbackPanel.Test.Default" %>
<%@ Register Assembly="DevelopmentWithADot.AspNetCallbackPanel" Namespace="DevelopmentWithADot.AspNetCallbackPanel" tagPrefix="web" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script>
		
		function onCallback()
		{
			debugger;
			document.getElementById('callback').callback('test', null);
		}

		function onCallbackError(error, context)
		{
			debugger;
		}

		function onBeforeCallback(arg, context)
		{
			debugger;
		}

		function onAfterCallback(result, context)
		{
			debugger;
		}

	</script>
</head>
<body>
	<form runat="server">
	<div>
		<asp:ScriptManager runat="server"></asp:ScriptManager>
		<web:CallbackPanel runat="server" ID="callback" SendAllData="false" OnBeforeCallback="onBeforeCallback" OnAfterCallback="onAfterCallback" OnCallbackError="onCallbackError" OnCallback="OnCallback">
			<asp:Label runat="server" ID="time"></asp:Label>
			<asp:TextBox runat="server" ID="text"></asp:TextBox>
			<asp:Button runat="server" ID="button" Text="Button"/>
		</web:CallbackPanel>
		<input type="button" value="Test" onclick="onCallback()"/>
	</div>	
	</form>
</body>
</html>
