using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurePhysicist.Models;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private List<HomeMenuItem> MenuItems { get; set; }
        private MainPage RootPage => Application.Current.MainPage as MainPage;
        private bool IsModal {get;set;}

        public HomePage(bool isModal = false)
        {
            this.IsModal = isModal;

            NavigationPage.SetHasNavigationBar(this, false);

            this.MenuItems = Helpers.Functions.GetMenuItems()
                .Where(i => i.Icon != null)
                .ToList();

            this.SetupHomePageView();
        }

        private void SetupHomePageView()
        {
            StackLayout topSection = new StackLayout
            {
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Padding = 4
            };
            topSection.Children.Add(new Label
            {
                Text = "Pure Physicist",
                TextColor = Color.White,
                FontSize = 36,
                FontAttributes = FontAttributes.Bold,
                VerticalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center
            });

            FlexLayout flexLayout = new FlexLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FlowDirection = FlowDirection.LeftToRight,
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.SpaceAround,
                Wrap = FlexWrap.Wrap,
                Margin = new Thickness(0, 30, 0, 0)
            };

            foreach (var item in this.MenuItems)
            {
                item.Icon.HeightRequest = 100;
                item.Icon.WidthRequest = 100;
                StackLayout itemLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = 5,
                    BackgroundColor = Color.Transparent,
                    Padding = 2
                };


                itemLayout.Children.Add(item.Icon);
                itemLayout.Children.Add(new Label
                {
                    Text = item.Title.Replace(" ", "\n"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontAttributes = FontAttributes.Bold,
                    HeightRequest = 40
                });

                TapGestureRecognizer tapGesture = new TapGestureRecognizer();
                bool isModal = this.IsModal;
                tapGesture.Tapped += async (s, e) =>
                {
                    if (item.IsPageReference)
                    {
                        MenuPage.SelectedItem = item;

                        item.Icon.FadeTo(0, 150, Easing.CubicInOut);
                        await item.Icon.ScaleTo(0, 150, Easing.CubicInOut);

                        if (isModal)
                            RootPage.Navigation.PopModalAsync();

                        await RootPage.NavigateFromMenu(item.Id, item.TopicColour);
                    }
                };

                itemLayout.GestureRecognizers.Add(tapGesture);
                itemLayout.AlignSelf(FlexAlignSelf.Center);

                flexLayout.Children.Add(itemLayout);
            }


            StackLayout stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            ScrollView scroller = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            scroller.Content = flexLayout;
            stackLayout.Children.Add(topSection);
            stackLayout.Children.Add(scroller);

            if (this.IsModal)
            {
                //Add back button!
                Button backBtn = new Button
                {
                    Style = Application.Current.Resources["CoolStuffBackButton"] as Style,
                    Text = "Back",
                    HorizontalOptions = LayoutOptions.Center
                };
                backBtn.Clicked += (e, s) => { this.Navigation.PopModalAsync(); };
                stackLayout.Children.Add(backBtn);
            }

            this.Content = stackLayout;
        }
    }
}