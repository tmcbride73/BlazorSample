using MatBlazor;
using System;
using System.IO;
using System.Threading.Tasks;


namespace BlazorSample
{
    public static class IMatFileUploadEntryExtensions
    {
        public static async Task<string> ToBase64(this IMatFileUploadEntry file)
        {
            string imageBase64;
            using (var stream = new MemoryStream())
            {
                await file.WriteToStreamAsync(stream);
                imageBase64 = Convert.ToBase64String(stream.ToArray());
            }
            return imageBase64;
        }
    }
}
