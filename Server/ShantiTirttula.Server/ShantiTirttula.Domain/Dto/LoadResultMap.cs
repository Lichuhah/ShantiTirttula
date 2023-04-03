namespace ShantiTirttula.Domain.Dto
{
    public class LoadResultMap<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int GroupCount { get; set; }
        public object[] Summary { get; set; }
    }
}
