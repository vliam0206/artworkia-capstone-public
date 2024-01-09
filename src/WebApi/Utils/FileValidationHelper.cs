namespace WebApi.Utils;

public static class FileValidationHelper
{
    private static readonly string[] ALLOW_IMAGE_EXTENSIONS = new[] { ".jpg", ".jpeg", ".gif", ".png" };
    private static readonly long MAX_AVATAR_FILE_SIZE = 5 * 1024 * 1024; // 5 MB
    private static readonly long MAX_IMAGE_FILE_SIZE = 32 * 1024 * 1024; // 32 MB

    public static bool IsImageFormatValid(string fileName)
    {
        var fileExtension = Path.GetExtension(fileName).ToLower();
        return ALLOW_IMAGE_EXTENSIONS.Contains(fileExtension);
    }

    public static bool IsImageFileSizeValid(IFormFile imageFile)
    {
        if (imageFile.Length > MAX_IMAGE_FILE_SIZE)
        {
            return false;
        }
        return true;
    }

    public static bool IsAvatarFileSizeValid(IFormFile imageFile)
    {
        if (imageFile.Length > MAX_AVATAR_FILE_SIZE)
        {
            return false;
        }
        return true;
    }
}
