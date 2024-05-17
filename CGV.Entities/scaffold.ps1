$dataSource = "localhost";
$initialCatalog = "cgv_clone_db";
$userId = "postgres";
$password = "naeL0821";
$provider = "Npgsql.EntityFrameworkCore.PostgreSQL";
$entityFolderPath = "../CGV.Entities/Entities";

$connectionString = "Host=$($dataSource); Database=$($initialCatalog); Username=$($userId); Password=$($password);";
$dbContextName = "CinemaDbContext";

Set-Location "Entities";
Remove-Item *.cs;
Set-Location ../../CGV.WebApi

$command = "dotnet ef dbcontext scaffold ""$connectionString"" $provider -d -f --namespace CGV.Entities -c $dbContextName -v -o $entityFolderPath"

Invoke-Expression "$command";