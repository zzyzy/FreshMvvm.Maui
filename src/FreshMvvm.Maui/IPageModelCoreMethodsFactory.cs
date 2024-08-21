using Microsoft.Maui.Controls;

namespace FreshMvvm.Maui;

public interface IPageModelCoreMethodsFactory
{
    public IPageModelCoreMethods Create(Page currentPage, FreshBasePageModel pageModel);
}