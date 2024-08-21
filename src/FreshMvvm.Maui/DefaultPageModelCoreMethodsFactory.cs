using Microsoft.Maui.Controls;

namespace FreshMvvm.Maui;

public class DefaultPageModelCoreMethodsFactory : IPageModelCoreMethodsFactory
{
    public IPageModelCoreMethods Create(Page currentPage, FreshBasePageModel pageModel)
    {
        return new PageModelCoreMethods(currentPage, pageModel);
    }
}