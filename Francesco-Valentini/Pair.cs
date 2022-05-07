using System;

namespace FrancescoValentini
{
    /// A standard generic Pair class with getters, HashCode, Equals, and ToString well implemented.
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class Pair<T1, T2>
    {
        /// First element of Pair.
        public T1 First { get; }

        /// Second element of Pair.
        public T2 Second { get; }

        /// Builds a pair of two elements.
        /// <param name="first">first element of pair</param>
        /// <param name="second">second element of pair</param>
        public Pair(T1 first, T2 second)
        {
            this.First = first;
            this.Second = second;
        }

        /// Returns a hash code value for the object.
        /// <returns>a hash code for this Pair</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// Checks if two pairs are equal to one another.
        /// <param name="obj">the object that's gonna be checked for equality</param>
        /// <returns>true if the two pairs are the same</returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            var other = (Pair<T1, T2>) obj;
            return Object.Equals(this.First, other.First)
                    && Object.Equals(this.Second, other.Second);
        }

        /// Creates a string representation for this object.
        /// <returns>a string representation of this Pair</returns>
        public override string ToString() => "Pair [e1=" + this.First + ", e2=" + this.Second + "]";
    }
}
