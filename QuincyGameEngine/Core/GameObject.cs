using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEngine.Core
{
	abstract class GameObject
	{
		public bool IsVisible = true;

		public bool IsEnabled = true;

		public float Order = 0;

		public Vector2 Position = Vector2.Zero;

		public Vector2 Origin = Vector2.Zero;

		public float Rotation = 0;

		public Vector2 Scale = Vector2.One;

		public Color Hue = Color.White;

		protected GameObject(bool isObjectSpawnIn = false, int order = 0)
		{
			if(!isObjectSpawnIn)
				QuincyEngine.Reference.Scenes.GetScene().Components.Add(this);
			else
				QuincyEngine.Reference.Scenes.GetScene().Components.Insert(order,this);
		}

		public virtual void Start()
		{
			
		}

		public virtual void Update(GameTime delta)
		{
			
		}

		public virtual void FixedUpdate(float delta)
		{
			
		}

		/// <summary>
		/// This Draw draws into the background before the Front calls
		/// </summary>
		public virtual void DrawBack(SpriteBatch sb)
		{
			
		}

		/// <summary>
		/// This Draw draws into the foreground so will appear after all the Back calls happen
		/// </summary>
		public virtual void DrawFront(SpriteBatch sb)
		{
			
		}

		public virtual void Destroy()
		{
			
		}
	}
}
