using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDependencyInject.Services
{
    public interface IProvider
    {
        string GetName();
    }
}
