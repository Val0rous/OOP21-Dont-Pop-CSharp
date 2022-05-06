using System;
using System.Text;

namespace Manuel_Tartagni
{

    /// <summary>
    /// The Class WhereToSpawn. Provide a Point 2D where an enemy or a powerup will spawns.
    /// The enemies will be spawned outside the game window.The  Powerups will spawn inside the
    /// game windows
    /// </summary>
    public class WhereToSpawn
    {

        // TODO: DOC 
        public enum SideOfSpawn
        {

            /** The west. */
            WEST,
            /** The east. */
            EAST,
            /** The south. */
            SOUTH,
            /** The north. */
            NORTH
        }

        /// <summary>
        /// Gets a spawn point for power-ups.
        /// </summary>
        /// <returns>new Point2D</returns>
        public Point2D GetPowerUPSpawnPoint()
        {
            double n = new RandomInt().GetRandomInt(0, 100) / 100;
            return new Point2D(n * 0.6 + 0.2, n * 0.6 + 0.2);
        }

        /// <summary>
        /// Gets a spawn side for thornBalls.
        /// </summary>
        /// <returns>new Point2D</returns>
        public int GetThornballRandomSide() => 1 + (new RandomInt().GetRandomInt(0, 1) * 2);   //1 o 3

        /// <summary>
        /// Gets a spawn side for enemies and power-ups.
        /// </summary>
        /// <returns>new side for spawn</returns>
        public int GetRandomSide()
        {
            RandomInt randomInt = new RandomInt();
            int side = randomInt.GetRandomInt(1, 4);
            return side;
        }



        /// <summary>
        /// Gets a spawn Point2D for Thornballs.
        /// </summary>
        /// <param name="side">side of a thornball's  spawn</param>
        /// <returns>new Point2D for thornbal's spawn</returns>
        public Point2D GetThornballSpawnPoint(int side)
        {

            RandomInt randomInt = new RandomInt();
            int sideOfSpawn = this.GetThornballRandomSide();
            double randomNumber = randomInt.GetRandomInt(1, 100) / 100;
            if (sideOfSpawn ==  (int) SideOfSpawn.WEST)
            {
                return new Point2D(-0.2, randomNumber);
            }
            else if (sideOfSpawn == (int)SideOfSpawn.EAST)
            {
                return new Point2D(1.2, randomNumber);
            }
            return new Point2D(0.2, -0.2); //default spawn point
        }

        /// <summary>
        /// Gets a spawn Point2D for enemies.
        /// </summary>
        /// <param name="side">side of a enemy's  spawn</param>
        /// <returns>new Point2D for enemy's spawn</returns>
        public Point2D GetEnemySpawnPoint(int side)
        {

            RandomInt randomInt = new RandomInt();

            double randomNumber = (double)randomInt.GetRandomInt(0, 100) / 100;
            if (side == 1)
            {
                return new Point2D(-0.2, randomNumber);
            }
            else if (side == 2)

            {
                return new Point2D(randomNumber, 1.2);
            }
            else if (side == 3)
            {
                return new Point2D(1.2, randomNumber);
            }
            else if (side == 4)
            {
                return new Point2D(randomNumber, -0.2);
            }
            else
            {
                return new Point2D(0.2, -0.2);
            }
        }
        /// <summary>
        /// Returns a hash code value for the object.
        /// </summary>
        /// <returns>a hash code for this class</returns>
        public override int GetHashCode() => base.GetHashCode();

        //?

        /// <summary>
        /// Creates a string representation for this object.
        /// </summary>
        /// <returns>a string representation of this WhereToSpawn</returns>
        public override string ToString() => base.ToString();


        //?

        /// <summary>
        /// Checks if two pairs are equal to one another.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>true if two objects are equals </returns>
        public override bool Equals(object obj) => base.Equals(obj);
    }

}
