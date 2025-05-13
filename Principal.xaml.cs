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
    private readonly List<string> images = new()
    {
        "vigia.jpg",
        "brisa.jpg",
        "mujeres.jpg",
        "rojos.jpg",
        "amarillos.jpg"
    };
    private int currentIndex = 0;
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


    private void OnPreviousClicked(object sender, EventArgs e)
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateImage();
        }
    }

    private void OnNextClicked(object sender, EventArgs e)
    {
        if (currentIndex < images.Count - 1)
        {
            currentIndex++;
            UpdateImage();
        }
    }

    private void UpdateImage()
    {
        imageDisplay.Source = images[currentIndex];
    }
}