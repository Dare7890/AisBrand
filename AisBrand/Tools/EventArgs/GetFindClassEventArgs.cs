namespace Tools.EventArgs
{
    public class GetFindClassEventArgs : System.EventArgs
    {
        public int FindsClassId { get; set; }

        public GetFindClassEventArgs(int findsClassId)
        {
            FindsClassId = findsClassId;
        }
    }
}
