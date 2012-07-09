<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="DotNetNuke.Authentication.Cas.Login, DotNetNuke.Authentication.Cas" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<table cellspacing="0" cellpadding="3" border="0" summary="SignIn Design Table" width="160">
    <tr id="trHelp" runat="server">
        <td><asp:Label ID="lblHelp" runat="Server" cssClass="normal" resourcekey="Help" /></td>
    </tr>
    <tr>
	    <td><asp:button id="cmdLogin" resourcekey="cmdLogin" cssclass="StandardButton" text="Login with CAS" runat="server" /></td>
    </tr>
</table>