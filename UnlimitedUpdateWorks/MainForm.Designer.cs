namespace UnlimitedUpdateWorks
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.msCatalogUrlTextbox = new System.Windows.Forms.TextBox();
            this.msCatalogUrlLabel = new System.Windows.Forms.Label();
            this.titleRegexLabel = new System.Windows.Forms.Label();
            this.titleRegexTextbox = new System.Windows.Forms.TextBox();
            this.productRegexTextbox = new System.Windows.Forms.TextBox();
            this.productRegexLabel = new System.Windows.Forms.Label();
            this.dateRegexTextbox = new System.Windows.Forms.TextBox();
            this.dateRegexLabel = new System.Windows.Forms.Label();
            this.secOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.parseButton = new System.Windows.Forms.Button();
            this.updatesListBox = new System.Windows.Forms.ListBox();
            this.updateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productFilterTextbox = new System.Windows.Forms.TextBox();
            this.productFilterLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.productLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.mainFormNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripUpdateStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLastChecked = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripManage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.Button();
            this.tabControlMainForm = new System.Windows.Forms.TabControl();
            this.tabUpdateParser = new System.Windows.Forms.TabPage();
            this.htmlIdLabel = new System.Windows.Forms.Label();
            this.getUrlButton = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.settingsControl = new System.Windows.Forms.TabControl();
            this.filteringPage = new System.Windows.Forms.TabPage();
            this.isInstalledCheckBox = new System.Windows.Forms.CheckBox();
            this.isCompatibleCheckBox = new System.Windows.Forms.CheckBox();
            this.automationPage = new System.Windows.Forms.TabPage();
            this.urlFetchingCheckbox = new System.Windows.Forms.CheckBox();
            this.chromeButton = new System.Windows.Forms.RadioButton();
            this.firefoxButton = new System.Windows.Forms.RadioButton();
            this.remindCheckBox = new System.Windows.Forms.CheckBox();
            this.remindIntervalLabel = new System.Windows.Forms.Label();
            this.autoCheckCheckBox = new System.Windows.Forms.CheckBox();
            this.remindIntervalNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.autoCheckIntervalNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkOnStartCheckBox = new System.Windows.Forms.CheckBox();
            this.autoCheckLabel = new System.Windows.Forms.Label();
            this.advancedPage = new System.Windows.Forms.TabPage();
            this.idRegexLabel = new System.Windows.Forms.Label();
            this.idRegexTextbox = new System.Windows.Forms.TextBox();
            this.autoCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.remindTimer = new System.Windows.Forms.Timer(this.components);
            this.chromiumButton = new System.Windows.Forms.RadioButton();
            this.chromiumTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.updateBindingSource)).BeginInit();
            this.notifyIconMenuStrip.SuspendLayout();
            this.tabControlMainForm.SuspendLayout();
            this.tabUpdateParser.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.settingsControl.SuspendLayout();
            this.filteringPage.SuspendLayout();
            this.automationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remindIntervalNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoCheckIntervalNumUpDown)).BeginInit();
            this.advancedPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // msCatalogUrlTextbox
            // 
            this.msCatalogUrlTextbox.Location = new System.Drawing.Point(9, 22);
            this.msCatalogUrlTextbox.Name = "msCatalogUrlTextbox";
            this.msCatalogUrlTextbox.Size = new System.Drawing.Size(539, 20);
            this.msCatalogUrlTextbox.TabIndex = 0;
            // 
            // msCatalogUrlLabel
            // 
            this.msCatalogUrlLabel.AutoSize = true;
            this.msCatalogUrlLabel.Location = new System.Drawing.Point(6, 6);
            this.msCatalogUrlLabel.Name = "msCatalogUrlLabel";
            this.msCatalogUrlLabel.Size = new System.Drawing.Size(187, 13);
            this.msCatalogUrlLabel.TabIndex = 1;
            this.msCatalogUrlLabel.Text = "Microsoft Update Catalog search URL";
            // 
            // titleRegexLabel
            // 
            this.titleRegexLabel.AutoSize = true;
            this.titleRegexLabel.Location = new System.Drawing.Point(6, 51);
            this.titleRegexLabel.Name = "titleRegexLabel";
            this.titleRegexLabel.Size = new System.Drawing.Size(61, 13);
            this.titleRegexLabel.TabIndex = 2;
            this.titleRegexLabel.Text = "Title Regex";
            // 
            // titleRegexTextbox
            // 
            this.titleRegexTextbox.Location = new System.Drawing.Point(8, 67);
            this.titleRegexTextbox.Name = "titleRegexTextbox";
            this.titleRegexTextbox.Size = new System.Drawing.Size(118, 20);
            this.titleRegexTextbox.TabIndex = 3;
            // 
            // productRegexTextbox
            // 
            this.productRegexTextbox.Location = new System.Drawing.Point(153, 67);
            this.productRegexTextbox.Name = "productRegexTextbox";
            this.productRegexTextbox.Size = new System.Drawing.Size(108, 20);
            this.productRegexTextbox.TabIndex = 5;
            // 
            // productRegexLabel
            // 
            this.productRegexLabel.AutoSize = true;
            this.productRegexLabel.Location = new System.Drawing.Point(151, 51);
            this.productRegexLabel.Name = "productRegexLabel";
            this.productRegexLabel.Size = new System.Drawing.Size(78, 13);
            this.productRegexLabel.TabIndex = 4;
            this.productRegexLabel.Text = "Product Regex";
            // 
            // dateRegexTextbox
            // 
            this.dateRegexTextbox.Location = new System.Drawing.Point(298, 67);
            this.dateRegexTextbox.Name = "dateRegexTextbox";
            this.dateRegexTextbox.Size = new System.Drawing.Size(108, 20);
            this.dateRegexTextbox.TabIndex = 7;
            // 
            // dateRegexLabel
            // 
            this.dateRegexLabel.AutoSize = true;
            this.dateRegexLabel.Location = new System.Drawing.Point(296, 51);
            this.dateRegexLabel.Name = "dateRegexLabel";
            this.dateRegexLabel.Size = new System.Drawing.Size(64, 13);
            this.dateRegexLabel.TabIndex = 6;
            this.dateRegexLabel.Text = "Date Regex";
            // 
            // secOnlyCheckBox
            // 
            this.secOnlyCheckBox.AutoSize = true;
            this.secOnlyCheckBox.Checked = true;
            this.secOnlyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.secOnlyCheckBox.Location = new System.Drawing.Point(3, 5);
            this.secOnlyCheckBox.Name = "secOnlyCheckBox";
            this.secOnlyCheckBox.Size = new System.Drawing.Size(200, 17);
            this.secOnlyCheckBox.TabIndex = 8;
            this.secOnlyCheckBox.Text = "Only include \"Security Only\" updates";
            this.secOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // parseButton
            // 
            this.parseButton.Location = new System.Drawing.Point(487, 286);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(84, 23);
            this.parseButton.TabIndex = 9;
            this.parseButton.Text = "Parse updates";
            this.parseButton.UseVisualStyleBackColor = true;
            this.parseButton.Click += new System.EventHandler(this.ParseButton_Click);
            // 
            // updatesListBox
            // 
            this.updatesListBox.DataSource = this.updateBindingSource;
            this.updatesListBox.DisplayMember = "Title";
            this.updatesListBox.FormattingEnabled = true;
            this.updatesListBox.Location = new System.Drawing.Point(6, 6);
            this.updatesListBox.Name = "updatesListBox";
            this.updatesListBox.Size = new System.Drawing.Size(566, 160);
            this.updatesListBox.TabIndex = 10;
            this.updatesListBox.SelectedIndexChanged += new System.EventHandler(this.UpdatesListBox_SelectedIndexChanged);
            this.updatesListBox.DataSourceChanged += new System.EventHandler(this.UpdatesListBox_DataSourceChanged);
            // 
            // updateBindingSource
            // 
            this.updateBindingSource.DataSource = typeof(UnlimitedUpdateWorks.Update);
            // 
            // productFilterTextbox
            // 
            this.productFilterTextbox.Location = new System.Drawing.Point(5, 94);
            this.productFilterTextbox.Name = "productFilterTextbox";
            this.productFilterTextbox.Size = new System.Drawing.Size(139, 20);
            this.productFilterTextbox.TabIndex = 12;
            // 
            // productFilterLabel
            // 
            this.productFilterLabel.AutoSize = true;
            this.productFilterLabel.Location = new System.Drawing.Point(3, 78);
            this.productFilterLabel.Name = "productFilterLabel";
            this.productFilterLabel.Size = new System.Drawing.Size(69, 13);
            this.productFilterLabel.TabIndex = 11;
            this.productFilterLabel.Text = "Product Filter";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(6, 173);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(33, 13);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Title: ";
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(7, 209);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(50, 13);
            this.productLabel.TabIndex = 14;
            this.productLabel.Text = "Product: ";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(6, 245);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(76, 13);
            this.dateLabel.TabIndex = 15;
            this.dateLabel.Text = "Release date: ";
            // 
            // mainFormNotifyIcon
            // 
            this.mainFormNotifyIcon.ContextMenuStrip = this.notifyIconMenuStrip;
            this.mainFormNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mainFormNotifyIcon.Icon")));
            this.mainFormNotifyIcon.Text = "Unlimited Update Works";
            this.mainFormNotifyIcon.Visible = true;
            this.mainFormNotifyIcon.BalloonTipClicked += new System.EventHandler(this.MainFormNotifyIcon_BalloonTipClicked);
            // 
            // notifyIconMenuStrip
            // 
            this.notifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUpdateStatus,
            this.toolStripLastChecked,
            this.toolStripSeparator1,
            this.toolStripManage,
            this.toolStripExit});
            this.notifyIconMenuStrip.Name = "contextMenuStrip1";
            this.notifyIconMenuStrip.Size = new System.Drawing.Size(175, 98);
            this.notifyIconMenuStrip.Text = "Test";
            // 
            // toolStripUpdateStatus
            // 
            this.toolStripUpdateStatus.Name = "toolStripUpdateStatus";
            this.toolStripUpdateStatus.Size = new System.Drawing.Size(174, 22);
            this.toolStripUpdateStatus.Text = "No updates found";
            this.toolStripUpdateStatus.Click += new System.EventHandler(this.ToolStripUpdateStatus_Click);
            // 
            // toolStripLastChecked
            // 
            this.toolStripLastChecked.Name = "toolStripLastChecked";
            this.toolStripLastChecked.Size = new System.Drawing.Size(174, 22);
            this.toolStripLastChecked.Text = "Last checked: Never";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // toolStripManage
            // 
            this.toolStripManage.Name = "toolStripManage";
            this.toolStripManage.Size = new System.Drawing.Size(174, 22);
            this.toolStripManage.Text = "Manage";
            this.toolStripManage.Click += new System.EventHandler(this.ToolStripManage_Click);
            // 
            // toolStripExit
            // 
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Size = new System.Drawing.Size(174, 22);
            this.toolStripExit.Text = "Exit";
            this.toolStripExit.Click += new System.EventHandler(this.ToolStripExit_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(496, 286);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // tabControlMainForm
            // 
            this.tabControlMainForm.Controls.Add(this.tabUpdateParser);
            this.tabControlMainForm.Controls.Add(this.tabSettings);
            this.tabControlMainForm.Location = new System.Drawing.Point(4, 3);
            this.tabControlMainForm.Name = "tabControlMainForm";
            this.tabControlMainForm.SelectedIndex = 0;
            this.tabControlMainForm.Size = new System.Drawing.Size(585, 341);
            this.tabControlMainForm.TabIndex = 17;
            // 
            // tabUpdateParser
            // 
            this.tabUpdateParser.Controls.Add(this.htmlIdLabel);
            this.tabUpdateParser.Controls.Add(this.getUrlButton);
            this.tabUpdateParser.Controls.Add(this.updatesListBox);
            this.tabUpdateParser.Controls.Add(this.parseButton);
            this.tabUpdateParser.Controls.Add(this.dateLabel);
            this.tabUpdateParser.Controls.Add(this.titleLabel);
            this.tabUpdateParser.Controls.Add(this.productLabel);
            this.tabUpdateParser.Location = new System.Drawing.Point(4, 22);
            this.tabUpdateParser.Name = "tabUpdateParser";
            this.tabUpdateParser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdateParser.Size = new System.Drawing.Size(577, 315);
            this.tabUpdateParser.TabIndex = 1;
            this.tabUpdateParser.Text = "Updates";
            this.tabUpdateParser.UseVisualStyleBackColor = true;
            // 
            // htmlIdLabel
            // 
            this.htmlIdLabel.AutoSize = true;
            this.htmlIdLabel.Location = new System.Drawing.Point(6, 281);
            this.htmlIdLabel.Name = "htmlIdLabel";
            this.htmlIdLabel.Size = new System.Drawing.Size(45, 13);
            this.htmlIdLabel.TabIndex = 29;
            this.htmlIdLabel.Text = "Html ID:";
            // 
            // getUrlButton
            // 
            this.getUrlButton.Location = new System.Drawing.Point(387, 286);
            this.getUrlButton.Name = "getUrlButton";
            this.getUrlButton.Size = new System.Drawing.Size(94, 23);
            this.getUrlButton.TabIndex = 28;
            this.getUrlButton.Text = "Get downlod link";
            this.getUrlButton.UseVisualStyleBackColor = true;
            this.getUrlButton.Click += new System.EventHandler(this.GetUrlButton_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.settingsControl);
            this.tabSettings.Controls.Add(this.saveButton);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(577, 315);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // settingsControl
            // 
            this.settingsControl.Controls.Add(this.filteringPage);
            this.settingsControl.Controls.Add(this.automationPage);
            this.settingsControl.Controls.Add(this.advancedPage);
            this.settingsControl.Location = new System.Drawing.Point(6, 6);
            this.settingsControl.Name = "settingsControl";
            this.settingsControl.SelectedIndex = 0;
            this.settingsControl.Size = new System.Drawing.Size(565, 274);
            this.settingsControl.TabIndex = 27;
            // 
            // filteringPage
            // 
            this.filteringPage.Controls.Add(this.isInstalledCheckBox);
            this.filteringPage.Controls.Add(this.secOnlyCheckBox);
            this.filteringPage.Controls.Add(this.productFilterTextbox);
            this.filteringPage.Controls.Add(this.productFilterLabel);
            this.filteringPage.Controls.Add(this.isCompatibleCheckBox);
            this.filteringPage.Location = new System.Drawing.Point(4, 22);
            this.filteringPage.Name = "filteringPage";
            this.filteringPage.Padding = new System.Windows.Forms.Padding(3);
            this.filteringPage.Size = new System.Drawing.Size(557, 248);
            this.filteringPage.TabIndex = 0;
            this.filteringPage.Text = "Filtering";
            this.filteringPage.UseVisualStyleBackColor = true;
            // 
            // isInstalledCheckBox
            // 
            this.isInstalledCheckBox.AutoSize = true;
            this.isInstalledCheckBox.Checked = true;
            this.isInstalledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isInstalledCheckBox.Location = new System.Drawing.Point(3, 28);
            this.isInstalledCheckBox.Name = "isInstalledCheckBox";
            this.isInstalledCheckBox.Size = new System.Drawing.Size(142, 17);
            this.isInstalledCheckBox.TabIndex = 18;
            this.isInstalledCheckBox.Text = "Exclude already installed";
            this.isInstalledCheckBox.UseVisualStyleBackColor = true;
            // 
            // isCompatibleCheckBox
            // 
            this.isCompatibleCheckBox.AutoSize = true;
            this.isCompatibleCheckBox.Checked = true;
            this.isCompatibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isCompatibleCheckBox.Location = new System.Drawing.Point(3, 51);
            this.isCompatibleCheckBox.Name = "isCompatibleCheckBox";
            this.isCompatibleCheckBox.Size = new System.Drawing.Size(126, 17);
            this.isCompatibleCheckBox.TabIndex = 17;
            this.isCompatibleCheckBox.Text = "Exclude incompatible";
            this.isCompatibleCheckBox.UseVisualStyleBackColor = true;
            this.isCompatibleCheckBox.CheckedChanged += new System.EventHandler(this.IsCompatibleCheckBox_CheckedChanged);
            // 
            // automationPage
            // 
            this.automationPage.Controls.Add(this.chromiumTextBox);
            this.automationPage.Controls.Add(this.chromiumButton);
            this.automationPage.Controls.Add(this.urlFetchingCheckbox);
            this.automationPage.Controls.Add(this.chromeButton);
            this.automationPage.Controls.Add(this.firefoxButton);
            this.automationPage.Controls.Add(this.remindCheckBox);
            this.automationPage.Controls.Add(this.remindIntervalLabel);
            this.automationPage.Controls.Add(this.autoCheckCheckBox);
            this.automationPage.Controls.Add(this.remindIntervalNumUpDown);
            this.automationPage.Controls.Add(this.autoCheckIntervalNumUpDown);
            this.automationPage.Controls.Add(this.checkOnStartCheckBox);
            this.automationPage.Controls.Add(this.autoCheckLabel);
            this.automationPage.Location = new System.Drawing.Point(4, 22);
            this.automationPage.Name = "automationPage";
            this.automationPage.Padding = new System.Windows.Forms.Padding(3);
            this.automationPage.Size = new System.Drawing.Size(557, 248);
            this.automationPage.TabIndex = 1;
            this.automationPage.Text = "Automation";
            this.automationPage.UseVisualStyleBackColor = true;
            // 
            // urlFetchingCheckbox
            // 
            this.urlFetchingCheckbox.AutoSize = true;
            this.urlFetchingCheckbox.Location = new System.Drawing.Point(3, 122);
            this.urlFetchingCheckbox.Name = "urlFetchingCheckbox";
            this.urlFetchingCheckbox.Size = new System.Drawing.Size(168, 17);
            this.urlFetchingCheckbox.TabIndex = 30;
            this.urlFetchingCheckbox.Text = "Enable download link fetching";
            this.urlFetchingCheckbox.UseVisualStyleBackColor = true;
            this.urlFetchingCheckbox.CheckedChanged += new System.EventHandler(this.UrlFetchingCheckbox_CheckedChanged);
            // 
            // chromeButton
            // 
            this.chromeButton.AutoSize = true;
            this.chromeButton.Location = new System.Drawing.Point(3, 168);
            this.chromeButton.Name = "chromeButton";
            this.chromeButton.Size = new System.Drawing.Size(61, 17);
            this.chromeButton.TabIndex = 29;
            this.chromeButton.TabStop = true;
            this.chromeButton.Text = "Chrome";
            this.chromeButton.UseVisualStyleBackColor = true;
            // 
            // firefoxButton
            // 
            this.firefoxButton.AutoSize = true;
            this.firefoxButton.Location = new System.Drawing.Point(3, 145);
            this.firefoxButton.Name = "firefoxButton";
            this.firefoxButton.Size = new System.Drawing.Size(56, 17);
            this.firefoxButton.TabIndex = 28;
            this.firefoxButton.TabStop = true;
            this.firefoxButton.Text = "Firefox";
            this.firefoxButton.UseVisualStyleBackColor = true;
            // 
            // remindCheckBox
            // 
            this.remindCheckBox.AutoSize = true;
            this.remindCheckBox.Checked = true;
            this.remindCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.remindCheckBox.Location = new System.Drawing.Point(3, 51);
            this.remindCheckBox.Name = "remindCheckBox";
            this.remindCheckBox.Size = new System.Drawing.Size(311, 17);
            this.remindCheckBox.TabIndex = 24;
            this.remindCheckBox.Text = "Use reminder instead of rechecking when updates are found";
            this.remindCheckBox.UseVisualStyleBackColor = true;
            this.remindCheckBox.CheckedChanged += new System.EventHandler(this.RemindCheckBox_CheckedChanged);
            // 
            // remindIntervalLabel
            // 
            this.remindIntervalLabel.AutoSize = true;
            this.remindIntervalLabel.Location = new System.Drawing.Point(147, 78);
            this.remindIntervalLabel.Name = "remindIntervalLabel";
            this.remindIntervalLabel.Size = new System.Drawing.Size(135, 13);
            this.remindIntervalLabel.TabIndex = 26;
            this.remindIntervalLabel.Text = "Reminder Interval (minutes)";
            // 
            // autoCheckCheckBox
            // 
            this.autoCheckCheckBox.AutoSize = true;
            this.autoCheckCheckBox.Checked = true;
            this.autoCheckCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoCheckCheckBox.Location = new System.Drawing.Point(3, 5);
            this.autoCheckCheckBox.Name = "autoCheckCheckBox";
            this.autoCheckCheckBox.Size = new System.Drawing.Size(137, 17);
            this.autoCheckCheckBox.TabIndex = 21;
            this.autoCheckCheckBox.Text = "Auto-check for updates";
            this.autoCheckCheckBox.UseVisualStyleBackColor = true;
            this.autoCheckCheckBox.CheckedChanged += new System.EventHandler(this.AutoCheckCheckBox_CheckedChanged);
            // 
            // remindIntervalNumUpDown
            // 
            this.remindIntervalNumUpDown.Location = new System.Drawing.Point(150, 94);
            this.remindIntervalNumUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.remindIntervalNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.remindIntervalNumUpDown.Name = "remindIntervalNumUpDown";
            this.remindIntervalNumUpDown.Size = new System.Drawing.Size(130, 20);
            this.remindIntervalNumUpDown.TabIndex = 25;
            this.remindIntervalNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.remindIntervalNumUpDown.ValueChanged += new System.EventHandler(this.RemindIntervalNumUpDown_ValueChanged);
            // 
            // autoCheckIntervalNumUpDown
            // 
            this.autoCheckIntervalNumUpDown.Location = new System.Drawing.Point(5, 94);
            this.autoCheckIntervalNumUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.autoCheckIntervalNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.autoCheckIntervalNumUpDown.Name = "autoCheckIntervalNumUpDown";
            this.autoCheckIntervalNumUpDown.Size = new System.Drawing.Size(130, 20);
            this.autoCheckIntervalNumUpDown.TabIndex = 23;
            this.autoCheckIntervalNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.autoCheckIntervalNumUpDown.ValueChanged += new System.EventHandler(this.AutoCheckIntervalNumUpDown_ValueChanged);
            // 
            // checkOnStartCheckBox
            // 
            this.checkOnStartCheckBox.AutoSize = true;
            this.checkOnStartCheckBox.Checked = true;
            this.checkOnStartCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkOnStartCheckBox.Location = new System.Drawing.Point(3, 28);
            this.checkOnStartCheckBox.Name = "checkOnStartCheckBox";
            this.checkOnStartCheckBox.Size = new System.Drawing.Size(192, 17);
            this.checkOnStartCheckBox.TabIndex = 22;
            this.checkOnStartCheckBox.Text = "Check for updates on program start";
            this.checkOnStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoCheckLabel
            // 
            this.autoCheckLabel.AutoSize = true;
            this.autoCheckLabel.Location = new System.Drawing.Point(2, 78);
            this.autoCheckLabel.Name = "autoCheckLabel";
            this.autoCheckLabel.Size = new System.Drawing.Size(145, 13);
            this.autoCheckLabel.TabIndex = 19;
            this.autoCheckLabel.Text = "Auto-check Interval (minutes)";
            // 
            // advancedPage
            // 
            this.advancedPage.Controls.Add(this.idRegexLabel);
            this.advancedPage.Controls.Add(this.idRegexTextbox);
            this.advancedPage.Controls.Add(this.msCatalogUrlTextbox);
            this.advancedPage.Controls.Add(this.dateRegexTextbox);
            this.advancedPage.Controls.Add(this.dateRegexLabel);
            this.advancedPage.Controls.Add(this.msCatalogUrlLabel);
            this.advancedPage.Controls.Add(this.titleRegexLabel);
            this.advancedPage.Controls.Add(this.productRegexTextbox);
            this.advancedPage.Controls.Add(this.titleRegexTextbox);
            this.advancedPage.Controls.Add(this.productRegexLabel);
            this.advancedPage.Location = new System.Drawing.Point(4, 22);
            this.advancedPage.Name = "advancedPage";
            this.advancedPage.Size = new System.Drawing.Size(557, 248);
            this.advancedPage.TabIndex = 2;
            this.advancedPage.Text = "Advanced";
            this.advancedPage.UseVisualStyleBackColor = true;
            // 
            // idRegexLabel
            // 
            this.idRegexLabel.AutoSize = true;
            this.idRegexLabel.Location = new System.Drawing.Point(428, 51);
            this.idRegexLabel.Name = "idRegexLabel";
            this.idRegexLabel.Size = new System.Drawing.Size(52, 13);
            this.idRegexLabel.TabIndex = 13;
            this.idRegexLabel.Text = "ID Regex";
            // 
            // idRegexTextbox
            // 
            this.idRegexTextbox.Location = new System.Drawing.Point(430, 67);
            this.idRegexTextbox.Name = "idRegexTextbox";
            this.idRegexTextbox.Size = new System.Drawing.Size(118, 20);
            this.idRegexTextbox.TabIndex = 14;
            // 
            // autoCheckTimer
            // 
            this.autoCheckTimer.Enabled = true;
            this.autoCheckTimer.Interval = 10000;
            this.autoCheckTimer.Tick += new System.EventHandler(this.AutoCheckTimer_Tick);
            // 
            // remindTimer
            // 
            this.remindTimer.Tick += new System.EventHandler(this.RemindTimer_Tick);
            // 
            // chromiumButton
            // 
            this.chromiumButton.AutoSize = true;
            this.chromiumButton.Location = new System.Drawing.Point(3, 191);
            this.chromiumButton.Name = "chromiumButton";
            this.chromiumButton.Size = new System.Drawing.Size(140, 17);
            this.chromiumButton.TabIndex = 31;
            this.chromiumButton.TabStop = true;
            this.chromiumButton.Text = "Custom Chromium binary";
            this.chromiumButton.UseVisualStyleBackColor = true;
            this.chromiumButton.CheckedChanged += new System.EventHandler(this.chromiumButton_CheckedChanged);
            // 
            // chromiumTextBox
            // 
            this.chromiumTextBox.Location = new System.Drawing.Point(5, 214);
            this.chromiumTextBox.Name = "chromiumTextBox";
            this.chromiumTextBox.Size = new System.Drawing.Size(275, 20);
            this.chromiumTextBox.TabIndex = 32;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 348);
            this.Controls.Add(this.tabControlMainForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Unlimited Update Works]";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.updateBindingSource)).EndInit();
            this.notifyIconMenuStrip.ResumeLayout(false);
            this.tabControlMainForm.ResumeLayout(false);
            this.tabUpdateParser.ResumeLayout(false);
            this.tabUpdateParser.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.settingsControl.ResumeLayout(false);
            this.filteringPage.ResumeLayout(false);
            this.filteringPage.PerformLayout();
            this.automationPage.ResumeLayout(false);
            this.automationPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remindIntervalNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoCheckIntervalNumUpDown)).EndInit();
            this.advancedPage.ResumeLayout(false);
            this.advancedPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox msCatalogUrlTextbox;
        private System.Windows.Forms.Label msCatalogUrlLabel;
        private System.Windows.Forms.Label titleRegexLabel;
        private System.Windows.Forms.TextBox titleRegexTextbox;
        private System.Windows.Forms.TextBox productRegexTextbox;
        private System.Windows.Forms.Label productRegexLabel;
        private System.Windows.Forms.TextBox dateRegexTextbox;
        private System.Windows.Forms.Label dateRegexLabel;
        private System.Windows.Forms.CheckBox secOnlyCheckBox;
        private System.Windows.Forms.Button parseButton;
        private System.Windows.Forms.ListBox updatesListBox;
        private System.Windows.Forms.BindingSource updateBindingSource;
        private System.Windows.Forms.TextBox productFilterTextbox;
        private System.Windows.Forms.Label productFilterLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.NotifyIcon mainFormNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripManage;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabControl tabControlMainForm;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabUpdateParser;
        private System.Windows.Forms.CheckBox isInstalledCheckBox;
        private System.Windows.Forms.CheckBox isCompatibleCheckBox;
        private System.Windows.Forms.Label autoCheckLabel;
        private System.Windows.Forms.CheckBox autoCheckCheckBox;
        private System.Windows.Forms.Timer autoCheckTimer;
        private System.Windows.Forms.CheckBox checkOnStartCheckBox;
        private System.Windows.Forms.NumericUpDown autoCheckIntervalNumUpDown;
        private System.Windows.Forms.Label remindIntervalLabel;
        private System.Windows.Forms.NumericUpDown remindIntervalNumUpDown;
        private System.Windows.Forms.CheckBox remindCheckBox;
        private System.Windows.Forms.Timer remindTimer;
        private System.Windows.Forms.ToolStripMenuItem toolStripUpdateStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripLastChecked;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl settingsControl;
        private System.Windows.Forms.TabPage filteringPage;
        private System.Windows.Forms.TabPage automationPage;
        private System.Windows.Forms.TabPage advancedPage;
        private System.Windows.Forms.RadioButton chromeButton;
        private System.Windows.Forms.RadioButton firefoxButton;
        private System.Windows.Forms.Label idRegexLabel;
        private System.Windows.Forms.TextBox idRegexTextbox;
        private System.Windows.Forms.CheckBox urlFetchingCheckbox;
        private System.Windows.Forms.Button getUrlButton;
        private System.Windows.Forms.Label htmlIdLabel;
        private System.Windows.Forms.TextBox chromiumTextBox;
        private System.Windows.Forms.RadioButton chromiumButton;
    }
}

