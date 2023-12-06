# Artworkia Web Api - Capstone Project
PLEASE READ THIS FILE CAREFULLY!
## EF migration code first
- To apply the latest migrations to your physical database, run this command(run the command from <strong>artworkia-web-api\src folder</strong>)
```
dotnet ef database update -s WebApi -p Migrators.MSSQL
```
Example:
![](./screenshots/Screenshot%202023-12-06%20183420.png)
- To add new migrations, run this command(run the command from <strong>artworkia-web-api\src folder</strong>)
```
dotnet ef migrations add MigrationName -s WebApi -p Migrators.MSSQL
```
Example:
![](./screenshots/Screenshot%202023-12-06%20232425.png)
## Branch convention
- For every new function, you must create a new branch, then invite other members to review your code in Git Hub, when that branch merged successfully, you can delete it and continue to create a new branch based on main for other functions.
- **Can not push code directly to the main branch**
- When you create a new branch, it must be based on the **main branch** and follow this naming convention:
**"YourName_FunctionName"**
## Commit naming convention
When you add a new commit, it must follow this naming convention:
**"[YourName][Action description]"**
## Pull request convention
You must create a pull request before your code is merged into main. The pull request must be followed this naming convention:
**"[YourName][YourFunction]"**
## Capstone project
- Back-end
1. Vo Ngoc Truc Lam
2. Huynh Van Phu
- Front-end
3. Nguyen Trung Thong
4. Dang Hoang Anh
