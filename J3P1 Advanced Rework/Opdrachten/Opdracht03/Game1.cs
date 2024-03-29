﻿using J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void Initialize()
    {
        SceneManager.Instance.GraphicsDevice = _graphics.GraphicsDevice;
        SceneManager.Instance.Game1 = this;
        SceneManager.Instance.AwakeManager();
        base.Initialize();
    }
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        SceneManager.Instance.Manager = Content;
        SceneManager.Instance.Font = Content.Load<SpriteFont>("SpriteFont");
        SceneManager.Instance.Viewport = new Viewport(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        SceneManager.Instance.LoadCurrentScene();
    }
    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        SceneManager.Instance.UpdateManager(gameTime);
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SceneManager.Instance.DrawManager(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}