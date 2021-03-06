﻿using System;

namespace Radischevo.Wahha.Data.Provider
{
	public class SqlDbDataProviderFactory : CommonDbDataProviderFactory
	{
		#region Instance Methods
		protected override IDbDataProvider CreateProvider(string connectionString)
		{
			return new SqlDbDataProvider(connectionString);
		}
		#endregion
	}
}