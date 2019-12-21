using GraphPathFinding.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinding
{
	public class MainPageViewModel : IMainPageViewModel
	{
		public IMainPageModel mainPageModel { get; set; }

		public IMainPageModel Get()
		{	
			mainPageModel.Text = "Hello World with dependency injection!";

			return mainPageModel;
		}
	}
}
