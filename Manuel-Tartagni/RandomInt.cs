using System;

namespace ManuelTartagni
{

    public class RandomInt
    {
        public int RandomInt2 { get; private set; }


        /// <summary>
        /// Generate a random integer number <paramref name="min"/> and <paramref name="max"/>
        /// </summary>
        /// <param name="min">first parameter</param>
        /// <param name="max">second parameter </param>
        /// <returns>Return a integer , random generated, number</returns>

        public int GetRandomInt(int min, int max)
        {
            this.RandomInt2 = new Random().Next(min, max);
            return this.RandomInt2;
        }

        /// <summary>
        /// Checks if two pairs are equal to one another.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>true if the two number are the equals</returns>
        public override bool Equals(object num)
        {
            if (num == null)
            {
                return false;
            }
            else if (num is int)
            {
                int n = (int)num;
                if (this.RandomInt2 == n)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Creates a string representation for this object.
        /// </summary>
        /// <returns>a string representation of this RandomInt</returns>
        public override string ToString() => $"RandomInt= {this.RandomInt2} ";

        /// <summary>
        /// Returns a hash code value for the object.
        /// </summary>
        /// <returns>a hash code for this RandomInt</returns>
        public override int GetHashCode() => base.GetHashCode();

    }

}
