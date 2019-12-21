using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GraphPathFinding.Abstract;

namespace GraphPathFinding.Installers
{
	public class WindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IMainPageModel>()
				.ImplementedBy<MainPageModel>());

			container.Register(Component.For<IMainPageViewModel>().
				ImplementedBy<MainPageViewModel>());

			container.Register(Component.For<IShell>()
				.ImplementedBy<Shell>());

			container.Register(Component.For<MainWindow>().LifestyleTransient());
		}
	}
}
