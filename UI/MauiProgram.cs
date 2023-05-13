using Microsoft.Extensions.Logging;
namespace UI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}

//TODO: Collection views and list of unwritten models
//TODO: Transaction Model
//TODO: Status bar
//TODO: Design MainPage and related pages including wireframe *