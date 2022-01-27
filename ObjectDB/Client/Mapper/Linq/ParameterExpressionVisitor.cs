﻿using System.Linq.Expressions;

namespace ObjectDB
{
    /// <summary>
    /// Class used to test in an Expression member expression is based on parameter `x => x.Name` or variable `x => externalVar`
    /// </summary>
    internal class ParameterExpressionVisitor : ExpressionVisitor
    {
        public bool IsParameter { get; private set; } = false;

        protected override Expression VisitParameter(ParameterExpression node)
        {
            this.IsParameter = true;

            return base.VisitParameter(node);
        }

        public static bool Test(Expression node)
        {
            var instance = new ParameterExpressionVisitor();

            instance.Visit(node);

            return instance.IsParameter;
        }
    }
}