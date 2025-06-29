using System;

namespace RestaurantApp.Utils
{
    public enum Role
    {
        Client,
        Chef,
        Waiter,
        Courier,
        Manager
    }

    [Flags]
    public enum Permissions
    {
        None = 0,
        ViewMenu = 1 << 0,
        CreateOrder = 1 << 1,
        UpdateDishStatus = 1 << 2,
        DeliverOrder = 1 << 3,
        PayOrder = 1 << 4,
        ViewStatistics = 1 << 5,
        RegisterEmployee = 1 << 6,
        All = ~None
    }

    public static class RoleHelper
    {
        public static Permissions GetPermissions(Role role)
        {
            switch (role)
            {
                case Role.Client:
                    return Permissions.ViewMenu | Permissions.CreateOrder;
                case Role.Chef:
                    return Permissions.UpdateDishStatus;
                case Role.Waiter:
                case Role.Courier:
                    return Permissions.DeliverOrder | Permissions.PayOrder;
                case Role.Manager:
                    return Permissions.All;
                default:
                    return Permissions.None;
            }
        }

        public static bool HasPermission(Permissions userPerms, Permissions requiredPerms)
        {
            return (userPerms & requiredPerms) == requiredPerms && requiredPerms != Permissions.None;
        }
    }
}