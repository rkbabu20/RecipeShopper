using System.Runtime.CompilerServices;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var role = Role.Admin;
            string roleString = role.ToString();
            Console.WriteLine(roleString);
            Console.Read();
        }
    }

    public enum Role
    {
        Admin,
        User,
        SuperAdmin
    }
}
