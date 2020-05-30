using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UsefulTypeExtensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Check, inherits or implements parent class or interface independend of generic type arguments
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static bool InheritsOrImplements(this Type child, Type parent)
        {
            parent = ResolveGenericTypeDefinition(parent);
            
            var currentChild = (child.IsGenericType && !child.IsConstructedGenericType) || (child.IsConstructedGenericType && parent.IsGenericType && !parent.IsConstructedGenericType)
                ? child.GetGenericTypeDefinition()
                : child;

            while (currentChild != null)
            {
                if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
                    return true;

                currentChild = currentChild.BaseType != null && currentChild.BaseType.IsGenericType && (!parent.IsConstructedGenericType)
                    ? currentChild.BaseType.GetGenericTypeDefinition()
                    : (parent.IsInterface ? currentChild.GetInterfaces().FirstOrDefault(i=>i.InheritsOrImplements(parent)) : currentChild.BaseType);

                if (currentChild == null)
                    return false;
            }
            return false;
        }

        #region For InheritsOrImplements

        private static bool HasAnyInterfaces(Type parent, Type child)
        {
            return child.GetInterfaces()
                .Any(childInterface =>
                {
                    var currentInterface = childInterface.IsGenericType
                        ? childInterface.GetGenericTypeDefinition()
                        : childInterface;

                    return currentInterface == parent;
                });
        }

        private static Type ResolveGenericTypeDefinition(Type parent)
        {
            var shouldUseGenericType = true;
            if (parent.IsGenericType && parent.GetGenericTypeDefinition() != parent)
                shouldUseGenericType = false;

            if (parent.IsGenericType && shouldUseGenericType)
                parent = parent.GetGenericTypeDefinition();
            return parent;
        }

        #endregion

        /// <summary>
        /// Get default value of type. Useful in common object value checks
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static object GetDefaultValue(this Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }
    }
}
