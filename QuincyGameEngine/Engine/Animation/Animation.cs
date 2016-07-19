using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using QuincyGameEngine.Engine.Utilities;

namespace QuincyGameEngine.Engine.Animation
{
	public class Animation
	{
		readonly List<Frame> frames;

		readonly Coroutine _coroutine;

		int _currentFrame;

		public Animation()
		{
			frames = new List<Frame>();
			_coroutine = new Coroutine();
		}

		public void Add(Rectangle rect, float time)
		{
			Frame f;
			f.SourceRectangle = rect;
			f.Duration = time;
			frames.Add(f);
		}

		public void PlayAnimation()
		{
			if(!_coroutine.Running)
			{
				_coroutine.Start(animation());
			}
			if(_coroutine.Running)
				_coroutine.Update();
		}

		IEnumerator animation()
		{
			foreach(var f in frames)
			{
				if(_currentFrame > frames.Count - 1)
					_currentFrame = 0;
				CurrentFrame = frames[_currentFrame].SourceRectangle;
				var delay = frames[_currentFrame].Duration;
				_currentFrame++;
				yield return Coroutine.Pause(delay);
			}
		}

		public Rectangle CurrentFrame { get; private set; }
	}
}
