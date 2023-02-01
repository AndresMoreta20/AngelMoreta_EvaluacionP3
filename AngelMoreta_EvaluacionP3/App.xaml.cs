using AngelMoreta_EvaluacionP3.Data;
namespace AngelMoreta_EvaluacionP3;

public partial class App : Application
{
    public static AMFraseDatabase AMFraseRepo { get; set; }
    public App(AMFraseDatabase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();
		AMFraseRepo= repo;
	}
}
