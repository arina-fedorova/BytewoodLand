using Unity.Gateway.Models;

namespace Unity.Gateway.Helpers;

public static class RoleNames
{
    public static string AsString(this Role role)
    {
        return role.ToString().ToLower();
    }
}
