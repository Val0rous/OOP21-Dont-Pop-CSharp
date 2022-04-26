using System;

namespace DontPop
{
    public class Pair implements Serializable
    {
        private static readonly Int64 _serialVersionUID = 1;

        private readonly E1 _e1;
        private readonly E2 _e2;

        public Pair(E1 e1, E2 e2)
        {
            super();
            _e1 = e1;
            _e2 = e2;
        }

        public E1 Get1()
        {
            return _e1;
        }

        public E2 Get2()
        {
            return _e2;
        }

        public Int32 HashCode()
        {
            return Objects.hash(_e1, e2);
        }

        public Boolean Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (GetClass() != obj.GetClass())
            {
                return false;
            }
            readonly Pair other = (Pair) obj;
            return Objects.Equals(_e1, other._e1)
                    && Objects.Equals(e2, other._e2);
        }

        public String ToString()
        {
            return "Pair [e1=" + _e1 + ", e2=" + _e2 + "]";
        }
    }
}