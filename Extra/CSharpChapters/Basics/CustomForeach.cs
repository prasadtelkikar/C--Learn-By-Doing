using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Basics
    {
    public class CustomForeach
        {
        public static void Main (string[] args)
            {
            CollectionsSet set = new CollectionsSet();
            foreach ( var value in set )
                {
                Console.WriteLine(value);
                }
            Console.ReadKey();
            }
        }

    public class CollectionsSet
        {
        public IEnumerator<string> GetEnumerator ()
            {
            yield return "Hello";
            yield return "World";
            yield return "!!";
            }
        }
    }