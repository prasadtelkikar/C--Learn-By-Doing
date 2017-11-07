using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
    {
    class EnumeratorFunctions
        {
        string[] names = { "ABC", "EFG", "PQR", "XYZ" };
        public IEnumerator<string> GetEnumerator ()
            {
            for ( int i = 0; i < names.Length; i++ )
                yield return names[i];
            }
        public IEnumerable<string> Reverse ()
            {
            for ( int i = names.Length - 1; i >= 0; i-- )
                yield return names[i];
            }
        public IEnumerable<string> Subset (int startingIndex, int length)
            {
            for ( int i = startingIndex; i < startingIndex + length; i++ )
                {
                yield return names[i];
                }
            }
        }

    public class UseOfEnumerator
        {
        public static void Main (string[] args)
            {
            EnumeratorFunctions enumFunct = new EnumeratorFunctions();

            Console.WriteLine("Foreach in forward direction");
            foreach ( string values in enumFunct )
                {
                Console.WriteLine(values);
                }

            Console.WriteLine();
            Console.WriteLine("Foreach in reverse direction");
            foreach ( var values in enumFunct.Reverse() )
                {
                Console.WriteLine(values);
                }

            Console.WriteLine();
            Console.WriteLine("Subset of foreach");
            foreach ( var value in enumFunct.Subset(2, 2) )
                {
                Console.WriteLine(value);
                }
            Console.ReadKey();
            }
        }
    }
