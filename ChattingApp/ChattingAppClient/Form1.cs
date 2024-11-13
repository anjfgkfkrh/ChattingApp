using ChatLib.Handlers;
using ChatLib.Models;
using ChatLib.Sockets;
using System.Net;
using System.Windows.Forms;

namespace ChattingAppClient;

public partial class Form1 : Form
{
    private ChatClient _chatClient;
    private ClientHandler _clientHandler;
    private bool isConnected;

    private int RoomId => (int)nudRoomId.Value;
    private string UserName => txtName.Text;
    private string Message => txtMessage.Text;

    public class MessageItem
    {
        public string Text { get; set; } = string.Empty;
        public Image Image { get; set; }
        public bool IsMine { get; set; }

        public MessageItem(string text, bool isMine, Image image)
        {
            Text = text;
            IsMine = isMine;
            Image = image;
        }
    }

    private void Connected(object? sender, ChatLib.Events.ChatEventArgs e)
    {
        flpMsg.Controls.Clear();
        _clientHandler = e.ClientHandler;
    }

    private void Disconnected(object? sender, ChatLib.Events.ChatEventArgs e)
    {
        _clientHandler = null;
        Label lb = new Label();
        lb.Text = "서버의 연결이 끊겼습니다.";
        lb.AutoSize = true;
        lb.Height = 30;
        flpMsg.Controls.Add(lb);
    }

    private void Received(object? sender, ChatLib.Events.ChatEventArgs e)
    {
        ChatHub hub = e.Hub;
        bool isMine = hub.UserName == UserName;
        string message = hub.State switch
        {
            ChatState.Connect => $"{hub.UserName}님이 접속하였습니다.",
            ChatState.Disconnect => $"{hub.UserName}님이 종료하였습니다.",
            _ => isMine ? hub.Message : $"{hub.UserName}: {hub.Message}"
        };

        AddMessage(message, isMine, hub.GetImage());
    }

    private void AddMessage(string message, bool isMine, Image? image)
    {
        Panel panel = new Panel();
        panel.Width = 455;
        panel.Anchor = AnchorStyles.Top;
        panel.AutoScroll = false;


        Label label = new Label();
        if (image != null)
        {
            label.Image = image.Width > 400 ? ResizeImage(image, 400) : image;
            label.Height = image.Height;
            label.Width = image.Width;
            label.TextAlign = ContentAlignment.BottomCenter;
            label.ImageAlign = ContentAlignment.TopCenter;
        }
        else
        {
            label.Text = message;
            label.TextAlign = isMine ? ContentAlignment.TopRight : ContentAlignment.TopLeft;
            label.AutoSize = true;
            label.MaximumSize = new Size(400, 0);
        }

        label.Dock = isMine ? DockStyle.Right : DockStyle.Left;

        panel.Height = label.Height;
        panel.Controls.Add(label);
        panel.Height = label.Height + 10;

        flpMsg.Controls.Add(panel);
    }

    Image ResizeImage(Image imgToResize, int maxWidth)
    {
        float ratio = (float)maxWidth / imgToResize.Width;
        int newWidth = maxWidth;
        int newHeight = (int)(imgToResize.Height * ratio);

        Bitmap newImage = new Bitmap(newWidth, newHeight);
        using (Graphics g = Graphics.FromImage(newImage))
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, newWidth, newHeight);
        }

        return newImage;
    }

    private void Send()
    {
        if (Message == "") return;

        _clientHandler?.Send(new ChatHub
        {
            RoomId = RoomId,
            UserName = UserName,
            Message = Message,
        });
        txtMessage.Clear();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
        Send();
    }

    private void txtMessage_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Send();
        }
    }

    private async void BtnConnect_Click(object sender, EventArgs e)
    {

        isConnected = true;
        await _chatClient.ConnectAsync(new ConnectionDetails
        {
            RoomId = RoomId,
            UserName = UserName,
        });
    }

    private void BtnImage_Click(object sender, EventArgs e)
    {
        using(OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Image Files| *.jpg;*.jpef;*.bmp;*.gif";
            openFileDialog.Multiselect = false;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var hub = new ChatHub
                {
                    RoomId = RoomId,
                    UserName = UserName,
                    Message = "!Image!"
                };

                hub.SetImage(openFileDialog.FileName);

                _clientHandler?.Send(hub);
            }
        }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        _chatClient.Close();
        flpMsg.Controls.Clear();
    }

    /*private void lbxMsg_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0) return;

        MessageItem? item = lbxMsg.Items[e.Index] as MessageItem;

        if (item == null) return;

        e.DrawBackground();

        if (item.IsMine)
        {
            if (item.Image != null)
                e.Graphics.DrawImage(item.Image, e.Bounds.Right - item.Image.Width, e.Bounds.Top);
            else
                e.Graphics.DrawString(item.Text, e.Font, Brushes.Black, e.Bounds.Right - e.Graphics.MeasureString(item.Text, e.Font).Width, e.Bounds.Top);
        }
        else
        {
            if (item.Image != null)
                e.Graphics.DrawImage(item.Image, e.Bounds.Left, item.Image.Width, item.Image.Height, e.Bounds.Top);
            else
                e.Graphics.DrawString(item.Text, e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top);
        }

        e.DrawFocusRectangle();
    }*/

    public Form1()
    {
        InitializeComponent();

        _chatClient = new ChatClient(IPAddress.Parse("127.0.0.1"), 8080);
        _chatClient.Connected += Connected;
        _chatClient.Disconnected += Disconnected;
        _chatClient.Received += Received;
        isConnected = false;
    }
}