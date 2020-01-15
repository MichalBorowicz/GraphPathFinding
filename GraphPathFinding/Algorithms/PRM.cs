using GraphPathFinding.Abstract;
using GraphPathFinding.Helpers.Abstract;
using GraphPathFinding.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GraphPathFinding.Algorithms
{
	public class PRM : IPRM
	{
		private readonly int _maxAmountOfRandomPoints = 1000;
		private readonly int _maksDistanceFromClosestPoint = 220;
		private ICollection<PointModel> points = new List<PointModel>();
		private int _id;

		private void DrawLine(Bitmap bitmap, int axisX, int axisY, Color color)
		{
			Graphics graphics = Graphics.FromImage(bitmap);

			SolidBrush solidBrush = new SolidBrush(color);
			graphics.FillEllipse(solidBrush, new Rectangle(axisX, axisY , 20, 20));
		}

		public Bitmap Get(Bitmap bitmap)
		{
			_id = 0;
			points = new List<PointModel>();
			bitmap = new Bitmap(@" C:\Users\Michał\source\repos\GraphPathFinding\GraphPathFinding\Resources\worldMap.png", true);
			GenerateRandomPoints(_maxAmountOfRandomPoints, bitmap);
			ProbabilisticRoadMap(bitmap);

			return bitmap;
		}

		private void GenerateRandomPoints(int maxAmountOfRandomPoints, Bitmap bitmap)
		{
			Random rnd = new Random();
			Graphics graphics = Graphics.FromImage(bitmap);
			AddStartAndEndPoint(bitmap);
			for (int i = 0; i < maxAmountOfRandomPoints; ++i)
			{
				var axisX = rnd.Next(0, bitmap.Width);
				var axisY = rnd.Next(0, bitmap.Height);

				if (IsPixelNotBlack(bitmap, axisX, axisY))
				{
					var pointToAdd = new PointModel(axisX, axisY, GetId());
					points.Add(pointToAdd);

					DrawLine(bitmap, pointToAdd.AxisX - 10, pointToAdd.AxisY - 10, Color.Brown);
				}
			}
		}

		private static bool IsPixelNotBlack(Bitmap bitmap, int axisX, int axisY)
		{
			return bitmap.GetPixel(axisX, axisY).R != 0;
		}

		private int GetId()
		{
			return _id++;
		}
		private void AddStartAndEndPoint(Bitmap bitmap)
		{
			var tokyoPoint = new PointModel(3060, 775, GetId());
			var londonPoint = new PointModel(1795, 541, GetId());

			points.Add(tokyoPoint);
			points.Add(londonPoint);
			DrawLine(bitmap, tokyoPoint.AxisX - 10,tokyoPoint.AxisY - 20, Color.Red);
			DrawLine(bitmap, londonPoint.AxisX, londonPoint.AxisY, Color.Green);
		}

		public ICollection<PointModel> GetPoints()
		{
			return points;
		}

		private Bitmap ProbabilisticRoadMap(Bitmap bitmap)
		{
			var isPath = false;		
			for (int i = 0; i < points.Count - 1; ++i)
			{
				for (int j = i + 1; j < points.Count; ++j)
				{
					PointModel pointA = points.ElementAt(i);
					PointModel pointB = points.ElementAt(j);
					int distance = Distance(pointA, pointB);
					if (distance != 0 && distance < _maksDistanceFromClosestPoint)
					{
						isPath = CheckIsPathBetweenToPointsIsValid(pointA, pointB, bitmap);
						if (isPath)
						{
							ConnectTwoPointsAsNeighbours(pointA, pointB, distance);

							using (var graphics = Graphics.FromImage(bitmap))
							{
								graphics.DrawLine(new Pen(Color.FromArgb(0, 0, 255), 1), pointA.AxisX, pointA.AxisY, pointB.AxisX, pointB.AxisY);
							}

						}
					}
				}
			}
			return bitmap;
		}

		private static void ConnectTwoPointsAsNeighbours(PointModel pointA, PointModel pointB, int distance)
		{
			pointA.Neighbours.Add(pointB);
			pointB.Neighbours.Add(pointA);
			pointA.Distance.Add(distance);
			pointB.Distance.Add(distance);
		}

		public int Distance(PointModel firstPoint, PointModel secendPoint)
		{
			float xAxisDistance = Math.Abs(firstPoint.AxisX - secendPoint.AxisX);
			float yAxisDistance = Math.Abs(firstPoint.AxisY - secendPoint.AxisY);
			int distance = (int)Math.Sqrt(xAxisDistance * xAxisDistance + yAxisDistance * yAxisDistance);
			return distance;
		}
		public bool CheckIsPathBetweenToPointsIsValid(PointModel firstPoint, PointModel secendPoint, Bitmap bitmap)
		{
			var isPath = true;
			int weight = secendPoint.AxisX - firstPoint.AxisX;
			int height = secendPoint.AxisY - firstPoint.AxisY;
			int firstPointAxisX = firstPoint.AxisX;
			int firstPointAxisY = firstPoint.AxisY;
			const int halfOfCollection = 2;
			int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
			if (weight < 0) dx1 = -1; else if (weight > 0) dx1 = 1;
			if (height < 0) dy1 = -1; else if (height > 0) dy1 = 1;
			if (weight < 0) dx2 = -1; else if (weight > 0) dx2 = 1;
			int longest = Math.Abs(weight);
			int shortest = Math.Abs(height);
			if (!(longest > shortest))
			{
				longest = Math.Abs(height);
				shortest = Math.Abs(weight);
				if (height < 0) dy2 = -1; else if (height > 0) dy2 = 1;
				dx2 = 0;
			}
			int numerator = longest / halfOfCollection;
			for (int i = 0; i <= longest; i++)
			{
				if (bitmap.GetPixel(firstPointAxisX, firstPointAxisY).B == 0)
				{
					isPath = false;
					break;
				}
				numerator += shortest;
				if (!(numerator < longest))
				{
					numerator -= longest;
					firstPointAxisX += dx1;
					firstPointAxisY += dy1;
				}
				else
				{
					firstPointAxisX += dx2;
					firstPointAxisY += dy2;
				}
			}
			return isPath;
		}
	}
}
