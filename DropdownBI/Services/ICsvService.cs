namespace DropdownBI.Services
{
    public interface ICsvService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file);
    }
}
