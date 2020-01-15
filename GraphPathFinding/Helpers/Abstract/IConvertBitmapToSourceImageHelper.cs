using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GraphPathFinding.Helpers.Abstract
{
	public interface IConvertBitmapToSourceImageHelper
	{
		BitmapImage Convert(Bitmap bitmap);
	}
}
