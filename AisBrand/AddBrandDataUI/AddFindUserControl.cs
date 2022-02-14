using AddBrandDataUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FindsClassModel = BrandDataProcessing.Models.FindsClass;

namespace AddBrandDataUI
{
    public partial class AddFindUserControl : UserControl, IUserControl<Find>
    {
        private FindsClassModel parentFindClass;
        private UserControl userControl;

        public byte[] Image { get; private set; }
        public byte[] Photo { get; private set; }

        public Classification ParentClassification { get; private set; }

        public AddFindUserControl(FindsClassModel findsClass, Find find = null)
        {
            InitializeComponent();

            if (find != null)
                FillTextFields(find);

            InitTypes(findsClass);
            InitUserControl(findsClass.Class);
            ShowUserControl(userControl);
        }

        private void InitUserControl(string subclass)
        {
            switch (subclass)
            {
                case "Клеймо":
                    userControl = new AddBrandUserControl();
                    break;
                default:
                    break;
            }
        }

        private void ShowUserControl(Control userControl)
        {
            if (userControl != null)
            {
                tlpMenu.Controls.Add(userControl, 0, 1);
                userControl.Dock = DockStyle.Fill;
            }
        }

        private void InitTypes(FindsClassModel findsClass)
        {
            this.parentFindClass = findsClass;
            IEnumerable<string> types = findsClass.Classifications.Select(c => c.Type)
                                                                    .Distinct()
                                                                    .OrderBy(t => t);
            InitTypes(types);
        }

        private void InitTypes(IEnumerable<string> types)
        {
            foreach (string type in types)
                cboType.Items.Add(type);

            SelectFirstItem(cboType);
        }

        private void InitVariantsCb(IEnumerable<string> variants)
        {
            foreach (string variant in variants)
                cboVariant.Items.Add(variant);

            SelectFirstItem(cboVariant);
        }

        private void SelectFirstItem(ComboBox cbo)
        {
            if (cbo.Items.Count > 0)
                cbo.SelectedIndex = 0;
        }

        public Find Add()
        {
            string formation = txtFormation.Text.Trim();
            string square = txtSquare.Text.Trim();
            string depth = txtDepth.Text.Trim();
            string fieldNumber = txtFieldNumber.Text.Trim();
            string collectorsNumber = txtCollectorsNumber.Text.Trim();
            string datingLowerBound = txtDatingLowerBound.Text.Trim();
            string datingUpperBound = txtDatingUpperBound.Text.Trim();
            string description = txtDescription.Text.Trim();
            string analogy = txtAnalogy.Text.Trim();
            string note = txtNote.Text.Trim();

            string type = cboType.SelectedItem?.ToString().Trim() ?? cboType.Text.Trim();
            string variant = cboVariant.SelectedItem?.ToString().Trim() ?? cboVariant.Text.Trim();
            ParentClassification = new(type, variant);

            int? parsedSquare = square == string.Empty ? null : int.Parse(square);
            int? parsedDepth = depth == string.Empty ? null : int.Parse(depth);
            int? parsedDatingLowerBound = datingLowerBound == string.Empty ? null : int.Parse(datingLowerBound);
            int? parsedDatingUpperBound = datingUpperBound == string.Empty ? null : int.Parse(datingUpperBound);

            switch (parentFindClass.Class)
            {
                case "Клеймо":
                    IUserControl<Brand> brandUserControl = (IUserControl<Brand>)userControl;
                    Brand brand = brandUserControl.Add();
                    return new Find(fieldNumber, formation, parsedSquare, parsedDepth, collectorsNumber, parsedDatingLowerBound, parsedDatingUpperBound, description, analogy,
                 note, Image, Photo, brand);
            }


            return new Find(fieldNumber, formation, parsedSquare, parsedDepth, collectorsNumber, parsedDatingLowerBound, parsedDatingUpperBound, description, analogy,
                note, Image, Photo);
        }

        private void FillTextFields(Find find)
        {
            txtFormation.Text = find.Formation;
            txtSquare.Text = find.Square.ToString();
            txtDepth.Text = find.Depth.ToString();
            txtFieldNumber.Text = find.FieldNumber;
            txtCollectorsNumber.Text = find.CollectorsNumber;
            txtDatingLowerBound.Text = find.DatingLowerBound.ToString();
            txtDatingUpperBound.Text = find.DatingUpperBound.ToString();
            txtDescription.Text = find.Description;
            txtAnalogy.Text = find.Analogy;
            txtNote.Text = find.Note;

            LoadImage(find.Image);
            ShowImage();

            LoadPhoto(find.Photo);
            ShowPhoto();
        }

