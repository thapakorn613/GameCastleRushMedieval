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
    class Background
    {
        private Texture2D[] backGround;
        private Texture2D BGtextures;
        public void AddTexture(Texture2D[] texture)// Pass the GPU
        {
            backGround = texture;
            BGtextures = backGround[0];
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(BGtextures, new Rectangle(0, 0, 950,741), Color.White);
        }
    }
}
