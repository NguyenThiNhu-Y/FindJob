using System;
using FindJob.Permissions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FindJob.Localization;
using FindJob.MultiTenancy;
using Volo.Abp.Account.Localization;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace FindJob.Blazor.Server.Tiered.Menus
{
    public class FindJobMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public FindJobMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private async Task<Task> ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<FindJobResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    FindJobMenus.Home,
                    l["Menu:Home"],
                    "/",
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
            administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

            return Task.CompletedTask;
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

            if (await context.IsGrantedAsync(FindJobPermissions.Notify.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(FindJobMenus.Notify, l["Menu:Notify"], "/Notifies/Notify")
                );
            }
            
            if (await context.IsGrantedAsync(FindJobPermissions.ManageCandidate.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(FindJobMenus.ManageCandidate, l["Menu:ManageCandidate"], "/ManageCandidates/ManageCandidate")
                );
            }
            if (await context.IsGrantedAsync(FindJobPermissions.Employer.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(FindJobMenus.Employer, l["Menu:Employer"], "/Employers/Employer")
                );
            }
        }
        
        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<FindJobResource>();
            var accountStringLocalizer = context.GetLocalizer<AccountResource>();
            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

            context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountStringLocalizer["MyAccount"],
                    $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}", icon: "fa fa-cog", order: 1000, null, "_blank").RequireAuthenticated());
            context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", l["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000).RequireAuthenticated());

            return Task.CompletedTask;
        }
    }
}
