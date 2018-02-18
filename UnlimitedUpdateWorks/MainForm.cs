using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace UnlimitedUpdateWorks
{
    /// <summary>
    /// This class manages GUI events and the program's core logic.
    /// </summary>
    public partial class MainForm : Form
    {
        List<Update> updatesList = new List<Update>(); // List in which the found updates are placed.
        bool updatesFound = false; // Flag which gets switched to true if updates are found.
        bool areFoundUpdatesInstalled = false; // Flag which gets switched to true if the found updates are already installed.

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the MainForm is loaded read all saved data from the config.xml file and place all parsed values in their respective textboxes, checkboxes and numupdowns.
        /// Enable the remind and auto-check timers if their respective checkboxes are checked.
        /// If the check on start checkbox is checked check for updates by calling the ParseAndFilterUpdates method.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            string[] xmlData = new string[6];
            XML.LoadXML("config.xml");
            xmlData = XML.ParseXML();
            msCatalogUrlTextbox.Text = xmlData[0];
            titleRegexTextbox.Text = xmlData[1];
            productRegexTextbox.Text = xmlData[2];
            dateRegexTextbox.Text = xmlData[3];
            productFilterTextbox.Text = xmlData[4];
            secOnlyCheckBox.Checked = Boolean.Parse(xmlData[5]);
            isCompatibleCheckBox.Checked = Boolean.Parse(xmlData[6]);
            isInstalledCheckBox.Checked = Boolean.Parse(xmlData[7]);
            autoCheckIntervalNumUpDown.Value = int.Parse(xmlData[8]);
            autoCheckCheckBox.Checked = Boolean.Parse(xmlData[9]);
            checkOnStartCheckBox.Checked = Boolean.Parse(xmlData[10]);
            remindCheckBox.Checked = Boolean.Parse(xmlData[11]);
            remindIntervalNumUpDown.Value = int.Parse(xmlData[12]);
            autoCheckTimer.Enabled = autoCheckCheckBox.Checked;
            autoCheckTimer.Interval = (int)autoCheckIntervalNumUpDown.Value * 60000;
            remindTimer.Enabled = remindCheckBox.Checked;
            remindTimer.Interval = (int)remindIntervalNumUpDown.Value * 60000;

            if (checkOnStartCheckBox.Checked)
            {
                ParseAndFilterUpdates();
            }

        }

        /// <summary>
        /// When the auto-check timer ticks, call the ParseAndFilterUpdates method.
        /// </summary>
        private void autoCheckTimer_Tick(object sender, EventArgs e)
        {
            ParseAndFilterUpdates();
        }

        /// <summary>
        /// When the remind timer ticks, if the updatesFound flag is set to true check if the found updates are already installed.
        /// If they are not then call the ShowUpdatesBalloonTipAndUpdateToolStrip function.
        /// </summary>
        private void remindTimer_Tick(object sender, EventArgs e)
        {
            if (updatesFound)
            {
                foreach (Update u in updatesList)
                {
                    if (UpdateFilters.IsInstalled(u.KB))
                    {
                        areFoundUpdatesInstalled = true;
                        autoCheckTimer.Enabled = true;
                    }
                }
                if (!areFoundUpdatesInstalled)
                {
                    autoCheckTimer.Enabled = false;
                    ShowUpdatesBalloonTipAndUpdateToolStrip(updatesList);
                }
            }
        }

        /// <summary>
        /// When the exclude incompatible checkbox gets checked or unchecked:
        /// - enable the product filter textbox if the exclude incompatible checkbox is checked
        /// - disable the product filter textbox if the exclude incompatible checkbox is checked
        /// </summary>
        private void isCompatibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            productFilterTextbox.Enabled = isCompatibleCheckBox.Checked;
        }

        /// <summary>
        /// When the auto-check for updates checkbox gets checked or unchecked:
        /// - enable the auto-check timer and auto-check interval numupdown if the auto-check checkbox is checked
        /// - disable the auto-check timer and auto-check interval numupdown if the auto-check checkbox is not checked
        /// </summary>
        private void autoCheckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            autoCheckTimer.Enabled = autoCheckCheckBox.Checked;
            autoCheckIntervalNumUpDown.Enabled = autoCheckCheckBox.Checked;
        }

        /// <summary>
        /// When the update reminder checkbox gets checked or unchecked:
        /// - enable the update reminder timer and auto-check interval numupdown if the update reminder checkbox is checked
        /// - disable the update reminder timer and auto-check interval numupdown if the update reminder checkbox is not checked
        /// </summary>
        private void remindCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            remindTimer.Enabled = remindCheckBox.Checked;
            remindIntervalNumUpDown.Enabled = remindCheckBox.Checked;
        }

        /// <summary>
        /// If the auto-check interval numupdown value changes, update the auto-check timer interval value (after converting the numupdown's value to milliseconds).
        /// </summary>
        private void autoCheckIntervalNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            autoCheckTimer.Interval = (int)autoCheckIntervalNumUpDown.Value * 60000;
        }

        /// <summary>
        /// If the update reminder interval numupdown value changes, update the update reminder timer interval value (after converting the numupdown's value to milliseconds).
        /// </summary>
        private void remindIntervalNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            remindTimer.Interval = (int)remindIntervalNumUpDown.Value * 60000;
        }

        /// <summary>
        /// When the save button (in the Settings tab of the MainForm) gets clicked save all data to the config.xml file by calling the UpdateXML method and passing all values to it as parameters.
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            XML.UpdateXML(msCatalogUrlTextbox.Text, titleRegexTextbox.Text, productRegexTextbox.Text, dateRegexTextbox.Text, productFilterTextbox.Text, secOnlyCheckBox.Checked.ToString(), isCompatibleCheckBox.Checked.ToString(),
                isInstalledCheckBox.Checked.ToString(), autoCheckIntervalNumUpDown.Value.ToString(), autoCheckCheckBox.Checked.ToString(), checkOnStartCheckBox.Checked.ToString(), remindCheckBox.Checked.ToString(), remindIntervalNumUpDown.Value.ToString());
        }

        /// <summary>
        /// When the parse button (in the Update Parser tab of the MainForm) gets clicked check for updates by calling the ParseAndFilterUpdates method then set the listbox's data source to the found updates.
        /// Then, if updates are found, update the labels below the listbox to display the auto-selected update.
        /// While all of this happens disable the parse button and set the cursor to the "busy" one.
        /// </summary>
        private void parseButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            parseButton.Enabled = false;
            updateBindingSource.DataSource = ParseAndFilterUpdates();
            if (updatesListBox.Items.Count > 0)
            {
                UpdateLabels();
            }
            Cursor.Current = Cursors.Default;
            Application.DoEvents();
            parseButton.Enabled = true;
        }

        /// <summary>
        /// Parse updates by using the Scrape and ParseUpdates methods. Update the "last checked" menu strip entry with the current date and time.
        /// If the respective filtering checkboxes are checked filter the parsed updates.
        /// After they have been filtered, if updates are found then display a balloon tip by calling the ShowUpdatesBalloonTipAndUpdateToolStrip method.
        /// </summary>
        /// <returns>A list containing all found and filtered updates.</returns>
        public List<Update> ParseAndFilterUpdates()
        {
            
            updatesList = HTML.ParseUpdates(HTML.Scrape(StringManagement.ReplaceYearMonth(msCatalogUrlTextbox.Text)), titleRegexTextbox.Text, productRegexTextbox.Text, dateRegexTextbox.Text);
            notifyIconMenuStrip.Items[1].Text = "Last checked: " + DateTime.Now;
            if (secOnlyCheckBox.Checked)
            {
                updatesList.RemoveAll(u => !UpdateFilters.IsSecOnly(u.Title));
            }
            if (isInstalledCheckBox.Checked)
            {
                updatesList.RemoveAll(u => UpdateFilters.IsInstalled(u.KB));
            }
            if (isCompatibleCheckBox.Checked)
            {
                updatesList.RemoveAll(u => !UpdateFilters.IsCompatible(u.Product, productFilterTextbox.Text));
            }
            ShowUpdatesBalloonTipAndUpdateToolStrip(updatesList);

            return updatesList;
        }

        /// <summary>
        /// Update the labels in the Update Parser tab of the GUI to match the update selected in the listbox.
        /// </summary>
        private void UpdateLabels()
        {
            if (updatesListBox.SelectedItem != null)
            {
                Update u = updatesListBox.SelectedItem as Update;
                titleLabel.Text = "Title:\n" + u.Title;
                productLabel.Text = "Product:\n" + u.Product;
                dateLabel.Text = "Release date:\n" + u.Date.ToShortDateString();
            }
            else
            {
                titleLabel.Text = "Title:";
                productLabel.Text = "Product:";
                dateLabel.Text = "Release date:";
            }
        }

        /// <summary>
        /// When the listbox data source changes, update the labels by calling the UpdateLabels method.
        /// </summary>
        private void updatesListBox_DataSourceChanged(object sender, EventArgs e)
        {
            if (updatesListBox.SelectedItem != null)
            {
                UpdateLabels();
            }
        }

        /// <summary>
        /// When the selected item in the listbox changes, update the labels by calling the UpdateLabels method.
        /// </summary>
        private void updatesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        /// <summary>
        /// When the MainForm is closed by the user, hide the MainForm window.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Show a balloon tip in the Windows taskbar displaying the found updates' KB numbers.
        /// </summary>
        /// <param name="updatesList">List containing the found updates.</param>
        private void ShowUpdatesBalloonTipAndUpdateToolStrip(List<Update> updatesList)
        {
            if (updatesList.Count == 1)
            {
                mainFormNotifyIcon.ShowBalloonTip(4000, "Update found", updatesList[0].KB + " Released " + updatesList[0].Date.ToShortDateString() + "\n\nClick to open in browser", ToolTipIcon.Info);
                updatesFound = true;
                notifyIconMenuStrip.Items[0].Text = "Update found, click to open in browser";
            }
            else if (updatesList.Count > 1)
            {
                string kbList = "";
                foreach (Update u in updatesList)
                {
                    kbList = kbList + u.KB + " Released " + u.Date.ToShortDateString() + "\n";
                }
                mainFormNotifyIcon.ShowBalloonTip(4000, "Updates found", kbList + "\n\nClick to open in browser", ToolTipIcon.Info);
                updatesFound = true;
                notifyIconMenuStrip.Items[0].Text = "Update found, click to open in browser";
            }
            else
            {
                notifyIconMenuStrip.Items[0].Text = "No updates found";
            }
        }

        /// <summary>
        /// When the balloon tip is clicked, open the search url(s) of the found update(s) on the default web browser.
        /// </summary>
        private void mainFormNotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            foreach (Update u in updatesList)
            {
                System.Diagnostics.Process.Start("https://www.catalog.update.microsoft.com/Search.aspx?q=" + u.KB);
            }
        }

        /// <summary>
        /// When the toolstrip update status entry gets clicked, if updates were found previously, open the search url(s) of the found update(s) on the default web browser.
        /// </summary>
        private void toolStripUpdateStatus_Click(object sender, EventArgs e)
        {
            if (updatesFound)
            {
                foreach (Update u in updatesList)
                {
                    System.Diagnostics.Process.Start("https://www.catalog.update.microsoft.com/Search.aspx?q=" + u.KB);
                }
            }
        }

        /// <summary>
        /// When the toolstrip manage entry is clicked, unhide the MainForm window.
        /// </summary>
        private void toolStripManage_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.ShowInTaskbar = true;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// When the toolstrip exit entry is clicked, exit the program.
        /// </summary>
        private void toolStripExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
