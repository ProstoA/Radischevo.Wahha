using System;
using System.Reflection;

using Radischevo.Wahha.Core;

namespace Radischevo.Wahha.Data.Mapping
{
	public abstract class MetaAssociation : MetaMember
	{
		#region Instance Fields
		private readonly bool _isMany;
		#endregion
		
		#region Constructors
		protected MetaAssociation (MetaType declaringType, MemberInfo member)
			: base(declaringType, member)
		{
			_isMany = Type.IsSequence();
		}
		#endregion
		
		#region Instance Properties
		public override bool AutoGenerated 
		{
			get 
			{
				return false;
			}
		}
		
		public override bool IsKey 
		{
			get 
			{
				return false;
			}
		}

		public override bool IsAssociation 
		{
			get 
			{
				return true;
			}
		}
		
		public bool IsMany 
		{
			get
			{
				return _isMany;
			}
		}
		
		public abstract bool IsProjected
		{
			get;
		}
		
		public abstract string Prefix
		{
			get;
		}
		
		public abstract string ThisKey
		{
			get;
		}
		
		public abstract string OtherKey
		{
			get;
		}
		#endregion
		
		#region Instance Methods
		public override string GetMemberKey ()
		{
			return (IsPersistent) ? ThisKey : Member.Name;
		}
		#endregion
	}
}

