using System;
using DotNetNuke.Services.Authentication;
using DotNetNuke.Services.Exceptions;

namespace DotNetNuke.Authentication.Cas
{
    public partial class Settings : AuthenticationSettingsBase
    {
        /// <summary>
        /// The OnLoad method runs when the Control is loaded
        /// </summary>
        /// <param name="e">An EventArgs object</param>
        protected override void OnLoad(EventArgs e)
        {
            //Call the base classes method
            base.OnLoad(e);

            try
            {
                var config = AuthenticationConfig.GetConfig(this.PortalId);
                SettingsEditor.DataSource = config;
                SettingsEditor.DataBind();
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
        
        public override void UpdateSettings()
        {
            if (SettingsEditor.IsValid && SettingsEditor.IsDirty)
                AuthenticationConfig.UpdateConfig(SettingsEditor.DataSource as AuthenticationConfig);
        }
    }
}