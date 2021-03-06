﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Radischevo.Wahha.Core;

namespace Radischevo.Wahha.Data
{
	public interface ISingleAssociationBuilder<TAssociation>
		: IHideObjectMembers
	{
		ISingleAssociationBuilder<TAssociation> Subset(IDbValueSetTransformer transformer);

		ISingleAssociationBuilder<TAssociation> Validate(IDbValueSetValidator validator);

		Link<TAssociation> Apply();

		Link<TAssociation> Apply(IDbValueSet source);

		Link<TAssociation> Apply<TMaterializer>(IDbValueSet source)
			where TMaterializer : IDbMaterializer<TAssociation>;
	}

	public interface ISingleAssociationSelectorBuilder<TAssociation>
		: ISingleAssociationBuilder<TAssociation>
	{
		ISingleAssociationBuilder<TAssociation> With<TRepository>(
			Expression<Func<TRepository, TAssociation>> selector)
			where TRepository : IRepository<TAssociation>;

		ISingleAssociationBuilder<TAssociation> With<TOperationFactory>(
			Expression<Func<TOperationFactory, IDbOperation<TAssociation>>> operation);

		ISingleAssociationBuilder<TAssociation> With<TOperation>(
			Expression<Func<TOperation>> operation)
			where TOperation : IDbOperation<TAssociation>;
	}

	public interface ICollectionAssociationSelectorBuilder<TAssociation>
		: IHideObjectMembers
	{
		ICollectionAssociationBuilder<TAssociation> With<TRepository>(
			Expression<Func<TRepository, IEnumerable<TAssociation>>> selector)
			where TRepository : IRepository<TAssociation>;

		ICollectionAssociationBuilder<TAssociation> With<TOperationFactory>(
			Expression<Func<TOperationFactory, IDbOperation<IEnumerable<TAssociation>>>> operation);

		ICollectionAssociationBuilder<TAssociation> With<TOperation>(
			Expression<Func<TOperation>> operation)
			where TOperation : IDbOperation<IEnumerable<TAssociation>>;
	}

	public interface ICollectionAssociationBuilder<TAssociation>
		: IHideObjectMembers
	{
		EnumerableLink<TAssociation> Apply();
	}

	public interface IEntityAssociationBuilder<TAssociation>
		: IHideObjectMembers
	{
		IEntityAssociationBuilder<TAssociation> Subset(IDbValueSetTransformer transformer);

		IEntityAssociationBuilder<TAssociation> Validate(IDbValueSetValidator validator);

		TAssociation Apply(IDbValueSet source);

		TAssociation Apply<TMaterializer>(IDbValueSet source)
			where TMaterializer : IDbMaterializer<TAssociation>;
	}

	internal sealed class SingleAssociationBuilder<TAssociation> :
		ISingleAssociationBuilder<TAssociation>,
		ISingleAssociationSelectorBuilder<TAssociation>
	{
		#region Instance Fields
		private Link<TAssociation> _association;
		private SingleLinkAssociator<TAssociation> _associator;
		private List<IDbValueSetTransformer> _transformers;
		private List<IDbValueSetValidator> _validators;
		#endregion

		#region Constructors
		internal SingleAssociationBuilder(Link<TAssociation> association)
		{
			_association = association;
			_associator = new SingleLinkAssociator<TAssociation>();
			_transformers = new List<IDbValueSetTransformer>();
			_validators = new List<IDbValueSetValidator>();
		}
		#endregion

		#region Instance Methods
		public ISingleAssociationBuilder<TAssociation> Subset(IDbValueSetTransformer transformer)
		{
			_transformers.Add(transformer);
			return this;
		}

		public ISingleAssociationBuilder<TAssociation> Validate(IDbValueSetValidator validator)
		{
			_validators.Add(validator);
			return this;
		}

		public ISingleAssociationBuilder<TAssociation> With<TRepository>(
			Expression<Func<TRepository, TAssociation>> selector)
			where TRepository : IRepository<TAssociation>
		{
			LinkAssociatorAction<TAssociation> action = 
				new RepositoryBasedSingleSelectorAction<TAssociation, TRepository>(selector);
			action.Order = 1;
			_associator.Actions.Add(action);

			return this;
		}

		public ISingleAssociationBuilder<TAssociation> With<TFactory>(
			Expression<Func<TFactory, IDbOperation<TAssociation>>> operation)
		{
			LinkAssociatorAction<TAssociation> action = 
				new OperationFactoryBasedSingleSelectorAction<TAssociation, TFactory>(operation);
			action.Order = 1;
			_associator.Actions.Add(action);

			return this;
		}

		public ISingleAssociationBuilder<TAssociation> With<TOperation>(
			Expression<Func<TOperation>> operation)
			where TOperation : IDbOperation<TAssociation>
		{
			LinkAssociatorAction<TAssociation> action =
				new OperationBasedSingleSelectorAction<TAssociation, TOperation>(operation);
			action.Order = 1;
			_associator.Actions.Add(action);

			return this;
		}

		private Link<TAssociation> Apply(LinkMaterializerAction<TAssociation> action)
		{
			foreach(IDbValueSetTransformer transformer in _transformers)
				action.Transformers.Add(transformer);

			foreach (IDbValueSetValidator validator in _validators)
				action.Validators.Add(validator);
			
			action.Order = 2;

			_associator.Actions.Add(action);
			return Apply();
		}

		public Link<TAssociation> Apply()
		{
			return (Link<TAssociation>)_associator.Execute(_association);
		}

		public Link<TAssociation> Apply(IDbValueSet source)
		{
			LinkMaterializerAction<TAssociation> action = 
				new LinkMaterializerAction<TAssociation>(source);

			return Apply(action);
		}

		public Link<TAssociation> Apply<TMaterializer>(IDbValueSet source) 
			where TMaterializer : IDbMaterializer<TAssociation>
		{
			LinkMaterializerAction<TAssociation> action =
				new LinkMaterializerAction<TAssociation, TMaterializer>(source);
			
			return Apply(action);
		}
		#endregion
	}
	
