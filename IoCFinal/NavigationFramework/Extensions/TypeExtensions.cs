using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NavigationFramework.Extensions
{
    public static class TypeExtensions
    {
        private static readonly Func<Type, Type> GetBaseTypeFunc;

        static TypeExtensions()
        {
            var parameterExpression = Expression.Parameter(typeof(Type));
            GetBaseTypeFunc = (Func<Type, Type>)Expression.Lambda(Expression.Property(
                parameterExpression, "BaseType"), parameterExpression).Compile();
        }
        
        public static bool IfHaveBaseClassOf<TBase>(this TypeInfo type) where TBase : class
        {
            return type.AsType().IfHaveBaseClassOf<TBase>();
        }

        public static bool IfHaveBaseClassOf<TBase>(this Type type) where TBase : class
        {
            var haveBase = false;
            var typeToCheck = type;
            var baseType = typeof(TBase);
            while (typeToCheck != null)
            {
                if (GetBaseTypeFunc(typeToCheck) == baseType)
                {
                    haveBase = true;
                    break;
                }
                typeToCheck = GetBaseTypeFunc(typeToCheck);
            }
            return haveBase;
        }
    }
}
