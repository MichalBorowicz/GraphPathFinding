using GraphPathFinding.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphPathFinding.Helpers.Implementation
{
	public class ConvertBitmapToSourceImageHelper : IConvertBitmapToSourceImageHelper
	{
		public BitmapImage Convert(Bitmap bitmap)
		{
			MemoryStream ms = new MemoryStream();
			bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
			BitmapImage image = new BitmapImage();
			image.BeginInit();
			ms.Seek(0, SeekOrigin.Begin);
			image.StreamSource = ms;
			image.EndInit();
			return image;	
  } 
	}
}
