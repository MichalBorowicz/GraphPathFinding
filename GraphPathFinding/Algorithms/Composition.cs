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
	public class Composition : IComposition
	{
		private ICollection<PointModel> points = new List<PointModel>();
		private int _id;
		public Bitmap Get(string bitmapPath)
		{
			points = new List<PointModel>();
			var bitmap = new Bitmap(bitmapPath, true);

			CompositionMethod(bitmap);

			return bitmap;
		}

		private Bitmap CompositionMethod(Bitmap bitmap)
		{
			throw new NotImplementedException();

			return bitmap;
		}

		private void AddPointToGraph()
		{

		}
		private bool CheckEmptyArea(int width, int height, Bitmap bitmap)
		{
			var onlyWhitePixel = true;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (bitmap.GetPixel(i, j).B != 0)
					{
						onlyWhitePixel = false;
						break;
					}

				}
			}
			return onlyWhitePixel;
		}

		private void DrawLine(Bitmap bitmap, int axisX, int axisY, Color color)
		{
			Graphics graphics = Graphics.FromImage(bitmap);

			SolidBrush solidBrush = new SolidBrush(color);
			graphics.FillEllipse(solidBrush, new Rectangle(axisX, axisY, 20, 20));
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
