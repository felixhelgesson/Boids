using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix_Boids
{
    public class Flock
    {

        public List<Boid> Boids = new List<Boid>();

        public Flock(Vector2 bounds, int nrOfBoids, int nrOfEnemies, Texture2D tex)
        {
            for (int i = 0; i < nrOfBoids; i++)
            {
                Boids.Add(new StandardBoid(bounds, this, tex));
            }

            for (int i = 0; i < nrOfEnemies; i++)
            {
                Boids.Add(new Enemy(bounds, this, tex));
            }
        }

        public void Update()
        {
            foreach (Boid boid in Boids)
            {
                boid.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Boid boid in Boids)
            {
                boid.Draw(spriteBatch);
            }
        }
    }
}
