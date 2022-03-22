using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using AddressBook.Bll.Interfaces;
using AddressBook.Bll.Services;

namespace AddressBook
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IContactInfoService, ContactInfoService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}