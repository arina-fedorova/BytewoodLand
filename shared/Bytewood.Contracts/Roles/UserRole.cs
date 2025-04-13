﻿namespace Bytewood.Contracts.Roles;

public enum UserRole
{
    /// <summary>
    ///     Default role used when no user is authenticated
    /// </summary>
    Wanderer = 0,

    /// <summary>
    ///     Authenticated user role — trusted access
    /// </summary>
    Guardian = 1,

    /// <summary>
    ///     Background processing, event watching
    /// </summary>
    Scout = 2
}