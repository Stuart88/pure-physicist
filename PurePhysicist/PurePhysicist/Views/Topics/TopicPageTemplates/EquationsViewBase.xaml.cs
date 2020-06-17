using PurePhysicist.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PurePhysicist.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.TopicPageTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquationsViewBase : ContentView, ITopicPage
    {
        public Color ThemeColour { get; set; }
        public string TopicTitle { get; set; }
        public List<EquationItem> Equations { get; set; }
        public ObservableCollection<EquationItem> EquationsFiltered { get; set; }

        public EquationsViewBase(){}
        public EquationsViewBase(string topicTitle, Color themeColour, List<EquationItem> equations)
        {

            equations.AssignIds();
            this.ThemeColour = themeColour;
            this.TopicTitle = topicTitle;
            this.Equations = equations;
            this.EquationsFiltered = new ObservableCollection<EquationItem>(equations);

            this.BindingContext = this;
            
            InitializeComponent();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            string query = ((SearchBar) sender).Text.ToLower().Replace("\'", "").Trim(); //remove apostrophes for lazy searching

            this.FilterEquationsList(query);
        }

        private void FilterEquationsList(string query)
        {
            var queryWords = query.Split(' ', '-').Where(s => !string.IsNullOrEmpty(s));

            var filtered = (from item in this.Equations
                    let label = item.LabelText.ToLower().Replace("\'", "").Trim()
                    let labelWords = label.Split(' ', '-').Where(s => !string.IsNullOrEmpty(s))
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

        private async void DetailsButton_Clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            string id = ((Button) sender).ClassId;

            EquationItem selected = this.Equations.FirstOrDefault(item => item.Id == id);

            if (selected != null)
            {
                await this.Navigation.PushModalAsync(new DerivationViewer(selected, this));
            }

            ((Button)sender).IsEnabled = true;
        }
    }
}