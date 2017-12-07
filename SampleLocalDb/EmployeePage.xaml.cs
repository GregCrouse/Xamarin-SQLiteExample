using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SampleLocalDb
{
    public partial class EmployeePage : ContentPage
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object sender, System.EventArgs e)
        {
            var employeeObject = (Employee)BindingContext;
            await App.Database.SaveEmployeeAsync(employeeObject);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var employeeObject = (Employee)BindingContext;
            await App.Database.DeleteEmployeeAsync(employeeObject);
            await Navigation.PopAsync();
        }
    }
}
