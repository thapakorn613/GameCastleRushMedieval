﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// tang na hee
    /// Art Ronin
    /// 7-11 TEST
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Level level = new Level();
        Level2 level2 = new Level2();
        Level3 level3 = new Level3();
        //Enemy enemy1;
        //Wave wave;
        WaveManeger waveManeger;
        WaveManeger2 waveManeger2;
        Background background = new Background();
        //Tower tower;
        Player player;
        Toolbar toolBar;
        Button arrowButton;
        Button slowButton;
        Button snipeButton;
        Button StartButton;
        Button Stage1Button;
        Button Stage2Button;
        Button Stage3Button;
        String state = "StartScreen";


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = level.Width * 50 + 400;// set window
            graphics.PreferredBackBufferHeight = level.Height * 50 + 91;
                ;
            graphics.ApplyChanges();
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D grass = Content.Load<Texture2D>("Block/grass");
            Texture2D path = Content.Load<Texture2D>("Block/path");
            Texture2D pathLT = Content.Load<Texture2D>("Block/pathLT");
            Texture2D pathT = Content.Load<Texture2D>("Block/pathT");
            Texture2D pathRT = Content.Load<Texture2D>("Block/pathRT");
            Texture2D pathL = Content.Load<Texture2D>("Block/pathL");
            Texture2D pathR = Content.Load<Texture2D>("Block/pathR");
            Texture2D pathLD = Content.Load<Texture2D>("Block/pathLD");
            Texture2D pathD = Content.Load<Texture2D>("Block/pathD");
            Texture2D pathRD = Content.Load<Texture2D>("Block/pathRD");
            level.AddTexture(grass);// Add Block GPU
            level.AddTexture(path);
            level.AddTexture(pathLT);
            level.AddTexture(pathT);
            level.AddTexture(pathRT);
            level.AddTexture(pathL);
            level.AddTexture(pathR);
            level.AddTexture(pathLD);
            level.AddTexture(pathD);
            level.AddTexture(pathRD);

            level2.AddTexture(grass);// level 2 texture
            level2.AddTexture(path);
            level2.AddTexture(pathLT);
            level2.AddTexture(pathT);
            level2.AddTexture(pathRT);
            level2.AddTexture(pathL);
            level2.AddTexture(pathR);
            level2.AddTexture(pathLD);
            level2.AddTexture(pathD);
            level2.AddTexture(pathRD);

            Texture2D tile = Content.Load<Texture2D>("tile");
            Texture2D path3 = Content.Load<Texture2D>("Block/path");
            Texture2D pathLT3 = Content.Load<Texture2D>("Block/pathLT");
            Texture2D pathT3 = Content.Load<Texture2D>("Block/pathT");
            Texture2D pathRT3 = Content.Load<Texture2D>("Block/pathRT");
            Texture2D pathL3 = Content.Load<Texture2D>("Block/pathL");
            Texture2D pathR3 = Content.Load<Texture2D>("Block/pathR");
            Texture2D pathLD3 = Content.Load<Texture2D>("Block/pathLD");
            Texture2D pathD3 = Content.Load<Texture2D>("Block/pathD");
            Texture2D pathRD3 = Content.Load<Texture2D>("Block/pathRD");
            level3.AddTexture(tile);// level 2 texture
            level3.AddTexture(path3);
            level3.AddTexture(pathLT3);
            level3.AddTexture(pathT3);
            level3.AddTexture(pathRT3);
            level3.AddTexture(pathL3);
            level3.AddTexture(pathR3);
            level3.AddTexture(pathLD3);
            level3.AddTexture(pathD3);
            level3.AddTexture(pathRD3);


            Texture2D[] back = new Texture2D[]
            {
                Content.Load<Texture2D>("background")
            };
            background.AddTexture(back);
            Texture2D[] enemyTexture = new Texture2D[]
            {
                Content.Load<Texture2D>("Enemy/Elf1"),
                Content.Load<Texture2D>("Enemy/Elf2"),
                Content.Load<Texture2D>("Enemy/Elf3"),
                Content.Load<Texture2D>("Enemy/Elf4"),
                Content.Load<Texture2D>("Enemy/Elf5")
            };
            //enemy1 = new Enemy(enemyTexture, Vector2.Zero, 100, 10, 1f);// change speed;
            //enemy1.SetWaypoints(level.Waypoints);


            Texture2D[] towerTextures = new Texture2D[]
            {
                Content.Load<Texture2D>("Tower/tower"),
                Content.Load<Texture2D>("Tower/Slow"),
                Content.Load<Texture2D>("Tower/Snipe")
            };
            Texture2D bulletTexture = Content.Load<Texture2D>("Tower/bullet");
            player = new Player(level, towerTextures, bulletTexture);
            Texture2D healthTexture = Content.Load<Texture2D>("HP");

            // set number of wave
            waveManeger = new WaveManeger(player, level, 16, enemyTexture,healthTexture);// set wave1
            waveManeger2 = new WaveManeger2(player, level2, 20, enemyTexture, healthTexture);// set wave2
            Texture2D topBar = Content.Load<Texture2D>("toolbar");
            SpriteFont font = Content.Load<SpriteFont>("Arial");

            toolBar = new Toolbar(topBar, font, new Vector2(0, level.Height * 50));

            // The "Normal" texture for the arrow button.
            Texture2D arrowNormal = Content.Load<Texture2D>("Tower/tower");
            // The "MouseOver" texture for the arrow button.
            Texture2D arrowHover = Content.Load<Texture2D>("Tower/tower");
            // The "Pressed" texture for the arrow button.
            Texture2D arrowPressed = Content.Load<Texture2D>("Tower/tower");
            // The "Normal" texture for the spike button.
            Texture2D slowNormal = Content.Load<Texture2D>("Tower/Slow");
            // The "MouseOver" texture for the spike button.
            Texture2D slowHover = Content.Load<Texture2D>("Tower/Slow");
            // The "Pressed" texture for the spike button.
            Texture2D slowPressed = Content.Load<Texture2D>("Tower/Slow");
            Texture2D snipeNormal = Content.Load<Texture2D>("Tower/Snipe");
            Texture2D snipeHover = Content.Load<Texture2D>("Tower/Snipe");
            Texture2D snipePressed = Content.Load<Texture2D>("Tower/Snipe");
            Texture2D StartNormal = Content.Load<Texture2D>("StartButtonPress");
            Texture2D StartHover = Content.Load<Texture2D>("StartButtonPress");
            Texture2D StartPressed = Content.Load<Texture2D>("StartButtonNormal");
            SpriteFont font2 = Content.Load<SpriteFont>("Descrip");
            // SpriteFont text_data_wave = Content.Load<SpriteFont>("textFont/File");
            // Initialize the arrow button.
            arrowButton = new Button(arrowNormal, arrowHover,arrowPressed, new Vector2(40, level.Height * 50 + 20),font2, "Arrow");
            arrowButton.Clicked += new EventHandler(arrowButton_Clicked);
            // Initialize the spike button.
            slowButton = new Button(slowNormal, slowHover, slowPressed, new Vector2(120, level.Height * 50 + 20), font2, "Slow");
            slowButton.Clicked += new EventHandler(slowButton_Clicked);

            snipeButton = new Button(snipeNormal, snipeHover, snipePressed, new Vector2(200, level.Height * 50 + 20), font2,"Snipe");
            snipeButton.Clicked += new EventHandler(snipeButton_Clicked);

            arrowButton.OnPress += new EventHandler(arrowButton_OnPress);
            slowButton.OnPress += new EventHandler(slowButton_OnPress);
            snipeButton.OnPress += new EventHandler(snipeButton_OnPress);

            StartButton = new Button(StartNormal, StartHover, StartPressed, new Vector2(375, 600), font2,"Start");
            StartButton.Clicked += new EventHandler(StartButton_Clicked);

            Stage1Button = new Button(StartNormal, StartHover, StartPressed, new Vector2(100, 600), font2, "Stage1");
            Stage1Button.Clicked += new EventHandler(Stage1Button_Clicked);
            Stage2Button = new Button(StartNormal, StartHover, StartPressed, new Vector2(400, 600), font2, "Stage2");
            Stage2Button.Clicked += new EventHandler(Stage2Button_Clicked);
            Stage3Button = new Button(StartNormal, StartHover, StartPressed, new Vector2(700, 600), font2, "Stage3");
            Stage3Button.Clicked += new EventHandler(Stage3Button_Clicked);


        }
        private void arrowButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "Arrow Tower";
            player.NewTowerIndex = 0;
        }
        private void slowButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "Slow Tower";
            player.NewTowerIndex = 1;
        }
        private void snipeButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "Snipe Tower";
            player.NewTowerIndex = 2;
        }
        private void arrowButton_OnPress(object sender, EventArgs e)
        {
            player.NewTowerType = "Arrow Tower";
            player.NewTowerIndex = 0;
        }
        private void slowButton_OnPress(object sender, EventArgs e)
        {
            player.NewTowerType = "Slow Tower";
            player.NewTowerIndex = 1;
        }
        private void snipeButton_OnPress(object sender, EventArgs e)
        {
            player.NewTowerType = "Snipe Tower";
            player.NewTowerIndex = 2;
        }
        private void StartButton_Clicked(object sender, EventArgs e)
        {
            this.state = "Menu";
        }
        private void Stage1Button_Clicked(object sender, EventArgs e)
        {
            this.state = "Stage1";
        }
        private void Stage2Button_Clicked(object sender, EventArgs e)
        {
            this.state = "Stage2";
        }
        private void Stage3Button_Clicked(object sender, EventArgs e)
        {
            this.state = "Stage3";
        }



        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (state == "StartScreen")
            {
                 StartButton.Update(gameTime);
            }
            else if(state == "Menu")
            {
                Stage1Button.Update(gameTime);
                Stage2Button.Update(gameTime);
                Stage3Button.Update(gameTime);
            }
            else if (state == "Stage1")
            {
                waveManeger.Update(gameTime);
                player.Update(gameTime, waveManeger.Enemies);
                arrowButton.Update(gameTime);
                slowButton.Update(gameTime);
                snipeButton.Update(gameTime);
            }
            else if (state == "Stage2")
            {
                waveManeger2.Update(gameTime);
                player.Update(gameTime, waveManeger.Enemies);
                arrowButton.Update(gameTime);
                slowButton.Update(gameTime);
                snipeButton.Update(gameTime);
            }
            else {
                waveManeger.Update(gameTime);
            player.Update(gameTime, waveManeger.Enemies);
            arrowButton.Update(gameTime);
            slowButton.Update(gameTime);
            snipeButton.Update(gameTime);
            }
            
            
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            if(state == "StartScreen")
            {
                background.Draw(spriteBatch);
                StartButton.Draw(spriteBatch);
            }
            else if (state == "Menu")
            {
                Stage1Button.Draw(spriteBatch);
                Stage2Button.Draw(spriteBatch);
                Stage3Button.Draw(spriteBatch);
            }
            else if (state == "Stage1")
            {
                level.Draw(spriteBatch);
                waveManeger.Draw(spriteBatch);
                player.Draw(spriteBatch);
                toolBar.Draw(spriteBatch, player);
                arrowButton.Draw(spriteBatch);
                slowButton.Draw(spriteBatch);
                snipeButton.Draw(spriteBatch);
                player.DrawPreview(spriteBatch);
            }
            else if (state == "Stage2")
            {
                level2.Draw(spriteBatch);
                waveManeger2.Draw(spriteBatch);
                player.Draw(spriteBatch);
                toolBar.Draw(spriteBatch, player);
                arrowButton.Draw(spriteBatch);
                slowButton.Draw(spriteBatch);
                snipeButton.Draw(spriteBatch);
                player.DrawPreview(spriteBatch);
            }
            else {
                level3.Draw(spriteBatch);
                //waveManeger.Draw(spriteBatch);
                player.Draw(spriteBatch);
                toolBar.Draw(spriteBatch, player);
                arrowButton.Draw(spriteBatch);
                slowButton.Draw(spriteBatch);
                snipeButton.Draw(spriteBatch);
                player.DrawPreview(spriteBatch);
            }
            


            base.Draw(gameTime);


            spriteBatch.End();
        }
    }
}
