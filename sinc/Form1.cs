using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.InteropServices;

namespace sinc
{
    [Serializable]
    public class Xq4a9Settings
    {
        public string TitleText { get; set; }
        public int TitleColorArgb { get; set; }
        public string ImageFileName { get; set; }
    }

    public partial class Rz7lForm : Form
    {
        private string _settingsFolder;
        private string _settingsFile;
        private Xq4a9Settings _settings;

        public Rz7lForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.txtTitleEdit.KeyDown += txtTitleEdit_KeyDown;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _settingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "sinc");
            _settingsFile = Path.Combine(_settingsFolder, "settings.xml");

            LoadSettings();

            if (!string.IsNullOrWhiteSpace(_settings?.TitleText))
                lblTitle.Text = _settings.TitleText;

            if (_settings != null && _settings.TitleColorArgb != 0)
                lblTitle.ForeColor = Color.FromArgb(_settings.TitleColorArgb);

            string imgPath = _settings?.ImageFileName;
            if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
            {
                try
                {
                    using (var img = Image.FromFile(imgPath))
                        ApplyPictureBoxImage(img);
                }
                catch
                {
                    imgPath = null;
                }
            }

            if (string.IsNullOrEmpty(imgPath))
            {
                const string imageUrl = "https://avatars.githubusercontent.com/u/243894575?v=4";
                try
                {
                    var saved = await DownloadAndSaveImageAsync(imageUrl, Path.Combine(_settingsFolder, "icon.png")).ConfigureAwait(false);
                    if (saved && File.Exists(Path.Combine(_settingsFolder, "icon.png")))
                    {
                        _settings.ImageFileName = Path.Combine(_settingsFolder, "icon.png");
                        SaveSettings();
                        if (pictureBoxIcon.InvokeRequired)
                        {
                            pictureBoxIcon.Invoke(new Action(() =>
                            {
                                using (var img = Image.FromFile(_settings.ImageFileName))
                                    ApplyPictureBoxImage(img);
                            }));
                        }
                        else
                        {
                            using (var img = Image.FromFile(_settings.ImageFileName))
                                ApplyPictureBoxImage(img);
                        }
                    }
                }
                catch
                {

                }
            }

