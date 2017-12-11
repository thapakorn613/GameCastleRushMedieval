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
    class Wave 
    {
        private Texture2D healthTexture; // A texture for the health bar.
        private Player player;
        private int numOfEnemies; // Number of enemies to spawn
        private int waveNumber; // What wave is this?
        private float spawnTimer = 0; // When should we spawn an enemy
        private int enemiesSpawned = 0; // How mant enemies have spawned

        private bool enemyAtEnd; // Has an enemy reached the end of the path?
        private bool spawningEnemies; // Are we still spawing enemies?
        private Level level; // A reference of the level
        private Texture2D[] enemyTexture; // A texture for the enemies
        public List<Enemy> enemies = new List<Enemy>(); // List of enemies

        public bool RoundOver
        {
            get
            {
                return enemies.Count == 0 && enemiesSpawned == numOfEnemies;
            }
        }
        public int RoundNumber
        {
            get { return waveNumber; }
        }

        public bool EnemyAtEnd
        {
            get { return enemyAtEnd; }
            set { enemyAtEnd = value; }
        }
        public List<Enemy> Enemies
        {
            get { return enemies; }
        }
        public Wave(int waveNumber, int numOfEnemies,Player player, Level level, Texture2D[] enemyTexture, Texture2D healthTexture)
        {
            this.waveNumber = waveNumber;
            this.numOfEnemies = numOfEnemies;

            this.player = player; // Reference the player.
            this.level = level;

            this.enemyTexture = enemyTexture;
            this.healthTexture = healthTexture;
        }
        private void AddEnemy()// set wave
        {
            Enemy enemy = new Enemy(enemyTexture,// wave 1st
            level.Waypoints.Peek(), waveNumber * 50 + 20 ,3, 1.0f);// set hp
            if (waveNumber == 1)// set wave to fast enemie
            {
                float speed = 2.5f;
                enemy = new Enemy(enemyTexture,level.Waypoints.Peek(), 50, 3, speed);
            }
            if (waveNumber == 2)// set wave to fast enemie
            {
                enemy = new Enemy(enemyTexture, level.Waypoints.Peek(), 50, 3, 1.0f);
            }
            enemy.SetWaypoints(level.Waypoints);
            enemies.Add(enemy);
            spawnTimer = 0;
            enemiesSpawned++;
        }
        public void Start()
        {
            spawningEnemies = true;
        }
        

        public void Update(GameTime gameTime)
        {
            if (enemiesSpawned == numOfEnemies)
                spawningEnemies = false; // We have spawned enough enemies
            if (spawningEnemies)
            {
                spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnTimer > 1)
                    AddEnemy(); // Time to add a new enemey
            }
            if (enemiesSpawned == numOfEnemies)
                spawningEnemies = false; // We have spawned enough enemies
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Update(gameTime);
                if (enemy.IsDead)
                {
                    if (enemy.CurrentHealth > 0) // Enemy is at the end
                    {
                        enemyAtEnd = true;
                        player.Lives -= 1;
                    }

                    else
                    {
                        player.Money += enemy.BountyGiven;
                    }

                    enemies.Remove(enemy);
                    i--;
                }
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
                Rectangle healthRectangle = new Rectangle((int)enemy.Position.X+8, (int)enemy.Position.Y, healthTexture.Width, healthTexture.Height);

                spriteBatch.Draw(healthTexture, healthRectangle, Color.Gray);
                float healthPercentage = enemy.HealthPercentage;
                float visibleWidth = (float)healthTexture.Width * healthPercentage;

                healthRectangle = new Rectangle((int)enemy.Position.X+8,(int)enemy.Position.Y,(int)(visibleWidth),healthTexture.Height);

                float red = (healthPercentage < 0.5 ? 1 : 1 - (2 * healthPercentage - 1));
                float green = (healthPercentage > 0.5 ? 1 : (2 * healthPercentage));

                Color healthColor = new Color(red, green, 0);

                spriteBatch.Draw(healthTexture, healthRectangle, healthColor);
            }
        }


    }
}
