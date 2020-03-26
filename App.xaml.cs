using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using SolutionChooser.Interfaces;
using SolutionChooser.Options;
using SolutionChooser.Services;
using SolutionChooser.ViewModels;

namespace SolutionChooser
{
    public class App : PrismApplication
    {
        public static bool IsSingleViewLifetime =>
            Environment.GetCommandLineArgs()
                .Any(a => a == "--fbdev" || a == "--drm");

        public static AppBuilder BuildAvaloniaApp() =>
            AppBuilder
                .Configure<App>()
                .UsePlatformDetect();

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            base.Initialize();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");

            var solutionChooserOptions = new SolutionChooserOptions();

            var configuration = configurationBuilder.Build();
            configuration.Bind("Options:SolutionChooserOptions", solutionChooserOptions);

            containerRegistry.Register<IMainWindowViewModel, MainWindowViewModel>();

            containerRegistry.RegisterInstance<IOptions<SolutionChooserOptions>>(new OptionsWrapper<SolutionChooserOptions>(solutionChooserOptions));

            containerRegistry.Register<ISolutionChooserService, SolutionChooserService>();
        }

        protected override IAvaloniaObject CreateShell()
        {
            var viewModel = Container.Resolve<IMainWindowViewModel>(); //with the interface trick, we have now all the ctor injections resolved by itself
            var mainWindow = Container.Resolve<MainWindow>();

            mainWindow.DataContext = viewModel;

            return mainWindow;
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
        }
    }
}
