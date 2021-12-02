using GrobEngine;
using System;
using Microsoft.Xna.Framework;

public class EngineMain : IGame
{
	private IGame textureLoader;
	private IGame inputTest;
	
	public EngineMain() {}
	
	public void Initialize(GrobEngineMain game)
    {
		Console.WriteLine("Script Initialize");
		textureLoader = ScriptEngine.LoadScriptFromContent("Game/Scripts/TextureLoad.cs", game.Content);
		inputTest = ScriptEngine.LoadScriptFromContent("Game/Scripts/InputTest.cs", game.Content);
		
		ApplyVideoSettings(game, 1280, 720, false, false);
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
	
	public void OnDeviceCreated(GrobEngineMain game, object sender, EventArgs e)
    {
		Console.WriteLine("Graphics Device Created");
	}
	
	public void OnDeviceReset(GrobEngineMain game, object sender, EventArgs e)
    {
		Console.WriteLine("Graphics Device Reset");
    }
	
	public void LoadContent(GrobEngineMain game)
    {
		Console.WriteLine("Script LoadContent");
        textureLoader.LoadContent(game);
    }

    public void UnloadContent(GrobEngineMain game)
    {
		Console.WriteLine("Script UnloadContent");
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