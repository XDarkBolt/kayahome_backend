namespace kayahome_backend.Models.Filters
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string id) : base(id + " ye sahip data bulunamadı")
        {

        }
    }
}
