using GraphPathFinding.Abstract;
using GraphPathFinding.Helpers.Abstract;
using GraphPathFinding.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphPathFinding
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IDijkstra _dijkstra;
		private readonly IAStarAlgorithm _aStarAlgorithm;
		private readonly IPRM _prm;
		private readonly IComposition _composition;
		private readonly IRasterAlgorithm _rasterAlgorithm;
		private readonly IConvertBitmapToSourceImageHelper _convertBitmapToSourceImageHelper;
		private Bitmap _bitmap;
		private ICollection<PointModel> _pointModels;
		public MainWindow(IDijkstra dijkstra, IPRM prm, IRasterAlgorithm rasterAlgorithm, IComposition composition, IConvertBitmapToSourceImageHelper convertBitmapToSourceImageHelper, IAStarAlgorithm aStarAlgorithm)
		{
			InitializeComponent();
			_bitmap = new Bitmap(@" C:\Users\Michał\source\repos\GraphPathFinding\GraphPathFinding\Resources\worldMap.png", true);
			_prm = prm;
			_composition = composition;
			_rasterAlgorithm = rasterAlgorithm;
			_dijkstra = dijkstra;
			_aStarAlgorithm = aStarAlgorithm;
			_convertBitmapToSourceImageHelper = convertBitmapToSourceImageHelper;
			WorldMap.Source = _convertBitmapToSourceImageHelper.Convert(_bitmap);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			Application.Current.Shutdown();
		}

		private void Button_Click_PRM(object sender, RoutedEventArgs e)
		{
			_bitmap = _prm.Get(_bitmap);
			_pointModels = _prm.GetPoints();
			WorldMap.Source = _convertBitmapToSourceImageHelper.Convert(_bitmap);
		}

		private void Button_Click_Dijkstra(object sender, RoutedEventArgs e)
		{
			WorldMap.Source = _convertBitmapToSourceImageHelper.Convert(_dijkstra.Get(_bitmap, _pointModels));
		}

		private void RasterButton_Click(object sender, RoutedEventArgs e)
		{
			_bitmap = _rasterAlgorithm.Get(_bitmap);
			_pointModels = _rasterAlgorithm.GetPoints();
			WorldMap.Source = _convertBitmapToSourceImageHelper.Convert(_bitmap);
		}

		private void Composition_Click(object sender, RoutedEventArgs e)
		{
			_bitmap = _composition.Get(_bitmap);
			_pointModels = _composition.GetPoints();
			WorldMap.Source = _convertBitmapToSourceImageHelper.Convert(_bitmap);
		}

		private void AStar_Click(object sender, RoutedEventArgs e)
		{
			WorldMap.Source = _convertBitmapToSourceImageHelper.Convert(_aStarAlgorithm.Get(_pointModels,_bitmap));
		}
	}
}
