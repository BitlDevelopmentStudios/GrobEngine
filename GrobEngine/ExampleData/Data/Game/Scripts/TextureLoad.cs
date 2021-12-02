using GrobEngine;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextureLoad : IGame
{
	private SpriteBatch batch;
	private Texture2D texture;
	
	public TextureLoad() {}
	
	public void Initialize(GrobEngineMain game) {}
	public void OnDeviceCreated(GrobEngineMain game, object sender, EventArgs e) {}
    public void OnDeviceReset(GrobEngineMain game, object sender, EventArgs e) {}
	public void Update(GrobEngineMain game, GameTime gameTime) {}
	
	public void LoadContent(GrobEngineMain game)
	{
		Console.WriteLine("Load Texture");
		batch = new SpriteBatch(game.GraphicsDevice);
		texture = game.Content.Load<Texture2D>("Game/Textures/Texture.png");
	}
	
	public void UnloadContent(GrobEngineMain game)
	{
		Console.WriteLine("Unload Texture");
		batch.Dispose();
		texture.Dispose();
	}
	
	public void Draw(GrobEngineMain game, GameTime gameTime)
	{
		batch.Begin();
		batch.Draw(texture, Vector2.Zero, Color.White);
		batch.End();
	}
}