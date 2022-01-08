using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Veterinary.Models;
namespace Veterinary
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var va = (AppointmentsList)BindingContext;
            va.Date = DateTime.UtcNow;
            await App.Database.SaveAppointmentsListAsync(va);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var va = (AppointmentsList)BindingContext;
            await App.Database.DeleteAppointmentsListAsync(va);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetServicePage((AppointmentsList)
           this.BindingContext)
            {
                BindingContext = new VetServices()
            });

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var va = (AppointmentsList)BindingContext;

            listView.ItemsSource = await App.Database.GetListVetServicesAsync(va.ID);
        }
    }
}