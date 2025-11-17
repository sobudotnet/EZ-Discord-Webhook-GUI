namespace sinc
{
    partial class Rz7lForm
    {
        /// <summary>
        /// y1K_obf_designer
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSeparator;

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Label lblWebhook;
        private System.Windows.Forms.TextBox txtWebhook;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;

        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnSend;

        private System.Windows.Forms.ToolTip toolTip1;

        // header customization controls
        private System.Windows.Forms.FlowLayoutPanel headerControls;
        private System.Windows.Forms.TextBox txtTitleEdit;
        private System.Windows.Forms.Button btnPickColor;
        private System.Windows.Forms.Button btnApplyTitle;
        private System.Windows.Forms.ColorDialog colorDialog1;

        /// <summary>
        /// c3V_cleanup_obf
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.headerControls = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTitleEdit = new System.Windows.Forms.TextBox();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.btnApplyTitle = new System.Windows.Forms.Button();
            this.panelSeparator = new System.Windows.Forms.Panel();

            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblWebhook = new System.Windows.Forms.Label();
            this.txtWebhook = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();

            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSend = new System.Windows.Forms.Button();

            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(54, 57, 63);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 110;
            this.panelHeader.Padding = new System.Windows.Forms.Padding(12, 20, 12, 20);
            this.panelHeader.Controls.Add(this.pictureBoxIcon);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.headerControls);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.FromArgb(88, 101, 242);
            this.pictureBoxIcon.Size = new System.Drawing.Size(56, 56);
            this.pictureBoxIcon.Location = new System.Drawing.Point(12, 20);
            this.pictureBoxIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(80, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "EZ Discord Webhook";
            // 
            // headerControls
            // 
            this.headerControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.headerControls.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.headerControls.AutoSize = true;
            this.headerControls.Padding = new System.Windows.Forms.Padding(6, 20, 6, 0);
            this.headerControls.Controls.Add(this.txtTitleEdit);
            this.headerControls.Controls.Add(this.btnPickColor);
            this.headerControls.Controls.Add(this.btnApplyTitle);
            // 
            // txtTitleEdit
            // 
            this.txtTitleEdit.Width = 260;
            this.txtTitleEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTitleEdit.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.txtTitleEdit.TabIndex = 100;
            // 
            // btnPickColor
            // 
            this.btnPickColor.Text = "Color";
            this.btnPickColor.AutoSize = true;
            this.btnPickColor.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnPickColor.TabIndex = 101;
            this.btnPickColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPickColor.UseVisualStyleBackColor = true;
            this.btnPickColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // btnApplyTitle
            // 
            this.btnApplyTitle.Text = "Apply";
            this.btnApplyTitle.AutoSize = true;
            this.btnApplyTitle.TabIndex = 102;
            this.btnApplyTitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApplyTitle.UseVisualStyleBackColor = true;
            this.btnApplyTitle.Click += new System.EventHandler(this.btnApplyTitle_Click);
            // 
            // panelSeparator
            // 
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator.Height = 1;
            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.panelSeparator.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            // 
            // tableLayout
            // 
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.RowCount = 3;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayout.Padding = new System.Windows.Forms.Padding(12);
            // 
            // lblWebhook
            // 
            this.lblWebhook.AutoSize = true;
            this.lblWebhook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWebhook.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWebhook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWebhook.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblWebhook.Text = "Webhook URL:";
            this.lblWebhook.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            // 
            // txtWebhook
            // 
            this.txtWebhook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWebhook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWebhook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWebhook.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtWebhook.TabIndex = 0;
            this.txtWebhook.UseSystemPasswordChar = true;
            this.toolTip1.SetToolTip(this.txtWebhook, "Webhook URL is hidden for privacy. It is stored encrypted on this machine.");
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblMessage.Text = "Message:";
            this.lblMessage.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Multiline = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtMessage.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtMessage, "Type the message to send to the webhook");
            // 
            // flowButtons
            // 
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowButtons.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = true;
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(88, 101, 242);
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.toolTip1.SetToolTip(this.btnSend, "Send message to the webhook (Enter to submit)");
            // 
            // flow add and table placements
            // 
            this.flowButtons.Controls.Add(this.btnSend);
            this.tableLayout.Controls.Add(this.lblWebhook, 0, 0);
            this.tableLayout.Controls.Add(this.txtWebhook, 1, 0);
            this.tableLayout.Controls.Add(this.lblMessage, 0, 1);
            this.tableLayout.Controls.Add(this.txtMessage, 1, 1);
            this.tableLayout.Controls.Add(this.flowButtons, 1, 2);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(782, 476);
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.panelSeparator);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "Rz7lForm";
            this.Text = "EZ Discord Webhook by sobu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}