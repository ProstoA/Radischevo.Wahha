﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Permissions;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;
using System.Web.SessionState;

using Radischevo.Wahha.Core;

namespace Radischevo.Wahha.Web.Abstractions
{
    /// <summary>
    /// Encapsulates the HTTP intrinsic object that contains 
    /// HTTP-specific information about an individual HTTP request.
    /// </summary>
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), 
     AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class HttpContextWrapper : HttpContextBase
    {
        #region Instance Fields
        private readonly HttpContext _context;
        #endregion

        #region Constructors
        public HttpContextWrapper(HttpContext context)
        {
            Precondition.Require(context, Radischevo.Wahha.Web
                .Error.ArgumentNull("context"));
            _context = context;
        }
        #endregion

        #region Instance Properties
        public override IEnumerable<Exception> AllErrors
        {
            get
            {
                return _context.AllErrors;
            }
        }

        public override HttpApplicationStateBase Application
        {
            get
            {
                return new HttpApplicationStateWrapper(_context.Application);
            }
        }

        public override HttpApplication ApplicationInstance
        {
            get
            {
                return _context.ApplicationInstance;
            }
            set
            {
                _context.ApplicationInstance = value;
            }
        }

        public override Cache Cache
        {
            get
            {
                return _context.Cache;
            }
        }

        public override IHttpHandler CurrentHandler
        {
            get
            {
                return _context.CurrentHandler;
            }
        }

        public override RequestNotification CurrentNotification
        {
            get
            {
                return _context.CurrentNotification;
            }
        }

        public override Exception Error
        {
            get
            {
                return _context.Error;
            }
        }

        public override IHttpHandler Handler
        {
            get
            {
                return _context.Handler;
            }
            set
            {
                _context.Handler = value;
            }
        }

        public override bool IsCustomErrorEnabled
        {
            get
            {
                return _context.IsCustomErrorEnabled;
            }
        }

        public override bool IsDebuggingEnabled
        {
            get
            {
                return _context.IsDebuggingEnabled;
            }
        }

        public override bool IsPostNotification
        {
            get
            {
                return _context.IsDebuggingEnabled;
            }
        }

        public override IDictionary Items
        {
            get
            {
                return _context.Items;
            }
        }

        public override IHttpHandler PreviousHandler
        {
            get
            {
                return _context.PreviousHandler;
            }
        }

        public override ProfileBase Profile
        {
            get
            {
                return _context.Profile;
            }
        }

        public override HttpRequestBase Request
        {
            get
            {
                return new HttpRequestWrapper(_context.Request);
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return new HttpResponseWrapper(_context.Response);
            }
        }

        public override HttpServerUtilityBase Server
        {
            get
            {
                return new HttpServerUtilityWrapper(_context.Server);
            }
        }

        public override HttpSessionStateBase Session
        {
            get
            {
                HttpSessionState session = _context.Session;
                if (session == null)
                    return null;
                
                return new HttpSessionStateWrapper(session);
            }
        }

        public override bool SkipAuthorization
        {
            get
            {
                return _context.SkipAuthorization;
            }
            set
            {
                _context.SkipAuthorization = value;
            }
        }

        public override DateTime Timestamp
        {
            get
            {
                return _context.Timestamp;
            }
        }

        public override TraceContext Trace
        {
            get
            {
                return _context.Trace;
            }
        }

        public override IPrincipal User
        {
            get
            {
                return _context.User;
            }
            set
            {
                _context.User = value;
            }
        }
        #endregion

        #region Instance Methods
        public override void AddError(Exception errorInfo)
        {
            _context.AddError(errorInfo);
        }

        public override void ClearError()
        {
            _context.ClearError();
        }

        public override object GetGlobalResourceObject(string classKey, string resourceKey)
        {
            return HttpContext.GetGlobalResourceObject(classKey, resourceKey);
        }

        public override object GetGlobalResourceObject(string classKey, 
            string resourceKey, CultureInfo culture)
        {
            return HttpContext.GetGlobalResourceObject(classKey, resourceKey, culture);
        }

        public override object GetLocalResourceObject(string virtualPath, string resourceKey)
        {
            return HttpContext.GetLocalResourceObject(virtualPath, resourceKey);
        }

        public override object GetLocalResourceObject(string virtualPath, 
            string resourceKey, CultureInfo culture)
        {
            return HttpContext.GetLocalResourceObject(virtualPath, resourceKey, culture);
        }

        public override object GetSection(string sectionName)
        {
            return _context.GetSection(sectionName);
        }

        public override object GetService(Type serviceType)
        {
            return ((IServiceProvider)_context).GetService(serviceType);
        }

        public override void RewritePath(string path)
        {
            _context.RewritePath(path);
        }

        public override void RewritePath(string path, bool rebaseClientPath)
        {
            _context.RewritePath(path, rebaseClientPath);
        }

        public override void RewritePath(string filePath, string pathInfo, string queryString)
        {
            _context.RewritePath(filePath, pathInfo, queryString);
        }

        public override void RewritePath(string filePath, string pathInfo, 
            string queryString, bool setClientFilePath)
        {
            _context.RewritePath(filePath, pathInfo, queryString, 
                setClientFilePath);
        }

        public override HttpContext Unwrap()
        {
            return _context;
        }
        #endregion
    }
}
