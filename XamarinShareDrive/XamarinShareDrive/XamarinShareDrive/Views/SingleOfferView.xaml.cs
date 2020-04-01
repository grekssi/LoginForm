using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinShareDrive.ViewModels;

namespace XamarinShareDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleOfferView : ContentView
    {
        public SingleOfferView()
        {
            InitializeComponent();
            this.BindingContext = new SingleOfferViewModel();
        }
    }
}