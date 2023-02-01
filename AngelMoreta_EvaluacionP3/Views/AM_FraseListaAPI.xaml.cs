using AngelMoreta_EvaluacionP3.Models;
using AngelMoreta_EvaluacionP3.Views;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;


namespace AngelMoreta_EvaluacionP3.Views;

public partial class AM_FraseListaAPI : ContentPage
{
    List<AMFrase> frases = new List<AMFrase>();
    public AM_FraseListaAPI()
    {
        actualizarLista();
        InitializeComponent();
        AM_FraseList.ItemsSource = frases;
        // List<Frase> frase = App.FraseRepo.GetAllFrases();
        //M_FraseList.ItemsSource = frase;
        BindingContext = this;
    }


    public void OnItemAdded(object sender, EventArgs e)
    {
       
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


    public async void actualizarLista()
    {
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://api.quotable.io/quotes?page=1");
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json"); var client = new HttpClient();
        HttpResponseMessage response = await client.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            String content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<Root>(content);
            frases = resultado.results;
            AM_FraseList.ItemsSource = frases;

        }
    }


    public async void OnBotonPoblarClicked(object sender, EventArgs e)
    {
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://api.quotable.io/quotes?page=1");
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json"); var client = new HttpClient();
        HttpResponseMessage response = await client.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            String content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<Root>(content);
            frases = resultado.results;
            
            // AM_Autor.Text = resultado.author;
            //AM_Contenido.Text = resultado.content;
            //Item._id = resultado._id;
            //Item.authorSlug = resultado.authorSlug;
            //Item.length = resultado.length;
            //Item.dateAdded = resultado.dateAdded;
            //Item.dateModified = resultado.dateModified;
        }
    }
}