﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Hanselman.Portable.Views
{
	public partial class MenuPage : ContentPage
	{
		private RootPage _root;
		private List<HomeMenuItem> _menuItems;

		public MenuPage (RootPage root)
		{
			_root = root;
			InitializeComponent ();

			if (!App.IsWindows10) {
				BackgroundColor = Color.FromHex ("#03A9F4");
				ListViewMenu.BackgroundColor = Color.FromHex ("#F5F5F5");
			}

			BindingContext = new BaseViewModel {
				Title = "Hanselman.Forms",
				Subtitle = "Hanselman.Forms",
				Icon = "slideout.png"
			};

			ListViewMenu.ItemsSource = _menuItems = new List<HomeMenuItem>
				{
					new HomeMenuItem { Title = "About", MenuType = MenuType.About, Icon ="about.png" },
					new HomeMenuItem { Title = "Blog", MenuType = MenuType.Blog, Icon = "blog.png" },
					new HomeMenuItem { Title = "Twitter", MenuType = MenuType.Twitter, Icon = "twitternav.png" },
					new HomeMenuItem { Title = "Hanselminues", MenuType = MenuType.Hanselminutes, Icon = "hm.png" },
					new HomeMenuItem { Title = "Ratchet", MenuType =MenuType.Ratchet, Icon = "ratchet.png" },
					new HomeMenuItem { Title = "Developers Life", MenuType = MenuType.DeveloperLife, Icon = "tdl.png"}, 
					new HomeMenuItem { Title = "Jannine Life", MenuType = MenuType.Jannine, Icon = "tdl.png"}
				};

			ListViewMenu.SelectedItem = _menuItems [0];

			ListViewMenu.ItemSelected += async (sender, e) => {
				if (ListViewMenu.SelectedItem == null)
					return;

				await this._root.NavigateAsync (((HomeMenuItem)e.SelectedItem).MenuType);
			};
		}
	}
}

