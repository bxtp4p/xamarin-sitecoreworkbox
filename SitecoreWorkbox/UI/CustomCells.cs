using Xamarin.Forms;
using System.Linq;

namespace SitecoreWorkbox.UI
{
	public enum AccessoryType { Disclosure, Detail, None, DetailDisclosure, Checkmark }
	
	public class AccessoryTextCell : TextCell, IAccessoryCell
	{
		public static readonly BindableProperty AccessoryTypeProperty = 
			BindableProperty.Create<AccessoryTextCell, AccessoryType>(e => e.AccessoryType, AccessoryType.None);
		
		public AccessoryType AccessoryType 
		{ 
			get { return (AccessoryType)GetValue (AccessoryTypeProperty); } 
			set { SetValue (AccessoryTypeProperty, value); }
		}
	}

	public class AccessoryImageCell : ImageCell, IAccessoryCell
	{
		public static readonly BindableProperty AccessoryTypeProperty = 
			BindableProperty.Create<AccessoryTextCell, AccessoryType>(e => e.AccessoryType, AccessoryType.None);
		

		public AccessoryType AccessoryType 
		{ 
			get { return (AccessoryType)GetValue (AccessoryTypeProperty); } 
			set { SetValue (AccessoryTypeProperty, value); }
		}
	}

	public interface IAccessoryCell
	{
		AccessoryType AccessoryType { get; set; }
	}
}

