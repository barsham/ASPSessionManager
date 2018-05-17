# Legacy Session Manager
A COM+ .NET DLL that provides cross site Session Management for ASP Classic and ASP.NET over Load Balancer

# Installation:

ASP Classic
----------------------------------------------
	1- Register the "LegacySessionManager" under "Administrative Tools"->"Component Services".
		1-1- Copy "LegacySessionManager.dll" and "LegacySessionManager.dll.config" to a {your_folder_name} folder on the Server which ASP site has access.
		1-2- Under "Console Root" -> Computers -> My Computer -> COM+ Applications -> Right Click and "New" -> "Application"
		1-3- Select "Create an empty Application". Use "Legacy Session Manager" as Name and Select "Library application" and Click "Next" & "Finish"
		1-4- Right click under "Legacy Session Manager"->"Compontents" and select "New"->"Component".
		1-5- Select "Install new component(s)" and select "LegacySessionManager.dll" from {your_folder_name} folder, and Click "Next" & "Finish"
		
	2- Add "globalInclude.asp" to your ASP project.
	3- Add "LegacySessionManager.dll.config" to your ASP project.
	4- Use "<!-- #include file=globalinclude.asp -->" in the beginning of each ASP Classic Page.
	5- Make sure you provided proper use account under App Pool to autherize database connection

ASP.NET
----------------------------------------------
	1- Add a reference to "LegacySessionManager.dll" in your project.
	2- Add "LegacySessionManager.dll.config" to your project. 
	3- Make sure all of your ASP.NET pages inherits from SessionPage
			Inherits="LegacySessionManager.SessionPage"
	4- Make sure your ASP.NET application runs under 32bit architecture.
	5- Make sure you provided proper user account under App Pool to autherize database connection
  
SQL Server (Or other databases)
----------------------------------------------
 1- Make sure both ASP and ASP.NET machines has access to SQL Server
 2- Update the SQL Server connection string in the LegacySessionManager.dll.config file.
