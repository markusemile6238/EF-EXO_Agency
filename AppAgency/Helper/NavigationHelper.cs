using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgency.Helper
{
    public class NavigationHelper
    {
        public static bool ShouldContinue()
        {
            var k = Console.ReadKey(true);

            return k.Key switch
            {
                ConsoleKey.O => true,
                ConsoleKey.N => false,
                ConsoleKey.X => throw new OperationCanceledException(),
                _=>true
            };
        }
    }
}
