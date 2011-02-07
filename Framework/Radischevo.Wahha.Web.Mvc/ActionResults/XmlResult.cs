﻿using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Radischevo.Wahha.Core;
using Radischevo.Wahha.Web.Abstractions;

namespace Radischevo.Wahha.Web.Mvc
{
    public class XmlResult : ActionResult
    {
        #region Constants
        private const string _defaultContentType = "text/xml";
        #endregion

        #region Instance Fields
        private Encoding _contentEncoding;
        private string _contentType;
        private object _data;
        private Type[] _includedTypes;
        #endregion

        #region Constructors
        public XmlResult() 
            : this(null)
        {
        }

        public XmlResult(object data)
            : this(data, null)
        {
        }

        public XmlResult(object data, params Type[] includedTypes)
        {
            _data = data;
            _includedTypes = includedTypes ?? new Type[] { typeof(object) };
        }
        #endregion

        #region Instance Properties
        public object Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public Encoding ContentEncoding
        {
            get
            {
                return _contentEncoding;
            }
            set
            {
                _contentEncoding = value;
            }
        }

        public string ContentType
        {
            get
            {
                return _contentType;
            }
            set
            {
                _contentType = value;
            }
        }
        #endregion

        #region Instance Methods
        public override void Execute(ControllerContext context)
        {
            Precondition.Require(context, () => Error.ArgumentNull("context"));
            HttpResponseBase response = context.Context.Response;

            if (!String.IsNullOrEmpty(_contentType))
                response.ContentType = _contentType;
            else
                response.ContentType = _defaultContentType;

            if (_contentEncoding != null)
                response.ContentEncoding = _contentEncoding;

            if (_data != null)
            {
                using (MemoryStream ms = new MemoryStream(500))
                {
                    using (XmlWriter writer = XmlTextWriter.Create(ms,
                        new XmlWriterSettings() {
                            OmitXmlDeclaration = true, Indent = true,
                            Encoding = response.ContentEncoding }))
                    {
                        XmlSerializer xs = new XmlSerializer(_data.GetType(), _includedTypes);
                        xs.Serialize(writer, _data);
                    }
                    ms.WriteTo(response.OutputStream);
                }
            }
        }
        #endregion
    }
}
