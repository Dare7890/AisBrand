using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GenericFilters
{
    public class GenericFilter<T>
    {
        private Expression expression;
        private ParameterExpression parameterExpression = Expression.Parameter(typeof(T));

		public IEnumerable<T> CheckStartsWith(IEnumerable<T> collection, string propertyName, string line)
        {
			CheckStartsWith(propertyName, line);
			return Apply(collection);
		}

		private void CheckStartsWith(string propertyName, string line)
		{
			MemberInfo property = typeof(T).GetProperty(propertyName);
			MemberExpression propertyExpression = Expression.MakeMemberAccess(parameterExpression, property);

			Expression valueExpression = Expression.Constant(line, typeof(string));

			MethodInfo containMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
			MethodCallExpression containsExpression = Expression.Call(propertyExpression, containMethod, valueExpression);

			expression = Expression.IsTrue(containsExpression);
		}

		private IEnumerable<T> Apply(IEnumerable<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException(nameof(collection));

			Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(expression, parameterExpression);

			return collection.Where(lambda.Compile());
		}
	}
}
