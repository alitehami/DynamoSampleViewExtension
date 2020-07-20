using System;
using System.Windows;

using System.Windows.Controls;
using Dynamo.Wpf.Extensions;


namespace SampleViewExtension
{
    class SampleViewExtension : IViewExtension
    {
        private MenuItem sampleMenuItem;

        public string UniqueId
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }

        public string Name
        {
            get
            {
                return "Sample View Extension";
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }


        public void Loaded(ViewLoadedParams p)
        {
            sampleMenuItem = new MenuItem { Header = "Sample ViewExtension, AliT" };
            sampleMenuItem.Click += (sender, args) =>
            {
                var viewModel = new SampleWindowViewModel(p);
                var window = new SampleWindow
                {
                    MainGrid = { DataContext = viewModel },
                    Owner = p.DynamoWindow
                };
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                window.Show();
            };
            p.AddMenuItem(MenuBarType.View, sampleMenuItem);
        }

        public void Shutdown()
        {
            //throw new NotImplementedException();
        }

        public void Startup(ViewStartupParams p)
        {
            //throw new NotImplementedException();
        }
    }
}
