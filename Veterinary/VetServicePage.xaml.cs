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
    public partial class VetServicePage : ContentPage
    {
        AppointmentsList al;
        public VetServicePage(AppointmentsList alist)
        {
            InitializeComponent();
            al = alist;

        }
        public VetServicePage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var vetservice = (VetServices)BindingContext;
            await App.Database.SaveVetServicesAsync(vetservice);
            listView.ItemsSource = await App.Database.GetVetServicesAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var vetservice = (VetServices)BindingContext;
            await App.Database.DeleteVetServicesAsync(vetservice);
            listView.ItemsSource = await App.Database.GetVetServicesAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetVetServicesAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            VetServices v;
            if (e.SelectedItem != null)
            {
                v = e.SelectedItem as VetServices;
                var lv = new ListVetServices()
                {
                    VetAppointmentID = al.ID,
                    VetServiceID = v.ID
                };
                await App.Database.SaveListVetServicesAsync(lv);
                v.ListVetServices = new List<ListVetServices> { lv };

                await Navigation.PopAsync();
            }
        }
    }
}