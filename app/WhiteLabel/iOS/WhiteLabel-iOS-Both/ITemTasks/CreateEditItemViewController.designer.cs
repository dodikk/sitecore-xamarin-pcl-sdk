// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
#endif
using System.CodeDom.Compiler;

namespace WhiteLabeliOS
{
	[Register ("CreateEditItemViewController")]
	partial class CreateEditItemViewController
	{
		[Outlet]
		UIButton createButton { get; set; }

		[Outlet]
		UITextField nameField { get; set; }

		[Outlet]
		UITextField pathField { get; set; }

		[Outlet]
		UITextField textField { get; set; }

		[Outlet]
		UITextField titleField { get; set; }

		[Outlet]
		UIButton updateButton { get; set; }

		[Action ("OnCreateItemButtonTapped:")]
		partial void OnCreateItemButtonTapped (NSObject sender);

		[Action ("OnUpdateItemButtonTapped:")]
		partial void OnUpdateItemButtonTapped (NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (nameField != null) {
				nameField.Dispose ();
				nameField = null;
			}

			if (pathField != null) {
				pathField.Dispose ();
				pathField = null;
			}

			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}

			if (titleField != null) {
				titleField.Dispose ();
				titleField = null;
			}

			if (createButton != null) {
				createButton.Dispose ();
				createButton = null;
			}

			if (updateButton != null) {
				updateButton.Dispose ();
				updateButton = null;
			}
		}
	}
}
