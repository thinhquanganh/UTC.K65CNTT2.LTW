using System.Collections.Generic;
using System.Linq;

namespace TqaLesson04.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public int TotalPages { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public List<Book> GetBookList()
        {
            return new List<Book>
            {
                new Book {
                    Id = 1,
                    Title = "Chí Phèo",
                    Author = "Nam Cao",
                    Genre = "Văn học",
                    AuthorId = 1,
                    GenreId = 1,
                    Price = 500000,
                    TotalPages = 300,
                    Image = "/images/chipheo.jpg",
                    Description = "Tác phẩm kinh điển của nhà văn Nam Cao."
                },
                new Book {
                    Id = 2,
                    Title = "Lão Hạc",
                    Author = "Nam Cao",
                    Genre = "Văn học",
                    AuthorId = 1,
                    GenreId = 1,
                    Price = 700000,
                    TotalPages = 400,
                    Image = "/images/laohac.jpg",
                    Description = "Truyện ngắn xuất sắc về người nông dân Việt Nam."
                },
                new Book {
                    Id = 3,
                    Title = "Thám tử lừng danh Conan",
                    Author = "Gosho Aoyama",
                    Genre = "Truyện tranh",
                    AuthorId = 2,
                    GenreId = 2,
                    Price = 25000,
                    TotalPages = 180,
                    Image = "/images/conan.jpg",
                    Description = "Bộ truyện tranh trinh thám nổi tiếng Nhật Bản."
                },
                new Book {
                    Id = 4,
                    Title = "Đường xưa mây trắng",
                    Author = "Thích Nhất Hạnh",
                    Genre = "Tôn giáo",
                    AuthorId = 3,
                    GenreId = 3,
                    Price = 120000,
                    TotalPages = 500,
                    Image = "/images/duongxua.jpg",
                    Description = "Cuộc đời của Đức Phật qua góc nhìn thiền sư."
                }
            };
        }
        public Book GetBookById(int id)
        {
            return GetBookList().FirstOrDefault(b => b.Id == id);
        }
    }
}