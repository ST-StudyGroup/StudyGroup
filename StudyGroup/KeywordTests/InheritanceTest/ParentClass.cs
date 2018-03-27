using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup.KeywordTests.InheritanceTest
{
    public class ParentClass
    {

        public string ParentClassMethod()
        {
            return "This is the ParentMethodClass";
        }
    }

    public sealed class SealedParentClass
    {
        public string SealedParentClassMethod()
        {
            return "This is the SealedParentClass";
        }
    }
}
