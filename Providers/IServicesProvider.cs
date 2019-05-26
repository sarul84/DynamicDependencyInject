//----------------------------------------------------------------------------------
// <copyright file="IServicesProvider.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>5/26/2019</date>
// <summary>The contract that defines methods for ServicesProvider</summary>
//-----------------------------------------------------------------------------------

namespace DynamicDependencyInject.Providers
{
    /// <summary>
    /// Defines the <see cref="IServicesProvider{TInterface}" /> that has methods for ServicesProvider
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    public interface IServicesProvider<TInterface>
    {
        /// <summary>
        /// The method returns corresponding resolved object from service container for the key
        /// </summary>
        /// <param name="key">The key<see cref="string"/></param>
        /// <returns>The implementation of <see cref="TInterface"/></returns>
        TInterface GetInstance(string key);
    }
}
