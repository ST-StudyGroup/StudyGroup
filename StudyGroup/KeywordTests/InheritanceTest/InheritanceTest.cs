using StudyGroup.KeywordTests.InheritanceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup
{
    public class InheritanceTest : ParentClass
    {
        public string InheritanceMethod()
        {
            return "This is the InheritanceMethod";
        }

        public void InheritanceDerivedMethod()
        {
            Console.WriteLine(ParentClassMethod());
        }
    }

    public class SealedInheritanceTest // : SealedParentClass  // ** Cannot inherit from a sealed type compilation error **
    {
       
    }
}
