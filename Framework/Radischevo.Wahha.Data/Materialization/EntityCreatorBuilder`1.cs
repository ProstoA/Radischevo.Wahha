﻿using System;
using System.Linq.Expressions;
using System.Reflection;

using Radischevo.Wahha.Core;
using Radischevo.Wahha.Core.Expressions;

namespace Radischevo.Wahha.Data
{
	public class EntityCreatorBuilder<TEntity>
		where TEntity : class
	{
		#region Constructors
		public EntityCreatorBuilder()
			: base()
		{
		}
		#endregion

		#region Instance Methods
		public Func<IValueSet, TEntity> Build(Type type)
		{
			BindingFlags instanceFlags = BindingFlags.Instance | BindingFlags.Public;
			MethodInfo resolveMethod = typeof(IServiceProvider).GetMethod("GetService",
				instanceFlags, null, new Type[] { typeof(Type) }, null);
			MethodInfo materializeMethod = type.GetMethod("Materialize", 
				instanceFlags, null, new Type[] { typeof(IValueSet) }, null);

			Precondition.Require(materializeMethod, () => Error.IncompatibleMaterializerType(type));

			ParameterExpression values = Expression.Parameter(typeof(IValueSet), "values");
			ConstantExpression service = Expression.Constant(ServiceLocator.Instance, typeof(IServiceLocator));
			ConstantExpression serviceType = Expression.Constant(type, typeof(Type));

			MethodCallExpression resolver = Expression.Call(service, resolveMethod, serviceType);
			UnaryExpression conversion = Expression.Convert(resolver, type);
			MethodCallExpression invocation = Expression.Call(conversion, materializeMethod, values);
			Expression<Func<IValueSet, TEntity>> func = Expression.Lambda<Func<IValueSet, TEntity>>(invocation, values);

			return CachedExpressionCompiler.Compile(func);
		}
		#endregion
	}
}