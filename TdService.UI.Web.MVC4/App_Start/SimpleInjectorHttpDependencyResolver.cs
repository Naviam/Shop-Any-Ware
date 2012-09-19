// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleInjectorHttpDependencyResolver.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The simple injector http dependency resolver.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.MVC4.App_Start
{
    using System;
    using System.Collections.Generic;

    using SimpleInjector;

    /// <summary>
    /// The simple injector http dependency resolver.
    /// </summary>
    public class SimpleInjectorHttpDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly Container container;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleInjectorHttpDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public SimpleInjectorHttpDependencyResolver(Container container)
        {
            this.container = container;
        }

        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// The System.Web.Http.Dependencies.IDependencyScope.
        /// </returns>
        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;
        }

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The System.Object.
        /// </returns>
        public object GetService(Type serviceType)
        {
            IServiceProvider provider = this.container;
            return provider.GetService(serviceType);
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; System.Object].
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.GetAllInstances(serviceType);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
        }
    }
}