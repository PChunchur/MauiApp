using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lets_Try.Models;
using Lets_Try.Pages;
using Lets_Try.Services;

namespace Lets_Try;

public partial class LoginPage : ContentPage
{
    private readonly ILoginRepository _loginRepository = new LoginServices();
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void BtnLogin_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            if (userName == null || password == null)
            {
                await DisplayAlert("Warning", "Empty Field : Username / Password", "Ok");
                return;
            }

            UserInfo userInfo = await _loginRepository.Login(userName, password);
            if (userInfo != null)
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Warning", "Incorrect:  Username / Password", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Ok");
        }

    }
}