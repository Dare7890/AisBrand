using BrandDataProcessing.Models;
using System;

namespace BrandDataProcessingBL
{
    public class AddExcavationEventArgs : EventArgs
    {
        public string FilePath { get; }

        public Excavation Excavation { get; }

        public AddExcavationEventArgs(string filePath, Excavation excavation)
        {
            FilePath = filePath;
            Excavation = excavation;
        }
    }
}