using GrobEngine;
using System;
using Microsoft.Xna.Framework;

public class GameMain : IObject
{
	private IObject textureLoader;
	private IObject inputTest;
	
	public GameMain() {}
	
	public override void Initialize(GrobEngineMain game)
    {
        string title = "GrobEngine Test";
        game.Window.Title = title;
        Console.Title = title;
		Console.WriteLine("Game Initialize");
		textureLoader = (IObject)Script.LoadScriptFromContent("Game/Scripts/TextureLoad.cs", game.Content);
		inputTest = (IObject)Script.LoadScriptFromContent("Game/Scripts/InputTest.cs", game.Content);
    }
	
	public override void LoadContent(GrobEngineMain game)
    {
        textureLoader.LoadContent(game);
    }

    public override void UnloadContent(GrobEngineMain game)
    {
        textureLoader.UnloadContent(game);
    }
	
	public override void Update(GrobEngineMain game, GameTime gameTime)
    {
		inputTest.Update(game, gameTime);
    }

    public override void Draw(GrobEngineMain game, GameTime gameTime)
    {
        game.GraphicsDevice.Clear(Color.Red);
        textureLoader.Draw(game, gameTime);
    }
}