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
    public enum ButtonStatus
    {
        Normal,
        MouseOver,
        Pressed,
    }

    class Button : Sprite
    {
        
        // Store the MouseState of the last frame.
        private MouseState previousState;

        // The the different state textures.
        private Texture2D hoverTexture;
        private Texture2D pressedTexture;

        // A rectangle that covers the button.
        private Rectangle bounds;

        // Store the current state of the button.
        private ButtonStatus state = ButtonStatus.Normal;
        // Gets fired when the button is pressed.
        public event EventHandler Clicked;
        // Gets fired when the button is held down.
        public event EventHandler OnPress;

        public string Currentstate;


        /// <summary>
        /// Constructs a new button.
        /// </summary>
        /// <param name="texture">The normal texture for the button.</param>
        /// <param name="hoverTexture">The texture drawn when the mouse is over the button.</param>
        /// <param name="pressedTexture">The texture drawn when the button has been pressed.</param>
        /// <param name="position">The position where the button will be drawn.</param>
        public Button(Texture2D texture, Texture2D hoverTexture, Texture2D pressedTexture, Vector2 position,SpriteFont font,string mainstate)
         : base(texture, position)
        {
            this.hoverTexture = hoverTexture;
            this.pressedTexture = pressedTexture;
            this.font = font;
            this.bounds = new Rectangle((int)position.X, (int)position.Y,
                texture.Width, texture.Height);
            this.Currentstate = mainstate;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;

            bool isMouseOver = bounds.Contains(mouseX, mouseY);
            if (isMouseOver && state != ButtonStatus.Pressed)
            {
                state = ButtonStatus.MouseOver;
            }
            else if (isMouseOver == false && state != ButtonStatus.Pressed)
            {
                state = ButtonStatus.Normal;
            }
            // Check if the player holds down the button.
            if (mouseState.LeftButton == ButtonState.Pressed &&
             previousState.LeftButton == ButtonState.Released)
            {
                if (isMouseOver == true)
                {
                    // Update the button state.
                    state = ButtonStatus.Pressed;
                    if (OnPress != null)
                    {
                        // Fire the OnPress event.
                        OnPress(this, EventArgs.Empty);
                    }
                }
                
            }

            // Check if the player releases the button.
            if (mouseState.LeftButton == ButtonState.Released &&
             previousState.LeftButton == ButtonState.Pressed)
            {
                if (isMouseOver == true)
                {
                    // update the button state.
                    state = ButtonStatus.MouseOver;

                    if (Clicked != null)
                    {
                        // Fire the clicked event.
                        Clicked(this, EventArgs.Empty);
                    }

                }

                else if (state == ButtonStatus.Pressed)
                {
                    state = ButtonStatus.Normal;
                }
            }

            previousState = mouseState;

        }

        private Vector2 DesctextPosition;
        private SpriteFont font;

        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (state)
            {

                case ButtonStatus.Normal:
                    
                    spriteBatch.Draw(texture, bounds, Color.White);
                    break;
                case ButtonStatus.MouseOver:
                    if(Currentstate == "Start")
                    {
                        spriteBatch.Draw(hoverTexture, bounds, Color.White);
                        string text = string.Format("Have fun!!");
                        DesctextPosition = new Vector2(300, 300);
                        spriteBatch.DrawString(font, text, DesctextPosition, Color.Black);
                    }
                    else if (Currentstate == "Stage1")
                    {
                        spriteBatch.Draw(hoverTexture, bounds, Color.White);
                        string text = string.Format("Stage1");
                        DesctextPosition = new Vector2(150, 570);
                        spriteBatch.DrawString(font, text, DesctextPosition, Color.Black);
                    }
                    else if (Currentstate == "Stage2")
                    {
                        spriteBatch.Draw(hoverTexture, bounds, Color.White);
                        string text = string.Format("Stage2");
                        DesctextPosition = new Vector2(450, 570);
                        spriteBatch.DrawString(font, text, DesctextPosition, Color.Black);
                    }
                    else if (Currentstate == "Stage3")
                    {
                        spriteBatch.Draw(hoverTexture, bounds, Color.White);
                        string text = string.Format("Stage3");
                        DesctextPosition = new Vector2(750, 570);
                        spriteBatch.DrawString(font, text, DesctextPosition, Color.Black);
                    }
                    else
                    {

                        spriteBatch.Draw(hoverTexture, bounds, Color.White);
                    
                    }
                    
                    break;
                case ButtonStatus.Pressed:

                    spriteBatch.Draw(pressedTexture, bounds, Color.White);
                    break;
                default:
                    spriteBatch.Draw(texture, bounds, Color.White);
                    break;
            }
        }

    }

}
