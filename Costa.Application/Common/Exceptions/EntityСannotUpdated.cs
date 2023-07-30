using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costa.Application.Common.Exceptions
{    
    public class EntityСannotUpdated : Exception
    {
        public EntityСannotUpdated(string name, object key) : base($"Entity \"{name}\" ({key}) can not updated because record already exist.") { }
    }
}
