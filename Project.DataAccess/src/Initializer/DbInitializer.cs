using Project.DataAccess.Context;
using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(PostgresContext context)
        {
            var students = new Student[]
            {
                new Student
                {
                    Name = "John",
                    LastName = "Doe",
                    BirthDate = DateTime.Parse("2000-09-01"),
                },
                new Student
                {
                    Name = "Jane",
                    LastName = "Doe",
                    BirthDate = DateTime.Parse("2001-10-01")
                },
            };

            foreach (Student s in students)
            {
                s.BirthDate = s.BirthDate.ToUniversalTime();
                context.Students?.Add(s);
            }

            context.SaveChanges();

            var careers = new Career[]
            {
                new Career { Name = "Engineering", Code = "ENG" },
                new Career { Name = "Arts", Code = "ART" },
            };

            foreach (Career c in careers)
            {
                context.Careers?.Add(c);
            }

            context.SaveChanges();
        }
    }
}
