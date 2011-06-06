﻿using System;
using System.Globalization;
using System.IO;
using System.Web;

namespace Radischevo.Wahha.Web.Mvc.Html.Razor 
{
    public class HelperResult : IHtmlString {
        private readonly Action<TextWriter> _action;

        public HelperResult(Action<TextWriter> action) {
            if (action == null) {
                throw new ArgumentNullException("action");
            }
            _action = action;
        }

        public string ToHtmlString() {
            return ToString();
        }

        public override string ToString() {
            using (var writer = new StringWriter(CultureInfo.InvariantCulture)) {
                _action(writer);
                return writer.ToString();
            }
        }

        public void WriteTo(TextWriter writer) {
            _action(writer);
        }
    }
}
