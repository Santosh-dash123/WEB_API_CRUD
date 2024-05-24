namespace FIRST_WEB_API_CRUD.Models
{
    using System.ComponentModel.DataAnnotations;
    public class STUDENT
    {
        [Key]
        public int ID { get; set; }
        public string? NAME { get; set; } //"?" this specifies means it will accept null value.
        public int AGE { get; set; }
        public string? ADDRESS { get; set; }
    }
}
