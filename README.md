# Cryptocurrency Exchange - .NET 6 API & WinForms & Flutter 

This is cryptocurrency exchange platform containing flutter mobile app for traders to buy/sell crypto assets and desktop WinForms app for management, supervision and reporting.

The communication goes over http protocol and the request handles .NET 6 API with layered architecture using repository pattern and SOLID principles.

![bubble](https://user-images.githubusercontent.com/45321513/193417642-0d704938-baa5-4b3a-99a5-55f6058444a0.jpg)

## Project consists of

- .NET 6 API 
  - N-tier architecture
  - REST API principles, CRUD operations
  - SqlServer database persistance
  - Using Entity Framework Core ORM (Migrate and seed data on startup)
  - Repository Pattern Implementation with SOLID principles
  - Deployed and available through Swagger Open API specification :
    - https://rs2seminarski.herokuapp.com/swagger (Heroku deployment)
    - https://rs2.p2098.app.fit.ba/swagger (Plesk deployment)
  - JWT user authorization (checking client, scope, role and permissions for access)
  - Containerization of API and SqlServer database using Docker 
 
- WinForms Desktop Management Application

  - Reporting on managment desktop
  - Supervision and management of users
  - Supervision and management of order book
    
- Flutter Mobile Client Application
  - Cryptocurrency offer personalization and recommanding (using CBF - Content-Based filttering algorithm)
  - User verification on registartion with backand generated user code 
  - Owning crypto wallet
  - Depositing/Withdrawing assets
  - Buying/Selling cryptocurrencies
  - Cryptocurrency stats for useful insight 
  
  

