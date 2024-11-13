using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Drawing;
using System.Threading.Tasks;

namespace ChatLib.Models
{
    public class ChatHub : ConnectionDetails
    {
        public static ChatHub Parse(string json) => JsonSerializer.Deserialize<ChatHub>(json)!;

        public ChatState State { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? ImageData { get; set; }
        public bool HasImage => !string.IsNullOrEmpty(ImageData);

        public void SetImage(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            ImageData = Convert.ToBase64String(imageBytes);
        }
        public Image GetImage()
        {
            if (ImageData == null) return null;
            byte[] imageBytes = Convert.FromBase64String(ImageData);
            using (MemoryStream imageStream = new MemoryStream(imageBytes))
            {
                return Image.FromStream(imageStream);
            }
        }

        public string ToJsonString() => JsonSerializer.Serialize(this);
    }
}
