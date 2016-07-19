using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using QuincyGameEngine.Engine.Utilities;

namespace QuincyGameEngine.Core
{
	enum ScreenHz
	{
		_30hz, _60hz, _75hz, _90hz, _120hz, _144hz
	}
	class SceneManager
	{
		internal Scene CurrentScene { get; set; }

		internal Dictionary<string, Scene> Scenes { get; }

		public int Count => Scenes.Count;

		public ScreenHz UpdateMode
		{
			get { return _fixedDelta; }
			set
			{
				switch(value)
				{
					case ScreenHz._30hz:
						_FixedDelta = 1 / 30f;
						break;
					case ScreenHz._60hz:
						_FixedDelta = 1 / 60f;
						break;
					case ScreenHz._75hz:
						_FixedDelta = 1 / 75f;
						break;
					case ScreenHz._90hz:
						_FixedDelta = 1 / 90f;
						break;
					case ScreenHz._120hz:
						_FixedDelta = 1 / 120f;
						break;
					case ScreenHz._144hz:
						_FixedDelta = 1 / 144f;
						break;
					default:
						_FixedDelta = 1 / 60f;
						break;
				}
				_fixedDelta = value;
			}
		}
		ScreenHz _fixedDelta;

		float _FixedDelta = 1 / 60f;

		float _accumlator = 0;

		public SceneManager()
		{
			Scenes = new Dictionary<string, Scene>();
		}

		public void Initialize()
		{
			if(Count == 0)
			{
				AddScene("Scene1", new QuincyGameEngine.TestScenes.DefaultScene());
				var firstScene = Scenes.First().Key;
				ChangeScene(firstScene);
			}
			else
			{
				var firstScene = Scenes.First().Key;
				ChangeScene(firstScene);
			}
		}

		public void Update(GameTime delta)
		{
			_accumlator += (float)delta.ElapsedGameTime.TotalSeconds;
			int loops = 0;
			CurrentScene?.OnUpdate(delta);
			while(_accumlator >= _FixedDelta)
			{
				CurrentScene?.OnFixedUpdate(_FixedDelta);
				_accumlator -= _FixedDelta;
				loops++;
			}
		}

/*		long _previousTicks = 0;

		public void UpdateMETA(GameTime delta)
		{
		Retry:
			var currentTicks = delta.ElapsedGameTime.Ticks;

			_accumlator += TimeSpan.FromTicks(currentTicks - _previousTicks).Ticks;

			if(_accumlator < _FixedDelta)
			{
				var sleepTime = (int)_FixedDelta - (int)_accumlator;

				Task.Delay(sleepTime).Wait();

				goto Retry;
			}

			int loops = 0;

			CurrentScene?.OnUpdate(delta);

			while(_accumlator >= _FixedDelta)
			{
				CurrentScene?.OnFixedUpdate(_FixedDelta);

				_accumlator -= _FixedDelta;

				loops++;
			}
		}*/

		public void Load()
		{
			CurrentScene?.OnLoad();
		}

		public void Draw()
		{
			CurrentScene?.OnDraw();
		}

		public void Unload()
		{
			CurrentScene?.OnUnload();
		}

		public void AddScene(string sceneName, Scene scene)
		{
			scene.SceneName = sceneName;
			Scenes.Add(sceneName, scene);
		}

		public void ChangeScene(string sceneName)
		{
			if(Scenes.ContainsKey(sceneName) && CurrentScene == null)
			{
				CurrentScene = Scenes[sceneName];
				Load();
			}
			else if(Scenes.ContainsKey(sceneName))
			{
				Unload();
				CurrentScene = Scenes[sceneName];
				Load();
			}
		}

		public Scene GetScene()
		{
			return CurrentScene;
		}
	}
	namespace QuincyGameEngine.TestScenes
	{
		class DefaultScene : Scene
		{
			protected override void Load()
			{

			}

			protected override void Update(GameTime delta)
			{
				if(Input.KeyPressed(Keys.Escape))
				{
					Exit();
				}

				if(Input.KeyDown(Keys.A))
				{
					ChangeScene(SceneName);
				}
			}
		}
	}
}
