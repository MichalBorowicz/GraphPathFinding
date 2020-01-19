using GraphPathFinding.Abstract;
using GraphPathFinding.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinding.Algorithms
{
	public class OpenL
	{
		public int Current { get; set; }
		public int Parent { get; set; }
		public float TotalMovementCostF { get; set; }
		public float MovementCostG { get; set; }
	}
	public class AStarAlgorithm : IAStarAlgorithm
	{
		public Bitmap Get(ICollection<PointModel> points, Bitmap bitmap)
		{
			throw new NotImplementedException();
		}
	}
}