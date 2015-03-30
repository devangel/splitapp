using Salesforce.SDK.App;
using Salesforce.SDK.Source.Security;
using Salesforce.SDK.Source.Settings;
using SplitApp.Common;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Split App template is documented at http://go.microsoft.com/fwlink/?LinkId=234228

namespace SplitApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : SalesforceApplication
    {
        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.InitializeConfig();
            GlobalClientManager.Logout();

            //this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
        /// <summary>
        /// InitializeConfig should implement the commented out code. You should come up with your own, unique password and salt and for added security
        /// you should implement your own key generator using the IKeyGenerator interface.  
        /// </summary>
        /// <returns></returns>
        protected override Salesforce.SDK.Source.Settings.SalesforceConfig InitializeConfig()
        {
            EncryptionSettings settings = new EncryptionSettings(new HmacSHA256KeyGenerator())
            {
                Password = "fbeffb40-aac6-4ea5-a4cf-388dccdfc93d",
                Salt = "9ca01492-e55a-4f30-afe2-a3783462f981"
            };
            Encryptor.init(settings);
            Config config = SalesforceConfig.RetrieveConfig<Config>();
            if (config == null)
                config = new Config();
            return config;
        }

        /// <summary>
        /// This returns the root application of your application. Please adjust to match your actual root page if you use something different.
        /// </summary>
        /// <returns></returns>
        protected override Type SetRootApplicationPage()
        {
            return typeof(ItemsPage);
        }
    }

}
