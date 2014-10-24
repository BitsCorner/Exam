using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using Unity.WebApi;
using Microsoft.Practices.Unity.Configuration;

namespace Exam.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {

            var container = new UnityContainer();
            container.LoadConfiguration();
           
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
        
    }
}