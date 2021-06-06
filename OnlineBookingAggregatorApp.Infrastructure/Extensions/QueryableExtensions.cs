using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineBookingAggregatorApp.Infrastructure.Pagination;
using ExpressionBuilder = OnlineBookingAggregatorApp.Infrastructure.Pagination.ExpressionBuilder;

namespace OnlineBookingAggregatorApp.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> src, int pageNumber, int pageSize) where T : class
        {
            return src.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        }

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> src, string filterValue,
            string[] filterProperties, LogicalOperator logicalOperator) where T : class
        {
            if (!string.IsNullOrWhiteSpace(filterValue) && filterProperties.Any())
            {
                var where = ExpressionBuilder.WhereExpression<T>(filterProperties, filterValue.ToLower(), logicalOperator);
                src = src.Where(where);
            }

            return src;
        }
        
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> src, string filterValue, string[] filterProperties) where T : class
        {
            if (!string.IsNullOrWhiteSpace(filterValue) && filterProperties.Any())
            {
                var where = ExpressionBuilder.WhereExpression<T>(filterProperties, filterValue.ToLower());
                src = src.Where(where);
            }

            return src;
        }

        public static IQueryable<T> ApplySort<T>(this IQueryable<T> src, string orderBy, bool ascending) where T : class
        {
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var orderByExpression = ExpressionBuilder.MemberExpression<T>(orderBy);
                src = ascending ? src.OrderBy(orderByExpression) : src.OrderByDescending(orderByExpression);
            }

            return src;
        }
    }
}