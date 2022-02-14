using AddBrandDataUI;
using AddBrandDataUI.ViewModels;

namespace Tools.Map
{
    public class FindMapper : IMapper<Find>
    {
        public Find Map(AddBrandDataForm<Find> form)
        {
            string formation = form.BrandData.Formation;
            int? square = form.BrandData.Square;
            int? depth = form.BrandData.Depth;
            string fieldNumber = form.BrandData.FieldNumber;
            string collectorsNumber = form.BrandData.CollectorsNumber;
            int? datingLowerBound = form.BrandData.DatingLowerBound;
            int? datingUpperBound = form.BrandData.DatingUpperBound;
            string description = form.BrandData.Description;
            string analogy = form.BrandData.Analogy;
            string note = form.BrandData.Note;

            byte[] image = CopyPicture(form.BrandData.Image);
            byte[] photo = CopyPicture(form.BrandData.Photo);

            Brand brand = form.BrandData.Brand;

            return new Find(fieldNumber, formation, square, depth, collectorsNumber, datingLowerBound, datingUpperBound, description, analogy, note, image, photo, brand);
        }

        // TODO : вынести в отдельный класс.
        private static byte[] CopyPicture(byte[] source)
        {
            byte[] target = null;
            if (source != null)
            {
                int pictuteLength = source.Length;
                int startIndex = 0;
                target = new byte[pictuteLength];
                source.CopyTo(target, startIndex);
            }

            return target;
        }
    }
}
