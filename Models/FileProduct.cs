namespace LearnAPI.Models
{
    public class FileProduct 
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] FileData { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}