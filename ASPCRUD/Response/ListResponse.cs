namespace ASPCRUD.Response
{
    public class ListResponse<T>: ReponseBase
    {
        public List<T> Model { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        
    }
}
