using Xamarin.Forms;
using SitecoreWorkbox.UI;
using SitecoreWorkbox.iOS.UI;
using UIKit;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (AccessoryImageCell), typeof (AccessoryImageCellRenderer))]
[assembly: ExportRenderer (typeof (AccessoryTextCell), typeof (AccessoryTextCellRenderer))]

namespace SitecoreWorkbox.iOS.UI
{
	public class AccessoryImageCellRenderer : ImageCellRenderer
	{
		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cell = base.GetCell (item, reusableCell, tv);

			CellRendererHelper.SetDisclosure (item, cell);

			return cell;
		}
	}

	public class AccessoryTextCellRenderer : TextCellRenderer
	{
		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cell = base.GetCell (item, reusableCell, tv);

			CellRendererHelper.SetDisclosure (item, cell);

			return cell;
		}
	}

	internal static class CellRendererHelper
	{
		public static void SetDisclosure (Cell item, UITableViewCell cell)
		{
			AccessoryType disclosureType = (item as IAccessoryCell).AccessoryType;

			switch (disclosureType) {
			case AccessoryType.Detail:
				cell.Accessory = UIKit.UITableViewCellAccessory.DetailButton;
				break;
			case AccessoryType.Disclosure:
				cell.Accessory = UIKit.UITableViewCellAccessory.DisclosureIndicator;
				break;
			case AccessoryType.Checkmark:
				cell.Accessory = UIKit.UITableViewCellAccessory.Checkmark;
				break;
			case AccessoryType.DetailDisclosure:
				cell.Accessory = UIKit.UITableViewCellAccessory.DetailDisclosureButton;
				break;
			case AccessoryType.None:
				cell.Accessory = UIKit.UITableViewCellAccessory.None;
				break;
			}
		}
	}
}

