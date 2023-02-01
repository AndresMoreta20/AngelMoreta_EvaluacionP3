namespace AngelMoreta_EvaluacionP3;
using AngelMoreta_EvaluacionP3.Views;
public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(AM_FraseItemPage), typeof(AM_FraseItemPage));
        Routing.RegisterRoute(nameof(AM_FraseListaAPI), typeof(AM_FraseListaAPI));
        Routing.RegisterRoute(nameof(AM_FraseListaDB), typeof(AM_FraseListaDB));
    }
}
