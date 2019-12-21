using GraphPathFinding.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinding
{
	public class Shell : IShell
	{
		public Shell(MainWindow mainWindow)
		{
			mainWindow.Title = "";
		}

		public virtual MainWindow Window { get; set; }
		public void Run()
		{
			Window.Show();
		}
	}
}
