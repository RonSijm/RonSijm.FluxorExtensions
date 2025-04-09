using System.Reflection;

namespace RonSijm.Syringe;

public static class StoreReflectionHelper
{
    public static object GetPrivateField(this Store store, string fieldName)
    {
        var field = typeof(Store).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (field == null)
        {
            throw new InvalidOperationException($"Field '{fieldName}' not found in Store.");
        }
        return field.GetValue(store);
    }

    public static T GetPrivateField<T>(this Store store, string fieldName)
    {
        return (T)GetPrivateField(store, fieldName);
    }
}