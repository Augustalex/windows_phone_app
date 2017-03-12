using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_3.Router
{
    class Dependency
    {
        public string Name { get; }
        public object DependencyObject { get; }

        public Dependency(string name, object dependencyObject)
        {
            Name = name;
            DependencyObject = dependencyObject;
        }
    }
}
