using System;
using System.Collections.Generic;
using FarseerPhysics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEngine.Core;

namespace QuincyGameEngine.Engine.Utilities
{
	public static class Extentions
	{
		#region Textures

		static RenderTarget2D CreateOneTextureFromMany<T>(Scene scene, List<T> list, EventHandler action, Vector2 vec)
		{
			var gd = QuincyEngine.Reference.GraphicsDevice;
			var render = new RenderTarget2D(gd, (int)vec.X, (int)vec.Y);
			gd.SetRenderTarget(render);
			scene.Render.Begin();
			foreach(var l in list)
			{
				action?.Invoke(l, null);
			}
			scene.Render.End();
			gd.SetRenderTarget(null);
			return render;
		}

		public static Texture2D CreateRectangle(int w, int h, Color color)
		{
			var texture = new Texture2D(QuincyEngine.Reference.GraphicsDevice, w, h);
			Color[] toTexture = new Color[w * h];
			for(int i = 0; i < toTexture.Length; i++)
				toTexture[i] = color;
			texture.SetData(toTexture);
			return texture;
		}

		public static Texture2D CreateCircle(int radius, Color color)
		{
			Texture2D texture = new Texture2D(QuincyEngine.Reference.GraphicsDevice, radius, radius);
			Color[] colorData = new Color[radius * radius];

			float diam = radius / 2f;
			float diamsq = diam * diam;

			for(int x = 0; x < radius; x++)
			{
				for(int y = 0; y < radius; y++)
				{
					int index = x * radius + y;
					Vector2 pos = new Vector2(x - diam, y - diam);
					if(pos.LengthSquared() <= diamsq)
					{
						colorData[index] = color;
					}
					else
					{
						colorData[index] = Color.Transparent;
					}
				}
			}

			texture.SetData(colorData);
			return texture;
		}

		#endregion

		#region Vectors

		public static Vector2 Up(this Vector2 vec)
		{
			return -Vector2.UnitY;
		}

		public static Vector2 Down(this Vector2 vec)
		{
			return Vector2.UnitY;
		}

		public static Vector2 Left(this Vector2 vec)
		{
			return -Vector2.UnitX;
		}

		public static Vector2 Right(this Vector2 vec)
		{
			return Vector2.UnitX;
		}

		#endregion

		#region Farseer Units

		public static Vector2 SimUnits(this Vector2 vec)
		{
			return ConvertUnits.ToSimUnits(vec);
		}

		public static Vector2 DisUnits(this Vector2 vec)
		{
			return ConvertUnits.ToDisplayUnits(vec);
		}

		#endregion

		#region Rectangle

		public static Vector2 AbsoluteCenter(this Rectangle rec)
		{
			return new Vector2(rec.X + (rec.Width / 2), rec.Y + (rec.Height / 2));
		}

		public static Vector2 Origin(this Rectangle rec)
		{
			return new Vector2((rec.Width / 2), (rec.Height / 2));
		}

		public static Vector2 TopRight(this Rectangle rec)
		{
			return new Vector2(rec.Right, rec.Y);
		}

		public static Vector2 TopLeft(this Rectangle rec)
		{
			return new Vector2(rec.X, rec.Y);
		}

		public static Vector2 BottomLeft(this Rectangle rec)
		{
			return new Vector2(rec.X, rec.Bottom);
		}

		public static Vector2 BottomRight(this Rectangle rec)
		{
			return new Vector2(rec.Right, rec.Bottom);
		}

		#endregion
	}
}
