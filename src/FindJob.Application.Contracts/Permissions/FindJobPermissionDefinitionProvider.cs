using FindJob.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FindJob.Permissions
{
    public class FindJobPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(FindJobPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(FindJobPermissions.MyPermission1, L("Permission:MyPermission1"));

            var fieldPermission = myGroup.AddPermission(FindJobPermissions.Field.Default, L("Permission:Field"));
            fieldPermission.AddChild(FindJobPermissions.Field.Create, L("Permission:Create"));
            fieldPermission.AddChild(FindJobPermissions.Field.Update, L("Permission:Update"));
            fieldPermission.AddChild(FindJobPermissions.Field.Delete, L("Permission:Delete"));

            var postPermission = myGroup.AddPermission(FindJobPermissions.Post.Default, L("Permission:Post"));
            postPermission.AddChild(FindJobPermissions.Post.Create, L("Permission:Create"));
            postPermission.AddChild(FindJobPermissions.Post.Update, L("Permission:Update"));
            postPermission.AddChild(FindJobPermissions.Post.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<FindJobResource>(name);
        }
    }
}
