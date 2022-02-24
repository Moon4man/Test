           
                       		 The File Storage
                       		 ----------------

To log in to the application, you must enter in the command line:
FileStorage.exe -l "login" -p "password"

--------------------------------
Login: SomeUser
Password: MyLittlePony45
--------------------------------

To work correctly, you need to change the path to the metafile 
and storage in app.config!

Max file size - 150 MB


Commands:

- info user 
(Get user information)
- file upload <path-to-file> 
(Upload file to the storage)
- file download <file-name> <destination-path> 
(Download file to the storage)
- file move <source-file-name> <destination-file-name> 
(Rename file in the storage)
- file remove <file-name> 
(Delete file from storage)
- file info <file-name> 
(Get file information)
- file find <file-name> 
(Find file in the storage)
- file export <destination-path> --format <format> 
(Saving meta information about files in a specified format)
- file export --info 
(Displaying a list of supported formats)
- app exit
(Allows to exit the application)


The following NuGet packages are used in the application:

- System.Configuration.ConfigurationManager (To work with the configuration file)
- Newtonsoft.Json (To format a binary metafile in Json format)