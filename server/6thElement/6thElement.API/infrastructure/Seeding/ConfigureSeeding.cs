using _6thElement.Domain;
using _6thElement.Domain.Users;
using _6thElement.Persistance.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace _6thElement.API.infrastructure.Seeding
{
    public static class ConfigureSeeding
    {
        public static void Seed(this IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            Migrate(dbContext);
            SeedModules(dbContext);
            SeedChapters(dbContext);
            SeedQuestions(dbContext);
            SeedAnswers(dbContext);
            SeedRoles(roleManager).GetAwaiter().GetResult();

        }

        public static void Migrate(AppDbContext context)
        {
            context.Database.Migrate();
        }


        public static async Task SeedRoles(RoleManager<Role> manager)
        {
            if ((await manager.FindByNameAsync("User")) == null)
            {
                await manager.CreateAsync(new Role { Name = "User" });
            }

        }
        public static void SeedModules(AppDbContext context)
        {
            var modules = new List<Module>()
            {
                new Module { Name = "Blockchain", Type = "Module"},
                new Module { Name = "Cryptocurrency", Type = "Module"},
                new Module { Name = "NFT", Type = "Module"},
            };

            foreach (var module in modules)
            {
                var exists = context.Modules.Any(x => x.Name == module.Name);

                if (!exists)
                {
                    context.Modules.Add(module);
                }

            }

            context.SaveChanges();
        }

        public static void SeedChapters(AppDbContext context)
        {
            var chapters = new List<Chapter>()
            {
                new Chapter { ModuleId = 1, Order = 0},
                new Chapter { ModuleId = 1, Order = 1},
                new Chapter { ModuleId = 1, Order = 2},
                new Chapter { ModuleId = 1, Order = 3},
                new Chapter { ModuleId = 1, Order = 4},
                new Chapter { ModuleId = 2, Order = 0},
                new Chapter { ModuleId = 2, Order = 1},
                new Chapter { ModuleId = 2, Order = 2},
                new Chapter { ModuleId = 2, Order = 3},
                new Chapter { ModuleId = 2, Order = 4},
                new Chapter { ModuleId = 3, Order = 0},
                new Chapter { ModuleId = 3, Order = 1},
                new Chapter { ModuleId = 3, Order = 2},
                new Chapter { ModuleId = 3, Order = 3},
                new Chapter { ModuleId = 3, Order = 4}
            };

            foreach (var chapter in chapters)
            {
                var exists = context.Chapters.Any(x => x.ModuleId == chapter.ModuleId && x.Order == chapter.Order);

                if (!exists)
                {
                    context.Chapters.Add(chapter);
                }
            }

            context.SaveChanges();
        }

        public static void SeedQuestions(AppDbContext context)
        {
            var questions = new List<Question>()
            {
                new Question { Description = "რა არის ბლოქჩეინი?", ChapterId = 1},
                new Question { Description = "ბლოქჩეინში ინფორმაცია ინახება:", ChapterId = 1},
                new Question { Description = "რას ინახავს ბლოკი?", ChapterId = 1},

                new Question { Description = "შესაძლებელია თუ არა ბლოქჩეინზე შენახული ინფორმაციის ცვლილება?", ChapterId = 2},
                new Question { Description = "რას ნიშნავს „ორმაგი ხარჯვა“ ბლოქჩეინ ტექნოლოგიაში?", ChapterId = 2},
                new Question { Description = "რისთვის გამოიყენება კონსესუსის მექანიზმები ბლოქჩეინ ტექნოლოგიაში?", ChapterId = 2},

                new Question { Description = "რა ხდის ბლოქჩეინს განსაკუთრებულს?", ChapterId = 3},
                new Question { Description = "რას გულისხმობს დეცენტრალიზაცია ბიტკოინში?", ChapterId = 3},
                new Question { Description = "რა არის სმარტ კონტრაქტი?", ChapterId = 3},

                new Question { Description = "რომელი ბლოქჩეინი უზრუნველყოფს ტრანზაქციების სრულ გამჭვირვალობას?", ChapterId = 4},
                new Question { Description = "რა განასხვავებს ბლოქჩეინს ტრადიციული ბაზისაგან?", ChapterId = 4},
                new Question { Description = "რომელი პროგრამული ენა გამოიყენება სმარტ კონტრაქტისათვის ეთერიუმის ბაზაზე?", ChapterId = 4},

                new Question { Description = "კონსესუსის რომელ მექანიზმს სჭირდება ბევრი ელექტრო ენერგია?", ChapterId = 5},
                new Question { Description = "რა არის დეცენტრალიზებული გადამცვლელების (DEX) ფუნქცია ბლოქჩეინ ეკოსისტემაში?", ChapterId = 5},
                new Question { Description = "რა როლს თამაშობს ნოუდი ბლოქჩეინ ტექნონლოგიაში?", ChapterId = 5},
            };

            foreach (var question in questions)
            {
                var exists = context.Questions.Any(x => x.Description == question.Description);
                if (!exists)
                {
                    context.Questions.Add(question);
                }
            }

            context.SaveChanges();
        }

        public static void SeedAnswers(AppDbContext context)
        {
            var answers = new List<Answer>()
            {
                new Answer { Description = "დეცენტრალიზებული დავთარი", IsCorrect = true, QuestionId = 1},
                new Answer { Description = "საბანკო პროდუქტი", IsCorrect = false, QuestionId = 1},
                new Answer { Description = "ეროვნული ბანკის სერვერი", IsCorrect = false, QuestionId = 1},

                new Answer { Description = "უჯრებში", IsCorrect = false, QuestionId = 2},
                new Answer { Description = "ბლოკებში", IsCorrect = true, QuestionId = 2},
                new Answer { Description = "ყუთებში", IsCorrect = false, QuestionId = 2},

                new Answer { Description = "ბიტკოინს", IsCorrect = false, QuestionId = 3},
                new Answer { Description = "დადასტურებულ ტრანზაქციებზე ინფორმაციას", IsCorrect = true, QuestionId = 3},
                new Answer { Description = "მიმდინარე ტრანზაქციებს", IsCorrect = false, QuestionId = 3},

                new Answer { Description = "კი", IsCorrect = false, QuestionId = 4},
                new Answer { Description = "არა", IsCorrect = true, QuestionId = 4},
                new Answer { Description = "ხანდახან", IsCorrect = false, QuestionId = 4},

                new Answer { Description = "ერთი და იმავე კრიპტოვალუტის დახარჯვა სხვადასხვა ტრანზაქციაში", IsCorrect = true, QuestionId = 5},
                new Answer { Description = "ორი ტრანზაქციის ერთობლივი განხორციელება სხვადასხვა ბლოქჩეინზე", IsCorrect = false, QuestionId = 5},
                new Answer { Description = "კრიპტოვალუტის ორ მიმღებთან გადაგზავნა", IsCorrect = false, QuestionId = 5},

                new Answer { Description = "ტრანზაქციების ვალიდაციისთვის", IsCorrect = true, QuestionId = 6},
                new Answer { Description = "ბლოქჩეინ ტექნოლოგიაში ვალიდაცია არ არის აუცილებელი", IsCorrect = false, QuestionId = 6},
                new Answer { Description = "კონფლიქტების თავიდან ასაცილებლად", IsCorrect = false, QuestionId = 6},

                new Answer { Description = "ბლოქჩეინმა ტელეპორტაცია გახადა შესაძლებელი", IsCorrect = false, QuestionId = 7},
                new Answer { Description = "ბლოქჩეინმა დიჯიტალ მონაცემების ცენტრალურას შენახვის საჭიროება გააქრო", IsCorrect = true, QuestionId = 7},
                new Answer { Description = "ბლოქჩეინმა ქაღალდის ფული ციფრულ ფულად აქცია", IsCorrect = false, QuestionId = 7},

                new Answer { Description = "მონაცემებზე წვდომა და კონტროლი ერთი ორგანიზაციის ქვეშაა", IsCorrect = false, QuestionId = 8},
                new Answer { Description = "მონაცემები და მასზე კონტროლი რამდენიმე მონაწილის მიერ ვერიფიცირდება და ინახება", IsCorrect = true, QuestionId = 8},
                new Answer { Description = "მხოლოდ ბანკებს აქვთ ბლოქჩეინ ტექნოლოგიაზე წვდომა", IsCorrect = false, QuestionId = 8},

                new Answer { Description = "კონტრაქტი რომელიც საჭიროებს სმარტ დევაისის გამოყენებას", IsCorrect = false, QuestionId = 9},
                new Answer { Description = "კონტრაქტი რომელსაც ხელს აწერს 2 მხარე", IsCorrect = false, QuestionId = 9},
                new Answer { Description = "აღსრულებადი კონტრაქტი რომელიც ბლოკჩეინშია გაწერილი", IsCorrect = true, QuestionId = 9},

                new Answer { Description = "საჯარო ბლოქჩეინი", IsCorrect = true, QuestionId = 10},
                new Answer { Description = "კერძო ბლოქჩეინი", IsCorrect = false, QuestionId = 10},
                new Answer { Description = "არცერთი", IsCorrect = false, QuestionId = 10},

                new Answer { Description = "ბლოქჩეინი ცენტრალიზებულია, ტრადიციული ბაზები დეცენტრალიზებული", IsCorrect = false, QuestionId = 11},
                new Answer { Description = "ბლოქჩეინი მხოლოდ ფინანსური ტრანზაქციებისთვის გამოიყენება", IsCorrect = false, QuestionId = 11},
                new Answer { Description = "ბლოქჩეინი იძლევა დეცენტრალიზების საშუალებას", IsCorrect = true, QuestionId = 11},

                new Answer { Description = "ჯავა", IsCorrect = false, QuestionId = 12},
                new Answer { Description = "სოლიდითი", IsCorrect = true, QuestionId = 12},
                new Answer { Description = "პითონი", IsCorrect = false, QuestionId = 12},

                new Answer { Description = "PoW", IsCorrect = true, QuestionId = 13},
                new Answer { Description = "PoS", IsCorrect = false, QuestionId = 13},
                new Answer { Description = "DPos", IsCorrect = false, QuestionId = 13},

                new Answer { Description = "ბიტკოინის ტრანზაქციების საზღვარზე გადაადგილების უზრუნველყოფა", IsCorrect = false, QuestionId = 14},
                new Answer { Description = "კრიპტოვალუტაზე მოთხოვნის რეგულირების უზრუნველყოფა", IsCorrect = false, QuestionId = 14},
                new Answer { Description = "კრიპტოვალუტით ვაჭრობის ხელშეწყობა ცენტრალიზებული გადამცვლელის გარეშე", IsCorrect = true, QuestionId = 14},

                new Answer { Description = "ახალი ბლოკის მაინინგი", IsCorrect = false, QuestionId = 15},
                new Answer { Description = "ტრანზაქციების ვალიდაცია", IsCorrect = true, QuestionId = 15},
                new Answer { Description = "პირადი გასაღების გენერირება", IsCorrect = false, QuestionId = 15},
            };

            foreach (var answer in answers)
            {
                var exists = context.Answers.Any(x => x.Description == answer.Description && x.QuestionId == answer.QuestionId);

                if (!exists)
                { 
                    context.Answers.Add(answer);
                }
            }

            context.SaveChanges();
        }

    }
}