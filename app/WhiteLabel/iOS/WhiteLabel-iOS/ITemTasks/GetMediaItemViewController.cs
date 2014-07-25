﻿

namespace WhiteLabeliOS
{
  using System;
  using System.Drawing;

  using MonoTouch.Foundation;
  using MonoTouch.UIKit;
  using Sitecore.MobileSDK;
  using Sitecore.MobileSDK.UrlBuilder.MediaItem;
  using System.IO;
  using Sitecore.MobileSDK.Session;


	public partial class GetMediaItemViewController : BaseTaskViewController
	{
		public GetMediaItemViewController (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("getMediaItem", null);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.MediaPathTextField.Placeholder = NSBundle.MainBundle.LocalizedString ("Type Media Path", null);

			string ButtonTitle = NSBundle.MainBundle.LocalizedString ("Download", null);
			this.DownloadButton.SetTitle (ButtonTitle, UIControlState.Normal);

			this.HeightLabel.Text = NSBundle.MainBundle.LocalizedString ("Height:", null);
			this.WidthLabel.Text = NSBundle.MainBundle.LocalizedString ("Width:", null);

			this.MediaPathTextField.Text = "/sitecore/media library/fffffffff";
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			this.maxWidth = (int)Math.Round (this.ImageView.Bounds.Width);
			this.maxHeight = (int)Math.Round (this.ImageView.Bounds.Height);

			this.WidthTextField.Text = maxWidth.ToString ();
			this.HeightTextField.Text = maxHeight.ToString ();
		}

		partial void OnDownloadButtonTouched (MonoTouch.Foundation.NSObject sender)
		{
			try
			{
				if (String.IsNullOrEmpty(this.WidthTextField.Text)
					||String.IsNullOrEmpty(this.HeightTextField.Text))
				{
					AlertHelper.ShowLocalizedAlertWithOkOption("Error", "Incorect width or height value");
					return;
				}

				this.width = Convert.ToInt32(this.WidthTextField.Text);
				this.height = Convert.ToInt32(this.HeightTextField.Text);

				if (String.IsNullOrEmpty(this.MediaPathTextField.Text))
				{
					AlertHelper.ShowLocalizedAlertWithOkOption("Error", "Please type media path");
				}
				else
				{
					bool wrongSizeData = this.width<=0
						||this.width>this.maxWidth
						||this.height<=0
						||this.height>this.maxHeight;

					if (wrongSizeData)
					{
						AlertHelper.ShowLocalizedAlertWithOkOption("Error", "Incorect width or height value");
					}
					else
						{
							this.HideKeyboard(this.MediaPathTextField);
							this.HideKeyboard(this.WidthTextField);
							this.HideKeyboard(this.HeightTextField);

							this.SendRequest();
						}
				}
			}
			catch(Exception e) 
			{
				AlertHelper.ShowLocalizedAlertWithOkOption("Error", e.Message);
			}
		}

		private async void SendRequest ()
		{
			try
			{
        ISitecoreWebApiSession session = this.instanceSettings.GetSession();

				IDownloadMediaOptions options = new MediaOptionsBuilder()
					.SetWidth(this.width)
					.SetHeight(this.height)
					.SetBackgroundColor("white")
					.Build();

				string path = this.MediaPathTextField.Text;

				var request = ItemWebApiRequestBuilder.ReadMediaItemRequest(path)
					.DownloadOptions(options)
					.Build();

				var response = await session.DownloadResourceAsync(request);

				byte[] data;

				using (BinaryReader br = new BinaryReader(response))
				{
					data = br.ReadBytes((int)response.Length);
				}

				UIImage image = null;
				image = new UIImage(NSData.FromArray(data));

				BeginInvokeOnMainThread(delegate
				{
					this.ImageView.Image = image;
					this.HideLoader();
				});

			}
			catch(Exception e) 
			{
				AlertHelper.ShowLocalizedAlertWithOkOption("Error", e.Message);
			}
			finally
			{
				BeginInvokeOnMainThread(delegate
				{
					this.HideLoader();
				});
			}
		}

		public int width;
		public int height;

		public int maxWidth;
		public int maxHeight;
	}
}
