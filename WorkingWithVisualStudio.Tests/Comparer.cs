using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingWithVisualStudio.Tests
{
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisonFunction;

        public Comparer(Func<T, T, bool> func)
        {
            comparisonFunction = func;
        }

        //here we are creating our own equals method to check for equality between the two objects of type T (could be anything).
        //we earlier passed a function when we created an instance of comparer
        public bool Equals(T x, T y)
        {
            return comparisonFunction(x, y);
        }

        //get hash code is required for iequalitycomparer interface. We can change how it works here, but using obj.gethashcode is what we want
        //obj.gethashcode returns an int hash code that is generated automatically and is used in hash-based collections such as dictionary. 
        //hash codes are generally used in algorithms that need quick checks of object equality (such as the Distinct() method that can be used on enumerables/queryables
        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}
