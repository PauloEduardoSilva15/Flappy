
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flappy
{
    
    public abstract class Sprite
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Color color = Color.White;




        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            
        }

        public abstract void Update();

        public abstract void Draw();
    }
}