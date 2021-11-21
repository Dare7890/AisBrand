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

		public void CheckEqualsToValue<TValue>(string propertyName, TValue value)
		{
			MemberInfo property = typeof(T).GetProperty(propertyName);
			MemberExpression propertyExpression = Expression.MakeMemberAccess(parameterExpression, property);

			Expression valueExpression = Expression.Constant(value, typeof(TValue));
			BinaryExpression binaryExpression = Expression.Equal(propertyExpression, valueExpression);
			AddCondition(binaryExpression);
		}

		public void CheckOnEmpty(string propertyName)
		{
			MemberInfo property = typeof(T).GetProperty(propertyName);
			MemberExpression propertyExpression = Expression.MakeMemberAccess(parameterExpression, property);

			ConstantExpression constantExpression = Expression.Constant(null);
			BinaryExpression binaryExpression = Expression.ReferenceEqual(propertyExpression, constantExpression);
			AddCondition(binaryExpression);
		}

		public void CheckGreaterThanValue<TValue>(string propertyName, TValue value)
			where TValue : IComparable<TValue>
		{
			MemberInfo property = typeof(T).GetProperty(propertyName);
			MemberExpression propertyExpression = Expression.MakeMemberAccess(parameterExpression, property);

			Expression valueExpression = Expression.Constant(value, typeof(TValue));
			MethodInfo comparer = typeof(TValue).GetMethod("CompareTo", new Type[] { typeof(TValue) });
			MethodCallExpression comparisonExpression = Expression.Call(propertyExpression, comparer, valueExpression);
			ConstantExpression constantExpression = Expression.Constant(0);
			BinaryExpression binaryExpression = Expression.GreaterThan(comparisonExpression, constantExpression);
			AddCondition(binaryExpression);
		}

		public void CheckGreaterThanOrEqualValue<TValue>(string propertyName, TValue value)
			where TValue : IComparable<TValue>
		{
			MemberInfo property = typeof(T).GetProperty(propertyName);
			MemberExpression propertyExpression = Expression.MakeMemberAccess(parameterExpression, property);

			Expression valueExpression = Expression.Constant(value, typeof(TValue));
			MethodInfo comparer = typeof(TValue).GetMethod("CompareTo", new Type[] { typeof(TValue) });
			MethodCallExpression comparisonExpression = Expression.Call(propertyExpression, comparer, valueExpression);
			ConstantExpression constantExpression = Expression.Constant(0);
			BinaryExpression binaryExpression = Expression.GreaterThanOrEqual(comparisonExpression, constantExpression);
			AddCondition(binaryExpression);
		}

		public void CheckLessThanValue<TValue>(string propertyName, TValue value)
			where TValue : IComparable<TValue>
		{
			MemberInfo property = typeof(T).GetProperty(propertyName);
			MemberExpression propertyExpression = Expression.MakeMemberAccess(parameterExpression, property);

			Expression valueExpression = Expression.Constant(value, typeof(TValue));
			MethodInfo comparer = typeof(TValue).GetMethod("CompareTo", new Type[] { typeof(TValue) });
			MethodCallExpression comparisonExpression = Expression.Call(propertyExpression, comparer, valueExpression);
			ConstantExpression constantExpression = Expression.Constant(0);
			BinaryExpression binaryExpression = Expression.LessThan(comparisonExpression, constantExpression);
			AddCondition(binaryExpression);
		}

		public void CheckLessThanOrEqualValue<TValue>(string propertyName, TValue value)
			where TValue : IComparable<TValue>
		{
			MemberInfo property = typeof(T).GetProperty(propertyName);
			MemberExpression propertyExpression = Expression.MakeMemberAccess(parameterExpression, property);

			Expression valueExpression = Expression.Constant(value, typeof(TValue));
			MethodInfo comparer = typeof(TValue).GetMethod("CompareTo", new Type[] { typeof(TValue) });
			MethodCallExpression comparisonExpression = Expression.Call(propertyExpression, comparer, valueExpression);
			ConstantExpression constantExpression = Expression.Constant(0);
			BinaryExpression binaryExpression = Expression.LessThanOrEqual(comparisonExpression, constantExpression);
			AddCondition(binaryExpression);
		}

		public void CheckBetween<TValue>(string propertyName, TValue min, TValue max)
			where TValue : IComparable<TValue>
		{
			CheckGreaterThanValue<TValue>(propertyName, min);
			CheckLessThanValue<TValue>(propertyName, max);
		}

		public void CheckContainLine(string propertyName, string line)
		{
			MemberInfo property = typeof(T).GetProperty(propertyName);
			MemberExpression propertyExpression = Expression.MakeMemberAccess(parameterExpression, property);

			Expression valueExpression = Expression.Constant(line, typeof(string));

			MethodInfo containMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
			MethodCallExpression containsExpression = Expression.Call(propertyExpression, containMethod, valueExpression);

			UnaryExpression containBinaryExpression = Expression.IsTrue(containsExpression);
			AddCondition(containBinaryExpression);
		}

		private void AddCondition(Expression filterExpression)
		{
			if (filterExpression == null)
				throw new ArgumentNullException(nameof(filterExpression));

			expression = (expression == null) ? filterExpression : Expression.And(expression, filterExpression);
		}

		public void Clear()
		{
			expression = null;
		}

		public IEnumerable<T> Apply(IEnumerable<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException(nameof(collection));

			Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(expression, parameterExpression);

			return collection.Where(lambda.Compile());
		}
	}
}
