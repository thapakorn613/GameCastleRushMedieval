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
    class WaveManeger2
    {
        private int numberOfWaves; // How many waves the game will have
        private float timeSinceLastWave; // How long since the last wave ended

        private Queue<Wave2> waves = new Queue<Wave2>(); // A queue of all our waves

        private Texture2D[] enemyTexture; // The texture used to draw the enemies

        private bool waveFinished = false; // Is the current wave over?

        private Level2 level; // A reference to our level class

        public Texture2D CurrentFrame;

        public Wave2 CurrentWave // Get the wave at the front of the queue
        {
            get { return waves.Peek(); }
        }

        public List<Enemy> Enemies // Get a list of the current enemeies
        {
            get { return CurrentWave.Enemies; }
        }

        public int Round // Returns the wave number
        {
            get { return CurrentWave.RoundNumber + 1; }
        }
        public WaveManeger2(Player player, Level2 level, int numberOfWaves, Texture2D[] enemyTexture, Texture2D healthTexture)
        {
            this.numberOfWaves = numberOfWaves;
            this.enemyTexture = enemyTexture;
            this.level = level;

            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumerOfEnemies = 6;
                int numberModifier = (i / 6) + 1;

                if (i == 0)
                {
                    initialNumerOfEnemies = 10;
                }
                // Pass the reference to the player, to the wave class.
                Wave2 wave = new Wave2(i, initialNumerOfEnemies, player, level, enemyTexture, healthTexture);
                ;

                waves.Enqueue(wave);
            }

            StartNextWave();
        }

        private void StartNextWave()
        {
            if (waves.Count > 0) // If there are still waves left
            {
                waves.Peek().Start(); // Start the next one

                timeSinceLastWave = 0; // Reset timer
                waveFinished = false;
            }
        }
        public void Update(GameTime gameTime)
        {
            CurrentWave.Update(gameTime); // Update the wave

            if (CurrentWave.RoundOver) // Check if it has finished
            {

                waveFinished = true;
            }

            if (waveFinished) // If it has finished
            {
                timeSinceLastWave += (float)gameTime.ElapsedGameTime.TotalSeconds; // Start the timer
            }

            if (timeSinceLastWave > 2.0f) // If 30 seconds has passed
            {
                waves.Dequeue(); // Remove the finished wave
                StartNextWave(); // Start the next wave
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentWave.Draw(spriteBatch);
        }

    }
}
