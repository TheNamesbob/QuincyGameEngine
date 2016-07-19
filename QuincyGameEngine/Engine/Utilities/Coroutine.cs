using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuincyGameEngine.Engine.Utilities
{
	public class Coroutine
	{
		readonly List<IEnumerator> _routines;

		public Coroutine()
		{
			_routines = new List<IEnumerator>();
		}

		public void Start(IEnumerator routine)
		{
			_routines.Add(routine);
		}

		public bool StartIfNotRunning(IEnumerator routine)
		{
			if(!Running)
			{
				_routines.Add(routine);
				return true;
			}
			return false;
		}

		public void StopAll()
		{
			_routines.Clear();
		}

		public void Update()
		{
			for(int i = 0; i < _routines.Count; i++)
			{
				if(_routines[i].Current is IEnumerator)
					if(MoveNext((IEnumerator)_routines[i].Current))
						continue;
				if(!_routines[i].MoveNext())
					_routines.RemoveAt(i--);
			}
		}

		bool MoveNext(IEnumerator routine)
		{
			if(routine.Current is IEnumerator)
				if(MoveNext((IEnumerator)routine.Current))
					return true;
			return routine.MoveNext();
		}

		public int Count => _routines.Count;

		public bool Running => _routines.Count > 0;

		public static IEnumerator Pause(float time)
		{
			var watch = Stopwatch.StartNew();
			while(watch.Elapsed.TotalSeconds < time)
				yield return 0;
		}
	}
}

