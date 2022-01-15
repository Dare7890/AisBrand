using AddBrandDataUI;
using AddBrandDataUI.ViewModels;

namespace Tools.Map
{
    public class ClassificationMapper : IMapper<Classification>
    {
        public Classification Map(AddBrandDataForm<Classification> form)
        {
            string type = form.BrandData.Type;
            string variant = form.BrandData.Variant;
            string description = form.BrandData.Description;

            byte[] pictute = null;
            if (form.BrandData.Image != null)
            {
                int pictuteLength = form.BrandData.Image.Length;
                int startIndex = 0;
                pictute = new byte[pictuteLength];
                form.BrandData.Image.CopyTo(pictute, startIndex);
            }

            return new Classification(type, variant, description, pictute);
        }
    }
}
