namespace BrandDataProcessingUI
{
    public struct NavigationInfo
    {
        public string Page { get; }

        public int? Id { get; }

        public NavigationInfo(string page, int? id)
        {
            Page = page;
            Id = id;
        }
    }
}
