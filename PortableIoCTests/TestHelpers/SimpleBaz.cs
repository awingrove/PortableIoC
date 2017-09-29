using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableIoCTests.TestHelpers
{
    public class SimpleBaz : IBaz
    {
        public SimpleBaz()
        {
            UniqueIdentifier = Guid.NewGuid();
        }

        public SimpleBaz(IFoo foo, IBar bar) : this()
        {
            Foo = foo;
            Bar = bar;
        }

        public IFoo Foo { get; set; }
        public IBar Bar { get; set; }
        public Guid UniqueIdentifier { get; private set; }
    }
}
