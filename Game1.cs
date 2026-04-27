using System;
using System.Net.Mime;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Flappy;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;

    //Sprite test;

    Player player;

    Pipe pipe, pipe2;
    Floor floor;

    SpriteFont font;

    SoundEffect getPointSound;

    ReloadMenu reloadMenu;

    int score = 0;

    public Game1()
    {
        Window.Title = "Flappy Bird Clone";
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = GameDefaults.width;
        _graphics.PreferredBackBufferHeight = GameDefaults.height;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        GameDefaults.spriteBatch = new SpriteBatch(GraphicsDevice);

        GameDefaults.pixel = new Texture2D(GraphicsDevice, 1, 1);
        GameDefaults.pixel.SetData(new[] { Color.White });
        //test = new Sprite(Content.Load<Texture2D>("images/sprites/flappy"), new Vector2(100,100), new Vector2(32,32)); 
        player = new Player(Content.Load<Texture2D>("images/sprites/flappy"), new Vector2(100,GameDefaults.height/2), new Vector2(32,32));
        floor = new Floor(Content.Load<Texture2D>("images/inanimates/Grass"));
        pipe = new Pipe(Content.Load<Texture2D>("images/inanimates/Pipe"), new Vector2(GameDefaults.width, GameDefaults.height/2));
        pipe2 = new Pipe(Content.Load<Texture2D>("images/inanimates/Pipe"), new Vector2(GameDefaults.width + 400, GameDefaults.height/2));
        getPointSound = Content.Load<SoundEffect>("Sounds/newPoint");
        font = Content.Load<SpriteFont>("Fonts/FlappyFont");
        reloadMenu = new ReloadMenu(new Vector2(GameDefaults.width / 2 - 150, GameDefaults.height / 2 - 150), font, score);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        
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
            Console.WriteLine(score);
        }

        if(Keyboard.GetState().IsKeyDown(Keys.R) && player.IsDead)
        {
            score = 0;
            player.IsDead = false;
            player = new Player(Content.Load<Texture2D>("images/sprites/flappy"), new Vector2(100,GameDefaults.height/2), new Vector2(32,32));
            floor = new Floor(Content.Load<Texture2D>("images/inanimates/Grass"));
            pipe = new Pipe(Content.Load<Texture2D>("images/inanimates/Pipe"), new Vector2(GameDefaults.width, GameDefaults.height/2));
            pipe2 = new Pipe(Content.Load<Texture2D>("images/inanimates/Pipe"), new Vector2(GameDefaults.width + 400, GameDefaults.height/2));
        }

        
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        GameDefaults.spriteBatch.Begin();
        //test.Draw();
        floor.Draw();  
        pipe.Draw();
        pipe2.Draw();
        

        player.Draw();

        if(player.IsDead)
        {
            reloadMenu.Draw();
        }

        GameDefaults.spriteBatch.DrawString(font, "Score " + score, new Vector2(10,10), Color.White);
        GameDefaults.spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
