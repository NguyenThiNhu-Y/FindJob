using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Indo.Abp.AspNetCore.Mvc.UI.Theme.AdminLTE.Bundling;
using Indo.Abp.AspNetCore.Mvc.UI.Theme.AdminLTE.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Identity.Web;
using Volo.Abp.Account.Web;
using Volo.Abp.TenantManagement.Web;

namespace Indo.Abp.AspNetCore.Mvc.UI.Theme.AdminLTE
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpTenantManagementWebModule)
        )]
    public class AbpAspNetCoreMvcUIAdminLTEThemeModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAspNetCoreMvcUIAdminLTEThemeModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<AdminLTETheme>();

                if (options.DefaultThemeName == null)
                {
                    options.DefaultThemeName = AdminLTETheme.Name;
                }
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUIAdminLTEThemeModule>("Indo.Abp.AspNetCore.Mvc.UI.Theme.AdminLTE");
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new AdminLTEThemeMainTopToolbarContributor());
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(AdminLTEThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Styles.Global)
                            .AddContributors(typeof(AdminLTEThemeGlobalStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(AdminLTEThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Scripts.Global)
                            .AddContributors(typeof(AdminLTEThemeGlobalScriptContributor));
                    });
            });
        }

        //public override void OnApplicationInitialization(ApplicationInitializationContext context)
        //{
        //    var app = context.GetApplicationBuilder();
        //    var env = context.GetEnvironment();

        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseAbpRequestLocalization();

        //    if (!env.IsDevelopment())
        //    {
        //        app.UseErrorPage();
        //    }

        //    app.UseCorrelationId();
        //    app.UseStaticFiles();
        //    app.UseRouting();
        //    app.UseAuthentication();
        //    //app.UseJwtTokenMiddleware();

        //    //if (MultiTenancyConsts.IsEnabled)
        //    //{
        //    //    app.UseMultiTenancy();
        //    //}

        //    app.UseUnitOfWork();
        //    app.UseIdentityServer();
        //    app.UseAuthorization();
            
        //    app.UseAuditing();
        //    //app.UseAbpSerilogEnrichers();
        //    app.UseConfiguredEndpoints();
        //}
    }
}
