using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Rattler.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(16)]
        public string Login { get; set; }

        
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
       
        private void SetPassword(string password)
        {
            Password = ComputeSha256Hash(password);
        }


        [Required()]
        [EmailAddress]
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }

        public User(string login, string password, string email)
        {

            SetPassword(password);
            Login = login;
            Email = email;
            Orders = new List<Order>();
        }
        static public string ComputeSha256Hash(string rawData)
        {
              
            using (SHA256 sha256Hash = SHA256.Create())
            {    
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
