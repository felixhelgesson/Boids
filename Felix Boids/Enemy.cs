using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix_Boids
{
    class Enemy : Boid
    {
        public Enemy(Vector2 boundary, Flock flock, Texture2D texture)
       : base(boundary, texture)
        {
            this.flock = flock;
            speed = 3f;
        }

        public override void Update()
        {
            Hunt();
            base.Update();
        }

        private void Hunt()
        {
            var inSight = flock.Boids.Where(b => b is StandardBoid == Vector2.Distance(position, b.Position) < sight);
            var sort = inSight.OrderBy(b => Vector2.Distance(position, b.Position));
            var nearest = sort.FirstOrDefault();
            Boid p = nearest;

            if (p != null)
            {
                offSet += p.Position - position;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.Red);
        }
    }
}
