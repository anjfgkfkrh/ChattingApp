namespace ChattingAppClient;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtMessage = new TextBox();
        BtnSend = new Button();
        txtName = new TextBox();
        LabelRoomNum = new Label();
        nudRoomId = new NumericUpDown();
        BtnConnect = new Button();
        LabelName = new Label();
        btnStop = new Button();
        BtnImage = new Button();
        flpMsg = new FlowLayoutPanel();
        ((System.ComponentModel.ISupportInitialize)nudRoomId).BeginInit();
        SuspendLayout();
        // 
        // txtMessage
        // 
        txtMessage.Location = new Point(9, 905);
        txtMessage.Name = "txtMessage";
        txtMessage.Size = new Size(349, 27);
        txtMessage.TabIndex = 0;
        txtMessage.KeyDown += txtMessage_KeyDown;
        // 
        // BtnSend
        // 
        BtnSend.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
        BtnSend.Location = new Point(364, 902);
        BtnSend.Name = "BtnSend";
        BtnSend.Size = new Size(63, 30);
        BtnSend.TabIndex = 1;
        BtnSend.Text = "Send";
        BtnSend.UseVisualStyleBackColor = true;
        BtnSend.Click += btnSend_Click;
        // 
        // txtName
        // 
        txtName.Location = new Point(166, 15);
        txtName.Name = "txtName";
        txtName.Size = new Size(172, 27);
        txtName.TabIndex = 4;
        // 
        // LabelRoomNum
        // 
        LabelRoomNum.AutoSize = true;
        LabelRoomNum.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
        LabelRoomNum.Location = new Point(3, 18);
        LabelRoomNum.Name = "LabelRoomNum";
        LabelRoomNum.Size = new Size(51, 20);
        LabelRoomNum.TabIndex = 5;
        LabelRoomNum.Text = "Room";
        LabelRoomNum.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // nudRoomId
        // 
        nudRoomId.Location = new Point(54, 15);
        nudRoomId.Name = "nudRoomId";
        nudRoomId.Size = new Size(49, 27);
        nudRoomId.TabIndex = 6;
        // 
        // BtnConnect
        // 
        BtnConnect.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
        BtnConnect.Location = new Point(344, 15);
        BtnConnect.Name = "BtnConnect";
        BtnConnect.Size = new Size(60, 30);
        BtnConnect.TabIndex = 7;
        BtnConnect.Text = "Connet";
        BtnConnect.UseVisualStyleBackColor = true;
        BtnConnect.Click += BtnConnect_Click;
        // 
        // LabelName
        // 
        LabelName.AutoSize = true;
        LabelName.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
        LabelName.Location = new Point(109, 18);
        LabelName.Name = "LabelName";
        LabelName.Size = new Size(51, 20);
        LabelName.TabIndex = 8;
        LabelName.Text = "Name";
        // 
        // btnStop
        // 
        btnStop.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
        btnStop.Location = new Point(410, 15);
        btnStop.Name = "btnStop";
        btnStop.Size = new Size(60, 30);
        btnStop.TabIndex = 9;
        btnStop.Text = "DisConnect";
        btnStop.UseVisualStyleBackColor = true;
        btnStop.Click += btnStop_Click;
        // 
        // BtnImage
        // 
        BtnImage.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
        BtnImage.ImageAlign = ContentAlignment.TopCenter;
        BtnImage.Location = new Point(429, 902);
        BtnImage.Name = "BtnImage";
        BtnImage.Size = new Size(39, 30);
        BtnImage.TabIndex = 10;
        BtnImage.Text = "+";
        BtnImage.UseVisualStyleBackColor = true;
        BtnImage.Click += BtnImage_Click;
        // 
        // flpMsg
        // 
        flpMsg.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        flpMsg.AutoScroll = true;
        flpMsg.BackColor = SystemColors.ControlLightLight;
        flpMsg.FlowDirection = FlowDirection.TopDown;
        flpMsg.Location = new Point(8, 49);
        flpMsg.Name = "flpMsg";
        flpMsg.Size = new Size(462, 851);
        flpMsg.TabIndex = 11;
        flpMsg.WrapContents = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.GradientInactiveCaption;
        ClientSize = new Size(482, 934);
        Controls.Add(flpMsg);
        Controls.Add(BtnImage);
        Controls.Add(btnStop);
        Controls.Add(LabelName);
        Controls.Add(BtnConnect);
        Controls.Add(nudRoomId);
        Controls.Add(LabelRoomNum);
        Controls.Add(txtName);
        Controls.Add(BtnSend);
        Controls.Add(txtMessage);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)nudRoomId).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtMessage;
    private Button BtnSend;
    private TextBox txtName;
    private Label LabelRoomNum;
    private NumericUpDown nudRoomId;
    private Button BtnConnect;
    private Label LabelName;
    private Button btnStop;
    private Button BtnImage;
    private FlowLayoutPanel flpMsg;
}