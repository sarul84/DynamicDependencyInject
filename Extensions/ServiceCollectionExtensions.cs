//----------------------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>5/26/2019</date>
// <summary>ServiceCollectionExtensions.cs</summary>
//-----------------------------------------------------------------------------------

namespace DynamicDependencyInject.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ServiceCollectionExtensions" />
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// The AddScopedDynamic
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <param name="services">The services<see cref="IServiceCollection"/></param>
        /// <param name="types">The types<see cref="IEnumerable{Type}"/></param>
        public static void AddScopedDynamic<TInterface>(this IServiceCollection services, IEnumerable<Type> types)
        {
            services.AddScoped<Func<string, TInterface>>(serviceProvider => tenant =>
            {
                var type = types.Where(x => typeof(TInterface).IsAssignableFrom(x) && !x.IsInterface 
                    && !x.IsAbstract && x.Name.StartsWith(tenant))
                                .FirstOrDefault();

                if (null == type)
                {
                    throw new KeyNotFoundException("No instance found for the given tenant.");
                }

                return (TInterface)serviceProvider.GetService(type);
            });
        }
    }
}
