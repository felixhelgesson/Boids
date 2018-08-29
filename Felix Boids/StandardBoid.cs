using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Felix_Boids
{
    class StandardBoid : Boid
    {
        Vector2 vel;

        public StandardBoid(Vector2 boundary, Flock flock, Texture2D texture)
        : base(boundary, texture)
        {
            this.flock = flock;
            speed = 4f;
        }
        public override void Update()
        {
            Flock();

            base.Update();
        }

        private void Flock()
        {
            foreach (Boid boid in flock.Boids.Where(boid => boid is StandardBoid))
            {
                float dist = Vector2.Distance(position, boid.Position);

                if (dist < separation)
                {
                    offSet += position - boid.Position;
                }
                else if (dist < sight)
                {
                    offSet += (boid.Position - position) * 0.025f;
                }

                if (dist < sight)
                {
                    offSet += boid.Offset * 1.5f;
                }

                vel = boid.Offset;
            }

            foreach (Boid enemy in flock.Boids.Where(enemy => enemy is Enemy))
            {
                float distEnemy = Vector2.Distance(position, enemy.Position);

                if (distEnemy < sight)
                {
                    offSet += (position - enemy.Position) * 1.5f;
                }
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            //spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 0, 0), null, Color.Green, (float)Math.Atan2(vel.X, vel.Y), new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 1f);
        }
    }
}
