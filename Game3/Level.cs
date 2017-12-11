using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Game3
{
    class Level
    {
        private Queue<Vector2> waypoints = new Queue<Vector2>();// Way point
        public Level()// Add Start to the end
        {
            waypoints.Enqueue(new Vector2(3, 0) * 50);
            waypoints.Enqueue(new Vector2(3, 1) * 50);
            waypoints.Enqueue(new Vector2(0, 1) * 50);
            waypoints.Enqueue(new Vector2(0, 6) * 50);
            waypoints.Enqueue(new Vector2(3, 6) * 50);
            waypoints.Enqueue(new Vector2(3, 4) * 50);
            waypoints.Enqueue(new Vector2(7, 4) * 50);
            waypoints.Enqueue(new Vector2(7, 9) * 50);
            waypoints.Enqueue(new Vector2(0, 9) * 50);
            waypoints.Enqueue(new Vector2(0, 12) * 50);
            waypoints.Enqueue(new Vector2(10, 12) * 50);
            waypoints.Enqueue(new Vector2(10, 1) * 50);
            waypoints.Enqueue(new Vector2(6, 1) * 50);
            waypoints.Enqueue(new Vector2(6, 0) * 50);


        }
        public Queue<Vector2> Waypoints// Access to Queue
        {
            get { return waypoints; }
        }

        int[,] map = new int[,] // Create Map
        {  
            {8,8,9,1,5,6,1,7,8,8,8,},
            {1,1,1,1,5,6,1,1,1,1,1,},
            {1,2,3,3,0,0,3,3,3,4,1,},
            {1,5,0,8,8,8,8,8,0,6,1,},
            {1,5,6,1,1,1,1,1,5,6,1,},
            {1,7,9,1,2,3,4,1,5,6,1,},
            {1,1,1,1,5,0,6,1,5,6,1,},
            {3,3,3,3,0,0,6,1,5,6,1,},
            {8,8,8,8,8,8,9,1,5,6,1,},
            {1,1,1,1,1,1,1,1,5,6,1,},
            {1,2,3,3,3,3,3,3,0,6,1,},
            {1,7,8,8,8,8,8,8,8,9,1,},
            {1,1,1,1,1,1,1,1,1,1,1,},

        };

        private List<Texture2D> tileTextures = new List<Texture2D>(); // list of GPU Block

        public void AddTexture(Texture2D texture)// Pass the GPU
        {
            tileTextures.Add(texture);
        }

        public int GetIndex(int cellX, int cellY)
        {
            if (cellX < 0 || cellX > Width - 1 || cellY < 0 || cellY > Height - 1)
                return 0;

            return map[cellY, cellX];
        }

        public int Width 
        {
            get { return map.GetLength(1); }
        }

        public int Height 
        {
            get { return map.GetLength(0); }
        }

        public void Draw(SpriteBatch batch)// Draw map
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = tileTextures[textureIndex];
                    batch.Draw(texture, new Rectangle(
                        x * 50, y * 50, 50, 50), Color.White);
                }
            }
        }


    }
}
