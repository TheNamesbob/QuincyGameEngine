using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuincyGameEngine.Core;
using QuincyGameEngine.Engine.Utilities;

namespace QuincyGameEngine.MetroidVania.Scenes
{
	class LevelOne : Scene
	{
		Texture2D texture;

		public LevelOne()
		{
			SceneName = "LevelOne";
			AddScene();
			SceneName = "Poo";
			ChangeScene(SceneName);
		}

		protected override void Load()
		{
			
		}

		protected override void Update(GameTime delta)
		{
			if(Input.KeyDown(Keys.Escape))
				Exit();

		}

		protected override void FixedUpdate(float delta)
		{
			
		}

		protected override void Unload()
		{
			
		}
	}
}
