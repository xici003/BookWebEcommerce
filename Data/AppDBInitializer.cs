using BookWebEcommerce.Data;
using BookWebEcommerce.Data.Enum;
using BookWebEcommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace BookWebEcommerce.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Database

                //Author
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            ProfilePictureURL = "https://danbrown.com/wp-content/themes/danbrown/images/db/slideshow/author/db.courter.01.jpg",
                            FullName = "Dan Brown",
                            Bio = "Dan Brown is a famous American writer known for his novels that combine mystery, history, and cryptography"
                        },
                        new Author()
                        {
                            ProfilePictureURL = "https://www.washingtonpost.com/blogs/style-blog/files/2015/02/77695641.jpg",
                            FullName = "Harper Lee",
                            Bio = "Harper Lee was an American author best known for her novel such as To Kill a Mockingbird."
                        },
                        new Author()
                        {
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/d/de/Nguy%E1%BB%85n_Nh%E1%BA%ADt_%C3%81nh.jpg",
                            FullName = "Nguyen Nhat Anh",
                            Bio = "Nguyễn Nhat Anh is a famous Vietnamese writer."
                        },
                        new Author()
                        {
                            ProfilePictureURL = "https://trangtrinhtham.files.wordpress.com/2018/04/keigo-higashino.jpeg",
                            FullName = "Higashino Keigo",
                            Bio = "Keigo Higashino is a Japanese author known for his crime and mystery novels. "
                        },

                    });
                    context.SaveChanges();
                }

                //Publisher
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            Logo = "https://static.ybox.vn/2020/10/2/1602555544371-c63df2a6-254e-11e8-a611-cac091044fd5.jpg",
                            Name = "Kim Dong Publishing House",
                            Description = "Established in 1957, has become one of the leading entities in the field of children's book publishing in Vietnam."
                        },
                        new Publisher()
                        {
                            Logo = "https://static.ybox.vn/2020/2/6/1582344898530-1582276635522-1561977250696-Nh%C3%A3%20Nam.jpg",
                            Name = "Nha Nam Publishing House",
                            Description = "Nha Nam Publishing was established in 2005"
                        },
                        new Publisher()
                        {
                            Logo = "https://shoptretho.com.vn/upload/image/provider/20131127/logo-nxb-ldxh.jpg",
                            Name = "Lao Dong Publishing House",
                            Description = "Established in 1957"
                        },
                        new Publisher()
                        {
                            Logo = "https://salt.tikicdn.com/cache/w220/ts/seller/12/4b/35/3b3513eebe81c2c5569a7e1ea41d28ec.jpg",
                            Name = "Tre Publishing House",
                            Description = "Established in 1981"
                        },
                    });
                    context.SaveChanges();
                }

                //Translator
                if (!context.Translators.Any())
                {
                    context.Translators.AddRange(new List<Translator>()
                    {
                        new Translator()
                        {
                            Bio = "https://3.bp.blogspot.com/-o0N1Uh5GbZ0/Vt-iG8-NEBI/AAAAAAACFfE/VgyiakatrdM/w271-h320/3.jpg",
                            Name = "Pham Viem Phuong",
                            Age =  60,
                            Nationality = "Viet Nam",
                            Genre = "To Kill a Mockingbird,..."
                        },
                        new Translator()
                        {
                            Bio = "https://images2.thanhnien.vn/Uploaded/bichhanh/2021_06_14/dichgianguyenxuanhong_RCUL.jpeg?width=500",
                            Name = "Nguyen Xuan Hong",
                            Age =  54,
                            Nationality = "Viet Nam",
                            Genre = "The Da Vinci Code, Inferno, ..."
                        },
                        new Translator()
                        {
                            Bio = "https://file1.hutech.edu.vn/file/editor/homepage/stories/hinh208-fdg/ts-le-tham-duong-2015-ohay-tv-29690.png",
                            Name = "Le Tham Duong",
                            Age =  54,
                            Nationality = "Viet Nam",
                            Genre = "Adults are people who know fear,...."
                        },
                    }); ;
                    context.SaveChanges();
                }

                //Book
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            ImageURL = "https://upload.wikimedia.org/wikipedia/vi/8/84/M%E1%BA%ADt_m%C3%A3_davinci.jpg",
                            Name = "The Da Vinci Code",
                            Description = "Collection of detective, thriller and conspiracy fiction genres",
                            Price = 20.50,
                            Category = BookCategory.Detective,
                            AuthorId = 1,
                            PublisherId = 2,
                            TranslatorId = 2,
                        },
                        new Book()
                        {
                            ImageURL = "https://salt.tikicdn.com/cache/w1200/ts/product/ea/57/9e/71ddae5c7ce50ab004c810849637576c.jpg",
                            Name = "To Kill a Mockingbird",
                            Description = "This is a very popular novel, one of the best-selling in the world with more than 10 million copies",
                            Price = 10.35,
                            Category = BookCategory.Romance,
                            AuthorId = 2,
                            PublisherId = 1,
                            TranslatorId = 1,
                        },
                        new Book()
                        {
                            ImageURL = "https://nhungcuonsachhay.com/wp-content/uploads/2021/10/Doan-Thu-Trang-Review-sach-Bi-Mat-Cua-Naoko-Higashino-Keigo.jpg",
                            Name = "Secrets of Naoko",
                            Description = "The novel won the 52nd Japan Detective Story Author Award",
                            Price = 15.50,
                            Category = BookCategory.Horror,
                            AuthorId = 4,
                            PublisherId = 4,
                            TranslatorId = 1,
                        },
                    });
                    context.SaveChanges();
                }

            }
        }
	

	}
}
