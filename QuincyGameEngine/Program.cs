using System;
using QuincyGameEngine.Core;

namespace QuincyGameEngine
{
	class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			using(var game = new QuincyEngine())
				game.Run();
		}
	}
}
