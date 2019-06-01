Dynamically inject dependency

Extending the below interface help to resolve configured services as per your own custom logic. Please refer this project for more information. 

```
public interface IServicesProvider<TInterface>
{
        /// <summary>
        /// The method returns corresponding resolved object from service container for the key
        /// </summary>
        /// <param name="key">The key<see cref="string"/></param>
        /// <returns>The implementation of <see cref="TInterface"/></returns>
        TInterface GetInstance(string key);
}

public class ServicesProvider<TInterface> : IServicesProvider<TInterface>
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
```
Register the above interface and implementation class with IoC container

```
services.AddSingleton(typeof(IServicesProvider<>), typeof(ServicesProvider<>));
```
