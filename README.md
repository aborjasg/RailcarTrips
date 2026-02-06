# Railcar Trips
- Author: Alex Borjas
- Date: 2026-02-06

## Instruction to run this solution

### 1. Check if LocalDB is installed
Visual Studio usually installs SQL Server Express LocalDB automatically.
Open a command prompt and run:
<pre>sqllocaldb info</pre>

### 2. Start the LocalDB instance
<pre>sqllocaldb info MSSQLLocalDB</pre>

### 3. Run EF migrations
<pre>dotnet ef database update</pre>

### 4. Clean + rebuild
<pre>
dotnet clean
<br>
dotnet build
</pre>

## Feature(s)
### Version 1.0 [2026-02-06]
- Import data about equipment, events and cities and group by trips
- List all the complete trips and discard all the uncomplete if there are missing data
- See Trip Details on a pop-up window
- Delete trips from data grid
