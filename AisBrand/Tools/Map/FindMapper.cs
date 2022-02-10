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

            byte[] image = null;
            CopyPicture(form.BrandData.Image, image);

            byte[] photo = null;
            CopyPicture(form.BrandData.Photo, photo);

            return new Find(fieldNumber, formation, square, depth, collectorsNumber, datingLowerBound, datingUpperBound, description, analogy, note, image, photo);
        }

        // TODO : вынести в отдельный класс.
        private static void CopyPicture(byte[] source, byte[] target)
        {
            if (source != null)
            {
                int pictuteLength = source.Length;
                int startIndex = 0;
                target = new byte[pictuteLength];
                source.CopyTo(target, startIndex);
            }
        }
    }
}
