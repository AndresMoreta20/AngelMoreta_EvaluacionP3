using Newtonsoft.Json;
using System.Net;
using AngelMoreta_EvaluacionP3.Models;
using AngelMoreta_EvaluacionP3.Views;
using AngelMoreta_EvaluacionP3.ViewModels;

namespace AngelMoreta_EvaluacionP3.Views;

[QueryProperty("Item", "Item")]
public partial class AM_FraseItemPage : ContentPage
{

    public AMFrase Item
    {
        get => BindingContext as AMFrase;
        set => BindingContext = value;
    }

    bool _flag = false;
    public AM_FraseItemPage()
    {
        InitializeComponent();
        /* DateTime thisDay = DateTime.Today;
         FechaActual.Text= "Fecha actual: "+ thisDay.ToString();*/
        // string cadena = Buscador.Text;

    }


    private async void OnSaveClicked(object sender, EventArgs e)
    {
        Item.FechaActual = FechaActualV.Text;
        App.AMFraseRepo.AddNewFrase(Item);
        // await Shell.Current.GoToAsync(nameof(AM_FraseListaDB));
        await Shell.Current.Navigation.PopAsync();
        /* Item.Name = nameB.Text;
         Item.Description = descB.Text;
      ;*/
        //Shell.Current.GoToAsync("..");

    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("..");
       // Shell.Current.GoToAsync(nameof(AM_FraseListaDB));
        Shell.Current.Navigation.PopAsync();
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        App.AMFraseRepo.DeleteFrase(Item);
        //Shell.Current.GoToAsync(nameof(AM_FraseListaDB));
        Shell.Current.Navigation.PopAsync();
    }

    public async void OnRandomClicked(object sender, EventArgs e)
    {
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://api.quotable.io/random");
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json"); var client = new HttpClient();
        HttpResponseMessage response = await client.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            String content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<AMFrase>(content);
            AM_Autor.Text = resultado.author;
            AM_Contenido.Text = resultado.content;
            Item._id = resultado._id;
            Item.authorSlug = resultado.authorSlug;
            Item.length = resultado.length;
            Item.dateAdded = resultado.dateAdded;
            Item.dateModified = resultado.dateModified;

            // List<Frase> lista = new List<Frase>();
            //  lista.Add(resultado);
            // ListaDemo.ItemsSource = lista;
        }
    }
}