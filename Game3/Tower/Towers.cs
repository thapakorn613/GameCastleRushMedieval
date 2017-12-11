using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3
{
    class Towers : Sprite
    {
        protected int cost; // How much will the tower cost to make
        protected int damage; // The damage done to enemy's

        protected float radius; // How far the tower can shoot

        protected Enemy target;

        protected Texture2D bulletTexture;

        protected float bulletTimer; // How long ago was a bullet fired
        protected List<Bullet> bulletList = new List<Bullet>();

        public int Cost
        {
            get { return cost; }
        }
        public int Damage
        {
            get { return damage; }
        }
        public virtual bool HasTarget
        {
            // Check if the tower has a target.
            get { return target != null; }
        }

        public float Radius
        {
            get { return radius; }
        }
        
        public Enemy Target
        {
            get { return target; }
        }

        public Towers(Texture2D texture, Texture2D bulletTexture, Vector2 position): base(texture, position)
        {
            this.bulletTexture = bulletTexture;
        }
        public bool IsInRange(Vector2 position)
        {
            return Vector2.Distance(center, position) <= radius;
        }
        public virtual void GetClosestEnemy(List<Enemy> enemies)// Target Closest Enemie
        {
            target = null;
            float smallestRange = radius;

            foreach (Enemy enemy in enemies)
            {
                if (Vector2.Distance(center, enemy.Center) < smallestRange)
                {
                    smallestRange = Vector2.Distance(center, enemy.Center);
                    target = enemy;
                }
            }
        }
        protected void FaceTarget()// face the enemie
        {
            Vector2 direction = center - target.Center;
            direction.Normalize();

            rotation = (float)Math.Atan2(-direction.X, direction.Y);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (target != null)
            {
                FaceTarget();

                if (!IsInRange(target.Center) || target.IsDead)
                {
                    target = null;
                    bulletTimer = 0;
                }
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in bulletList)
                bullet.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
