using GrobEngine;
using System;
using Microsoft.Xna.Framework;

public class GameMain : IObject
{
	private IObject textureLoader;
	private IObject inputTest;
	
	public GameMain() {}
	
	public void Initialize(GrobEngineMain game)
    {
		Console.WriteLine("Game Initialize");
		textureLoader = (IObject)ScriptEngine.LoadScriptFromContent("Game/Scripts/TextureLoad.cs", game.Content);
		inputTest = (IObject)ScriptEngine.LoadScriptFromContent("Game/Scripts/InputTest.cs", game.Content);
    }
	
	public void ApplyVideoSettings(GrobEngineMain game, int width, int height, bool fullscreen, bool vsync)
	{
		Console.WriteLine("Applying Settings");
		game.graphics.PreferredBackBufferWidth = width;
		game.graphics.PreferredBackBufferHeight = height;
		game.graphics.SynchronizeWithVerticalRetrace = vsync;
		game.graphics.IsFullScreen = fullscreen;

		// Apply!
		game.graphics.ApplyChanges();
	}
	
	public void LoadContent(GrobEngineMain game)
    {
        textureLoader.LoadContent(game);
    }

    public void UnloadContent(GrobEngineMain game)
    {
        textureLoader.UnloadContent(game);
    }
	
	public void Update(GrobEngineMain game, GameTime gameTime)
    {
		inputTest.Update(game, gameTime);
    }

    public void Draw(GrobEngineMain game, GameTime gameTime)
    {
        game.GraphicsDevice.Clear(Color.Red);
        textureLoader.Draw(game, gameTime);
    }
}