namespace BaseCureAPI.Helpers
{
    public static class ImageHelper
    {
        public static string GetImageFromByteArray(byte[] imageBytes)
        {
            return imageBytes != null ? $"data:image/png;base64,{System.Convert.ToBase64String(imageBytes)}" : "";
        }
    }
}
