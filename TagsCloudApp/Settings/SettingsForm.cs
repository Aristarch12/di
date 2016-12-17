﻿using System.Windows.Forms;

namespace TagsCloudApp.Settings
{
    public static class SettingsForm
    {
        public static SettingsForm<TSettings> For<TSettings>(TSettings settings)
        {
            return new SettingsForm<TSettings>(settings);
        }
    }
    public class SettingsForm<TSettings> : Form
    {
        public SettingsForm(TSettings settings)
        {
            var okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom,
            };
            Controls.Add(okButton);
            Controls.Add(new PropertyGrid
            {
                SelectedObject = settings,
                Dock = DockStyle.Fill
            });
            AcceptButton = okButton;
        }
    }
}