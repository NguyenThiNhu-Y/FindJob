namespace FindJob.Permissions
{
    public static class FindJobPermissions
    {
        public const string GroupName = "FindJob";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Field
        {
            public const string Default = GroupName + ".Field";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Post
        {
            public const string Default = GroupName + ".Post";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}