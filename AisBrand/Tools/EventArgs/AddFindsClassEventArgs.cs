using System.Collections.Generic;

namespace Tools.EventArgs
{
    public class AddFindsClassEventArgs : System.EventArgs
    {
        public string FilePath { get; }
        public IEnumerable<string> Classes { get; }
        public int ParentId { get; }

        public AddFindsClassEventArgs(string filePath, IEnumerable<string> classes, int parentId)
        {
            FilePath = filePath;
            Classes = classes;
            ParentId = parentId;
        }
    }
}
