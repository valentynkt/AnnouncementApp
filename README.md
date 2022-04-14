# AnnouncementApp
It is my test project for NerdySoft company.
First of all, I want to say that I have added some additional features and I tried to make this project scalable and easy to add new functionality.Moreover,I made 3-layered architecture which is not needed in this project and of course, I could make it easier but I just tried to show my skills and knowledge of different technologies, to make it easier for you to evaluate me. 
Backend(.NET 6 Web Api):
As I noticed before I made 3-layered architecture in Backend(DAL,BL,PL).In DAL I used Repository pattern realized by UnitOfWork concept.I was using interfaces for every repository and also I have 1 main interface which was inhereted by other repository interfaces.Also I have BaseEntity and interface IEntity.
Code-First approach(EFCore),MSSQL,Dependency Injection configured in PL Program.cs
In BL I have services for Announcement and interfaces with one main service and I threw exceptions in methods and caught them in Controller.Furthermore I have extensions methods.
In PL I configured Serilog and used it in Controllers for easy debugging.Serilog creates 2 log files one for debug level and and another for warning level(logs contain methods name and line of code).Configured SwaggerUI for testing Web Api.Additional method GetByTitle
Unit-Tests:NUnit for testing DAL level and MOQ.
Frontend(React):
I used axios to make HTTP requests,React Hooks(useState,useEffect,useParams,useNavigate),react-router-dom.
Also I used Bootstrap 5 and Materil Ui componets to save time styling layout.
