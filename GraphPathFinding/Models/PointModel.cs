using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinding.Models
{
	public class PointModel
	{
		public int AxisX { get; set; }
		public int AxisY { get; set; }
		public ICollection<int> Distance { get; set; }
		public ICollection<PointModel> Neighbours { get; set; }
		public int Id { get; set; }

		public PointModel(int axisX, int axisY, int id)
		{
			Id = id;
			AxisX = axisX;
			AxisY = axisY;
			Distance = new List<int>();
			Neighbours = new List<PointModel>();
		}

	}
}
