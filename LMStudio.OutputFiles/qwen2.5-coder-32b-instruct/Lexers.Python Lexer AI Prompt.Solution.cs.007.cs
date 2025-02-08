var lexer = new Lexer("x = 5");
var parser = new Parser(lexer);
var ast = parser.Parse();
var printer = new PrettyPrinter(ast);
printer.Print();