namespace ASPCRUD.Response
{
    public class ModelReponse<T> : ReponseBase
    {
        public T Model { get; set; }        
    }
}
