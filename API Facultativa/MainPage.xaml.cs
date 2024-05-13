namespace API_Facultativa;
using API_Facultativa.ViewModels;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        ProductosViewModel viewModel = new ProductosViewModel();

        // Establecer el ViewModel como contexto de datos de la página
        this.BindingContext = viewModel;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
       
    }
}
