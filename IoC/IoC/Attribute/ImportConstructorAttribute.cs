using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ImportConstructorAttribute : System.Attribute
    {
    }
}
