﻿using Microsoft.Win32;
using System.IO;

namespace GbXmlDesignSuite.Services
{
    public interface IDialogsService
    {
        string OpenFilePath { get; }
        string SaveFilePath { get; }

        bool? ShowOpenFileDialog(string filter);
        bool? ShowSaveFileDialog(string filter);
        bool? ShowSaveFileDialog(string filter, string filepath);
    }


    public class DialogService : IDialogsService
    {
        #region Fields

        private OpenFileDialog _OpenFileDialog = new OpenFileDialog();
        private SaveFileDialog _SaveFileDialog = new SaveFileDialog();

        #endregion

        #region Properties

        /// <summary>
        /// The open file path.
        /// </summary>
        public string OpenFilePath { get; set; }

        /// <summary>
        /// The save file path.
        /// </summary>
        public string SaveFilePath { get; set; }

        #endregion

        #region Public Methods

        /// <summary>    
        /// Show open file dialog.      
        /// </summary>
        /// <param name="filter">The current file name filter string, which determines the choices that appear in the "Save as file type" or "Files of type" box in the dialog box.</param>
        /// <returns>A Nullable<T> value of type Boolean that specifies whether the activity was accepted (true) or canceled (false). The return value is the value of the DialogResult property before a window closes</returns>
        public bool? ShowOpenFileDialog(string filter)
        {
            _OpenFileDialog.Filter = filter;
            bool? result = _OpenFileDialog.ShowDialog();
            OpenFilePath = _OpenFileDialog.FileName;
            return result;
        }

        /// <summary>
        /// Show save file dialog
        /// </summary>
        /// <param name="filter">The current file name filter string, which determines the choices that appear in the "Save as file type" or "Files of type" box in the dialog box</param>
        /// <returns>A Nullable<T> value of type Boolean that specifies whether the activity was accepted (true) or canceled (false). The return value is the value of the DialogResult property before a window closes</returns>
        public bool? ShowSaveFileDialog(string filter)
        {
            _SaveFileDialog.Filter = filter;
            bool? result = _SaveFileDialog.ShowDialog();
            SaveFilePath = _SaveFileDialog.FileName;
            return result;
        }

        /// <summary>
        /// Show save file dialog
        /// </summary>
        /// <param name="filter">The current file name filter string, which determines the choices that appear in the "Save as file type" or "Files of type" box in the dialog box</param>
        /// <param name="filepath">The save file path</param>
        /// <returns>A Nullable<T> value of type Boolean that specifies whether the activity was accepted (true) or canceled (false). The return value is the value of the DialogResult property before a window closes</returns>
        public bool? ShowSaveFileDialog(string filter, string filepath)
        {
            string filename = Path.GetFileNameWithoutExtension(filepath);

            _SaveFileDialog.Filter = filter;
            _SaveFileDialog.FileName = filename;
            bool? result = _SaveFileDialog.ShowDialog();
            SaveFilePath = _SaveFileDialog.FileName;
            return result;
        }
        #endregion
    }
}
