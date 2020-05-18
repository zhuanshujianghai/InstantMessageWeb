/*必须的包*/
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
/*说明文档*/
https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell
/*自动生成实体类*/
Scaffold-DbContext -Connection "server=.;uid=sa;pwd=123456;database=InstantMessageDB;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir InstantMessageDB -context ImDbContext -Project InstantMessage.DataModel -force