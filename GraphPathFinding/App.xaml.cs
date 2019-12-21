using Castle.Windsor;
using Castle.Windsor.Installer;
using GraphPathFinding.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GraphPathFinding
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly IWindsorContainer _windsorContainer;

		public App()
		{
			_windsorContainer = new WindsorContainer();
		}
		private void ApplicationStartup(object sender, StartupEventArgs e)
		{
			
			_windsorContainer.Install(FromAssembly.This());

			var start = _windsorContainer.Resolve<IShell>();
			start.Run();

			_windsorContainer.Release(start);
		}
	}
}
