                            Setting Up an MSSQL Database for HRAS Project
         (***   These instructions are subject to change as the project is being developed!!!! ***)


Introduction
-This guide provides instructions for setting up an MSSQL database for the HRAS project. 
It assumes that you have already installed an MSSQL Server and have administrative access to create a database.

Prerequisites:

    1) MSSQL Server installed and running.
    2) Administrative access to create and modify a database.

Required Setup Instructions (on a local machine):

    Create a Database using MSSQL SSMS:
    1) Open MSSQL Server Management Studio and connect to the server.
    2) In the Object Explorer, expand the server instance and right-click on "Databases".
    3) Select "New Database" and enter a name for the new database.
    4) Configure any additional options as needed, such as data and log file locations and sizes.
    5) Click "OK" to create the database. 
       Move to Step 6.

    - OR -

    Create a Database using Visual Studio:
    1) Click on the 'SQL' menu in the Visual Studio's main toolbar. The 'Connect' window will appear. 
    2) Clock on 'Connect' in the 'Connection' sub-menu.
    3) Click on the 'Local' dropdown menu.
    4) Choose the server you want to work with (the one created for this project).
    5) Choose the authentication type. Insert the User Name and Password if the authentication requires so.
    6) In the 'Database Name' dropdown menu choose the database you want to work with.
    7) Click 'Connect'.
       Move to Step 6.


    6) Open the DatabaseSetup.sql file located in "HRAS_2023\Database\" folder.
    7) Enable SQLCMD mode by clicking on the "SQLCMD Mode" button in the toolbar.
       The "SQLCMD Mode" button is usually located on the rightmost side of the SQL Editor Toolbar.
       Visual Studio might highlight all the lines that start with ':r' command to show that these are SQLCMD commands.
    8) Select lines 1 through 14.
    9) Click 'Execute' button on the upper leftmost side of the SQL Editor Toolbar. The 'Execute' button looks 
       like a green triangle. 
       You can execute all the SQLCMD script by pressing CTRL+SHIFT+E.
    10) Select line 15 and click execute.

    If at this point the 'Connect' window appears, then the DatabaseSetup.sql file requires additional connection,
    even though your SQL Server Explorer is connected. Follow these steps:
    
    1) Click on the 'Local' dropdown menu.
    2) Choose the server you want to work with (the one created for this project).
    3) Choose the authentication type. Insert the User Name and Password if the authentication requires so.
    4) In the 'Database Name' dropdown menu choose the database you want to work with.
    5) Click 'Connect'.

Data Population
    1) Navigate to the 'HRAS_DataPopulation' project in the HRAS_2023 Solution
    2) Right click on the HRAS_2023.csproj file and click 'Set As Startup Project'
    3) Open the 'DataPopulate.cs' file
    4) Set up your connection string as a string value for 'connectionString' variable in the 'Main' method. 
    5) Run the project by clicking on the Run button

This will populate the 'Staff' table for testing purposes for the Beta Release.

Usage:
    
    This setup allows the HRAS project to have all the necessary components for it to function.
    You can connect to the database using an appropriate client such as SQL Server Management Studio, 
    or using code that accesses the database programmatically.

Troubleshooting:

    If you encounter any issues during the setup process, refer to the MSSQL Server documentation 
    or seek assistance from your database administrator or SuperSoft Development Team. 

Conclusion:

    Congratulations, you have successfully set up an MSSQL database for the HRAS Project! 