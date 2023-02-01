using AngelMoreta_EvaluacionP3.Models;
using AngelMoreta_EvaluacionP3.Views;
namespace AngelMoreta_EvaluacionP3.Views;

public partial class AM_FraseListaDB : ContentPage
{
    public AM_FraseListaDB()
    {
        InitializeComponent();
        List<AMFrase> frase = App.AMFraseRepo.GetAllFrases();
        AM_FraseList.ItemsSource = frase;
        BindingContext = this;
    }


    public void OnItemAdded(object sender, EventArgs e)
    {
        // await Shell.Current.GoToAsync(nameof(BurgerItemPage));
        Shell.Current.GoToAsync(nameof(AM_FraseItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new AMFrase()
        });

    }

    public void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        AMFrase selectedFrase = (AMFrase)AM_FraseList.SelectedItem;
        if (selectedFrase != null)
        {
            Shell.Current.GoToAsync(nameof(AM_FraseItemPage), true, new Dictionary<string, object>
            {
                ["Item"] = selectedFrase
            });

        }
        else
        {
            Console.WriteLine("error");
        }
    }

    private void OnActualizarClicked(object sender, EventArgs e)
    {
        List<AMFrase> frase = App.AMFraseRepo.GetAllFrases();
        AM_FraseList.ItemsSource = frase;

    }

    private void OnActualizarClic(object sender, EventArgs e)
    {

        List<AMFrase> frase = App.AMFraseRepo.GetAllFrases();
        AM_FraseList.ItemsSource = frase;
    }
}