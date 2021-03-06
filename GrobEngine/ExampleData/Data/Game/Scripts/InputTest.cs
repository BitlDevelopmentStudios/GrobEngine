using GrobEngine;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class InputTest : IObject
{
	private KeyboardState keyboardPrev = new KeyboardState();
	private MouseState mousePrev = new MouseState();
	private GamePadState gpPrev = new GamePadState();
	
	public InputTest() {}
	
	public override void Update(GrobEngineMain game, GameTime gameTime) 
	{
		// Poll input
		KeyboardState keyboardCur = Keyboard.GetState();
		MouseState mouseCur = Mouse.GetState();
		GamePadState gpCur = GamePad.GetState(PlayerIndex.One);

		// Check for presses
		if (keyboardCur.IsKeyDown(Keys.Space) && keyboardPrev.IsKeyUp(Keys.Space))
		{
			System.Console.WriteLine("Space bar was pressed!");
		}
		if (mouseCur.RightButton == ButtonState.Released && mousePrev.RightButton == ButtonState.Pressed)
		{
			System.Console.WriteLine("Right mouse button was released!");
		}
		if (gpCur.Buttons.A == ButtonState.Pressed && gpPrev.Buttons.A == ButtonState.Pressed)
		{
			System.Console.WriteLine("A button is being held!");
		}

		// Current is now previous!
		keyboardPrev = keyboardCur;
		mousePrev = mouseCur;
		gpPrev = gpCur;
	}
}