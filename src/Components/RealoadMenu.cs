using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Flappy
{
    public class ReloadMenu
    {
        
        SpriteFont font;
        Rectangle rectangle;

        public ReloadMenu(Vector2 origin, SpriteFont font)
        {
            this.font = font;
            this.rectangle = new Rectangle((int)origin.X, (int)origin.Y, 300, 200);
            //this.score = score;
        }

        public void Reaload(Scene game, bool playerIsDead)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.R) && playerIsDead)
            {
                game.reloadGame();
            }
        }

        public void Draw(int score)
        {
            GameDefaults.spriteBatch.Draw(GameDefaults.pixel, rectangle, Color.Brown);
            GameDefaults.spriteBatch.DrawString(font, "Press R to Restart", 
                                                new Vector2((rectangle.Width / 2)-50,(rectangle.Y + (rectangle.Height / 2) - 50)), 
                                                Color.White);
            GameDefaults.spriteBatch.DrawString(font, "Score " + score,
                                                new Vector2((rectangle.Width / 2)-50, (rectangle.Y + (rectangle.Height / 2) + 30)),
                                                Color.White);
        }
    }
}