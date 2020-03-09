GUIDE:

1) Preinstall: .NET 3.1 SDK/Runtime + database MSSQL (tested on 2017)

Running API 
1) Open SimpleWeb.API and go to appsettings.json
2) Edit connection string for your database parameters. If DB user has permission to create database and tables only what you had to do is run the application

Importing tests on Postman:
1) Open Postman. Go to: File -> Import
2) Select/drop file: .\SimpleWeb.Tests\SimpleWebApi.tests.json 

Running Angular Single-Page-Application (SPA) (you have to install node.js: https://nodejs.org/en/)
1) Navigate to SPA folder and install npm packages: npm install
2) Run Angular application: ng serve

Troubleshooting:
1) if your API is not running by default on localhost:3000 - go for 
.\SimpleWebSPA\src\environments and set there URL to your API address.
