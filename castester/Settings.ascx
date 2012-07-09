<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="DotNetNuke.Authentication.Cas.Settings, DotNetNuke.Authentication.Cas" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<dnn:propertyeditorcontrol id="SettingsEditor" runat="Server" 
                           AutoGenerate="false"
                           editcontrolwidth="200px" 
                           labelwidth="250px" 
                           width="450px" 
                           editcontrolstyle-cssclass="NormalTextBox" 
                           helpstyle-cssclass="Help" 
                           labelstyle-cssclass="SubHead" 
                           editmode="Edit"
                           SortMode="SortOrderAttribute" />