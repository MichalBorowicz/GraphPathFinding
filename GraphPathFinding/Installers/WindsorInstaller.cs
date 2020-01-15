using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GraphPathFinding.Abstract;
using GraphPathFinding.Algorithms;
using GraphPathFinding.Helpers.Abstract;
using GraphPathFinding.Helpers.Implementation;

namespace GraphPathFinding.Installers
{
	public class WindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IShell>().ImplementedBy<Shell>())
					 .Register(Component.For<IPRM>().ImplementedBy<PRM>())
					 .Register(Component.For<IRasterAlgorithm>().ImplementedBy<RasterAlgorithm>())
					 .Register(Component.For<IComposition>().ImplementedBy<Composition>())
					 .Register(Component.For<IDijkstra>().ImplementedBy<Dijkstra>())
					 .Register(Component.For<IConvertBitmapToSourceImageHelper>().ImplementedBy<ConvertBitmapToSourceImageHelper>())
					 .Register(Component.For<MainWindow>().LifestyleTransient());
		}
	}
}
