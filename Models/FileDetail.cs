namespace LearnAPI.Models 
{
    public class FileDetail 
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] FileData { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}