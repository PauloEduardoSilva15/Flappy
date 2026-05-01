using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
namespace Flappy
{
    public class Scene
    {

    Player player;

    Pipe pipe, pipe2;
    Floor floor;

    SpriteFont font;

    SoundEffect getPointSound;

    ReloadMenu reloadMenu;

    int score = 0;
        public Scene(ContentManager content)
        {
            player = new Player(content.Load<Texture2D>("images/sprites/flappy"), new Vector2(100,GameDefaults.height/2), new Vector2(32,32));
            floor = new Floor(content.Load<Texture2D>("images/inanimates/Grass"));
            pipe = new Pipe(content.Load<Texture2D>("images/inanimates/Pipe"), new Vector2(GameDefaults.width, GameDefaults.height/2));
            pipe2 = new Pipe(content.Load<Texture2D>("images/inanimates/Pipe"), new Vector2(GameDefaults.width + 400, GameDefaults.height/2));
            getPointSound = content.Load<SoundEffect>("Sounds/newPoint");
            font = content.Load<SpriteFont>("Fonts/FlappyFont");
            reloadMenu = new ReloadMenu(new Vector2(GameDefaults.width / 2 - 150, GameDefaults.height / 2 - 150), font);
        }
        public void reloadGame()
        {
            score = 0;
            player.IsDead = false;
            player.Position = player.StartPosition;
            pipe.Position = pipe.StartPosition;
            pipe2.Position = pipe2.StartPosition;
            floor.Position = floor.StartPosition;
        }

        public void Update()
        {
            if (!player.IsDead)
            {
                player.Update();
                floor.Update();
                pipe.Update();
                pipe2.Update();

            }
            if(player.PointAdded)
            {
                score++;
                player.PointAdded = false;
                getPointSound.Play();
            }

            reloadMenu.Reaload(this, player.IsDead);
            
        }

        public void Draw()
        {
            floor.Draw();  
            pipe.Draw();
            pipe2.Draw();
        

            player.Draw();

            if(player.IsDead)
            {
                reloadMenu.Draw(score);
            }

            GameDefaults.spriteBatch.DrawString(font, "Score " + score, new Vector2(10,10), Color.White);
        }
    }
}