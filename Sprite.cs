
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flappy
{
    
    public abstract class Sprite
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 startPosition;
        protected Color color = Color.White;

        public Vector2 Position
        {
            get{return position;}
            set{position = value;}
        }
         public Vector2 StartPosition
        {
            get{return startPosition;}
        }


        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.startPosition = position;
            this.position = startPosition;
            
        }

        public abstract void Update();

        public abstract void Draw();
    }
}