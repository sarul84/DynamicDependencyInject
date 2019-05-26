using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDependencyInject.Services
{
    public class NameProvider : IProvider
    {
        public string GetName()
        {
            return "Name provider";
        }
    }
}
