using AngelMoreta_EvaluacionP3.Data;
namespace AngelMoreta_EvaluacionP3;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        string dbPath = AMFileAccessHelper.GetLocalFilePath("AMfrase.db3");
        builder.Services.AddSingleton<AMFraseDatabase>(s => ActivatorUtilities.CreateInstance<AMFraseDatabase>(s, dbPath));

        return builder.Build();
	}
}
