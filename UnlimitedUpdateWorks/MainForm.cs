using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;

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
            urlFetchingCheckbox.Checked = Boolean.Parse(xmlData[13]);
            firefoxButton.Checked = Boolean.Parse(xmlData[14]);
            chromeButton.Checked = Boolean.Parse(xmlData[15]);
            idRegexTextbox.Text = xmlData[16];
            getUrlButton.Enabled = false;

            if (checkOnStartCheckBox.Checked)
            {
                ParseAndFilterUpdates();
            }

        }

        /// <summary>
        /// When the auto-check timer ticks, call the ParseAndFilterUpdates method.
        /// </summary>
        private void AutoCheckTimer_Tick(object sender, EventArgs e)
        {
            ParseAndFilterUpdates();
        }

        /// <summary>
        /// When the remind timer ticks, if the updatesFound flag is set to true check if the found updates are already installed.
        /// If they are not then call the ShowUpdatesBalloonTipAndUpdateToolStrip function.
        /// </summary>
        private void RemindTimer_Tick(object sender, EventArgs e)
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
        private void IsCompatibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            productFilterTextbox.Enabled = isCompatibleCheckBox.Checked;
        }

        /// <summary>
        /// When the auto-check for updates checkbox gets checked or unchecked:
        /// - enable the auto-check timer and auto-check interval numupdown if the auto-check checkbox is checked
        /// - disable the auto-check timer and auto-check interval numupdown if the auto-check checkbox is not checked
        /// </summary>
        private void AutoCheckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            autoCheckTimer.Enabled = autoCheckCheckBox.Checked;
            autoCheckIntervalNumUpDown.Enabled = autoCheckCheckBox.Checked;
        }

        /// <summary>
        /// When the update reminder checkbox gets checked or unchecked:
        /// - enable the update reminder timer and auto-check interval numupdown if the update reminder checkbox is checked
        /// - disable the update reminder timer and auto-check interval numupdown if the update reminder checkbox is not checked
        /// </summary>
        private void RemindCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            remindTimer.Enabled = remindCheckBox.Checked;
            remindIntervalNumUpDown.Enabled = remindCheckBox.Checked;
        }

        /// <summary>
        /// If the auto-check interval numupdown value changes, update the auto-check timer interval value (after converting the numupdown's value to milliseconds).
        /// </summary>
        private void AutoCheckIntervalNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            autoCheckTimer.Interval = (int)autoCheckIntervalNumUpDown.Value * 60000;
        }

        /// <summary>
        /// If the update reminder interval numupdown value changes, update the update reminder timer interval value (after converting the numupdown's value to milliseconds).
        /// </summary>
        private void RemindIntervalNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            remindTimer.Interval = (int)remindIntervalNumUpDown.Value * 60000;
        }

        /// <summary>
        /// When the save button (in the Settings tab of the MainForm) gets clicked save all data to the config.xml file by calling the UpdateXML method and passing all values to it as parameters.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            XML.UpdateXML(msCatalogUrlTextbox.Text, titleRegexTextbox.Text, productRegexTextbox.Text, dateRegexTextbox.Text, productFilterTextbox.Text, secOnlyCheckBox.Checked.ToString(), isCompatibleCheckBox.Checked.ToString(),
                isInstalledCheckBox.Checked.ToString(), autoCheckIntervalNumUpDown.Value.ToString(), autoCheckCheckBox.Checked.ToString(), checkOnStartCheckBox.Checked.ToString(), remindCheckBox.Checked.ToString(), remindIntervalNumUpDown.Value.ToString(), 
                urlFetchingCheckbox.Checked.ToString(), firefoxButton.Checked.ToString(), chromeButton.Checked.ToString(), idRegexTextbox.Text);
        }

        /// <summary>
        /// When the parse button (in the Update Parser tab of the MainForm) gets clicked check for updates by calling the ParseAndFilterUpdates method then set the listbox's data source to the found updates.
        /// Then, if updates are found, update the labels below the listbox to display the auto-selected update.
        /// While all of this happens disable the parse button and set the cursor to the "busy" one.
        /// </summary>
        private void ParseButton_Click(object sender, EventArgs e)
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
            
            updatesList = HTML.ParseUpdates(HTML.Scrape(StringManagement.ReplaceYearMonth(msCatalogUrlTextbox.Text)), titleRegexTextbox.Text, productRegexTextbox.Text, dateRegexTextbox.Text, idRegexTextbox.Text);
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
                htmlIdLabel.Text = "Html ID:\n" + u.HtmlID;
                if (urlFetchingCheckbox.Checked)
                {
                    getUrlButton.Enabled = true;
                }
                
            }
            else
            {
                titleLabel.Text = "Title:";
                productLabel.Text = "Product:";
                dateLabel.Text = "Release date:";
                htmlIdLabel.Text = "Html ID:";
                getUrlButton.Enabled = false;
            }
        }

        /// <summary>
        /// When the listbox data source changes, update the labels by calling the UpdateLabels method.
        /// </summary>
        private void UpdatesListBox_DataSourceChanged(object sender, EventArgs e)
        {
            if (updatesListBox.SelectedItem != null)
            {
                UpdateLabels();
            }
        }

        /// <summary>
        /// When the selected item in the listbox changes, update the labels by calling the UpdateLabels method.
        /// </summary>
        private void UpdatesListBox_SelectedIndexChanged(object sender, EventArgs e)
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

            if (updatesList.Count == 1 && urlFetchingCheckbox.Checked)
            {
                mainFormNotifyIcon.ShowBalloonTip(4000, "Update found", updatesList[0].KB + " Released " + updatesList[0].Date.ToShortDateString() + "\n\nClick to fetch download URL and copy to clipboard", ToolTipIcon.Info);
                updatesFound = true;
                notifyIconMenuStrip.Items[0].Text = "Update found, click to fetch download URL and copy to clipboard";
                updateBindingSource.DataSource = updatesList;
                if (updatesListBox.SelectedItem != null)
                {
                    UpdateLabels();
                }


            }
            else if(updatesList.Count == 1 && !urlFetchingCheckbox.Checked)
            {
                mainFormNotifyIcon.ShowBalloonTip(4000, "Update found", updatesList[0].KB + " Released " + updatesList[0].Date.ToShortDateString() + "\n\nClick to open in browser", ToolTipIcon.Info);
                updatesFound = true;
                notifyIconMenuStrip.Items[0].Text = "Update found, click to open in browser";
                updateBindingSource.DataSource = updatesList;
                if (updatesListBox.SelectedItem != null)
                {
                    UpdateLabels();
                }
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
                notifyIconMenuStrip.Items[0].Text = "Updates found, click to open in browser";
                updateBindingSource.DataSource = updatesList;
                if (updatesListBox.SelectedItem != null)
                {
                    UpdateLabels();
                }
            }
            else
            {
                notifyIconMenuStrip.Items[0].Text = "No updates found";
            }
        }

        /// <summary>
        /// When the balloon tip is clicked, open the search url(s) of the found update(s) on the default web browser.
        /// </summary>
        private void MainFormNotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if(updatesList.Count == 1 && chromeButton.Checked && urlFetchingCheckbox.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                mainFormNotifyIcon.ShowBalloonTip(4000, "Fetching download URL", "Please wait...", ToolTipIcon.None);
                Clipboard.SetText(FetchDownloadLinkChrome("https://www.catalog.update.microsoft.com/Search.aspx?q=" + updatesList[0].HtmlID, updatesList[0].HtmlID));
                mainFormNotifyIcon.ShowBalloonTip(4000, "Done", "Download URL copied to clipboard", ToolTipIcon.Info);
                Cursor.Current = Cursors.Default;
            }
            else if(updatesList.Count == 1 && firefoxButton.Checked && urlFetchingCheckbox.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                mainFormNotifyIcon.ShowBalloonTip(4000, "Fetching download URL", "Please wait...", ToolTipIcon.None);
                Clipboard.SetText(FetchDownloadLinkFirefox("https://www.catalog.update.microsoft.com/Search.aspx?q=" + updatesList[0].HtmlID, updatesList[0].HtmlID));
                mainFormNotifyIcon.ShowBalloonTip(4000, "Done", "Download URL copied to clipboard", ToolTipIcon.Info);
                Cursor.Current = Cursors.Default;
            }
            else if(updatesList.Count > 1 || !urlFetchingCheckbox.Checked)
            {
                foreach (Update u in updatesList)
                {
                    System.Diagnostics.Process.Start("https://www.catalog.update.microsoft.com/Search.aspx?q=" + u.HtmlID);
                }
            }
        }

        /// <summary>
        /// When the toolstrip update status entry gets clicked, if update(s) were previously found open the search url(s) of the found update(s) on the default web browser.
        /// </summary>
        private void ToolStripUpdateStatus_Click(object sender, EventArgs e)
        {
            if (updatesList.Count == 1 && chromeButton.Checked && urlFetchingCheckbox.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                mainFormNotifyIcon.ShowBalloonTip(4000, "Fetching download URL", "Please wait...", ToolTipIcon.None);
                Clipboard.SetText(FetchDownloadLinkChrome("https://www.catalog.update.microsoft.com/Search.aspx?q=" + updatesList[0].HtmlID, updatesList[0].HtmlID));
                mainFormNotifyIcon.ShowBalloonTip(4000, "Done", "Download URL copied to clipboard", ToolTipIcon.Info);
                Cursor.Current = Cursors.Default;
            }
            else if (updatesList.Count == 1 && firefoxButton.Checked && urlFetchingCheckbox.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                mainFormNotifyIcon.ShowBalloonTip(4000, "Fetching download URL", "Please wait...", ToolTipIcon.None);
                Clipboard.SetText(FetchDownloadLinkFirefox("https://www.catalog.update.microsoft.com/Search.aspx?q=" + updatesList[0].HtmlID, updatesList[0].HtmlID));
                mainFormNotifyIcon.ShowBalloonTip(4000, "Done", "Download URL copied to clipboard", ToolTipIcon.Info);
                Cursor.Current = Cursors.Default;
            }
            else if (updatesList.Count > 1 || !urlFetchingCheckbox.Checked)
            {
                foreach (Update u in updatesList)
                {
                    System.Diagnostics.Process.Start("https://www.catalog.update.microsoft.com/Search.aspx?q=" + u.HtmlID);
                }
            }
        }

        /// <summary>
        /// When the toolstrip manage entry is clicked, unhide the MainForm window.
        /// </summary>
        private void ToolStripManage_Click(object sender, EventArgs e)
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
        private void ToolStripExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Fetch the download link of the desired update by using the Selenium Firefox driver (a Firefox installation in the default directory is needed).
        /// </summary>
        /// <param name="searchUrl">Url of the starting website.</param>
        /// <param name="htmlID">Unique HTML ID of the specific update (e.g. 26896846-497d-4755-893a-6870f72ddcf4). This is only exposed in the HTML source code, however it is usable as a search parameter for the Microsoft Update Catalog</param>
        /// <returns>Direct download link to the specific update.</returns>
        private string FetchDownloadLinkFirefox(string searchUrl, string htmlID)
        {
            FirefoxDriverService driverService = FirefoxDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("-headless");
            IWebDriver driver = new FirefoxDriver(driverService, options, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(searchUrl);
            IWebElement test = driver.FindElement(By.XPath($"//input[@id='{htmlID}' and @value='Download']"));
            PopupWindowFinder finder = new PopupWindowFinder(driver);
            string popupWindowHandle = finder.Click(test);
            driver.SwitchTo().Window(popupWindowHandle);
            Thread.Sleep(2000);
            IWebElement downloadLinkElement = driver.FindElement(By.PartialLinkText(""));
            string downloadLink = downloadLinkElement.GetAttribute("href");
            driver.Quit();
            return downloadLink;
        }

        /// <summary>
        /// Fetch the download link of the desired update by using the Selenium Chrome driver (a Chrome installation in the default directory is needed).
        /// </summary>
        /// <param name="searchUrl">Url of the starting website.</param>
        /// <param name="htmlID">Unique HTML ID of the specific update (e.g. 26896846-497d-4755-893a-6870f72ddcf4). This is only exposed in the HTML source code, however it is usable as a search parameter for the Microsoft Update Catalog</param>
        /// <returns>Direct download link to the specific update.</returns>
        private string FetchDownloadLinkChrome(string searchUrl, string htmlID)
        {
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            options.AddArguments("--proxy-server='direct://'");
            options.AddArguments("--proxy-bypass-list=*");
            options.AddArguments("--disable-gpu");
            IWebDriver driver = new ChromeDriver(driverService, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(searchUrl);
            IWebElement test = driver.FindElement(By.XPath($"//input[@id='{htmlID}' and @value='Download']"));
            PopupWindowFinder finder = new PopupWindowFinder(driver);
            string popupWindowHandle = finder.Click(test);
            driver.SwitchTo().Window(popupWindowHandle);
            IWebElement downloadLinkElement = driver.FindElement(By.PartialLinkText(""));
            string downloadLink = downloadLinkElement.GetAttribute("href");
            driver.Quit();
            return downloadLink;
        }

        /// <summary>
        /// Handles the basic radiobutton event logic.
        /// </summary>
        private void ChromeButton_CheckedChanged(object sender, EventArgs e)
        {

            if (firefoxButton.Checked && chromeButton.Checked)
            {
                firefoxButton.Checked = false;
            }
        }

        /// <summary>
        /// Handles the basic radiobutton event logic.
        /// </summary>
        private void FirefoxButton_CheckedChanged(object sender, EventArgs e)
        {
            if (chromeButton.Checked && firefoxButton.Checked)
            {
                chromeButton.Checked = false;
            }
        }

        /// <summary>
        /// When the "get url" button is pressed either the Chrome or Firefox fetch function gets called depending on the settings, and the returning value (the direct link) gets copied to the clipboard.
        /// </summary>
        private void GetUrlButton_Click(object sender, EventArgs e)
        {
            Update u = updatesListBox.SelectedItem as Update;
            if (chromeButton.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                mainFormNotifyIcon.ShowBalloonTip(4000, "Fetching download URL", "Please wait...", ToolTipIcon.None);
                Clipboard.SetText(FetchDownloadLinkChrome("https://www.catalog.update.microsoft.com/Search.aspx?q=" + u.HtmlID, u.HtmlID));
                mainFormNotifyIcon.ShowBalloonTip(4000, "Done", "Download URL copied to clipboard", ToolTipIcon.Info);
                Cursor.Current = Cursors.Default;
            }
            else if (firefoxButton.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                mainFormNotifyIcon.ShowBalloonTip(4000, "Fetching download URL", "Please wait...", ToolTipIcon.None);
                Clipboard.SetText(FetchDownloadLinkFirefox("https://www.catalog.update.microsoft.com/Search.aspx?q=" + u.HtmlID, u.HtmlID));
                mainFormNotifyIcon.ShowBalloonTip(4000, "Done", "Download URL copied to clipboard", ToolTipIcon.Info);
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the basic radiobutton event logic.
        /// </summary>
        private void UrlFetchingCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (urlFetchingCheckbox.Checked)
            {
                chromeButton.Enabled = true;
                firefoxButton.Enabled = true;
            }
            else if (!urlFetchingCheckbox.Checked)
            {
                chromeButton.Enabled = false;
                firefoxButton.Enabled = false;
                getUrlButton.Enabled = false;
            }
        }
    }
}
