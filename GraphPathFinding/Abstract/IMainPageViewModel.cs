using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinding.Abstract
{
	public interface IMainPageViewModel
	{
		IMainPageModel mainPageModel { get; set; }
		IMainPageModel Get();
	}
}
