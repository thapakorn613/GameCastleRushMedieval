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
    class Toolbar
    {
        private Texture2D texture;
        // A class to access the font we created
        private SpriteFont font;

        // The position of the toolbar
        private Vector2 position;
        // The position of the text
        private Vector2 GoldtextPosition;
        private Vector2 LifetextPosition;
        public Toolbar(Texture2D texture, SpriteFont font, Vector2 position)
        {
            this.texture = texture;
            this.font = font;

            this.position = position;
            // Offset the text to the bottom right corner
            GoldtextPosition = new Vector2(400, position.Y + 20);
            LifetextPosition = new Vector2(400, position.Y + 50);
            
        }
        public void Draw(SpriteBatch spriteBatch, Player player)
        {
            spriteBatch.Draw(texture, position, Color.White);
            
            string Gtext = string.Format("Gold : {0}", player.Money);
            string Ltext = string.Format("Lives : {0}", player.Lives);
            spriteBatch.DrawString(font, Gtext, GoldtextPosition, Color.Gold);
            spriteBatch.DrawString(font, Ltext, LifetextPosition, Color.Red);
        }


    }
}
