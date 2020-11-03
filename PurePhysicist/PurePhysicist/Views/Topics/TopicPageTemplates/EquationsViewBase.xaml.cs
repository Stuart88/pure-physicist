using PurePhysicist.Helpers;
using PurePhysicist.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.TopicPageTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquationsViewBase : ContentView, ITopicPage
    {
        #region Public Properties

        public List<EquationItem> Equations { get; set; }
        public ObservableCollection<EquationItem> EquationsFiltered { get; set; }
        public string PageTitle { get; set; }
        public Color ThemeColour { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public EquationsViewBase()
        {
        }

        public EquationsViewBase(string topicTitle, Color themeColour, List<EquationItem> equations)
        {
            equations.AssignIds();
            this.ThemeColour = themeColour;
            this.PageTitle = topicTitle;
            this.Equations = equations;
            this.EquationsFiltered = new ObservableCollection<EquationItem>(equations);

            this.BindingContext = this;

            InitializeComponent();

            if (this.PageTitle == Constants.TopicTitles.Thermodynamics)
                this.ContentsTitle.TextColor = Color.White;
        }

        #endregion Public Constructors

        #region Private Methods

        private async void DetailsButton_Clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            string id = ((Button)sender).ClassId;

            EquationItem selected = this.Equations.FirstOrDefault(item => item.Id == id);

            if (selected != null)
            {
                await this.Navigation.PushModalAsync(new DerivationViewer(selected));
            }

            ((Button)sender).IsEnabled = true;
        }

        private void FilterEquationsList(string query)
        {
            query = query.MakeNicerQueryString();
            char[] splitChars = {' ', '-', '(', ')'};
            var queryWords = query.Split(splitChars).Where(s => !string.IsNullOrEmpty(s));

            var filtered = (from item in this.Equations
                            let label = item.LabelText.ToLower().MakeNicerQueryString().Trim()
                            let labelWords = label.Split(splitChars).Where(s => !string.IsNullOrEmpty(s))
                            where string.IsNullOrEmpty(query)
                                  || labelWords.Intersect(queryWords).Any()
                                  || labelWords.Any(w => queryWords.Any(q => w.StartsWith(q)))
                                  || label.StartsWith(query)
                            orderby label.StartsWith(query)
                                //labelWords.Any(w => queryWords.Any(q => w.StartsWith(q)))
                                descending
                            select item)
                .ToList();

            EquationsFiltered = new ObservableCollection<EquationItem>(filtered);
            OnPropertyChanged(nameof(EquationsFiltered));
        }
        
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = ((SearchBar)sender).Text.ToLower().Trim(); //remove apostrophes for lazy searching

            this.FilterEquationsList(query);
        }

        #endregion Private Methods
    }
}