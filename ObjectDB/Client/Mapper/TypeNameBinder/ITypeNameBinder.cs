using System;

namespace ObjectDB
{
    public interface ITypeNameBinder
    {
        string GetName(Type type);
        Type GetType(string name);
    }
}