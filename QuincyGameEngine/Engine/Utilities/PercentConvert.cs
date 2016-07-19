using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEngine.Engine.Utilities
{
	public static class DisplayConvert
	{
		public static Vector2 GetMiddle(Viewport _vp)
		{
			return new Vector2(_vp.Width / 2, _vp.Height / 2);
		}

		public static Vector2 PercentToPixel(Viewport _vp, Vector2 percentLocation)
		{
			Vector2 temp = GetMiddle(_vp);
			Vector2 newVec;
			if(percentLocation.X == 0 && percentLocation.Y == 0)
			{
				return temp;
			}
			newVec.X = temp.X += (temp.X * percentLocation.X);
			newVec.Y = temp.Y -= (temp.Y * percentLocation.Y);
			return newVec;
		}

		public static float PercentToPixelX(Viewport _vp, float percentLocation)
		{
			Vector2 temp = GetMiddle(_vp);

			var newFloat = temp.X += (temp.X * percentLocation);

			return newFloat;
		}

		public static float PercentToPixelY(Viewport _vp, float percentLocation)
		{
			Vector2 temp = GetMiddle(_vp);

			var newFloat = temp.Y -= (temp.Y * percentLocation);

			return newFloat;
		}
	}
}
