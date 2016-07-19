using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEngine.Core
{
	class GameComponents
	{
		readonly List<GameObject> _gameObjects;

		public int Count => _gameObjects.Count;

		public GameComponents()
		{
			_gameObjects = new List<GameObject>();
		}
		/// <summary>
		/// Adds object before the start of the scene
		/// </summary>
		/// <param name="gameObject"></param>
		public void Add(GameObject gameObject)
		{
			_gameObjects.Add(gameObject);
		}

		/// <summary>
		/// removes object at any time, calls dispose so use carefully.
		/// </summary>
		/// <param name="gameObject"></param>
		public void Remove(GameObject gameObject)
		{
			gameObject.Destroy();
			_gameObjects.Remove(gameObject);
		}

		/// <summary>
		/// Insert a game object into the 
		/// </summary>
		/// <param name="position"></param>
		/// <param name="gameObject"></param>
		public void Insert(int position, GameObject gameObject)
		{
			_gameObjects.Insert(position, gameObject);
			gameObject.Start();
		}

		public void Update(GameTime delta)
		{
			for(int i = 0; i < Count; i++)
			{
				if(_gameObjects[i].IsEnabled)
					_gameObjects[i].Update(delta);
			}
		}

		public void FixedUpdate(float delta)
		{
			for(int i = 0; i < Count; i++)
			{
				if(_gameObjects[i].IsEnabled)
					_gameObjects[i].FixedUpdate(delta);
			}
		}

		public void DrawBack(SpriteBatch sb)
		{
			for(int i = 0; i < Count; i++)
			{
				if(_gameObjects[i].IsVisible)
				{
					_gameObjects[i].DrawBack(sb);
				}
			}
		}

		public void DrawFront(SpriteBatch sb)
		{
			for(int i = 0; i < Count; i++)
			{
				if(_gameObjects[i].IsVisible)
				{
					_gameObjects[i].DrawFront(sb);
				}
			}
		}

		public void Destroy()
		{
			for(int i = 0; i < Count; i++)
			{
				_gameObjects[i].Destroy();
			}
		}
	}
}
