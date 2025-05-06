namespace ProyectoBDD;

public partial class Principal : ContentPage
{
    public Command<string> NavigateCommand { get; }
    public Principal()
	{
		InitializeComponent();
        NavigateCommand = new Command<string>(NavigateToPage);
        BindingContext = this;
    }
    private async void NavigateToPage(string SistemaTransporte)
    {
        //if (!string.IsNullOrEmpty(pageName))
        //{
        //    await Shell.Current.GoToAsync(pageName);
        //}
    }

    private async void IrSistemTrans(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SistemaTransporte());
    }
}