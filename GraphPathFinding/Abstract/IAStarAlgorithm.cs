using GraphPathFinding.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinding.Abstract
{
	public interface IAStarAlgorithm
	{
		Bitmap Get(ICollection<PointModel> points, Bitmap bitmap);
	}
}
