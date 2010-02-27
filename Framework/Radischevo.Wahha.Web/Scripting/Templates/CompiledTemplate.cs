﻿using System;
using System.Collections.Generic;
using System.Web;

using Radischevo.Wahha.Core;

namespace Radischevo.Wahha.Web.Scripting.Templates
{
	public abstract class CompiledTemplate
	{
		#region Instance Fields
		private string _source;
		private string _name;
		private List<TemplateParameter> _parameters;
		#endregion

		#region Constructors
		protected CompiledTemplate()
		{
			_parameters = new List<TemplateParameter>();
		}
		#endregion

		#region Instance Properties
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public string Source
		{
			get
			{
				return _source;
			}
			set
			{
				_source = value;
			}
		}

		public ICollection<TemplateParameter> Parameters
		{
			get
			{
				return _parameters;
			}
		}
		#endregion

		#region Instance Methods
		public void Execute(HttpContext context, object[] parameters)
		{
			Precondition.Require(context, () => Error.ArgumentNull("context"));
			ExecuteInternal(context, parameters);
		}

		protected abstract void ExecuteInternal(HttpContext context, object[] parameters);
		#endregion
	}
}
