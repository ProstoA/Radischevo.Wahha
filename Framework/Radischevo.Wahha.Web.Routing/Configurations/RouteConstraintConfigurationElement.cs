﻿using System;
using System.Configuration;

using Radischevo.Wahha.Core;

namespace Radischevo.Wahha.Web.Routing.Configurations
{
    public sealed class RouteConstraintConfigurationElement : ConfigurationElement
    {
        #region Instance Fields
        private ValueDictionary _attributes;
        #endregion

        #region Constructors
        public RouteConstraintConfigurationElement()
            : base()
        {
            _attributes = new ValueDictionary();
        }
        #endregion

        #region Instance Properties
        [ConfigurationProperty("type", IsRequired = true,
            DefaultValue = "")]
        public string Type
        {
            get
            {
                return base["type"].ToString();
            }
        }

        public IValueSet Attributes
        {
            get
            {
                return _attributes;
            }
        }
        #endregion

        #region Instance Methods
        protected sealed override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            _attributes[name] = value;
            return true;
        }
        #endregion
    }
}
