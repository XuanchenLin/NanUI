// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;
internal static class AppBuilderExtensions
{
    public static void EnsureIsDerivedType(this Type derivedType, Type baseType)
    {
        if (baseType == derivedType)
        {
            throw new Exception($"Cannot specify the base type {baseType.Name} itself as generic type parameter.");
        }

        if (!baseType.IsAssignableFrom(derivedType))
        {
            throw new Exception($"Type {derivedType.Name} must implement {baseType.Name}.");
        }

        if (derivedType.IsAbstract || derivedType.IsInterface)
        {
            throw new Exception($"Type {derivedType.Name} cannot be an interface or abstract class.");
        }
    }
}
