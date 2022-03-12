namespace Tools.EventArgs
{
    public class FilterEventArgs<T> : System.EventArgs
    {
        public string Property { get; set; }

        public string Text { get; set; }

        public FilterEventArgs(string property, string text)
        {
            Property = property;
            Text = text;
        }
    }
}
