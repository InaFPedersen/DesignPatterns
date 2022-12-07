using Strategy;

var order = new Order("Marvin Software", 5, "Visual Studio License"); //Quick action to insert using statement.
order.Export(new CSVExportService());

order.Export(new JSONExportService());

order.Export(new XMLExportService());

Console.ReadKey();