        private void LoadPhoto(byte[] image)
        {
            LoadPicture(image, Photo);
        }

        private void LoadPicture(byte[] image, byte[] targetImage)
        {
            if (image != null)
            {
                int pictuteLength = image.Length;
                int startIndex = 0;
                targetImage = new byte[pictuteLength];
                image.CopyTo(targetImage, startIndex);
            }
        }

        private void LoadImage(byte[] image)
        {
            LoadPicture(image, Image);
        }

        private void ShowImage()
        {
            if (Image != null)
                ShowPicture(Image, pctImage.Size, pctImage);
        }

        private void ShowPhoto()
        {
            if (Photo != null)
                ShowPicture(Photo, pctPhoto.Size, pctPhoto);
        }

        private void ShowPicture(byte[] imageBytes, Size imageSize, PictureBox pictureBox)
        {
            using (Stream stream = new MemoryStream(imageBytes))
            {
                Image image = System.Drawing.Image.FromStream(stream);
                Bitmap bitmap = new Bitmap(image, imageSize);
                pictureBox.Image = bitmap;
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            AddImage();
        }

        private void AddImage()
        {
            Image = RetrievePictureAsByte();
            ShowImage();
        }

        //TODO: вынести в отдельный класс.
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

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            Photo = RetrievePictureAsByte();
            ShowPhoto();
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            ClearImage();
        }

        private void ClearImage()
        {
            if (Image != null)
                Image = null;

            pctImage.Image = null;
        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            ClearPhoto();
        }

        private void ClearPhoto()
        {
            if (Photo != null)
                Photo = null;

            pctPhoto.Image = null;
        }

        private void txtSquare_Validating(object sender, CancelEventArgs e)
        {
            ValidatingSquare(e);
        }

        private void ValidatingSquare(CancelEventArgs e)
        {
            string square = txtSquare.Text.Trim();
            bool isValid = Validator.Find.ValidSquare(square, out string errorMessage);
            ValidatingProperty(isValid, txtSquare, e, errorMessage);
        }

        private void txtDepth_Validating(object sender, CancelEventArgs e)
        {
            ValidatingDepth(e);
        }

        private void ValidatingDepth(CancelEventArgs e)
        {
            string depth = txtDepth.Text.Trim();
            bool isValid = Validator.Find.ValidDepth(depth, out string errorMessage);
            ValidatingProperty(isValid, txtDepth, e, errorMessage);
        }

        private void txtFieldNumber_Validating(object sender, CancelEventArgs e)
        {
            ValidatingFieldNumber(e);
        }

        private void ValidatingFieldNumber(CancelEventArgs e)
        {
            string fieldNumber = txtFieldNumber.Text.Trim();
            bool isValid = Validator.Find.ValidFieldNumber(fieldNumber, out string errorMessage);
            ValidatingProperty(isValid, txtFieldNumber, e, errorMessage);
        }

        //TODO: в отдельный класс.
        private void ValidatingProperty(bool isValid, TextBox textBox, CancelEventArgs e, string errorMessage)
        {
            if (!isValid)
            {
                e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);

                errValidating.SetError(textBox, errorMessage);
            }
            else
            {
                errValidating.SetError(textBox, string.Empty);
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearVariants();
            FillVariants();
        }

        private void ClearVariants()
        {
            ClearComboBox(cboVariant);
        }

        private void ClearComboBox(ComboBox cboVariant)
        {
            cboVariant.Items.Clear();
        }

        private void FillVariants()
        {
            string selectedType = cboType.SelectedItem?.ToString().Trim() ?? cboType.Text.Trim();
            IEnumerable<string> variants = GetVatiantsByType(selectedType);
            InitVariantsCb(variants);
        }

        private IEnumerable<string> GetVatiantsByType(string type)
        {
            return parentFindClass.Classifications.Where(c => c.Type == type)
                                                    .Select(c => c.Variant)
                                                    .Distinct();
        }
    }
}
