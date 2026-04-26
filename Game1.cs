using System.Net.Mime;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flappy;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;

    //Sprite test;

    Player player;

    Pipe pipe, pipe2;
    Floor floor;

    public Game1()
    {
        Window.Title = "Flappy Birdo";
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
        //test = new Sprite(Content.Load<Texture2D>("images/sprites/flappy"), new Vector2(100,100), new Vector2(32,32)); 
        player = new Player(Content.Load<Texture2D>("images/sprites/flappy"), new Vector2(100,100), new Vector2(32,32));
        floor = new Floor(Content.Load<Texture2D>("images/inanimates/Grass"));
        pipe = new Pipe(Content.Load<Texture2D>("images/inanimates/Pipe"), new Vector2(GameDefaults.width, GameDefaults.height/2));
        pipe2 = new Pipe(Content.Load<Texture2D>("images/inanimates/Pipe"), new Vector2(GameDefaults.width + 400, GameDefaults.height/2));
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        player.Update();
        floor.Update();
        pipe.Update();
        pipe2.Update();
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
        GameDefaults.spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
