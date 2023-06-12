using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui;
using Syncfusion.Maui.Charts;
using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;

namespace UI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.ConfigureSyncfusionCore();
        builder.UseMauiCommunityToolkit();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("fontello.ttf", "Icons");
            fonts.AddFont("SpaceMono-Regular.ttf", "SpaceR");
            fonts.AddFont("SpaceMono-Bold.ttf", "SpaceB");
            fonts.AddFont("SpaceGrotesk-Light.ttf", "SpaceGL");
            fonts.AddFont("SpaceGrotesk-Regular.ttf", "SpaceGR");
            fonts.AddFont("SpaceGrotesk-Bold.ttf", "SpaceGB");
            fonts.AddFont("fontelloo.ttf", "Iconss");

        });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}

//TODO: Collection views and list of unwritten models
//TODO: Transaction Model
//TODO: busuiness logic
//TODO: Status bar
//TODO: Design MainPage and related pages including wireframe *