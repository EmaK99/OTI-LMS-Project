Firstly, create the database using the SQL Query code provided inside the DB folder. (If using SSMS and encountering a network issue while connecting to the server, it may be resolved by adding "Encrypt=False" to the text box available upon clicking "Additional Connection Parameters" tab on the "Connect to Server" window.)

Then launch the project on Visual Studio and make the necessary changes to the connection string (the server name, database name, connection type and password if needed). 

Following this, using the Tools option in VS, connect to the database as normal. 

The Default.aspx file should be set as the start page so the project can launch as intended.

The admin username and password is 'admin' for both (it is encoded and cannot be changed through the LMS itself).