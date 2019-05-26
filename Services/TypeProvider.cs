using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDependencyInject.Services
{
    public class TypeProvider : IProvider
    {
        public string GetName()
        {
            return "Type Provider";
        }
    }
}
