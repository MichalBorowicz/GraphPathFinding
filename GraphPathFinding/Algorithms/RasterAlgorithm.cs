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
	public class RasterAlgorithm : IRasterAlgorithm
	{
		private ICollection<PointModel> points = new List<PointModel>();
		private int _id;
		public Bitmap Get(string bitmapPath)
		{
			_id = 0;
			points = new List<PointModel>();
			var bitmap = new Bitmap(bitmapPath, true);
			AddStartAndEndPoint(bitmap);
			RasterMethod(bitmap);

			return bitmap;
		}

		private void DrawSquare(Bitmap bitmap, int axisX, int axisY, Color color, int sqareSize)
		{
			Graphics graphics = Graphics.FromImage(bitmap);
			var x = axisX >= sqareSize ? axisX - sqareSize : 0;
			var y = axisY >= sqareSize ? axisY - sqareSize : 0;
			Pen solidBrush = new Pen(Color.Red);
			graphics.DrawRectangle(solidBrush, new Rectangle(x, y, sqareSize, sqareSize));
		}
		private void DrawLine(Bitmap bitmap, int axisX, int axisY, Color color)
		{
			Graphics graphics = Graphics.FromImage(bitmap);

			SolidBrush solidBrush = new SolidBrush(color);
			graphics.FillEllipse(solidBrush, new Rectangle(axisX, axisY, 8, 8));
		}
		private Bitmap RasterMethod(Bitmap bitmap)
		{
			var squareSize = 16;
			var width = bitmap.Width / squareSize;
			var height = bitmap.Height / squareSize;

			for (int widthCounter = 0; widthCounter < width; widthCounter++)
			{
				for (int heightCounter = 0; heightCounter < height; heightCounter++)
				{
					var widthSquareEndPixel = widthCounter * squareSize;
					var heightSquareEndPixel = heightCounter * squareSize;
					if (CheckEmptyArea(widthSquareEndPixel, heightSquareEndPixel, bitmap, squareSize))
					{
						AddPointToGraph(widthSquareEndPixel, heightSquareEndPixel, squareSize, bitmap);
					DrawSquare(bitmap, widthSquareEndPixel, heightSquareEndPixel, Color.Red, squareSize);
					}
				}
			}
			AssignNeighbours(bitmap);



			return bitmap;
		}
		private void AssignNeighbours(Bitmap bitmap)
		{
			var _maksDistanceFromClosestPoint = 100;
			for (int i = 0; i < points.Count - 1; ++i)
			{
				for (int j = i + 1; j < points.Count; ++j)
				{
					PointModel pointA = points.ElementAt(i);
					PointModel pointB = points.ElementAt(j);
					int distance = Distance(pointA, pointB);
					if (distance != 0 && distance < _maksDistanceFromClosestPoint)
					{
						ConnectTwoPointsAsNeighbours(pointA, pointB, distance);
					}
				}
			}
		}
		private static void ConnectTwoPointsAsNeighbours(PointModel pointA, PointModel pointB, int distance)
		{
			pointA.Neighbours.Add(pointB);
			pointB.Neighbours.Add(pointA);
			pointA.Distance.Add(distance);
			pointB.Distance.Add(distance);
		}
		private void AddPointToGraph(int widthSquareEndPixel, int heightSquareEndPixel, int sqareSize, Bitmap bitmap)
		{
			var point = new PointModel(widthSquareEndPixel + sqareSize / 2, heightSquareEndPixel + sqareSize / 2, GetId());
			points.Add(point);
			DrawLine(bitmap, point.AxisX, point.AxisY, Color.Blue);
		}
		private bool CheckEmptyArea(int maxWidth, int maxHeight, Bitmap bitmap, int squareSize)
		{
			var onlyWhitePixel = true;

			int widthPixelLenght = maxWidth - squareSize;
			if (widthPixelLenght < 0)
			{
				widthPixelLenght = 0;
			}
			while (widthPixelLenght <= maxWidth && onlyWhitePixel)
			{
				int heightPixelLenght = maxHeight - squareSize;
				if (heightPixelLenght < 0)
				{
					heightPixelLenght = 0;
				}
				while (heightPixelLenght <= maxHeight && onlyWhitePixel)
				{
					var pixel = bitmap.GetPixel(widthPixelLenght, heightPixelLenght);
					if (pixel.B == 0 && pixel.G == 0 && pixel.R == 0)
					{
						onlyWhitePixel = false;
						break;
					}
					heightPixelLenght++;
				}
				widthPixelLenght++;
			}

			return onlyWhitePixel;
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
			DrawLine(bitmap, tokyoPoint.AxisX - 10, tokyoPoint.AxisY - 20, Color.Red);
			DrawLine(bitmap, londonPoint.AxisX, londonPoint.AxisY, Color.Green);
		}

		public ICollection<PointModel> GetPoints()
		{
			return points;
		}
		public int Distance(PointModel firstPoint, PointModel secendPoint)
		{
			float xAxisDistance = Math.Abs(firstPoint.AxisX - secendPoint.AxisX);
			float yAxisDistance = Math.Abs(firstPoint.AxisY - secendPoint.AxisY);
			int distance = (int)Math.Sqrt(xAxisDistance * xAxisDistance + yAxisDistance * yAxisDistance);
			return distance;
		}
	}
}
