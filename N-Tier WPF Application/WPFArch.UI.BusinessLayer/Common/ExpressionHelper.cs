using System;
using System.Linq.Expressions;

namespace WPFArch.UI.BusinessLayer.Common
{
    public static class ExpressionHelper
    {
        public static string GetMethodName(Expression<Func<object, object>> property)
        {
            var expr = (property.Body);
            string method = string.Empty;

            if (expr is UnaryExpression)
            {
                method =
                    (((MemberExpression)
                    (((UnaryExpression)
                    (property.Body)).Operand)).Member).Name;
            }
            else if (expr is MemberExpression)
            {
                method = (((MemberExpression)
                         (property.Body)).Member).Name;
            }

            return method;
        }

    }
}
