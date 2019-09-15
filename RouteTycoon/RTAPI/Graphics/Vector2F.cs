using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteTycoon.RTAPI.Graphics
{
    public class Vector2F
    {
        public float xpos;
        public float ypos;

        public static float worldXpos;
        public static float worldYpos;

        public Vector2F()
        {
            this.xpos = 0.0f;
            this.ypos = 0.0f;
        }

        public Vector2F(float xpos, float ypos)
        {
            this.xpos = xpos;
            this.ypos = ypos;
        }

        public static Vector2F zero()
        {
            return new Vector2F(0, 0);
        }

        public void normalize()
        {
            double length = Math.Sqrt(xpos * xpos + ypos * ypos);

            if (length != 0.0)
            {
                float s = 1.0f / (float)length;
                xpos = xpos * s;
                ypos = ypos * s;
            }
        }

        public Vector2F getScreenLoacation()
        {
            return new Vector2F(xpos, ypos);
        }

        public Vector2F getWorldScreenLoacation()
        {
            return new Vector2F(xpos - worldXpos, ypos - worldYpos);
        }

		public override bool Equals(object obj)
		{
			if (!(obj is Vector2F)) return false;

			Vector2F vec = obj as Vector2F;

			return (this.xpos == vec.xpos && this.ypos == vec.ypos);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public bool equlas(Vector2F vec)
		{
			return this.Equals(vec);
		}

		public Vector2F copy(Vector2F vec)
        {
            xpos = vec.xpos;
            ypos = vec.ypos;

            return new Vector2F(xpos, ypos);
        }

        public Vector2F add(Vector2F vec)
        {
            xpos = xpos + vec.xpos;
            ypos = xpos + vec.ypos;

            return new Vector2F(xpos, ypos);
        }

        public static void setWorldVaribles(float wx, float wy)
        {
            worldXpos = wx;
            worldYpos = wy;
        }

        public static double getDistanceOnScreen(Vector2F vec1, Vector2F vec2)
        {
            float v1 = vec1.xpos - vec2.xpos;
            float v2 = vec1.ypos - vec2.ypos;

            return Math.Sqrt(v1 * v1 + v2 * v2);
        }

        public double getDistanceBetweenWorldVectors(Vector2F vec)
        {
            float dx = Math.Abs(getWorldScreenLoacation().xpos - vec.getWorldScreenLoacation().xpos);
            float dy = Math.Abs(getWorldScreenLoacation().ypos - vec.getWorldScreenLoacation().ypos);

            return Math.Abs(dx * dx - dy * dy);
        }
    }
}
