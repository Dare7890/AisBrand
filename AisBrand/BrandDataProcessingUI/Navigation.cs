using System.Collections.Generic;

namespace BrandDataProcessingUI
{
    public class Navigation
    {
        private Stack<NavigationInfo> pages;

        public bool IsExistsPages
        {
            get { return pages.Count > 0; }
        }

        public Navigation()
        {
            pages = new Stack<NavigationInfo>();
        }

        public void Forward(string page, int? id)
        {
            pages.Push(new NavigationInfo(page, id));
        }

        public NavigationInfo Back()
        {
            return pages.Pop();
        }
    }
}
