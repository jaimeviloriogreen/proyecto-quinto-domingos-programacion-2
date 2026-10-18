using QuintoProyecto.Models;

namespace QuintoProyecto.Services;

public class BookService {
  // Simula mi base de datos
  private readonly List<Book> _books = [
    new Book{
      Id = 1,
      Title = "La fiesta del chivo",
      Description = "Novela política"
    },
    new Book{
      Id = 2,
      Title = "El Maquiavelo",
      Description = "Filosofía política"
    },
    new Book{
      Id = 3,
      Title = "El hombre duplicado",
      Description = "Suspenso psicológico"
    }
  ];

  public List<Book> FindAll() {
    return _books;
  }
}