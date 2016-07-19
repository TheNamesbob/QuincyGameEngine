using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using QuincyGameEngine.Core;

namespace QuincyGameEngine.Engine.Utilities
{
	/// <summary>
	/// FPS Counter Class
	/// </summary>
	class FpsCounter : GameObject
	{
		/// <summary>
		/// Total Frames since start
		/// </summary>
		public long TotalFrames;

		/// <summary>
		/// Total Seconds since start
		/// </summary>
		public float TotalSeconds;

		/// <summary>
		/// Average FPS
		/// </summary>
		public float AverageFramesPerSecond;

		/// <summary>
		/// Current FPS
		/// </summary>
		public double CurrentFramesPerSecond;

		const int MaximumSamples = 100;

		readonly Queue<float> _sampleBuffer;

		public FpsCounter()
		{
			_sampleBuffer = new Queue<float>();
		}

		public override void Update(GameTime gameTime)
		{
			var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

			CurrentFramesPerSecond = 1.0 / delta;

			_sampleBuffer.Enqueue((float)CurrentFramesPerSecond);

			if(_sampleBuffer.Count > MaximumSamples)
			{
				_sampleBuffer.Dequeue();
				AverageFramesPerSecond = _sampleBuffer.Average(i => i);
			}
			else
			{
				AverageFramesPerSecond = (float)CurrentFramesPerSecond;
			}

			TotalFrames++;
			TotalSeconds += (float)delta;
		}

		/// <summary>
		/// Get current FPS rounded up to the nearest 10th
		/// </summary>
		public string GetCurrentFps()
		{
			return CurrentFramesPerSecond.ToString("0.00");
		}

		/// <summary>
		/// Get Average FPS rounded up to the nearest 10th
		/// </summary>
		public string GetAverageFps()
		{
			return AverageFramesPerSecond.ToString("0.00");
		}
	}
}