using System.Drawing;
using System.Windows.Forms;
using TagsCloudApp.Actions;
using TagsCloudApp.Settings;

namespace TagsCloudApp
{
    class ApplicationWindow : Form, IClient
    {
        public ApplicationWindow(IUiAction[] actions, Canvas canvas, ImageSettings imageSettings)
        {
            ClientSize = new Size(imageSettings.Width, imageSettings.Height);
            var mainMenu = new MenuStrip();
            mainMenu.Items.AddRange(actions.ToMenuItems());
            Controls.Add(mainMenu);
            canvas.Dock = DockStyle.Fill;
            Controls.Add(canvas);
        }

        public void Run()
        {
            Application.Run(this);
        }
    }
}