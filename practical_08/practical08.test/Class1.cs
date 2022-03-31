using NUnit.Framework;
using practical_08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical08.test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void Chkstring()
        {
            var s = new testcase();
            Assert.That(s.strcomp(), Is.EqualTo("Hello world"));
        }
    }
    
}