            if (pictureBoxIcon != null)
            {
                pictureBoxIcon.Cursor = Cursors.Hand;
                pictureBoxIcon.Click -= pictureBoxIcon_Click;
                pictureBoxIcon.Click += pictureBoxIcon_Click;
            }
        }

        private void LoadSettings()
        {
            try
            {
                if (!Directory.Exists(_settingsFolder))
                    Directory.CreateDirectory(_settingsFolder);

                if (File.Exists(_settingsFile))
                {
                    var xs = new XmlSerializer(typeof(Xq4a9Settings));
                    using (var fs = File.OpenRead(_settingsFile))
                    {
                        _settings = (Xq4a9Settings)xs.Deserialize(fs);
                    }
                }
                else
                {
                    _settings = new Xq4a9Settings
                    {
                        TitleText = lblTitle?.Text ?? "EZ Discord Webhook",
                        TitleColorArgb = lblTitle?.ForeColor.ToArgb() ?? Color.White.ToArgb(),
                        ImageFileName = null
                    };
                    SaveSettings();
                }
            }
            catch
            {
                _settings = new Xq4a9Settings
                {
                    TitleText = lblTitle?.Text ?? "EZ Discord Webhook",
                    TitleColorArgb = lblTitle?.ForeColor.ToArgb() ?? Color.White.ToArgb(),
                    ImageFileName = null
                };
            }
        }

        private void SaveSettings()
        {
            try
            {
                if (!Directory.Exists(_settingsFolder))
                    Directory.CreateDirectory(_settingsFolder);

                var xs = new XmlSerializer(typeof(Xq4a9Settings));
                using (var fs = File.Create(_settingsFile))
                {
                    xs.Serialize(fs, _settings);
                }
            }
            catch
            {
                // r7x_ignore_save
            }
        }

        private async Task<bool> DownloadAndSaveImageAsync(string url, string destPath)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var bytes = await client.GetByteArrayAsync(url).ConfigureAwait(false);
                    var dir = Path.GetDirectoryName(destPath);
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                    using (var ms = new MemoryStream(bytes))
                    using (var img = Image.FromStream(ms))
                    {
                        img.Save(destPath, ImageFormat.Png);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // u4p_sendwebhook_obf
        private async void btnSend_Click(object sender, EventArgs e)
        {
            var webhook = txtWebhook.Text?.Trim();
            var message = txtMessage.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(webhook))
            {
                MessageBox.Show("Please enter a webhook URL.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Uri.TryCreate(webhook, UriKind.Absolute, out Uri webhookUri) ||
                (webhookUri.Scheme != Uri.UriSchemeHttp && webhookUri.Scheme != Uri.UriSchemeHttps))
            {
                MessageBox.Show("Please enter a valid HTTP or HTTPS webhook URL.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                var res = MessageBox.Show("Message is empty. Send anyway?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes) return;
            }

            btnSend.Enabled = false;
            btnSend.Text = "Sending...";

            try
            {
                var payload = $"{{\"content\":\"{JsonEscape(message)}\"}}";

                using (var client = new HttpClient())
                using (var content = new StringContent(payload, Encoding.UTF8, "application/json"))
                {
                    var response = await client.PostAsync(webhook, content).ConfigureAwait(false);
                    await Task.Yield();
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Message sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var respText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        MessageBox.Show($"Failed to send message. Status: {response.StatusCode}\n{respText}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending webhook: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = true;
                btnSend.Text = "Send";
            }
        }

        private static string JsonEscape(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return s
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "")
                .Replace("\n", "\\n");
        }

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Title = "Select an image";
                    dlg.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All Files|*.*";
                    dlg.CheckFileExists = true;
                    dlg.Multiselect = false;

                    if (dlg.ShowDialog(this) != DialogResult.OK) return;

                    using (var img = Image.FromFile(dlg.FileName))
                    {
                        if (!Directory.Exists(_settingsFolder))
                            Directory.CreateDirectory(_settingsFolder);

                        var dest = Path.Combine(_settingsFolder, "icon.png");
                        try
                        {
                            img.Save(dest, ImageFormat.Png);
                            _settings.ImageFileName = dest;
                            SaveSettings();
                        }
                        catch { }

                        ApplyPictureBoxImage(img);

                        try { SetFormIconFromImage(img); } catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load image: {ex.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyPictureBoxImage(Image source)
        {
            if (pictureBoxIcon == null || source == null) return;

            try
            {
                var previous = pictureBoxIcon.Image;
                pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxIcon.Image = new Bitmap(source);
                previous?.Dispose();
            }
            catch { }
        }

        private void btnApplyTitle_Click(object sender, EventArgs e)
        {
            if (lblTitle == null || txtTitleEdit == null) return;
            var text = string.IsNullOrWhiteSpace(txtTitleEdit.Text) ? "EZ Discord Webhook" : txtTitleEdit.Text.Trim();
            lblTitle.Text = text;

            _settings.TitleText = text;
            SaveSettings();
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            if (lblTitle == null) return;
            try
            {
                if (colorDialog1 == null) colorDialog1 = new ColorDialog();
                colorDialog1.Color = lblTitle.ForeColor;
                if (colorDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    lblTitle.ForeColor = colorDialog1.Color;
                    _settings.TitleColorArgb = colorDialog1.Color.ToArgb();
                    SaveSettings();
                }
            }
            catch { }
        }

        private void txtTitleEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnApplyTitle_Click(sender, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SetFormIconFromImage(Image source)
        {
            if (source == null) return;

            var size = 32;
            using (var bmp = new Bitmap(source, new Size(size, size)))
            {
                IntPtr hIcon = bmp.GetHicon();
                try
                {
                    using (var tmpIcon = Icon.FromHandle(hIcon))
                    {
                        var newIcon = (Icon)tmpIcon.Clone();
                        var previous = this.Icon;
                        this.Icon = newIcon;
                        previous?.Dispose();
                    }
                }
                finally
                {
                    DestroyIcon(hIcon);
                }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DestroyIcon(IntPtr handle);
    }
}