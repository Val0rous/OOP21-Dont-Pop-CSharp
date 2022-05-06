using System;

namespace Manuel_Tartagni
{

    public class RandomInt
    {
        public int RandomInt2 { get; private set; }


        /// <summary>
        /// Metodo per generare un intero casuale compreso tra <paramref name="min"/> e <paramref name="max"/>
        /// </summary>
        /// <param name="min">primo operando</param>
        /// <param name="max">secondo operando</param>
        /// <returns>In risultato dell'operazione</returns>
        /// 
        public int GetRandomInt(int min, int max)
        {
            var mathRandom = new Random().Next(int.MinValue, int.MaxValue);
            float randomN = mathRandom * (max - min);
            this.RandomInt2 = (int)Math.Round(randomN) + min;
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
