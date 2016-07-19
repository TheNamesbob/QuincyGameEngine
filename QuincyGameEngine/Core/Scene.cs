using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEngine.Engine.Utilities;

namespace QuincyGameEngine.Core
{
	abstract class Scene
	{
		public string SceneName { get; set; }

		public Color Background { get; set; }

		public Rectangle Window { get; set; }

		public SpriteBatch Render { get; set; }

		public GraphicsDevice Device { get; set; }

		public World Physics { get; set; }

		public Coroutine Coroutines { get; set; }

		public GameComponents Components { get; set; }

		public SamplerState RenderSampler { get; set; }

		public Vector2 Gravity { get; set; }

		public Input InputHandler { get; set; }

		protected void AddScene()
		{
			if(!QuincyEngine.Reference.Scenes.Scenes.ContainsKey(SceneName))
				QuincyEngine.Reference.Scenes.AddScene(SceneName, this);
		}

		protected void ChangeScene(string sceneName)
		{
			QuincyEngine.Reference.Scenes.ChangeScene(sceneName);
		}

		protected void Exit()
		{
			QuincyEngine.Reference.Exit();
		}

		public void OnLoad()
		{
			Device = QuincyEngine.Reference.GraphicsDevice;
			Background = Color.CornflowerBlue;
			Window = Device.Viewport.Bounds;
			Render = new SpriteBatch(Device);
			Gravity = new Vector2(0, 9.81f);
			Physics = new World(Gravity);
			Coroutines = new Coroutine();
			RenderSampler = SamplerState.AnisotropicClamp;
			Components = new GameComponents();
			InputHandler = new Input();
			Load();
		}

		protected virtual void Load()
		{

		}

		public void OnUpdate(GameTime delta)
		{
			Update(delta);
			Components.Update(delta);
		}

		protected virtual void Update(GameTime delta)
		{
			
		}

		public void OnFixedUpdate(float delta)
		{
			FixedUpdate(delta);
			Components.FixedUpdate(delta);
		}

		protected virtual void FixedUpdate(float delta)
		{

		}

		public void OnDraw()
		{
			Draw();
		}

		protected virtual void Draw()
		{
			Clear();
			Render.Begin(samplerState: RenderSampler);
			Components.DrawBack(Render);
			Render.End();
			Render.Begin();
			Components.DrawFront(Render);
			Render.End();
		}

		public void OnUnload()
		{
			Input.Flush();
			Unload();
			Components?.Destroy();
			Render.Dispose();
			QuincyEngine.Reference.Content.Dispose();
			QuincyEngine.Reference.Content = new ContentManager(QuincyEngine.Reference.Services, QuincyEngine.Pipeline);
		}

		protected virtual void Unload()
		{
			
		}

		void Clear()
		{
			Device.Clear(Background);
		}
	}
}
