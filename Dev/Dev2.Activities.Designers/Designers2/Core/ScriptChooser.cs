using System.Linq;
using Dev2.Studio.Core.Messages;

namespace Dev2.Activities.Designers2.Core
{
    public class ScriptChooser : IScriptChooser
    {
        #region Implementation of IScriptChooser

        public FileChooserMessage ChooseScriptSources(string includeFile)
        {
            const string separator = @";";
            var chooserMessage = new FileChooserMessage();
            
            if (includeFile == null)
            {
                includeFile = "";
            }
            chooserMessage.SelectedFiles = includeFile.Split(separator.ToCharArray());
            chooserMessage.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == @"SelectedFiles")
                {
                    if (chooserMessage.SelectedFiles == null || !chooserMessage.SelectedFiles.Any())
                    {
                        includeFile = "";
                    }
                    else
                    {
                        if (chooserMessage.SelectedFiles != null)
                        {
                            includeFile = string.Join(separator, chooserMessage.SelectedFiles);
                        }
                    }
                }
            };
            return chooserMessage;
        }

        #endregion
    }
}