using PromedioAcademico.ViewModels;

namespace PromedioAcademico.Views;

public partial class PromedioPage : ContentPage
{
    public PromedioPage()
    {
        InitializeComponent();
        BindingContext = new PromedioViewModel();
    }
}