namespace Bytewood.Contracts.Roles;

public static class RoleHelper
{
    public static string AsString(this UserRole role)
    {
        return role.ToString().ToLower();
    }
    public static string AsString(this ServiceRole role)
    {
        return role.ToString().ToLower();
    }
}