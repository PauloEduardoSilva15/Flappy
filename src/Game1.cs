using System;
using System.Net.Mime;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Runtime.Intrinsics.X86;

namespace Flappy;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;

    //Sprite test;
    Scene game;


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
        game = new Scene(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        game.Update();
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        GameDefaults.spriteBatch.Begin();

        game.Draw();

        GameDefaults.spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
