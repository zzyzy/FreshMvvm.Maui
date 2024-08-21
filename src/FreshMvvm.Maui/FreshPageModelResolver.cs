using System;
using FreshMvvm.Maui.IOC;
using Microsoft.Maui.Controls;

namespace FreshMvvm.Maui
{
    public static class FreshPageModelResolver
    {
        public static Page ResolvePageModel<T> () where T : FreshBasePageModel
        {
            return ResolvePageModel<T> (null);
        }

        public static Page ResolvePageModel<T> (object initData) where T : FreshBasePageModel
        {
            var pageModel = DependancyService.Resolve<T> ();

            return ResolvePageModel<T> (initData, pageModel);
        }

        public static Page ResolvePageModel<T> (object data, T pageModel) where T : FreshBasePageModel
        {
            var type = pageModel.GetType ();
            return ResolvePageModel (type, data, pageModel);
        }

        public static Page ResolvePageModel (Type type, object data) 
        {
            var pageModel = DependancyService.Resolve(type) as FreshBasePageModel;
            return ResolvePageModel (type, data, pageModel);
        }

        public static Page ResolvePageModel (Type type, object data, FreshBasePageModel pageModel)
        {
            var modelMapper = DependancyService.Resolve<IFreshPageModelMapper>();
            var name = modelMapper.GetPageTypeName (type);
            var pageType = Type.GetType (name);
            if (pageType == null)
                throw new Exception (name + " not found");

            var page = (Page)DependancyService.Resolve(pageType);

            BindingPageModel(data, page, pageModel);

            return page;
        }

        public static Page BindingPageModel(object data, Page targetPage, FreshBasePageModel pageModel)
        {
            var pageModelCoreMethodFactory = DependancyService.Resolve<IPageModelCoreMethodsFactory>();
            pageModel.WireEvents(targetPage);
            pageModel.CurrentPage = targetPage;
            pageModel.CoreMethods = pageModelCoreMethodFactory.Create(targetPage, pageModel);
            pageModel.Init(data);
            targetPage.BindingContext = pageModel;
            return targetPage;
        }
    }
}

