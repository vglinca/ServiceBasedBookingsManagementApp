using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace OnlineBookingAggregatorApp.Infrastructure.Pagination
{
    public static class ExpressionBuilder
    {
        public static Expression<Func<T, bool>> WhereChildrenExpression<T>(string[] properties, string filter) where T : class
        {
            //left side of lambda: x =>

            var instance = Expression.Parameter(typeof(T), "x"); // x =>
            var childPropertyAccessor = Expression.Property(instance, "children"); // x.children

            var childrenInstance = Expression.Parameter(typeof(T), "y"); // y =>
            var childrenFilter = ChainContainsCallExpression(childrenInstance, properties, filter); // y.field.Contains(filter)
            var childrenLambda = Expression.Lambda<Func<T, bool>>(childrenFilter, childrenInstance);// y => y.field.Contains(filter)

            // x.subItems.Any(y => y.field.Contains(filter));
            var memberCall = Expression.Call(null, GetGenericMethodInfo<T>("Any", 2), childPropertyAccessor, childrenLambda);

            // x.field.Contains(filter);
            var parentFilter = ChainContainsCallExpression(instance, properties, filter);
            // x.subItems.Any(y => y.field.Contains(filter)) || x.field.Contains(filter);
            Expression group = Expression.OrElse(parentFilter, memberCall);

            return Expression.Lambda<Func<T, bool>>(group, instance);
        }

        private static MethodInfo GetGenericMethodInfo<T>(string methodName, int paramNumber)
        {
            var methods = typeof(Enumerable).GetMethods(BindingFlags.Public | BindingFlags.Static);
            var method = methods.First(m => m.Name == methodName && m.GetParameters().Count() == paramNumber);
            return method.MakeGenericMethod(typeof(T));
        }
        
        public static Expression<Func<T, bool>> WhereExpression<T>(string[] properties, string filter, LogicalOperator logicalOperator = LogicalOperator.Or)
        {
            //left side of lambda: x =>
            var instance = Expression.Parameter(typeof(T), "x");

            var memberContainsCalls = ChainContainsCallExpression(instance, properties, filter, logicalOperator);

            //compose lambda: x => x.property1.Contains("filter") || ...;
            return Expression.Lambda<Func<T, bool>>(memberContainsCalls, instance);
        }
        
        private static Expression ChainContainsCallExpression(ParameterExpression instance, string[] properties,
            string filter, LogicalOperator logicalOperator = LogicalOperator.Or)
        {
            return logicalOperator switch
            {
                LogicalOperator.And => properties
                    .Select(field => ContainsCallExpression(instance, field, filter)) //contains call: x.property.Contains("filter");
                    .Aggregate<Expression>(Expression.AndAlso),
                LogicalOperator.Or => properties
                    .Select(field => ContainsCallExpression(instance, field, filter)) //contains call: x.property.Contains("filter");
                    .Aggregate<Expression>(Expression.OrElse),
                _ => throw new ArgumentOutOfRangeException(nameof(LogicalOperator))
            };
        }

        private static MethodCallExpression ContainsCallExpression(ParameterExpression instance, string field, string filter) =>
            Expression.Call(Expression.Call(MemberChainExpression(instance, field),
                    typeof(string).GetMethod("ToLower", new Type[] { }) ?? throw new InvalidOperationException()),
                "Contains",
                null,
                Expression.Constant(filter)
            );

        private static MemberExpression MemberChainExpression(ParameterExpression instance, string propertyChain)
        {
            var properties = propertyChain.Split('.');
            //build the chain for filters like countryCode.Name
            var memberExpression = Expression.Property(instance, properties[0]);
            for (var i = 1; i < properties.Length; i++)
            {
                memberExpression = Expression.Property(memberExpression, properties[i]);
            }
                
            return memberExpression;
        }

        public static Expression<Func<T, object>> MemberExpression<T>(string field)
        {
            var argParam = Expression.Parameter(typeof(T), "x");
            Expression property = MemberChainExpression(argParam, field);
            Expression conversion = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<T, object>>(conversion, argParam);
        }
    }
}