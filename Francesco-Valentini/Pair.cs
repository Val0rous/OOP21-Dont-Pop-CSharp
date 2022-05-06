using System;

namespace Francesco_Valentini
{
    /// A standard generic Pair<E1, E2> with getters, HashCode, Equals, and ToString well implemented.
    /// <typeparam name="E1"></typeparam>
    /// <typeparam name="E2"></typeparam>
    public class Pair<E1, E2>
    {
        /// First element of Pair.
        public E1 e1 { get; }

        /// Second element of Pair.
        public E2 e2 { get; }

        /// Builds a pair of two elements.
        /// <param name="e1">first element of pair</param>
        /// <param name="e2">second element of pair</param>
        public Pair(E1 e1, E2 e2)
        {
            this.e1 = e1;
            this.e2 = e2;
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
            var other = (Pair<E1, E2>) obj;
            return Object.Equals(this.e1, other.e1)
                    && Object.Equals(this.e2, other.e2);
        }

        /// Creates a string representation for this object.
        /// <returns>a string representation of this Pair</returns>
        public override string ToString() => "Pair [e1=" + this.e1 + ", e2=" + this.e2 + "]";
    }
}
