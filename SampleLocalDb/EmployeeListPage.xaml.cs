using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SampleLocalDb
{
    public partial class EmployeeListPage : ContentPage
    {
        public EmployeeListPage()
        {
            InitializeComponent();
            this.Title = "Employee List";

            var toolbarItem = new ToolbarItem
            {
                Text = "+"
            };
            toolbarItem.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new EmployeePage() { BindingContext = new Employee()});
            };

            ToolbarItems.Add(toolbarItem);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            EmployeeListView.ItemsSource = await App.Database.GetEmployeesAsync();
        }

        async void Employee_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EmployeePage() { BindingContext = e.SelectedItem as Employee });
            }
        }
    }
}
