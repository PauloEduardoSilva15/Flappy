using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flappy
{
    public class Pipe : Sprite
    {
        Random random = new Random();

        Rectangle hitboxPipe1;
        Rectangle hitboxPipe2;

        public Pipe(Texture2D texture, Vector2 origin) : base(texture, origin)
        {
            hitboxPipe1 = new Rectangle((int)position.X, (int)position.Y + 200, texture.Width, texture.Height);
            hitboxPipe2 = new Rectangle((int)position.X, (int)position.Y - (texture.Height + 200), texture.Width, texture.Height);
        }

        public override void Update()
        {
            position.X -= 5;
            if (position.X <= -texture.Width)
            {
                position.X = GameDefaults.width + 200;
                position.Y = random.Next(100, GameDefaults.height / 2);
            }

            hitboxPipe1 = new Rectangle((int)position.X, (int)position.Y + 200, texture.Width, texture.Height);
            hitboxPipe2 = new Rectangle((int)position.X + 200, (int)position.Y, texture.Width * (-1), texture.Height * (-1));
        }

        public override void Draw()
        {
            GameDefaults.spriteBatch.Draw(texture, hitboxPipe1, color);
            GameDefaults.spriteBatch.Draw(texture, hitboxPipe2, color);
        }
    }
}
