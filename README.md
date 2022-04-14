# AnnouncementApi
It is my test project for NerdySoft company.
First of all i want to say that I add some additional features and tried to made this project scalable and easy to add new functionality thats why i made 3-layered architecture which is not extremly needed  in this project and it could be done more easily.I just tried to show my skills and knowledge of different technologies so you can easily estimate me.
Backend(.NET 6 Web Api):
As i noticed before i made 3-layered architecture in Backend(DAL,BL,PL).In DAL i used Repository pattern realized by UnitOfWork concept.I was using interfaces for every repository and also i have 1 main interface which was inhereted by other repository interfaces.Also i have BaseEntity and interface IEntity.
Code-First approach(EFCore),MSSQL,Dependency Injection configured in PL Program.cs
In BL i have services for Announcement and interfaces with one main service and i threw exceptions in methods and caught them in Controller.Also i have extensions methods.
In PL i configured Serilog and used it in Controllers for easy debugging.Serilog creates 2 log files one for debug level and and another for warning level(logs contain methods name and line of code).Configured SwaggerUI for testing Web Api.Additional method GetByTitle
Unit-Tests:NUnit for testing DAL level and MOQ.
Frontend(React):
I used axios to make HTTP requests,React Hooks(useState,useEffect,useParams,useNavigate),react-router-dom.
Also i used Bootstrap 5 and Materil Ui componets to save time styling layout.
