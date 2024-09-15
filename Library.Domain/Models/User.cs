using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models
{
    public class User : IdentityUser<Guid> // Наследуемся от IdentityUser и используем Guid как тип идентификатора
    {
        
        public string FirstName { get; set; } // Имя
        public string LastName { get; set; } // Фамилия

        public ICollection<BookInstance> BookInstances { get; set; } = new List<BookInstance>();
    }
}
