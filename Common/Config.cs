namespace Common
{
    public static class Config
    {
         //docker
         public static string DatabasePath { get; } = "/data/data.db";
         //local
         //public static string DatabasePath { get; } = "../EnronData/data.db";
        public static string DataSourcePath { get; } = "C:\\EnronData";
        public static int NumberOfFoldersToIndex { get; } = 10; // Use 0 or less for indexing all folders
    }
}