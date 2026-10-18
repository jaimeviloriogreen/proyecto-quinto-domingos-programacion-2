using QuintoProyecto.Services;
using Spectre.Console;

// bool running = true;

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

  var bookService = new BookService();

  switch (option) {
    case "1. Agregar un libro":
      Console.WriteLine("Agregando un libro");
      break;
    case "2. Eliminar un libro":
      Console.WriteLine("Eliminando un libro");
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

      var books = bookService.FindAll();

      foreach (var book in books) {
        table.AddRow(book.Id.ToString(), book.Title, book.Description);
      }

      AnsiConsole.Write(table);
      break;
    case "4. Salir":
      AnsiConsole.Clear();
      AnsiConsole.MarkupLine("[green]Fin de la aplicación.[/]");
      // running = false;
      // break;
      return;
  }
}