	internal sealed class CollectionAssociationBuilder<TAssociation> :
		ICollectionAssociationSelectorBuilder<TAssociation>,
		ICollectionAssociationBuilder<TAssociation>
	{
		#region Instance Fields
		private EnumerableLink<TAssociation> _association;
		private CollectionLinkAssociator<TAssociation> _associator;
		#endregion

		#region Constructors
		internal CollectionAssociationBuilder(
			EnumerableLink<TAssociation> association)
		{
			_association = association;
			_associator = new CollectionLinkAssociator<TAssociation>();
		}
		#endregion

		#region Instance Methods
		public ICollectionAssociationBuilder<TAssociation> With<TRepository>(
			Expression<Func<TRepository, IEnumerable<TAssociation>>> selector) 
			where TRepository : IRepository<TAssociation>
		{
			LinkAssociatorAction<IEnumerable<TAssociation>> action =
				new RepositoryBasedCollectionSelectorAction<TAssociation, TRepository>(selector);
			action.Order = 1;
			_associator.Actions.Add(action);

			return this;
		}

		public ICollectionAssociationBuilder<TAssociation> With<TFactory>(
			Expression<Func<TFactory, IDbOperation<IEnumerable<TAssociation>>>> operation)
		{
			LinkAssociatorAction<IEnumerable<TAssociation>> action =
				new OperationFactoryBasedCollectionSelectorAction<TAssociation, TFactory>(operation);
			action.Order = 1;
			_associator.Actions.Add(action);

			return this;
		}

		public ICollectionAssociationBuilder<TAssociation> With<TOperation>(
			Expression<Func<TOperation>> operation)
			where TOperation : IDbOperation<IEnumerable<TAssociation>>
		{
			LinkAssociatorAction<IEnumerable<TAssociation>> action =
				new OperationBasedCollectionSelectorAction<TAssociation, TOperation>(operation);
			action.Order = 1;
			_associator.Actions.Add(action);

			return this;
		}

		public EnumerableLink<TAssociation> Apply()
		{
			return (EnumerableLink<TAssociation>)_associator.Execute(_association);
		}
		#endregion
	}

	internal sealed class EntityAssociationBuilder<TAssociation> :
		IEntityAssociationBuilder<TAssociation>
	{
		#region Instance Fields
		private TAssociation _association;
		private EntityAssociator<TAssociation> _associator;
		private List<IDbValueSetTransformer> _transformers;
		private List<IDbValueSetValidator> _validators;
		#endregion

		#region Constructors
		internal EntityAssociationBuilder(TAssociation association)
		{
			_association = association;
			_associator = new EntityAssociator<TAssociation>();
			_transformers = new List<IDbValueSetTransformer>();
			_validators = new List<IDbValueSetValidator>();
		}
		#endregion

		#region Instance Methods
		public IEntityAssociationBuilder<TAssociation> Subset(IDbValueSetTransformer transformer)
		{
			_transformers.Add(transformer);
			return this;
		}

		public IEntityAssociationBuilder<TAssociation> Validate(IDbValueSetValidator validator)
		{
			_validators.Add(validator);
			return this;
		}

		private TAssociation Apply(EntityMaterializerAction<TAssociation> action)
		{
			foreach (IDbValueSetTransformer transformer in _transformers)
				action.Transformers.Add(transformer);

			foreach (IDbValueSetValidator validator in _validators)
				action.Validators.Add(validator);

			action.Order = 1;
			_associator.Actions.Add(action);

			return _associator.Execute(_association);
		}

		public TAssociation Apply(IDbValueSet source)
		{
			EntityMaterializerAction<TAssociation> action =
				new EntityMaterializerAction<TAssociation>(source);

			return Apply(action);
		}

		public TAssociation Apply<TMaterializer>(IDbValueSet source)
			where TMaterializer : IDbMaterializer<TAssociation>
		{
			EntityMaterializerAction<TAssociation> action =
				new EntityMaterializerAction<TAssociation, TMaterializer>(source);

			return Apply(action);
		}
		#endregion
	}
}