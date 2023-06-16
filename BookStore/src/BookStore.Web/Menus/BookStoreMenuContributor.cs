using System.Threading.Tasks;
using BookStore.Localization;
using BookStore.MultiTenancy;
using BookStore.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace BookStore.Web.Menus;

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

        var bookStoreMenu = new ApplicationMenuItem(
            "BooksStore",
            l["Menu:BookStore"],
            icon: "fa fa-book"
        );

        context.Menu.AddItem(bookStoreMenu);

        //CHECK the PERMISSION
        if (await context.IsGrantedAsync(BookStorePermissions.Books.Default))
        {
            bookStoreMenu.AddItem(new ApplicationMenuItem(
                "BooksStore.Books",
                l["Menu:Books"],
                url: "/Books"
            ));
        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
        
        if (await context.IsGrantedAsync(BookStorePermissions.Authors.Default))
        {
            bookStoreMenu.AddItem(new ApplicationMenuItem(
                "BooksStore.Authors",
                l["Menu:Authors"],
                url: "/Authors"
            ));
        }
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
