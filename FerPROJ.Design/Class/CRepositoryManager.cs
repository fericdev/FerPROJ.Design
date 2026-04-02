using FerPROJ.Design.Class;
using FerPROJ.Design.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.DBHelper.DBCrud {
    public static class CRepositoryManager {
        public static async Task<TResult> ExecuteMethodAsync<TResult>(
            Type repositoryType,
            string methodName,
            params object[] parameters) {

            var method = ResolveMethod(repositoryType, methodName, parameters);

            if (method == null)
                throw new InvalidOperationException("Method not found.");

            using (var freshDbContext = (DbContext)Activator.CreateInstance(CAppConstants.DB_CONTEXT_TYPE)) {

                var instance = Activator.CreateInstance(repositoryType, freshDbContext);

                var finalParameters = BuildParameterList(method, parameters);

                var taskObject = method.Invoke(instance, finalParameters);

                if (taskObject is Task<TResult> typedTask)
                    return await typedTask;

                if (taskObject is Task nonGenericTask) {
                    await nonGenericTask;
                    return default;
                }

                throw new InvalidOperationException("Method must return Task or Task<TResult>.");
            }
        }
        public static LambdaExpression Equal(
            Type entityType,
            string propertyName,
            object value) {
            var parameter = Expression.Parameter(entityType, "x");
            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(value.ToString());

            var body = Expression.Equal(property, constant);

            return Expression.Lambda(body, parameter);
        }
        public static LambdaExpression Equal(
            Type entityType,
            List<(FilterOperator Operator, string PropertyName, object Value)> conditions) {
            var parameter = Expression.Parameter(entityType, "x");
            Expression body = Expression.Constant(true);

            foreach (var condition in conditions) {
                var property = Expression.Property(parameter, condition.PropertyName);

                // Ensure value matches property type
                var targetType = Nullable.GetUnderlyingType(property.Type) ?? property.Type;
                var convertedValue = Convert.ChangeType(condition.Value, targetType);
                var constant = Expression.Constant(convertedValue, property.Type);

                Expression comparison = null;

                switch (condition.Operator) {
                    case FilterOperator.Equal:
                        comparison = Expression.Equal(property, constant);
                        break;

                    case FilterOperator.NotEqual:
                        comparison = Expression.NotEqual(property, constant);
                        break;

                    case FilterOperator.GreaterThan:
                        comparison = Expression.GreaterThan(property, constant);
                        break;

                    case FilterOperator.LessThan:
                        comparison = Expression.LessThan(property, constant);
                        break;

                    case FilterOperator.GreaterThanOrEqual:
                        comparison = Expression.GreaterThanOrEqual(property, constant);
                        break;

                    case FilterOperator.LessThanOrEqual:
                        comparison = Expression.LessThanOrEqual(property, constant);
                        break;

                    case FilterOperator.Contains:
                        comparison = Expression.Call(property, typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) }), constant);
                        break;
                    case FilterOperator.StartsWith:
                        comparison = Expression.Call(property, typeof(string).GetMethod(nameof(string.StartsWith), new[] { typeof(string) }), constant);
                        break;
                    case FilterOperator.EndsWith:
                        comparison = Expression.Call(property, typeof(string).GetMethod(nameof(string.EndsWith), new[] { typeof(string) }), constant);
                        break;
                    case FilterOperator.IsNull:
                        comparison = Expression.Equal(property, Expression.Constant(null));
                        break;
                    case FilterOperator.IsNotNull:
                        comparison = Expression.NotEqual(property, Expression.Constant(null));
                        break;

                }

                body = Expression.AndAlso(body, comparison);
            }

            return Expression.Lambda(body, parameter);
        }
        private static MethodInfo ResolveMethod(
            Type repositoryType,
            string methodName,
            object[] parameters) {
            var methods = repositoryType
                .GetMethods()
                .Where(m => m.Name == methodName);

            foreach (var method in methods) {
                var methodParams = method.GetParameters();

                if (methodParams.Length != parameters.Length)
                    continue;

                bool isMatch = true;

                for (int i = 0; i < methodParams.Length; i++) {
                    var expectedType = methodParams[i].ParameterType;
                    var actualValue = parameters[i];

                    if (actualValue == null) {
                        // Null allowed only for reference or Nullable<T>
                        if (expectedType.IsValueType &&
                            Nullable.GetUnderlyingType(expectedType) == null) {
                            isMatch = false;
                            break;
                        }
                    }
                    else {
                        var actualType = actualValue.GetType();

                        if (!expectedType.IsAssignableFrom(actualType)) {
                            isMatch = false;
                            break;
                        }
                    }
                }

                if (isMatch)
                    return method;
            }

            return null;
        }
        private static object[] BuildParameterList(
            MethodInfo method,
            object[] suppliedParams) {
            var methodParams = method.GetParameters();
            var finalParams = new object[methodParams.Length];

            for (int i = 0; i < methodParams.Length; i++) {
                if (i < suppliedParams.Length) {
                    finalParams[i] = suppliedParams[i];
                }
                else {
                    // Use default value if optional
                    if (methodParams[i].HasDefaultValue) {
                        finalParams[i] = methodParams[i].DefaultValue;
                    }
                    else {
                        finalParams[i] = GetDefault(methodParams[i].ParameterType);
                    }
                }
            }

            return finalParams;
        }

        private static object GetDefault(Type type) {
            if (type.IsValueType)
                return Activator.CreateInstance(type);

            return null;
        }
        public enum FilterOperator {
            Equal,
            NotEqual,
            GreaterThan,
            LessThan,
            GreaterThanOrEqual,
            LessThanOrEqual,
            Contains,
            StartsWith,
            EndsWith,
            IsNull,
            IsNotNull
        }
    }
}
