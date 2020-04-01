using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinShareDrive.Adapters;
using XamarinShareDrive.BusinessLogic;
using XamarinShareDrive.Services;
using XamarinShareDrive.ViewModels;

namespace XamarinShareDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersPage : ContentPage
    {
        public OffersPage()
        {
            InitializeComponent();
            this.BindingContext = new OfferViewModel();

        }
    }
}