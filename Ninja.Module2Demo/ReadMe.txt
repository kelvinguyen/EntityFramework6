Step 1 : create a model classes in NinjaDomain.Classes
Step 2 : create DBContext in NinjaDomain.DataModel
			- install entity framework 6 using nuget package manager or cmd: Install-Package entity framework
			- install entity framework powers tool using http://bit.ly/EFPTVS2015
Step 3 : Data Migration : update database schema as the model change
			- enable migration using PM> enable-migrations
			- Let migration create database using PM> add-migration NameOFMigration(initialMigrate)
			- Let migration change the database using PM> update-database -script (for sql script) or -verbose(create database)

Step 4 : Change model logic and need to update database
			- PM> add-migration NameOfMigration
			- PM> update-database -verbose