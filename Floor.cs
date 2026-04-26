using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Flappy{
    public class Floor : Sprite
    {
        public Floor(Texture2D texture) : base(texture, new Vector2(0, GameDefaults.height - texture.Height)){}
        public override void Update()
        {
            position.X -= 5;
            if(position.X <= -texture.Width) position.X = 0;
        }
        public override void Draw()
        {
            GameDefaults.spriteBatch.Draw(texture, position, color);
            GameDefaults.spriteBatch.Draw(texture, new Vector2(position.X + texture.Width, position.Y), color);
        }               
    }
}


