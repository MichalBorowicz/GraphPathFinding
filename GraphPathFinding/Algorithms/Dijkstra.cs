using GraphPathFinding.Abstract;
using GraphPathFinding.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphPathFinding.Algorithms
{
	public class Dijkstra : IDijkstra
	{
		private const int infinityCost = 1000000;
		private const int noPathCost = -1;
		public Bitmap Get(Bitmap bitmap, ICollection<PointModel> points)
		{
			if (!points.Any())
			{
				MessageBox.Show("You should generate points with PRM method first!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return bitmap;
			}

			var pointsChecked = new List<PointModel>();
			var pointsToCheck = new List<PointModel>();

			pointsToCheck.AddRange(points);

			List<int> distancesBeetwenPoints = new List<int>();
			List<int> previousPoint = new List<int>();
			for (int i = 0; i < points.Count; i++)
			{
				distancesBeetwenPoints.Add(infinityCost);
				previousPoint.Add(noPathCost);
			}
			distancesBeetwenPoints[0] = 0;
			int howMuchToCheck = pointsToCheck.Count;

			while (howMuchToCheck > 0)
			{
				int minCost = infinityCost;
				var minimums = new List<PointModel>();

				foreach (var point in points)
				{
					if (pointsToCheck.Contains(point) && distancesBeetwenPoints[point.Id] < minCost)
					{
						minimums = new List<PointModel>();
						minimums.Add(point);
						minCost = distancesBeetwenPoints[point.Id];
					}
					else if (pointsToCheck.Contains(point) && distancesBeetwenPoints[point.Id] == minCost)
					{
						minimums.Add(point);
					}
				}

				foreach (var minimum in minimums)
				{
					pointsChecked.Add(minimum);
					pointsToCheck.Remove(minimum);
					howMuchToCheck = pointsToCheck.Count;
					var itterator = 0;
					foreach (var neighbour in points.ElementAt(minimum.Id).Neighbours)
					{
						if (pointsToCheck.Contains(neighbour))
						{							
							if (distancesBeetwenPoints[neighbour.Id] > distancesBeetwenPoints[minimum.Id] + points.ElementAt(minimum.Id).Distance.ElementAt(itterator))
							{
								distancesBeetwenPoints[neighbour.Id] = distancesBeetwenPoints[minimum.Id] + points.ElementAt(minimum.Id).Distance.ElementAt(itterator);
								previousPoint[neighbour.Id] = minimum.Id;
							}
						}
						itterator++;
					}
				}
			}

			List<int> path = new List<int>();
			path.Add(previousPoint[1]);

			int startPoint = previousPoint[1];
			int counter = 0;

			while (startPoint != 0)
			{
				try
				{
					path.Add(previousPoint[path[counter]]);
					startPoint = path[counter];
					counter++;
				}
				catch 
				{
					MessageBox.Show("No path available", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return bitmap;
				}
			}


			for (int i = 0; i < points.Count; i++)
			{
				if (path.Contains(i))
				{
					using (var graphics = Graphics.FromImage(bitmap))
					{

						SolidBrush solidBrush = new SolidBrush(Color.Yellow);
						graphics.FillEllipse(solidBrush, new Rectangle(points.ElementAt(i).AxisX - 10, points.ElementAt(i).AxisY - 10, 30, 30));
					}

				}
			}
			return bitmap;

		}
	}
}
