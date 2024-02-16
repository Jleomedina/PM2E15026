﻿using Microsoft.Extensions.Logging;

namespace PM2E15026
{
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
                })

                .UseMauiMaps();
                ;

    		builder.Services.AddSingleton<Controles.UbicacionesControl>();


            return builder.Build();
        }
    }
}
