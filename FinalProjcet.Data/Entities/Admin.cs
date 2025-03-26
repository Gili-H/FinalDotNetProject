namespace FinalProjectNetCore.Data.Entities
{
    public class Admin:User
    {

        public int Id {  get; set; }
        public string Name {  get; set; }

        // קשר של אחד לרבים עם המשתמשים ששייכים לו
        public List<User>? ManagedUsers { get; set; }


    }
}

