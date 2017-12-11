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
    class AnimateSprite
    {
       
            protected Texture2D[] texture;
            protected Texture2D currentTexture;
            protected int CurrentFrame=0;
            protected int TimeSinceLastFrame=0;
            protected int MillionsecondPerFrame = 50;
            protected Vector2 position;
            protected Vector2 velocity;
            protected SpriteEffects effect;
            protected Vector2 center;
            protected Vector2 origin;
            protected Rectangle source;
            protected float LastpositionX;
            //protected float LastpositionY;
            protected float CurrentpositionX;
           // protected float CurrentpositionY;
        protected float rotation;

            public Vector2 Center
            {
                get { return center; }
            }
            public Vector2 Position
            {
                get { return position; }
            }

            public AnimateSprite(Texture2D[] tex, Vector2 pos)
            {
                texture = tex;
                currentTexture = texture[0];
                position = pos;
                velocity = Vector2.Zero;

                center = new Vector2(position.X + currentTexture.Width /
                    2, position.Y + currentTexture.Height / 2);
                origin = new Vector2(currentTexture.Width / 2, currentTexture.Height / 2);
                source = new Rectangle(0,0, currentTexture.Width, currentTexture.Height);
                CurrentpositionX = position.X + currentTexture.Width / 2;
                LastpositionX = position.X + currentTexture.Width / 2;
            }

            public virtual void Update(GameTime gameTime)
            {
                this.center = new Vector2(position.X + currentTexture.Width / 2,
                position.Y + currentTexture.Height / 2);
                CurrentpositionX = position.X + currentTexture.Width / 2;
                TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeSinceLastFrame > MillionsecondPerFrame)
                {
                    TimeSinceLastFrame -= MillionsecondPerFrame;
                    CurrentFrame++;
                    TimeSinceLastFrame = 0;
                    if (CurrentFrame == 5)
                    {
                        CurrentFrame = 0;
                    }
                }
                currentTexture = texture[CurrentFrame];
                if (LastpositionX>CurrentpositionX)
                {
                    effect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    effect = SpriteEffects.None;
                }
                LastpositionX = CurrentpositionX;
            }
        

            public virtual void Draw(SpriteBatch spriteBatch)// Draw Sprite
            {
                spriteBatch.Draw(currentTexture, center, source, Color.White,
                  0, origin, 1.0f, effect, 0);
            }
            public virtual void Draw(SpriteBatch spriteBatch, Color color)// Draw Sprite 
            {
                spriteBatch.Draw(currentTexture, center, source, color, rotation,
                    origin, 1.0f, SpriteEffects.None, 0);
            }
        }
    }

