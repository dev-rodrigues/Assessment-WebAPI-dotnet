using CORE.Models;
using DATA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace API.Models.Input {
    public class InputBookModel {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }

        public int IdAuthor { get; set; }

        public static Book Create(InputBookModel input, Author author) {
            var books_authors = new Collection<BookAuthor>();

            var new_book = new Book() {
                Title = input.Title,
                ISBN = input.ISBN,
                Year = input.Year,
            };

            var book_author = new BookAuthor() {
                Author = author,
                Book = new_book
            };

            books_authors.Add(book_author);

            new_book.BookAuthors.Add(book_author);

            return new_book;
        }

        public static Book UpdateBook(InputBookModel input, Book book) {
            book.Title = input.Title;
            book.ISBN = input.ISBN;
            book.Year = input.Year;
            return book;
        }
    }
}