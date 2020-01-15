using GraphPathFinding.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GraphPathFinding.Abstract
{
	public interface IPRM
	{
		Bitmap Get(Bitmap bitmap);
		ICollection<PointModel> GetPoints();
	}
}
