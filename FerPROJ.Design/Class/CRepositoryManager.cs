using FerPROJ.Design.Class;
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

            using (var freshDbContext = (DbContext)Activator.CreateInstance(CAppConstants.DbContextType)) {
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
            var constant = Expression.Constant(value);

            var body = Expression.Equal(property, constant);

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
    }
}
