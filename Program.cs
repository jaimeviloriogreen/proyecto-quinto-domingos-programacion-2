using QuintoProyecto.Models;
using QuintoProyecto.Services;
using Spectre.Console;

BookService bookService = new();

string[] options = [
  "1. Agregar un libro",
      "2. Eliminar un libro",
      "3. Mostrar todos los libros",
      "4. Salir"
  ];

while (true) {
  var selections = new SelectionPrompt<string>()
    .Title("Indica la opción a seleccionar: ")
    .HighlightStyle(Color.GreenYellow)
    .AddChoices(options)
    .WrapAround();

  var option = AnsiConsole.Prompt(selections);

  List<Book> books = bookService.FindAll();

  switch (option) {
    case "1. Agregar un libro":
      AnsiConsole.Clear();

      var title = AnsiConsole.Ask<string>("[DarkGoldenrod]Indica el título del libro:[/]");
      var description = AnsiConsole.Ask<string>("[DarkGoldenrod]Indica la descripción del libro:[/]");

      var Ids = books.Max(book => book.Id);

      var newBook = new Book {
        Id = Ids + 1,
        Title = title,
        Description = description
      };

      bookService.Create(newBook);
      AnsiConsole.Clear();
      AnsiConsole.MarkupLine("\n[Green]Libro agregado.[/]\n");

      break;
    case "2. Eliminar un libro":
      AnsiConsole.Clear();
      var id = AnsiConsole.Ask<int>("Indica el id del libro a eliminar:");
      AnsiConsole.WriteLine("");

      var confirm = AnsiConsole.Confirm("¿Estás seguro que deseas eliminarlo?:");

      if (confirm) {
        var deleted = bookService.Delete(id);

        if (deleted) {
          AnsiConsole.MarkupLine("\n[green]!Libro eliminado![/]\n");
          break;
        }

        AnsiConsole.MarkupLine("\n[red]¡Libro no encontrado![/]\n");
        break;
      }

      AnsiConsole.MarkupLine("\n[red]Operación cancelada[/]\n");

      break;
    case "3. Mostrar todos los libros":
      AnsiConsole.Clear();

      var table = new Table()
        .Title("Lista de mis libros")
        .BorderColor(Color.Yellow)
        .RoundedBorder(); // .ShowRowSeparators()

      table.AddColumn("Id");
      table.AddColumn("Título");
      table.AddColumn("Descripción");

      foreach (var book in books) {
        table.AddRow(book.Id.ToString(), book.Title, book.Description);
      }

      AnsiConsole.Write(table);
      break;
    case "4. Salir":
      AnsiConsole.Clear();
      AnsiConsole.MarkupLine("[green]Fin de la aplicación.[/]");

      return;

  }
}