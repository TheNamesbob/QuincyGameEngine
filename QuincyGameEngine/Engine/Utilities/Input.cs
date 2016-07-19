using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using QuincyGameEngine.Core;

namespace QuincyGameEngine.Engine.Utilities
{
	class Input : GameObject
	{
		static KeyboardState _currentKeyboard;
		static KeyboardState _previousKeyboard;

		static MouseState _currentMouse;
		static MouseState _previousMouse;

		static GamePadState[] _currentPadState;
		static GamePadState[] _previousPadState;

		public static KeyboardState CurrentKeyboard => _currentKeyboard;

		public static KeyboardState PreviousKeyboard => _previousKeyboard;

		public static MouseState CurrentMouse => _currentMouse;

		public static MouseState PreviousMouse => _previousMouse;

		public static GamePadState[] CurrentPadState => _currentPadState;

		public static GamePadState[] PreviousPadState => _previousPadState;

		public event EventHandler OnMouseClicked;

		public Input()
		{
			_currentKeyboard = Keyboard.GetState();
			_currentMouse = Mouse.GetState();

			_currentPadState = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
			foreach(PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
				_currentPadState[(int)index] = GamePad.GetState(index);
		}

		public override void Update(GameTime gameTime)
		{
			_previousKeyboard = _currentKeyboard;
			_currentKeyboard = Keyboard.GetState();

			_previousMouse = _currentMouse;
			_currentMouse = Mouse.GetState();

			if(MouseLeftClicked())
				OnMouseClicked?.Invoke(this, null);

			_previousPadState = (GamePadState[])_currentPadState.Clone();
			foreach(PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
				_currentPadState[(int)index] = GamePad.GetState(index);
		}

		public static void Flush()
		{
			_previousKeyboard = _currentKeyboard;
			_previousMouse = _currentMouse;
			_previousPadState = _currentPadState;
		}

		public static bool KeyReleased(Keys k)
		{
			return _currentKeyboard.IsKeyUp(k) && _previousKeyboard.IsKeyDown(k);
		}

		public static bool KeyPressed(Keys k)
		{
			return _currentKeyboard.IsKeyDown(k) && _previousKeyboard.IsKeyUp(k);
		}

		public static bool KeyDown(Keys k)
		{
			return _currentKeyboard.IsKeyDown(k);
		}

		public static bool MouseLeftClicked()
		{
			return _currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released;
		}

		public static bool MouseLeftHeld()
		{
			return _currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Pressed;
		}

		public static bool MouseLeftReleased(Keys k)
		{
			return _currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed;
		}

		public static bool MouseRightClicked()
		{
			return _currentMouse.RightButton == ButtonState.Pressed && _previousMouse.RightButton == ButtonState.Released;
		}

		public static bool MouseRightHeld()
		{
			return _currentMouse.RightButton == ButtonState.Pressed && _previousMouse.RightButton == ButtonState.Pressed;
		}

		public static bool MouseRightReleased(Keys k)
		{
			return _currentMouse.RightButton == ButtonState.Released && _previousMouse.RightButton == ButtonState.Pressed;
		}

		public static bool MouseStateChanged()
		{
			return _currentMouse != _previousMouse;
		}

		public static bool ScrollWheelUp()
		{
			return _currentMouse.ScrollWheelValue > _previousMouse.ScrollWheelValue;
		}

		public static bool ScrollWheelDown()
		{
			return _currentMouse.ScrollWheelValue < _previousMouse.ScrollWheelValue;
		}

		/// <summary>
		/// No love for gamepads
		/// </summary>
		public static bool ButtonReleased(Buttons button, PlayerIndex index)
		{
			return _currentPadState[(int)index].IsButtonUp(button) && _previousPadState[(int)index].IsButtonDown(button);
		}
		public static bool ButtonPressed(Buttons button, PlayerIndex index)
		{
			return _currentPadState[(int)index].IsButtonDown(button) && _previousPadState[(int)index].IsButtonUp(button);
		}
		public static bool ButtonDown(Buttons button, PlayerIndex index)
		{
			return _currentPadState[(int)index].IsButtonDown(button);
		}
	}
}

