using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace X_dos.Services
{
	public class BaseRepository
	{
		protected string _connectionName;
		private readonly IConfiguration _configuration;


		public BaseRepository(IConfiguration configuration)
		{
			_configuration = configuration;

		}

		public IDbConnection NewConnection() => new SqlConnection(_connectionName);


		public TResult WithConnection<TResult>(Func<IDbConnection, TResult> func)
		{
			using (var connection = NewConnection())
			{
				connection.Open();
				return func(connection);
			}
		}

		public async Task<TResult> WithConnection<TResult>(Func<IDbConnection, Task<TResult>> funcAsync)
		{
			using (var connection = NewConnection())
			{
				connection.Open();
				return await funcAsync(connection);
			}
		}

		//public async Task WithConnection<TResult>(Action<IDbConnection> funcAsync)
		//{
		//	using (var connection = NewConnection())
		//	{
		//		connection.Open();
		//		funcAsync(connection);
		//	}
		//}

		public async Task WithConnection<TResult>(Func<IDbConnection, Task >funcAsync)
		{
			using (var connection = NewConnection())
			{
				connection.Open();
				await funcAsync(connection);
			}
		}
	}
}
