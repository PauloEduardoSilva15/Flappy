using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flappy
{
    public class Pipe : Sprite
    {
        Random random = new Random();

        float velocity = 5;    

        public static Rectangle hitboxPipe1;
        public static Rectangle hitboxPipe2;

        public static Rectangle pointMarker;

        bool isHitboxVisible = false;

        public Pipe(Texture2D texture, Vector2 origin) : base(texture, origin)
        {
            hitboxPipe1 = new Rectangle((int)position.X, 
                                        (int)position.Y + 200, 
                                        texture.Width, 
                                        texture.Height);

            hitboxPipe2 = new Rectangle((int)position.X, 
                                        (int)position.Y - texture.Height, 
                                        texture.Width, 
                                        texture.Height);
            pointMarker = new Rectangle((int)position.X + texture.Width/2,
                                        (int)position.Y,
                                        1,
                                        200);
        }

        public override void Update()
        {
            position.X -= velocity;
            if (position.X <= -texture.Width)
            {
                position.X = GameDefaults.width + 200;
                position.Y = random.Next(100, GameDefaults.height / 2);
            }

            hitboxPipe1.X = (int)position.X;
            hitboxPipe1.Y = (int)position.Y + 200;

            hitboxPipe2.X = (int)position.X;
            hitboxPipe2.Y = (int)position.Y - texture.Height;

            pointMarker.X = (int)position.X + texture.Width / 2;
            pointMarker.Y = (int)position.Y;

        }
 
        public override void Draw()
        {

            if(isHitboxVisible)
            {
                //pipe 1 hitbox
                GameDefaults.spriteBatch.Draw(GameDefaults.pixel, 
                                            hitboxPipe1, 
                                            Color.Green);
                //pipe 2 hitbox
                GameDefaults.spriteBatch.Draw(GameDefaults.pixel, 
                                            hitboxPipe2, 
                                            Color.Green);
                //point marker
                GameDefaults.spriteBatch.Draw(GameDefaults.pixel, 
                                            pointMarker, 
                                            Color.Yellow);
            }
            GameDefaults.spriteBatch.Draw(texture, hitboxPipe1, color);
            GameDefaults.spriteBatch.Draw(texture, hitboxPipe2, color);

        }
    }
}
