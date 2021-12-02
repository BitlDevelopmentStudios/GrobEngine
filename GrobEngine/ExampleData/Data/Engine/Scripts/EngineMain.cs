using GrobEngine;
using System;
using Microsoft.Xna.Framework;

public class EngineMain : IGame
{
	private IGame gameMain;
	
	public EngineMain() {}
	
	public void Initialize(GrobEngineMain game)
    {
		Console.WriteLine("Engine Initialize");
		gameMain = ScriptEngine.LoadScriptFromContent("Game/Scripts/GameMain.cs", game.Content);
		gameMain.Initialize(game);
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
        gameMain.LoadContent(game);
    }

    public void UnloadContent(GrobEngineMain game)
    {
        gameMain.UnloadContent(game);
    }
	
	public void Update(GrobEngineMain game, GameTime gameTime) 
	{ 
		gameMain.Update(game, gameTime);
	}

    public void Draw(GrobEngineMain game, GameTime gameTime) 
	{ 
		gameMain.Draw(game, gameTime);
	}
}