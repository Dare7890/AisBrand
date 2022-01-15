using AddBrandDataUI.ViewModels;
using System;
using System.IO;
using System.Windows.Forms;

namespace AddBrandDataUI
{
    public partial class AddClassificationUserControl : UserControl, IUserControl<Classification>
    {
        public byte[] Image { get; private set; }

        public AddClassificationUserControl(Classification classification = null)
        {
            InitializeComponent();

            if (classification != null)
                FillTextFields(classification);
        }

        private void FillTextFields(Classification classification)
        {
            txtType.Text = classification.Type;
            txtVariant.Text = classification.Variant;
            txtDescription.Text = classification.Description;

            if (classification.Image != null)
            {
                int pictuteLength = classification.Image.Length;
                int startIndex = 0;
                Image = new byte[pictuteLength];
                classification.Image.CopyTo(Image, startIndex);
            }

            if (Image != null)
                ShowPicture(Image);
        }

        public Classification Add()
        {
            string type = txtType.Text.Trim();
            string variant = txtVariant.Text.Trim();
            string description = txtDescription.Text.Trim();

            return new Classification(type, variant, description, Image);
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            AddPicture();
        }

        private void AddPicture()
        {
            Image = RetrievePictureAsByte();
            ShowPicture(Image);
        }

        private byte[] RetrievePictureAsByte()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    throw new InvalidOperationException("Can't open file.");

                string filePath = openFileDialog.FileName;
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        private void ShowPicture(byte[] image)
        {
            using (Stream stream = new MemoryStream(image))
            {
                picPicture.Image = System.Drawing.Image.FromStream(stream);
            }
        }
    }
}
