//using GbXmlDesignSuite.Core.Constants;
//using GbXmlDesignSuite.Core.Interfaces;
//using MahApps.Metro.Controls;
//using MahApps.Metro.Controls.Dialogs;
//using System.Threading.Tasks;
//using System.Windows;
//using Unity;

//namespace GbXmlDesignSuite.Core.Services
//{
//    public class MessageDisplayService : IMessageDisplayService
//    {
//        /// <summary>
//        /// CTOR
//        /// </summary>
//        /// <param name="container">Unity container.</param>
//        public MessageDisplayService(IUnityContainer container)
//        {
//            this.MainWindow = container.Resolve<Window>(WindowNames.MainWindowName) as MetroWindow;
//        }

//        #region Properties

//        private MetroWindow mainWindow;

//        /// <summary>
//        /// The main window
//        /// </summary>
//        public MetroWindow MainWindow
//        {
//            get { return mainWindow; }
//            private set { mainWindow = value; }
//        }

//        #endregion Properties
//        /// <summary>
//        ///  Shows a Message Dialog Window
//        /// </summary>
//        /// <param name="title"> Dialog Title </param>
//        /// <param name="message"> Dialog Message </param>
//        /// <param name="style"> Dialog Style </param>
//        /// <param name="settings"> Dialog Settings</param>
//        /// <returns></returns>
//        public async Task<MessageDialogResult> ShowMessageAsnyc(string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
//        {
//            this.MainWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;

//            return await this.MainWindow.ShowMessageAsync(title, message, style, this.MainWindow.MetroDialogOptions);
//        }

//    }
//}
