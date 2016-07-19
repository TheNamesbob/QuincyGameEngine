using Microsoft.Xna.Framework;

namespace QuincyGameEngine.Core
{
	class QuincyEngine : Game
	{
		public GraphicsDeviceManager DeviceManager { get; set; }

		public SceneManager Scenes { get; set; }

		public static QuincyEngine Reference { get; private set; }

		public static string Pipeline { get; private set; }

		public QuincyEngine()
		{
			DeviceManager = new GraphicsDeviceManager(this)
			{
				SynchronizeWithVerticalRetrace = false,
				PreferredBackBufferWidth = 1280,
				PreferredBackBufferHeight = 720,
				PreferMultiSampling = true,
				HardwareModeSwitch = true, 
				IsFullScreen = false,
			};
			DeviceManager.ApplyChanges();
		}

		protected override void LoadContent()
		{
			IsFixedTimeStep = false;
			IsMouseVisible = true;
			Reference = this;
			Pipeline = @"Content/bin/Assets/";
			Content.RootDirectory = Pipeline;
			Scenes = new SceneManager();
			Scenes.Initialize();
		}

		protected override void Update(GameTime gameTime)
		{
			Scenes.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			Scenes.Draw();
		}

		protected override void UnloadContent()
		{
			Scenes.Unload();
		}
	}
}
