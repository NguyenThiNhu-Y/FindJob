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

            //var cVsPermission = myGroup.AddPermission(FindJobPermissions.CVs.Default, L("Permission:CVs"));
            //cVsPermission.AddChild(FindJobPermissions.CVs.Create, L("Permission:Create"));
            //cVsPermission.AddChild(FindJobPermissions.CVs.Update, L("Permission:Update"));
            //cVsPermission.AddChild(FindJobPermissions.CVs.Delete, L("Permission:Delete"));

            var cVPermission = myGroup.AddPermission(FindJobPermissions.CV.Default, L("Permission:CV"));
            cVPermission.AddChild(FindJobPermissions.CV.Create, L("Permission:Create"));
            cVPermission.AddChild(FindJobPermissions.CV.Update, L("Permission:Update"));
            cVPermission.AddChild(FindJobPermissions.CV.Delete, L("Permission:Delete"));

            

            var notifyPermission = myGroup.AddPermission(FindJobPermissions.Notify.Default, L("Permission:Notify"));
            notifyPermission.AddChild(FindJobPermissions.Notify.Create, L("Permission:Create"));
            notifyPermission.AddChild(FindJobPermissions.Notify.Update, L("Permission:Update"));
            notifyPermission.AddChild(FindJobPermissions.Notify.Delete, L("Permission:Delete"));

            //var employerPermission = myGroup.AddPermission(FindJobPermissions.Employer.Default, L("Permission:Employer"));
            //employerPermission.AddChild(FindJobPermissions.Employer.Create, L("Permission:Create"));
            //employerPermission.AddChild(FindJobPermissions.Employer.Update, L("Permission:Update"));
            //employerPermission.AddChild(FindJobPermissions.Employer.Delete, L("Permission:Delete"));

            var manageCandidatePermission = myGroup.AddPermission(FindJobPermissions.ManageCandidate.Default, L("Permission:ManageCandidate"));
            manageCandidatePermission.AddChild(FindJobPermissions.ManageCandidate.Create, L("Permission:Create"));
            manageCandidatePermission.AddChild(FindJobPermissions.ManageCandidate.Update, L("Permission:Update"));
            manageCandidatePermission.AddChild(FindJobPermissions.ManageCandidate.Delete, L("Permission:Delete"));

            var employerPermission = myGroup.AddPermission(FindJobPermissions.Employer.Default, L("Permission:Employer"));
            employerPermission.AddChild(FindJobPermissions.Employer.Create, L("Permission:Create"));
            employerPermission.AddChild(FindJobPermissions.Employer.Update, L("Permission:Update"));
            employerPermission.AddChild(FindJobPermissions.Employer.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<FindJobResource>(name);
        }
    }
}
