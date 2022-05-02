using System;

namespace Francesco_Valentini
{
    /// <summary>
    /// A standard generic Pair<E1, E2> with getters, HashCode, Equals, and ToString well implemented.
    /// </summary>
    /// <typeparam name="E1"></typeparam>
    /// <typeparam name="E2"></typeparam>
    public class Pair<E1, E2>
    {
        public E1 e1 { get; }
        public E2 e2 { get; }

        /// <summary>
        /// Builds a pair of two elements.
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        public Pair(E1 e1, E2 e2)
        {
            this.e1 = e1;
            this.e2 = e2;
        }

        /// <summary>
        /// Returns a hash code value for the object.
        /// </summary>
        /// <returns>a hash code for this Pair</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Checks if two pairs are equal to one another.
        /// </summary>
        /// <param name="obj"></param>
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
            if (GetType() != obj.GetType())
            {
                return false;
            }
            Pair<E1, E2> other = (Pair<E1, E2>) obj;
            return Object.Equals(this.e1, other.e1)
                    && Object.Equals(this.e2, other.e2);
        }

        /// <summary>
        /// Creates a string representation for this object.
        /// </summary>
        /// <returns>a string representation of this Pair</returns>
        public override string ToString() => "Pair [e1=" + this.e1 + ", e2=" + this.e2 + "]";
    }
}