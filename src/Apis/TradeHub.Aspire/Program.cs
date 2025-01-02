var builder = DistributedApplication.CreateBuilder(args);

//var sqlPassword = builder.AddParameter("sql-password", secret: true);
//var TradeHubSql = builder.AddSqlServer("TradeHubSql", sqlPassword, 1433);
//var productsDb = TradeHubSql.AddDatabase("ProductsDb");

builder.AddProject<Projects.TradeHub_Api>("TradeHub-api");
    //.WithReference(productsDb);

builder.Build().Run();
