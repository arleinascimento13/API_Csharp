using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Users.Entity
{
    [Table("users")]
    public class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
