using System;

namespace BrandDataProcessing
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CategoryAttribute : Attribute
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public CategoryAttribute(string title)
        {
            this.title = title;
        }
    }
}
