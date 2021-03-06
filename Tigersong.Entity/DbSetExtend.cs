//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a Tigersong Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
//     Author:Haibin Jiang
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Data.Entity;
using System.Linq.Expressions;

using Tigersong.Model;

namespace Tigersong.Entity
{
	public static class DbSetExtend
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="dbSet"></param>
		/// <param name="where"></param>
		/// <returns></returns>
		public static bool Exist<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where)
		where TEntity : BaseModel
		{
			return dbSet.Count(where) > 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="dbSet"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> FindAll<TEntity>(this DbSet<TEntity> dbSet)
		where TEntity : BaseModel
		{
			return
				from item in dbSet
				where true
				select item;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <typeparam name="TKey"></typeparam>
		/// <param name="dbSet"></param>
		/// <param name="pageNumber"></param>
		/// <param name="pageSize"></param>
		/// <param name="total"></param>
		/// <param name="orderBy"></param>
		/// <param name="isAsc"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> FindAll<TEntity, TKey>(this DbSet<TEntity> dbSet, int pageNumber, int pageSize, out int total, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true)
		where TEntity : BaseModel
		{
			total = dbSet.Count();
			IQueryable<TEntity> tEntities =
				from item in dbSet
				where true
				select item;
			tEntities = (!isAsc ? tEntities.OrderByDescending<TEntity, TKey>(orderBy) : tEntities.OrderBy<TEntity, TKey>(orderBy));
			tEntities = tEntities.Skip((pageNumber - 1) * pageSize).Take(pageSize);
			return tEntities;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="dbSet"></param>
		/// <param name="where"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> FindBy<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where)
		where TEntity : BaseModel
		{
			return dbSet.Where(where);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entities"></param>
		/// <param name="where"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> FindBy<TEntity>(this IQueryable<TEntity> entities, Expression<Func<TEntity, bool>> where)
		where TEntity : BaseModel
		{
			return entities.Where(where);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="dbSet"></param>
		/// <param name="where"></param>
		/// <param name="pageNumber"></param>
		/// <param name="pageSize"></param>
		/// <param name="total"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> FindBy<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize, out int total)
		where TEntity : BaseModel
		{
			total = dbSet.Count(where);
			return dbSet.Where(where).OrderBy<TEntity, object>((TEntity item) => item.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entities"></param>
		/// <param name="where"></param>
		/// <param name="pageNumber"></param>
		/// <param name="pageSize"></param>
		/// <param name="total"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> FindBy<TEntity>(this IQueryable<TEntity> entities, Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize, out int total)
		where TEntity : BaseModel
		{
			total = entities.Count(where);
			return entities.Where(where).OrderBy<TEntity, object>((TEntity item) => item.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <typeparam name="TKey"></typeparam>
		/// <param name="dbSet"></param>
		/// <param name="where"></param>
		/// <param name="pageNumber"></param>
		/// <param name="pageSize"></param>
		/// <param name="total"></param>
		/// <param name="orderBy"></param>
		/// <param name="isAsc"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> FindBy<TEntity, TKey>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize, out int total, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true)
		where TEntity : BaseModel
		{
			IQueryable<TEntity> tEntities;
			total = dbSet.Count(where);
			tEntities = (!isAsc ? dbSet.Where(where).OrderByDescending<TEntity, TKey>(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize) : dbSet.Where(where).OrderBy<TEntity, TKey>(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize));
			return tEntities;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <typeparam name="TKey"></typeparam>
		/// <param name="entities"></param>
		/// <param name="where"></param>
		/// <param name="pageNumber"></param>
		/// <param name="pageSize"></param>
		/// <param name="total"></param>
		/// <param name="orderBy"></param>
		/// <param name="isAsc"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> FindBy<TEntity, TKey>(this IQueryable<TEntity> entities, Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize, out int total, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true)
		{
			IQueryable<TEntity> tEntities;
			total = entities.Count(where);
			tEntities = (!isAsc ? entities.Where(where).OrderByDescending<TEntity, TKey>(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize) : entities.Where(where).OrderBy<TEntity, TKey>(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize));
			return tEntities;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="dbSet"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public static TEntity FindById<TEntity>(this DbSet<TEntity> dbSet, object id)
		where TEntity : BaseModel
		{
			return dbSet.FirstOrDefault((TEntity p) => p.Id == id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entities"></param>
		/// <param name="total"></param>
		/// <param name="orderBy"></param>
		/// <param name="pageNumber"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> GetPage<TEntity>(this IQueryable<TEntity> entities, out int total, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageNumber = 1, int pageSize = 20)
		{
			if (orderBy == null)
			{
				throw new ArgumentNullException("排序条件不能为空");
			}
			total = entities.Count();
			entities = orderBy(entities);
			IQueryable<TEntity> tEntities = entities.Skip((pageNumber - 1) * pageSize).Take(pageSize);
			return tEntities;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entities"></param>
		/// <param name="total"></param>
		/// <param name="pageNumber"></param>
		/// <param name="pageSize"></param>
		/// <param name="orderBy"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> GetPage<TEntity>(this IQueryable<TEntity> entities, out int total, int pageNumber = 1, int pageSize = 20, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
		where TEntity : BaseModel
		{
			if (orderBy == null)
			{
				orderBy = (IQueryable<TEntity> d) =>
					from o in d
					orderby o.Id descending
					select o;
			}
			total = entities.Count();
			entities = orderBy(entities);
			IQueryable<TEntity> tEntities = entities.Skip((pageNumber - 1) * pageSize).Take(pageSize);
			return tEntities;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="dbSet"></param>
		/// <param name="ids"></param>
		public static void Remove<TEntity>(this DbSet<TEntity> dbSet, params object[] ids)
		where TEntity : BaseModel
		{
			List<TEntity> tEntities = new List<TEntity>();
			object[] objArray = ids;
			for (int i = 0; i < objArray.Length; i++)
			{
				tEntities.Add(dbSet.FindById<TEntity>(objArray[i]));
			}
			dbSet.RemoveRange(tEntities);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="dbSet"></param>
		/// <param name="where"></param>
		public static void Remove<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where)
		where TEntity : BaseModel
		{
			dbSet.RemoveRange(dbSet.FindBy(where));
		}

		/// <summary>
		/// 动态排序扩展
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="propertyName"></param>
		/// <param name="ascending"></param>
		/// <returns></returns>
		public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending) where T : class
		{
			Type type = typeof(T);

			PropertyInfo property = type.GetProperty(propertyName);
			if (property == null)
				throw new ArgumentException("propertyName", "Not Exist");

			ParameterExpression param = Expression.Parameter(type, "p");
			Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
			LambdaExpression orderByExpression = Expression.Lambda(propertyAccessExpression, param);

			string methodName = ascending ? "OrderBy" : "OrderByDescending";

			MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));

			return source.Provider.CreateQuery<T>(resultExp);
		}

		/// <summary>
		/// 动态排序扩展
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="propertyName"></param>
		/// <param name="ascending"></param>
		/// <returns></returns>
		public static IQueryable<T> ThenOrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending) where T : class
		{
			Type type = typeof(T);

			PropertyInfo property = type.GetProperty(propertyName);
			if (property == null)
				throw new ArgumentException("propertyName", "Not Exist");

			ParameterExpression param = Expression.Parameter(type, "p");
			Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
			LambdaExpression orderByExpression = Expression.Lambda(propertyAccessExpression, param);

			string methodName = ascending ? "ThenBy" : "ThenByDescending";

			MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));

			return source.Provider.CreateQuery<T>(resultExp);
		}
	}
}
