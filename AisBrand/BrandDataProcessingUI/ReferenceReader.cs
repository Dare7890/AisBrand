using System.Diagnostics;

namespace BrandDataProcessingUI
{
    public class ReferenceReader
    {
        private const string filePath = @"..\..\..\..\..\Reference.docx";

        public void Show()
        {
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}