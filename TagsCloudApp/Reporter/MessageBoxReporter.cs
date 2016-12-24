using System.Windows.Forms;

namespace TagsCloudApp.Reporter
{
    public class MessageBoxReporter : IReporter
    {
        public void Report(string message)
        {
            MessageBox.Show(message);
        }
    }
}