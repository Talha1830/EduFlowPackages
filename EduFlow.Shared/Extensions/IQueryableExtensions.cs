using EduFlow.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduFlow.Shared.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Paginates the queryable source based on the specified page number and page size.
        /// </summary>
        /// <param name="query">The queryable source.</param>
        /// <param name="page">The page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>The paginated queryable source.</returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Conditionally applies a filter to the queryable source based on the specified condition.
        /// </summary>
        /// <param name="query">The queryable source.</param>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="predicate">The filter predicate to apply if the condition is true.</param>
        /// <returns>The filtered queryable source if the condition is true; otherwise, the original queryable source.</returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }

        /// <summary>
        /// Orders the queryable source by the specified property name in ascending order.
        /// </summary>
        /// <param name="source">The queryable source.</param>
        /// <param name="propertyName">The name of the property to order by.</param>
        /// <returns>The ordered queryable source.</returns>
        /// <exception cref="ArgumentException">Thrown if the property does not exist on the type.</exception>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            var entityType = typeof(T);
            var property = entityType.GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' does not exist on type '{entityType.Name}'");
            }

            var parameter = Expression.Parameter(entityType, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var typeArguments = new Type[] { entityType, property.PropertyType };
            var orderByMethod = typeof(Queryable).GetMethods().First(m => m.Name == "OrderBy" && m.GetParameters().Length == 2)
                                                 .MakeGenericMethod(typeArguments);

            return (IQueryable<T>)orderByMethod.Invoke(null, new object[] { source, orderByExp });
        }

        /// <summary>
        /// Orders the queryable source by the specified property name in descending order.
        /// </summary>
        /// <param name="source">The queryable source.</param>
        /// <param name="propertyName">The name of the property to order by.</param>
        /// <returns>The ordered queryable source.</returns>
        /// <exception cref="ArgumentException">Thrown if the property does not exist on the type.</exception>
        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            var entityType = typeof(T);
            var property = entityType.GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' does not exist on type '{entityType.Name}'");
            }

            var parameter = Expression.Parameter(entityType, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var typeArguments = new Type[] { entityType, property.PropertyType };
            var orderByMethod = typeof(Queryable).GetMethods().First(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2)
                                                 .MakeGenericMethod(typeArguments);

            return (IQueryable<T>)orderByMethod.Invoke(null, new object[] { source, orderByExp });
        }

        /// <summary>
        /// Searches the queryable source for items that contain the specified search term in the specified property.
        /// </summary>
        /// <param name="query">The queryable source.</param>
        /// <param name="propertySelector">An expression that selects the property to search within.</param>
        /// <param name="searchTerm">The term to search for.</param>
        /// <returns>The queryable source filtered by the search term.</returns>
        public static IQueryable<T> Search<T>(this IQueryable<T> query, Expression<Func<T, string>> propertySelector, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return query;
            }

            var parameter = propertySelector.Parameters.Single();
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var searchExpression = Expression.Call(propertySelector.Body, containsMethod, Expression.Constant(searchTerm, typeof(string)));

            var lambda = Expression.Lambda<Func<T, bool>>(searchExpression, parameter);

            return query.Where(lambda);
        }

        /// <summary>
        /// Includes multiple related entities in the queryable source.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The queryable source.</param>
        /// <param name="includes">An array of expressions specifying the related entities to include.</param>
        /// <returns>The queryable source with the specified related entities included.</returns>
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        /// <summary>
        /// Converts the queryable source to a paged list asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the items in the list.</typeparam>
        /// <param name="source">The queryable source.</param>
        /// <param name="pageIndex">The 1-based index of the page to retrieve.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the paged list.</returns>
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageIndex, pageSize);
        }

    }
}