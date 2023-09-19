public static class DataStore
{
    public static string[] ContentStringsFromTextFile { get; set; }

    static DataStore()
    {
        ContentStringsFromTextFile = Array.Empty<string>();
    }
}
