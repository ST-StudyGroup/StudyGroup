using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup.KeywordTests
{
    public class CheckedTest
    {
        public int AccountTotalNotChecking(int newDeposits, bool notChecked = false)
        {
            int currentAccountValue = 2147483647;
            currentAccountValue += newDeposits;
            return currentAccountValue;
        }

        public int AccountTotalChecking(int newDeposits)
        {
            int currentAccountValue = 2147483647;

            checked
            {
                currentAccountValue += newDeposits;
            }

            return currentAccountValue;
        }
    }
}
