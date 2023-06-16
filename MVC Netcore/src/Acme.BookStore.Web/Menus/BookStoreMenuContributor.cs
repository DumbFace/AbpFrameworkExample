using System.Threading.Tasks;
using Acme.BookStore.Localization;
using Acme.BookStore.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Acme.BookStore.Web.Menus;

public class BookStoreMenuContributor : IMenuContributor
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
        var l = context.GetLocalizer<BookStoreResource>();

        context.Menu.AddItem(
                new ApplicationMenuItem("MyProject.CRM", l["Group Menu"],null,"far fa-snowflake")
                .AddItem( new ApplicationMenuItem(
                    name: BookStoreMenus.Home,
                    displayName: l["Menu:Home"],
                    url: "~/",
                    icon: "fas fa-home"))
                .AddItem(new ApplicationMenuItem(
                    name: BookStoreMenus.Test,
                    displayName: l["Test"],
                    url: "~/test",
                    icon: "fas fa-wifi"))
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
    }
}
