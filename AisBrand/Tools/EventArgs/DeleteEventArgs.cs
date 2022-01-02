using AddBrandDataUI.ViewModels;

//TODO: перенести viewModel в другую библиотеку.

namespace Tools.EventArgs
{
    public class DeleteEventArgs<T> : System.EventArgs
    {
        public string FilePath { get; set; }

        public T DeletedBrandData { get; }

        public DeleteEventArgs(string filePath, T deletedData)
        {
            FilePath = filePath;
            DeletedBrandData = deletedData;
        }
    }
}