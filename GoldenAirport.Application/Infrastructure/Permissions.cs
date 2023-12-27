namespace GoldenAirport.Application.Infrastructure
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
         {
             $"Permissions.{module}.Actions",
             //$"Permissions.{module}.Create",
             //$"Permissions.{module}.Edit",
             //$"Permissions.{module}.Delete"
         };
        }

        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();

            var modules = Enum.GetValues(typeof(Modules));

            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));

            return allPermissions;
        }

        #region AppModules
        public static class Flight
        {
            public const string Actions = "Permissions.Flight";
            //public const string Create = "Permissions.Flight.Create";
            //public const string Edit = "Permissions.Flight.Edit";
            //public const string Delete = "Permissions.Flight.Delete";
        }
        public static class Hotels
        {
            public const string Actions = "Permissions.Hotels";
            //public const string Create = "Permissions.Hotels.Create";
            //public const string Edit = "Permissions.Hotels.Edit";
            //public const string Delete = "Permissions.Hotels.Delete";
        }
        public static class Trips
        {
            public const string Actions = "Permissions.Trips.Actions";
            //public const string Create = "Permissions.Trips.Create";
            //public const string Edit = "Permissions.Trips.Edit";
            //public const string Delete = "Permissions.Trips.Delete";
        }
        public static class Packges
        {
            public const string Actions = "Permissions.Packges";
            //public const string Create = "Permissions.Packges.Create";
            //public const string Edit = "Permissions.Packges.Edit";
            //public const string Delete = "Permissions.Packges.Delete";
        }

        #endregion
    }
}
