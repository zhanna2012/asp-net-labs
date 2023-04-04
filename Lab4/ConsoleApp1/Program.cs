using System.Reflection;

internal class Program
{
    // #1
    public class Person
    {
        // Fields
        private string firstName;
        public string lastName;
        protected int age;
        internal bool isStudent;
        public static int numberOfPeople = 0;

        // Constructor
        public Person(string firstName, string lastName, int age, bool isStudent)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.isStudent = isStudent;
            numberOfPeople++;
        }

        // Methods
        public void SayHello()
        {
            Console.WriteLine("Hello, my name is " + firstName + " " + lastName + ".");
        }

        private void SayAge()
        {
            Console.WriteLine("I am " + age + " years old.");
        }

        protected string GetFullName()
        {
            return firstName + " " + lastName;
        }
    }

    private static void Main(string[] args)
    {
        // #2
        Type personType = typeof(Person);
        TypeInfo personTypeInfo = personType.GetTypeInfo();

        Console.WriteLine("Person type name: " + personType.Name);
        Console.WriteLine("Is Person an abstract class? " + personTypeInfo.IsAbstract);
        Console.WriteLine("Is Person a sealed class? " + personTypeInfo.IsSealed);
        Console.WriteLine("Person has " + personTypeInfo.DeclaredFields.Count() + " fields.");
        Console.WriteLine("Person has " + personTypeInfo.DeclaredMethods.Count() + " methods.");

        // #3

        MemberInfo lastNameMember = typeof(Person).GetMember("lastName")[0];
        Console.WriteLine("Member name: " + lastNameMember.Name);
        Console.WriteLine("Member type: " + lastNameMember.MemberType);
        Console.WriteLine("Member declaring type: " + lastNameMember.DeclaringType);

        // #4

        FieldInfo ageField = typeof(Person).GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine("Field name: " + ageField.Name);
        Console.WriteLine("Field type: " + ageField.FieldType);
        Console.WriteLine("Field is private: " + ageField.IsPrivate);
        Console.WriteLine("Field value: " + ageField.GetValue(new Person("Zhanna", "Rudenko", 20, false)));

        // #5

        Person person = new Person("Zhanna", "Rudenko", 20, false);
        MethodInfo sayHelloMethod = typeof(Person).GetMethod("SayHello");
        sayHelloMethod.Invoke(person, null);

    }


}