using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Flappy{
    public class Floor : Sprite
    {

        public static Rectangle hitbox;
        bool isHitboxVisible = false;

        public Floor(Texture2D texture) : base(texture, new Vector2(0, GameDefaults.height - texture.Height))
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public override void Update()
        {
            position.X -= 5;
            if(position.X <= -texture.Width) position.X = 0;
        }
        public override void Draw()
        {
            

            GameDefaults.spriteBatch.Draw(texture, 
                                            position, 
                                            color);
            GameDefaults.spriteBatch.Draw(texture, 
                                        new Vector2(position.X + texture.Width, 
                                        position.Y), 
                                        color);

            if(isHitboxVisible)
            {
                GameDefaults.spriteBatch.Draw(GameDefaults.pixel, 
                                            hitbox, 
                                            Color.Blue);
            }
        }               
    }
}


