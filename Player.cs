
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

        public static Rectangle hitbox;

        int cutdown = 0;

        bool isDead = false;
        bool isHitboxVisible = false;

        bool pointAdded = false;

        private int currentFrame = 0;

        private int numFrames;

        public bool PointAdded { get{return pointAdded;} 
                                set{pointAdded = value;} }
        public bool IsDead { get{return isDead;} 
                            set{isDead = value;}}
        public Player(Texture2D texture, Vector2 position, Vector2 frameSize) : base(texture, position)
        {
            this.rotate = 0;
            this.frameSize = frameSize;

            numFrames = texture.Width / (int)frameSize.X;

            this.frameCut = new Rectangle(0, 
                                        0, 
                                        (int)frameSize.X, 
                                        (int)frameSize.Y);
            hitbox = new Rectangle((int)position.X, 
                                    (int)position.Y-10, 
                                    (int)frameSize.X-2, 
                                    (int)frameSize.Y-10);
        }

        public override void Update()
        {
            if(rotate < 2)
            {
                rotate += 0.1f;
            }

            position.Y += 5; 

            if(Keyboard.GetState().IsKeyDown(Keys.Space) && position.Y > 0)
            {
                position.Y -= 10;
            }

            if(Keyboard.GetState().IsKeyDown(Keys.Space) && rotate > -0.5f)
            {
                rotate -= 0.2f;
            }

            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y-10;


            if(hitbox.Intersects(Floor.hitbox)|| hitbox.Intersects(Pipe.hitboxPipe1) || hitbox.Intersects(Pipe.hitboxPipe2))
            {
                IsDead = true;
            }

            if(hitbox.Intersects(Pipe.pointMarker) && cutdown == 0)
            {
                pointAdded = true;
                cutdown = 1;
                /*Game1.score++;
                cutdown = 1;
                Console.WriteLine(Game1.score);
                */ 
            }

            if(cutdown == 1 && !hitbox.Intersects(Pipe.pointMarker))
            {
                cutdown = 0;
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

            if(isHitboxVisible)
            {
                GameDefaults.spriteBatch.Draw(GameDefaults.pixel, 
                                                position,
                                                hitbox, 
                                                Color.Red, 
                                                rotate, 
                                                new Vector2(hitbox.Width / 2, hitbox.Height / 2), 
                                                new Vector2(1, 1), 
                                                SpriteEffects.None, 
                                                0);
            }

            GameDefaults.spriteBatch.Draw(texture, 
                                        position, 
                                        frameCut, 
                                        color, 
                                        rotate, 
                                        new Vector2(hitbox.Width / 2, hitbox.Height / 2), 
                                        1f, 
                                        SpriteEffects.None, 
                                        0);
            
        }
    }
}