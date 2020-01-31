public static class ExtensionMethods
{
    public static string CovertToTimeFormatString(this float time)
    {
        return string.Format("{0:00}:{1:00}", (int)time / 60, (int)time % 60);
    }
}
