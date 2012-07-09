using System;
using System.Collections.Specialized;
using DotNetNuke.Authentication.Cas.Components;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Services.Authentication;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Log.EventLog;

namespace DotNetNuke.Authentication.Cas
{
    public partial class Login : AuthenticationLoginBase
    {
        public EventLogController EventLogController { get; set; }

        public Login()
        {
            EventLogController = new EventLogController();
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!string.IsNullOrWhiteSpace(Request.QueryString["ticket"]))
            {
                EventLogController.AddLog("Ticket", "Cas returned with ticket", PortalSettings, -1, EventLogController.EventLogType.ADMIN_ALERT);

                CasLogin();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            cmdLogin.Click += CasLogin;
        }

        private void OnAuthComplete(string username, bool success)
        {
            EventLogController.AddLog("Auth Success", "Auth completed for " + username, PortalSettings, -1, EventLogController.EventLogType.ADMIN_ALERT);

            UserLoginStatus loginStatus = UserLoginStatus.LOGIN_FAILURE;

            UserInfo objUser = UserController.ValidateUser(PortalId, username, "", "Cas", "", PortalSettings.PortalName, IPAddress, ref loginStatus);
            UserController.UserLogin(PortalId, objUser, PortalSettings.PortalName, IPAddress, true);

            EventLogController.AddLog("Validation",
                                      "Validation for user " + username + ". Login status: " + loginStatus.ToString(),
                                      PortalSettings, -1, EventLogController.EventLogType.ADMIN_ALERT);

            //Raise UserAuthenticated Event
            var eventArgs = new UserAuthenticatedEventArgs(objUser, username, loginStatus, "Cas") {AutoRegister = false};

            OnUserAuthenticated(eventArgs);
        }

        private void CasLogin(object sender = null, EventArgs e = null)
        {
            CASHelper.LoginAndRedirect(OnAuthComplete);
        }
    }
}