using System;

namespace BrandDataProcessing
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TranslatedNameAttribute : Attribute
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public TranslatedNameAttribute(string name)
        {
            this.name = name;
        }
    }
}
