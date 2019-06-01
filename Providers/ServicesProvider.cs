//----------------------------------------------------------------------------------
// <copyright file="ServicesProvider.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>5/26/2019</date>
// <summary>Defines the generic class to resolve and inject objects dynamically</summary>
//-----------------------------------------------------------------------------------

namespace DynamicDependencyInject.Providers
{
    using Microsoft.AspNetCore.Http;
    using System;

    /// <summary>
    /// Defines the <see cref="ServicesProvider{TInterface}" /> generic class to resolve and inject objects dynamically
    /// </summary>
    /// <typeparam name="TInterface">The generic interface type</typeparam>
    public sealed class ServicesProvider<TInterface> : IServicesProvider<TInterface>
    {
        /// <summary>
        /// Defines the httpContextAccessor field
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesProvider{TInterface}"/> class.
        /// </summary>
        /// <param name="contextAccessor">The contextAccessor<see cref="IHttpContextAccessor"/> object</param>
        public ServicesProvider(IHttpContextAccessor contextAccessor)
        {
            this.httpContextAccessor = contextAccessor;
        }

        /// <summary>
        /// The method returns corresponding resolved object from service container for the key
        /// </summary>
        /// <param name="key">The key<see cref="string"/></param>
        /// <returns>The implementation of <see cref="TInterface"/></returns>
        public TInterface GetInstance(string key)
        {
            var service = this.GetService();
            return service(key);
        }

        /// <summary>
        /// The method returns service container that can be used to resolve and inject object dynamically
        /// </summary>
        /// <returns>The <see cref="Func{string, TInterface}"/></returns>
        private Func<string, TInterface> GetService()
        {
            return (Func<string, TInterface>)this.httpContextAccessor.HttpContext
                .RequestServices.GetService(typeof(Func<string, TInterface>));
        }
    }
}
