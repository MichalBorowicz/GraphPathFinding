using GraphPathFinding.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinding.Abstract
{
	public interface IRasterAlgorithm
	{
		Bitmap Get(string bitmapPath);

		ICollection<PointModel> GetPoints();
	}
}
