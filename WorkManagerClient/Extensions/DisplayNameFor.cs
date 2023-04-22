using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace WorkManagerClient.Extensions
{
    public static class DisplayNameForExtension
    {
        public static string DisplayNameFor<T>(this T model, Expression<Func<T, object>> propertyExpression)
        {
            Expression body = propertyExpression;
            if (body is LambdaExpression expression)
            {
                body = expression.Body;
            }

            if (!(body is MemberExpression memberExpression))
            {
                throw new InvalidOperationException("Expression is not a property");
            }

            var displayAttribute = memberExpression.Member.GetCustomAttributes(typeof(DisplayAttribute), false).OfType<DisplayAttribute>().First();

            return displayAttribute.Name;
        }
    }
}
