using Project.DataAccess.Context;
using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(PostgresContext context)
        {
            var students = new List<Student>();
            var careers = new List<Career>();

            var firstNames = new List<string>
            {
                "John",
                "Jane",
                "Bob",
                "Alice",
                "Charlie",
                "Diana",
                "Ethan",
                "Fiona",
                "George",
                "Hannah",
                "Ivan",
                "Julia",
                "Kevin",
                "Laura",
                "Michael"
            };
            var lastNames = new List<string>
            {
                "Doe",
                "Smith",
                "Johnson",
                "Williams",
                "Brown",
                "Davis",
                "Miller",
                "Wilson",
                "Moore",
                "Taylor",
                "Clark",
                "Robinson",
                "Lewis",
                "Walker",
                "Hall"
            };
            for (int i = 0; i < 15; i++)
            {
                students.Add(
                    new Student
                    {
                        Name = firstNames[i],
                        LastName = lastNames[i],
                        BirthDate = DateTime.Parse("2001-09-01").AddYears(i),
                    }
                );
            }

            var careerNames = new List<string>
            {
                "Engineering",
                "Arts",
                "Science",
                "Mathematics",
                "History",
                "Literature",
                "Physics",
                "Chemistry",
                "Biology",
                "Music"
            };
            for (int i = 0; i < 10; i++)
            {
                careers.Add(
                    new Career
                    {
                        Name = careerNames[i],
                        Code = $"CR-{i.ToString().PadLeft(2, '0')}"
                    }
                );
            }

            Random rand = new Random();

            foreach (Student s in students)
            {
                List<int> usedIndices = new List<int>();

                for (int j = 0; j < 3; j++)
                {
                    int randomIndex;
                    do
                    {
                        randomIndex = rand.Next(careers.Count);
                    } while (usedIndices.Contains(randomIndex));

                    usedIndices.Add(randomIndex);
                    s.Relations.Add(careers[randomIndex]);

                    careers[randomIndex].Relations.Add(s);
                }
            }

            foreach (Student s in students)
            {
                s.BirthDate = s.BirthDate.ToUniversalTime();
                context.Set<Student>().Add(s);
            }

            foreach (Career c in careers)
            {
                context.Set<Career>().Add(c);
            }

            context.SaveChanges();
        }
    }
}
