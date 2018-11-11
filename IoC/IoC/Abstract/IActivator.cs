using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Abstract
{
    public interface IActivator
    {
        object CreateInstance(Type type, params object[] parameters);
    }
}
