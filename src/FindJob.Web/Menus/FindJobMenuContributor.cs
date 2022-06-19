using System.Threading.Tasks;
using FindJob.Permissions;
using FindJob.Localization;
using FindJob.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace FindJob.Web.Menus
{
    public class FindJobMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<FindJobResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    FindJobMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );
            
            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
            if (await context.IsGrantedAsync(FindJobPermissions.Field.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(FindJobMenus.Field, l["Menu:Field"], "/Fields/Field")
                );
            }
            if (await context.IsGrantedAsync(FindJobPermissions.Post.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(FindJobMenus.Post, l["Menu:Post"], "/Posts/Post")
                );
            }
           
            if (await context.IsGrantedAsync(FindJobPermissions.CV.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(FindJobMenus.CV, l["Menu:CV"], "/CVs/CV")
                );
            }
        }
    }
}
