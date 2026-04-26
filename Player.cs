using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Flappy
{
    public class Player : Sprite
    {
        Rectangle frameCut;

        Vector2 frameSize;

        float rotate;


        private int currentFrame = 0;

        private int numFrames;
        public Player(Texture2D texture, Vector2 position, Vector2 frameSize) : base(texture, position)
        {
            this.rotate = 0;
            this.frameSize = frameSize;

            numFrames = texture.Width / (int)frameSize.X;

            this.frameCut = new Rectangle(0, 0, (int)frameSize.X, (int)frameSize.Y);
        }

        public override void Update()
        {
            if(rotate < 2)
            {
                rotate += 0.1f;
            }

            position.Y += 5; 

            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                position.Y -= 10;
            }

            

            if(Keyboard.GetState().IsKeyDown(Keys.Space) && rotate > -0.5f)
            {
                rotate -= 0.2f;
            }

            Animation();
        }

        public void Animation()
        {

            currentFrame = (currentFrame + 1) % numFrames;
            frameCut.X = currentFrame * (int)frameSize.X;
        }

        public override void Draw()
        {
            GameDefaults.spriteBatch.Draw(texture, position, frameCut, color, rotate, new Vector2(frameSize.X / 2, frameSize.Y / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}