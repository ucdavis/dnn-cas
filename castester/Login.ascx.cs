using System;
using System.Collections.Specialized;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Services.Authentication;
using DotNetNuke.Services.Localization;

namespace DotNetNuke.Authentication.Cas
{
    public partial class Login : AuthenticationLoginBase
    {
        protected string LastUsedId
        {
            get { return "http://test/srkirkland"; }
        }

        
        ///// <summary>
        ///// Gets the Return Uri
        ///// </summary>
        //protected Uri ReturnUri
        //{
        //    get
        //    {
        //        if (returnUri == null)
        //        {
        //            UriBuilder builder = new UriBuilder(Request.Url.AbsoluteUri);
        //            builder.Path = Request.ApplicationPath;
        //            builder.Query = "tabId=" + PortalSettings.ActiveTab.TabID.ToString();
        //            builder.Query += "&ctl=Login";
        //            if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
        //            {
        //                builder.Query += "&ReturnUrl=" + Request.QueryString["ReturnUrl"];
        //            }
        //            returnUri = new Uri(builder.ToString());
        //        }
        //        return returnUri;
        //    }
        //}

        /// <summary>
        /// Enabled is a flag that determines whether OpenID is enabled for this portal
        /// </summary>
        public override bool Enabled
        {
            get 
            {
                // Return whether the user has enabled OpenID
                return AuthenticationConfig.GetConfig(PortalId).Enabled;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            cmdLogin.Click += new EventHandler(CasLogin);
        }

        void CasLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}