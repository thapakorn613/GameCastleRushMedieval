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
        private Texture2D backGround;
        public void AddTexture(Texture2D texture)// Pass the GPU
        {
            backGround = texture;
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(backGround, new Rectangle(0, 0, 990, 770), Color.White);
        }
    }
}
