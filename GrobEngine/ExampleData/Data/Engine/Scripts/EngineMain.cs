using GrobEngine;
using System;
using Microsoft.Xna.Framework;

public class EngineMain : IEngine
{
	private IObject gameMain;
	
	public EngineMain() {}
	
	public override void Initialize(GrobEngineMain game)
    {
		Console.WriteLine("Engine Initialize");
		gameMain = (IObject)ScriptEngine.LoadScriptFromContent("Game/Scripts/GameMain.cs", game.Content);
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
	
	public override void OnDeviceCreated(GrobEngineMain game, object sender, EventArgs e)
    {
		Console.WriteLine("Graphics Device Created");
	}
	
	public override void OnDeviceReset(GrobEngineMain game, object sender, EventArgs e)
    {
		Console.WriteLine("Graphics Device Reset");
    }
	
	public override void LoadContent(GrobEngineMain game)
    {
        gameMain.LoadContent(game);
    }

    public override void UnloadContent(GrobEngineMain game)
    {
        gameMain.UnloadContent(game);
    }
	
	public override void Update(GrobEngineMain game, GameTime gameTime) 
	{ 
		gameMain.Update(game, gameTime);
	}

    public override void Draw(GrobEngineMain game, GameTime gameTime) 
	{ 
		gameMain.Draw(game, gameTime);
	}
}