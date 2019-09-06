using System;
using System.Linq.Expressions;

namespace Sample.Base.Core.Extensions
{
    public static class ExtensionMethod
    {
        /// <summary>
        ///  Get the name of a static or instance property from a property access lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            if (body == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }
            return body.Member.Name;
        }
    }
}
