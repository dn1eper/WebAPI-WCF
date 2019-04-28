namespace Server.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }

        public static bool Validate(Employee emp)
        {
            return !(
                string.IsNullOrEmpty(emp.FirstName)  ||
                string.IsNullOrEmpty(emp.LastName) ||
                string.IsNullOrEmpty(emp.Department)
           );
        }
    }
}