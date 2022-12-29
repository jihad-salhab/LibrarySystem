namespace LibrarySystem.Shared.Models
{
    public class DataResult<T>
    {
        public T? Data { get; set; }
        public bool DidFail { get; set; }
        public string Reason { get; set; } = string.Empty;

    }
}
