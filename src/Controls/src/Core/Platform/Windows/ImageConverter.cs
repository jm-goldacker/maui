#nullable disable
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Internals;
using Microsoft.UI.Xaml.Controls;

namespace Microsoft.Maui.Controls.Platform
{
	public class ImageConverter : Microsoft.UI.Xaml.Data.IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{

			//Todo
			if (value is not ImageSource source)
				return null;

			var context = source.FindMauiContext(true);
			return source.GetPlatformImageAsync(context).ContinueWith(task => task.Result.Value).AsAsyncValue();
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotSupportedException();
		}
	}
}