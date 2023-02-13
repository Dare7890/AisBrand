using System.IO;
using System.Text.Json;
using BrandDataProcessing.Constants;

namespace BrandDataProcessing
{
    public static class SubFieldsRetriever
    {
        private static string _fileName = "../../../../../ListData.json";

        public static SubFields Retrieve()
        {
            string jsonString = File.ReadAllText(_fileName);
            return JsonSerializer.Deserialize<SubFields>(jsonString);
        } 
    }
}
