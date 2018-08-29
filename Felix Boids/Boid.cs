using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix_Boids
{
    public abstract class Boid
    {
        protected static Random rand = new Random();
        private static Vector2 border = new Vector2(100f, 100f);
        protected static float sight = 75f;
        protected static float separation = 30f;
        protected float speed;
        protected Vector2 boundary;

        protected Flock flock;
        protected Texture2D texture;

        protected Vector2 position;
        public Vector2 Position
        {
            get { return position; }
        }

        protected Vector2 offSet;
        public Vector2 Offset
        {
            get { return offSet; }

        }

        protected static Vector2 Border
        {
            get { return border; }
            set { border = value; }
        }

        public Boid(Vector2 boundary, Texture2D texture)
        {
            position = new Vector2(rand.Next((int)boundary.X), rand.Next((int)boundary.X));
            this.boundary = boundary;
            this.texture = texture;
        }

        public virtual void Update()
        {
            HandleEdgeCollision();
            LimitVelocity();
            position += offSet;
        }

        private void HandleEdgeCollision()
        {
            //Left & Top
            if (position.X < Border.X)
            {
                offSet.X += Border.X - position.X;
            }

            if (position.Y < Border.Y)
            {
                offSet.Y += Border.Y - position.Y;
            }

            //Right & bottom
            Vector2 farEnd = boundary - Border;

            if (position.X > farEnd.X)
            {
                offSet.X += farEnd.X - position.X;
            }

            if (position.Y > farEnd.Y)
            {
                offSet.Y += farEnd.Y - position.Y;
            }
        }

        protected void LimitVelocity()
        {
            float offSetLength = offSet.Length();

            if (offSetLength > speed)
            {
                offSet = offSet * speed / offSetLength;
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
