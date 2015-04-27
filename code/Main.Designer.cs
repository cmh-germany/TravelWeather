namespace TravelWeather
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.comboBox_weatherSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_getWeather = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_calendarSource = new System.Windows.Forms.ComboBox();
            this.button_readCalendar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_locationSource = new System.Windows.Forms.ComboBox();
            this.button_Options = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_weatherSource
            // 
            this.comboBox_weatherSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_weatherSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_weatherSource.FormattingEnabled = true;
            this.comboBox_weatherSource.Items.AddRange(new object[] {
            "Weather Underground",
            "OpenWeatherMap",
            "The Weather Channel",
            "World Weather Online",
            "Yahoo Weather",
            "Wetter.com",
            "Norwegian Meteorological Institute"});
            this.comboBox_weatherSource.Location = new System.Drawing.Point(96, 45);
            this.comboBox_weatherSource.Name = "comboBox_weatherSource";
            this.comboBox_weatherSource.Size = new System.Drawing.Size(157, 21);
            this.comboBox_weatherSource.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Weather source:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 490);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(930, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // button_getWeather
            // 
            this.button_getWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_getWeather.Location = new System.Drawing.Point(786, 432);
            this.button_getWeather.Name = "button_getWeather";
            this.button_getWeather.Size = new System.Drawing.Size(132, 33);
            this.button_getWeather.TabIndex = 5;
            this.button_getWeather.Text = "get weather";
            this.button_getWeather.UseVisualStyleBackColor = true;
            this.button_getWeather.Click += new System.EventHandler(this.button_getWeather_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Calendar source:";
            // 
            // comboBox_calendarSource
            // 
            this.comboBox_calendarSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_calendarSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_calendarSource.FormattingEnabled = true;
            this.comboBox_calendarSource.Items.AddRange(new object[] {
            "Google",
            "iCalendar"});
            this.comboBox_calendarSource.Location = new System.Drawing.Point(96, 82);
            this.comboBox_calendarSource.Name = "comboBox_calendarSource";
            this.comboBox_calendarSource.Size = new System.Drawing.Size(157, 21);
            this.comboBox_calendarSource.TabIndex = 1;
            // 
            // button_readCalendar
            // 
            this.button_readCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_readCalendar.Location = new System.Drawing.Point(659, 432);
            this.button_readCalendar.Name = "button_readCalendar";
            this.button_readCalendar.Size = new System.Drawing.Size(107, 32);
            this.button_readCalendar.TabIndex = 7;
            this.button_readCalendar.Text = "read calendar";
            this.button_readCalendar.UseVisualStyleBackColor = true;
            this.button_readCalendar.Click += new System.EventHandler(this.button_readCalendar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location source:";
            // 
            // comboBox_locationSource
            // 
            this.comboBox_locationSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_locationSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_locationSource.FormattingEnabled = true;
            this.comboBox_locationSource.Items.AddRange(new object[] {
            "OpenWeatherMap",
            "OpenStreetMap",
            "GeoNames"});
            this.comboBox_locationSource.Location = new System.Drawing.Point(96, 8);
            this.comboBox_locationSource.Name = "comboBox_locationSource";
            this.comboBox_locationSource.Size = new System.Drawing.Size(157, 21);
            this.comboBox_locationSource.TabIndex = 1;
            // 
            // button_Options
            // 
            this.button_Options.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Options.Location = new System.Drawing.Point(12, 432);
            this.button_Options.Name = "button_Options";
            this.button_Options.Size = new System.Drawing.Size(107, 32);
            this.button_Options.TabIndex = 8;
            this.button_Options.Text = "Options";
            this.button_Options.UseVisualStyleBackColor = true;
            this.button_Options.Click += new System.EventHandler(this.button_Options_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_calendarSource, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_weatherSource, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_locationSource, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(659, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 111);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 512);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_Options);
            this.Controls.Add(this.button_readCalendar);
            this.Controls.Add(this.button_getWeather);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "TravelWeather";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_weatherSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button button_getWeather;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_calendarSource;
        private System.Windows.Forms.Button button_readCalendar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_locationSource;
        private System.Windows.Forms.Button button_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

