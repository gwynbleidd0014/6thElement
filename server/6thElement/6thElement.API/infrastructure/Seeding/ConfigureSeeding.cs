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
            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            Migrate(dbContext);
            SeedModules(dbContext, config);
            SeedChapters(dbContext);
            SeedQuestions(dbContext, config);
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
        public static void SeedModules(AppDbContext context, IConfiguration config)
        {
            var modules = new List<Module>()
            {
                new Module { Name = "Basic", Type = "Module", ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png" },
                new Module { Name = "Blockchain", Type = "Module", ImagePath=$"/{config["Constants:ResourcePath"]}/342cc13c-77ee-4bc4-8bd9-8eccf0aaa84a.png" },
                new Module { Name = "Cryptocurrency", Type = "Module", ImagePath=$"/{config["Constants:ResourcePath"]}/256f7b68-ca99-4f8e-b03a-1d28b612719e.png"},
                new Module { Name = "NFT", Type = "Module", ImagePath=$"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
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
                new Chapter { ModuleId = 2, Order = 0},
                new Chapter { ModuleId = 2, Order = 1},
                new Chapter { ModuleId = 2, Order = 2},
                new Chapter { ModuleId = 2, Order = 3},
                new Chapter { ModuleId = 2, Order = 4},

                new Chapter { ModuleId = 3, Order = 0},
                new Chapter { ModuleId = 3, Order = 1},
                new Chapter { ModuleId = 3, Order = 2},
                new Chapter { ModuleId = 3, Order = 3},
                new Chapter { ModuleId = 3, Order = 4},

                new Chapter { ModuleId = 4, Order = 0},
                new Chapter { ModuleId = 4, Order = 1},
                new Chapter { ModuleId = 4, Order = 2},
                new Chapter { ModuleId = 4, Order = 3},
                new Chapter { ModuleId = 4, Order = 4},

                new Chapter { ModuleId = 1, Order = 0},
                new Chapter { ModuleId = 1, Order = 1},
                new Chapter { ModuleId = 1, Order = 2},
                new Chapter { ModuleId = 1, Order = 3},
                new Chapter { ModuleId = 1, Order = 4},

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

        public static void SeedQuestions(AppDbContext context, IConfiguration config)
        {
            var questions = new List<Question>()
            {
                new Question { Description = "რა არის ბლოქჩეინი?", ChapterId = 1, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "ბლოქჩეინში ინფორმაცია ინახება:", ChapterId = 1, ImagePath=$"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რას ინახავს ბლოკი?", ChapterId = 1, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "შესაძლებელია თუ არა ბლოქჩეინზე შენახული ინფორმაციის ცვლილება?", ChapterId = 2, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "რას ნიშნავს „ორმაგი ხარჯვა“ ბლოქჩეინ ტექნოლოგიაში?", ChapterId = 2, ImagePath=$"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რისთვის გამოიყენება კონსესუსის მექანიზმები ბლოქჩეინ ტექნოლოგიაში?", ChapterId = 2,ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "რა ხდის ბლოქჩეინს განსაკუთრებულს?", ChapterId = 3, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "რას გულისხმობს დეცენტრალიზაცია ბიტკოინში?", ChapterId = 3, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რა არის სმარტ კონტრაქტი?", ChapterId = 3, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "რომელი ბლოქჩეინი უზრუნველყოფს ტრანზაქციების სრულ გამჭვირვალობას?", ChapterId = 4, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "რა განასხვავებს ბლოქჩეინს ტრადიციული ბაზისაგან?", ChapterId = 4, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რომელი პროგრამული ენა გამოიყენება სმარტ კონტრაქტისათვის ეთერიუმის ბაზაზე?", ChapterId = 4, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "კონსესუსის რომელ მექანიზმს სჭირდება ბევრი ელექტრო ენერგია?", ChapterId = 5, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "რა არის დეცენტრალიზებული გადამცვლელების (DEX) ფუნქცია ბლოქჩეინ ეკოსისტემაში?", ChapterId = 5, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რა როლს თამაშობს ნოუდი ბლოქჩეინ ტექნონლოგიაში?", ChapterId = 5, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "ბლოქჩეინი და კრიპტოვალუტა სინონიმებია:", ChapterId = 6, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "ჯამში რამდენი ბიტკოინის იარსებებს?", ChapterId = 6, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რომელი ვირტუალური ვალუტაა ბლოქჩეინ ტექნოლოგიის პირველი მაგალითი?", ChapterId = 6, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "რა როლს თამაშობენ მაინერები ბიტკოინში?", ChapterId = 7, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "რა არის პირადი გასაღები?", ChapterId = 7, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "კონსესუსის რომელ მექანიზმს იყენებს ბიტკოინი?", ChapterId = 7, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "კონსესუსის რომელ მექანიზმს იყენებს ეთერიუმი 2022 წლიდან?", ChapterId = 8, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "რომელი კრიპტოვალუტა შექმნა სატოში ნაკამოტომ?", ChapterId = 8, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რომელმა კრიპტოვალუტამ დანერგა სმარტ კონტრაქცის ფუნქციონალი?", ChapterId = 8, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "Tether არის:", ChapterId = 9, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "სტაბილკოინი USDT:", ChapterId = 9, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რა არის BINANCE?", ChapterId = 9, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "რეგულატორებს და კანონის აღმასრულებელ ორგანოებს არ შეუძლიათ ბიტკოინის ტრანზაქციებს ‘გაყვნენ’", ChapterId = 10, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "ბიტკოინის ფასი მომავალში მხოლოდ გაიზრდება, რადგანაც მხოლოდ 21 მილიონი ბიკტოინის დამაინერება მოხდება:", ChapterId = 10, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "კრიპტოვალუტა შეიძლება გამოყენებულ იქნეს გადახდებისათვის", ChapterId = 10, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "როგორ იშიფრება NFT?", ChapterId = 11, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "ყველა NFT აქვს მაღალი ღირებულება:", ChapterId = 11, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რა განასხვავებს NFT-ს ბიტკოინისგან და ეთერიუმისგან?", ChapterId = 11, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "რომელი პლატფორმა არის პოპულარულის NFT-ების გამოსაცემად, სმარტ კონტრაქტებისა და დეცენტრალიზებული აპლიკაციების ქონის გამო?", ChapterId = 12, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "ეთერიუმის პლატფორმაზე NFT რომელი სტანდარტი გამოიყენება?", ChapterId = 12, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რას გულისხმობს ‘minting’ NFT კონტექსტში?", ChapterId = 12, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "როგორ შეიძლება გამოიყურებოდეს NFT?", ChapterId = 13, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "NFT შესანახად რომელი მეთოდი არის უსაფრთხო?", ChapterId = 13, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რა არის OPENSEA?", ChapterId = 13, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "DAO არის:", ChapterId = 14, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "რომელია ყველაზე ძვირადღირებული NFT", ChapterId = 14, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "NFT-ში ინვესტიცია", ChapterId = 14, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "ყველას შეუძლია NFT-ის გამოშვება?", ChapterId = 15, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "NFT-ის გაყიდვა", ChapterId = 15, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რა განსაზღვრავს NFT ღირებულებას?", ChapterId = 15, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "რა არის ფული?:", ChapterId = 16, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "სად არის უკეთესი ფულის შენახვა? :", ChapterId = 16, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რა არის დაზოგვა?", ChapterId = 16, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "რა არის ბიუჯეტი?", ChapterId = 17, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "რას ნიშნავს პროცენტი?", ChapterId = 17, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რა არის შემოსავალი?", ChapterId = 17, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

                new Question { Description = "რა არის კრედიტი?", ChapterId = 18, ImagePath=$"/{config["Constants:ResourcePath"]}/9a6286e9-c2a1-4e90-9fc2-57f07fd7bcf2.png"},
                new Question { Description = "რა არის ინფლაცია?", ChapterId = 18, ImagePath = $"/{config["Constants:ResourcePath"]}/151b8db7-9552-4217-adeb-c443feef9bbd.png"},
                new Question { Description = "რა არის საფონდო ბირჟა?", ChapterId = 18, ImagePath=$"/{config["Constants:ResourcePath"]}/d3daf41a-de2f-4baf-9fae-aaa753bef1bf.png"},

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

                new Answer { Description = "სწორია", IsCorrect = false, QuestionId = 16},
                new Answer { Description = "არასწორია", IsCorrect = true, QuestionId = 16},
                new Answer { Description = "გააჩნია სიტუაციას", IsCorrect = false, QuestionId = 16},

                new Answer { Description = "21 მილიონი", IsCorrect = true, QuestionId = 17},
                new Answer { Description = "100 მილიონი", IsCorrect = false, QuestionId = 17},
                new Answer { Description = "უსასრულო რაოდენობა", IsCorrect = false, QuestionId = 17},

                new Answer { Description = "ლარი", IsCorrect = false, QuestionId = 18},
                new Answer { Description = "ბიტკოინი", IsCorrect = true, QuestionId = 18},
                new Answer { Description = "რიპლი", IsCorrect = false, QuestionId = 18},

                new Answer { Description = "არეგულირებენ კრიპტოვალუტის ღირებულებას", IsCorrect = false, QuestionId = 19},
                new Answer { Description = "არანაირი ფუნქცია არ აქვთ", IsCorrect = false, QuestionId = 19},
                new Answer { Description = "ვერიფიცირებას უკეთებენ ტრანზაქციებს", IsCorrect = true, QuestionId = 19},

                new Answer { Description = "სახლის გასაღები", IsCorrect = false, QuestionId = 20},
                new Answer { Description = "გასაღები, რომელიც გამოიყენება კრიპტოვალუტის სამართავად", IsCorrect = false, QuestionId = 20},
                new Answer { Description = "ბლოკში არსებული ინფორმაციის წაშლის საშუალება", IsCorrect = true, QuestionId = 20},

                new Answer { Description = "PoW", IsCorrect = true, QuestionId = 21},
                new Answer { Description = "PoS", IsCorrect = false, QuestionId = 21},
                new Answer { Description = "DPo", IsCorrect = false, QuestionId = 21},

                new Answer { Description = "PoW", IsCorrect = false, QuestionId = 22},
                new Answer { Description = "PoS", IsCorrect = true, QuestionId = 22},
                new Answer { Description = "DPo", IsCorrect = false, QuestionId = 22},

                new Answer { Description = "ლარი", IsCorrect = false, QuestionId = 23},
                new Answer { Description = "ბიტკოინი", IsCorrect = true, QuestionId = 23},
                new Answer { Description = "რიპლი", IsCorrect = false, QuestionId = 23},

                new Answer { Description = "ლაითქოინი", IsCorrect = false, QuestionId = 24},
                new Answer { Description = "რიპლი", IsCorrect = false, QuestionId = 24},
                new Answer { Description = "ეთერიუმი", IsCorrect = true, QuestionId = 24},

                new Answer { Description = "ბიკტოინის ნაირსახეობა", IsCorrect = false, QuestionId = 25},
                new Answer { Description = "სტაბილკოინი", IsCorrect = true, QuestionId = 25},
                new Answer { Description = "სმარტ კონტრაქტის სახეობა", IsCorrect = false, QuestionId = 25},

                new Answer { Description = "მიბულია FIAT-ზე", IsCorrect = true, QuestionId = 26},
                new Answer { Description = "მიბმულია ოქროს ღირებულებაზე", IsCorrect = false, QuestionId = 26},
                new Answer { Description = "არაფერზეა მიბმული", IsCorrect = false, QuestionId = 26},

                new Answer { Description = "ეროვნული ბანკის მიერ გამოშვებული ციფრული ლარი", IsCorrect = false, QuestionId = 27},
                new Answer { Description = "კრიპტოვალუტის გადამცვლელი", IsCorrect = true, QuestionId = 27},
                new Answer { Description = "ნახევარი ბიტკოინი", IsCorrect = false, QuestionId = 27},

                new Answer { Description = "სწორი", IsCorrect = false, QuestionId = 28},
                new Answer { Description = "არასწორია", IsCorrect = true, QuestionId = 28},
                new Answer { Description = "შეუძლიათ მხოლოს 50 ტრანზაქციამდე", IsCorrect = false, QuestionId = 28},

                new Answer { Description = "სწორია", IsCorrect = false, QuestionId = 29},
                new Answer { Description = "არასწორია", IsCorrect = false, QuestionId = 29},
                new Answer { Description = "არავინ იცის რა დაემართება ბიტკოინის ფასს", IsCorrect = true, QuestionId = 29},

                new Answer { Description = "სწორია", IsCorrect = true, QuestionId = 30},
                new Answer { Description = "არასწორია", IsCorrect = false, QuestionId = 30},
                new Answer { Description = "კრიპტოვალუტით გადახდა აკრძალულია", IsCorrect = false, QuestionId = 30},

                new Answer { Description = "Non Fungible Toke", IsCorrect = true, QuestionId = 31},
                new Answer { Description = "Natela,Fati,Tamari", IsCorrect = false, QuestionId = 31},
                new Answer { Description = "Non Feeding Telephone", IsCorrect = false, QuestionId = 31},

                new Answer { Description = "არასწორია", IsCorrect = true, QuestionId = 32},
                new Answer { Description = "სწორია", IsCorrect = false, QuestionId = 32},
                new Answer { Description = "სწორია მხოლოდ ამერიკის ბაზრისთვის", IsCorrect = false, QuestionId = 32},

                new Answer { Description = "თითოეული ტოკენი უნიკალურია და მისი სხვა ტოკენით შეცვლა არ შეიძლება", IsCorrect = true, QuestionId = 33},
                new Answer { Description = "შესაძლებელია ბიტკოინის გაყოფა", IsCorrect = false, QuestionId = 33},
                new Answer { Description = "არაფრით", IsCorrect = false, QuestionId = 33},

                new Answer { Description = "რიპლი", IsCorrect = false, QuestionId = 34},
                new Answer { Description = "ეთერიუმი", IsCorrect = true, QuestionId = 34},
                new Answer { Description = "ბიტკოინი", IsCorrect = false, QuestionId = 34},

                new Answer { Description = "ERC-721", IsCorrect = false, QuestionId = 35},
                new Answer { Description = "ERC -123", IsCorrect = true, QuestionId = 35},
                new Answer { Description = "ERC – 1050", IsCorrect = false, QuestionId = 35},

                new Answer { Description = "NFT-ით ვაჭრობას", IsCorrect = false, QuestionId = 36},
                new Answer { Description = "NFT-ის საფულეზე გადატანას", IsCorrect = false, QuestionId = 36},
                new Answer { Description = "ახალი NFT გამოცემას", IsCorrect = true, QuestionId = 36},

                new Answer { Description = "როგორც ეთერიუმი", IsCorrect = false, QuestionId = 37},
                new Answer { Description = "როგორც ბიტოკინი", IsCorrect = false, QuestionId = 37},
                new Answer { Description = "როგორც არტი", IsCorrect = true, QuestionId = 37},

                new Answer { Description = "საფულე", IsCorrect = true, QuestionId = 38},
                new Answer { Description = "ცენტრალიზებული სერვერ", IsCorrect = false, QuestionId = 38},
                new Answer { Description = "მეგობრის სახლი", IsCorrect = false, QuestionId = 38},

                new Answer { Description = "კრიპტოვალუტა", IsCorrect = false, QuestionId = 39},
                new Answer { Description = "NFT სავაჭრო პლატფორმა", IsCorrect = true, QuestionId = 39},
                new Answer { Description = "NFT-ის ბიტკოინად გადაკეთების საშუალება", IsCorrect = false, QuestionId = 39},

                new Answer { Description = "decentralized autonomous organization", IsCorrect = true, QuestionId = 40},
                new Answer { Description = "digital asset operation", IsCorrect = false, QuestionId = 40},
                new Answer { Description = "defined active omit", IsCorrect = false, QuestionId = 40},

                new Answer { Description = "Merge", IsCorrect = true, QuestionId = 41},
                new Answer { Description = "Server", IsCorrect = false, QuestionId = 41},
                new Answer { Description = "DPBingeo", IsCorrect = false, QuestionId = 41},

                new Answer { Description = "ყველაზე უსაფრთხოა", IsCorrect = false, QuestionId = 42},
                new Answer { Description = "სარისკოა", IsCorrect = true, QuestionId = 42},
                new Answer { Description = "უსაფრთხოა აშშ-ში", IsCorrect = false, QuestionId = 42},

                new Answer { Description = "კი", IsCorrect = true, QuestionId = 43},
                new Answer { Description = "არა", IsCorrect = false, QuestionId = 43},
                new Answer { Description = "კი, თუ კაპიტალი აღემატება 50 000 ლარს", IsCorrect = false, QuestionId = 43},

                new Answer { Description = "შესაძლებელია", IsCorrect = true, QuestionId = 44},
                new Answer { Description = "შეუძლებელია", IsCorrect = false, QuestionId = 44},
                new Answer { Description = "შესაძლებელია მხოლოდ ბაინანსზე", IsCorrect = false, QuestionId = 44},

                new Answer { Description = "მეტავერსი", IsCorrect = false, QuestionId = 45},
                new Answer { Description = "მოსახლეობა", IsCorrect = true, QuestionId = 45},
                new Answer { Description = "გამომშვები", IsCorrect = false, QuestionId = 45},

                new Answer { Description = "მხოლოდ ქაღალდის ბანკნოტები", IsCorrect = false, QuestionId = 46},
                new Answer { Description = "საშუალება ნივთების და მომსახურების შესაძენად", IsCorrect = true, QuestionId = 46},
                new Answer { Description = "მხოლოდ მონეტები", IsCorrect = false, QuestionId = 46},

                new Answer { Description = "ბალიშის ქვეშ", IsCorrect = false, QuestionId = 47},
                new Answer { Description = "სათამაშოების ყუთში", IsCorrect = false, QuestionId = 47},
                new Answer { Description = "ბანკში ან საფულეში ", IsCorrect = true, QuestionId = 47},

                new Answer { Description = "ფულის დახარჯვა ყველაფერზე, რაც გვინდა", IsCorrect = false, QuestionId = 48},
                new Answer { Description = "ფულის გვერდზე გადადება მომავლისთვის", IsCorrect = true, QuestionId = 48},
                new Answer { Description = "ფულის სხვებისთვის მიცემა", IsCorrect = false, QuestionId = 48},

                new Answer { Description = "დიდი ჩანთა ფულისთვის", IsCorrect = false, QuestionId = 49},
                new Answer { Description = "გეგმა, თუ როგორ დავხარჯოთ და დავზოგოთ ფული ", IsCorrect = true, QuestionId = 49},
                new Answer { Description = "ბანკის სპეციალური ანგარიში", IsCorrect = false, QuestionId = 49},

                new Answer { Description = "ასიდან ერთი ნაწილი", IsCorrect = true, QuestionId = 50},
                new Answer { Description = "ფულის დაბრუნება", IsCorrect = false, QuestionId = 50},
                new Answer { Description = "ბანკის თანამშრომელი", IsCorrect = false, QuestionId = 50},

                new Answer { Description = "ფული, რომელსაც ვხარჯავთ", IsCorrect = false, QuestionId = 51},
                new Answer { Description = "ფული, რომელსაც ვსესხულობთ", IsCorrect = false, QuestionId = 51},
                new Answer { Description = "ფული, რომელსაც ვიღებთ სამუშაოს ან ბიზნესიდან", IsCorrect = true, QuestionId = 51},

                new Answer { Description = "ფული, რომელსაც გვაძლევენ სესხად და უნდა დავაბრუნოთ", IsCorrect = true, QuestionId = 52},
                new Answer { Description = "ფული, რომელსაც ვაგროვებთ", IsCorrect = false, QuestionId = 52},
                new Answer { Description = "ფული, რომელსაც ვხარჯავთ მაღაზიაში", IsCorrect = false, QuestionId = 52},

                new Answer { Description = "როცა ფასები იზრდება და ფულის ღირებულება მცირდება ", IsCorrect = true, QuestionId = 53},
                new Answer { Description = "როცა ბანკი გვაძლევს მეტ ფულს", IsCorrect = false, QuestionId = 53},
                new Answer { Description = "როცა ვყიდულობთ აქციებს", IsCorrect = false, QuestionId = 53},

                new Answer { Description = "ადგილი, სადაც ვცვლით ძველ ნივთებს", IsCorrect = false, QuestionId = 54},
                new Answer { Description = "ბაზარი, სადაც ვყიდულობთ და ვყიდით კომპანიების წილებს", IsCorrect = true, QuestionId = 54},
                new Answer { Description = "ბანკის სპეციალური განყოფილება", IsCorrect = false, QuestionId = 54},
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