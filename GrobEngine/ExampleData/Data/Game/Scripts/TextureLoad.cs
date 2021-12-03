using GrobEngine;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextureLoad : IObject
{
	private SpriteBatch batch;
	private Texture2D texture;
	
	public TextureLoad() {}
	
	public override void LoadContent(GrobEngineMain game)
	{
		Console.WriteLine("Load Texture");
		batch = new SpriteBatch(game.GraphicsDevice);
		texture = game.Content.Load<Texture2D>("Game/Textures/Texture.png");
	}
	
	public override void UnloadContent(GrobEngineMain game)
	{
		Console.WriteLine("Unload Texture");
		batch.Dispose();
		texture.Dispose();
	}
	
	public override void Draw(GrobEngineMain game, GameTime gameTime)
	{
		batch.Begin();
		batch.Draw(texture, Vector2.Zero, Color.White);
		batch.End();
	}
}