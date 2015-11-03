���W��Git�ɮצ]���e�q���D�A�R��[project]/packages�B[project]/[subproject]/bin�B[project]/[subproject]/obj�A�H�W�ɮק��|��M�׽sĶ�᭫�ءC

0. MVC

MVC stands for model-view-controller.  MVC is a pattern for developing applications that are well architected, testable  and easy to maintain. MVC-based applications contain:

Models: Classes that represent the data of the application  and that use validation logic to enforce business rules for that data.
Views: Template files that your application uses to dynamically  generate HTML responses.
Controllers: Classes that handle incoming browser requests,  retrieve model data, and then specify view templates that return a response  to the browser.

0-1.Controller
http://www.asp.net/mvc/overview/getting-started/introduction/adding-a-controller

��Notice in Solution Explorer that a new file has been created named HelloWorldController.cs and a new folder Views\HelloWorld. The controller is open in the IDE.
��g��IDE���ͱ�����P�ɡA�|���͹�����View�ɮק��C

ASP.NET MVC invokes different controller classes (and different action methods within  them) depending on the incoming URL. The default URL routing logic used by ASP.NET MVC uses a format like this to determine what code to invoke:

/[Controller]/[ActionName]/[Parameters]

Controller �۷��HRESTful WebAPI�Φ��إߤF�l�\��F��URL�榡�� /[Controller]/[ActionName]/[Parameters]
�Ҧp�GHelloWorld Controller Class�A��Index method����http://xxxx/HelloWorld/�AOther method����http://xxx/HelloWorld/Other�C

�M�׹w�]�A��URL�����ѥ���l�q�A�������l�q�h��App_Start/RouteConfig.cs�]�w���ѡF�]���A�Y�n�ק�w�]�l�q�h�󦹳]�w�C
��ƶǤJ�W�A�i�H�ϥ�query strings�A�Ҧp�G?name=xx&id=yy�A�h�������\�઺��ƿ�J function( string name, int id )�Y�i����ǤJ�ȡC
�t�~�i�ιBWebAPI�\��A�bRouteMap���]�w�����l�q����S�w�ѼơA�Y�ѼƤ����h��Hquery string�ɨ��C

���Y�s�b�@��ơA��W��Welcome�A�h
http://xxxx/HelloWorld/Welcome�A����Welcome���
http://xxxx/HelloWorld/Welcome/5�A����Welcome��ƨðe�J�Ѽ�5

�Ѽƹ����Ѧ�RouteMap�A�Y�]�w��{controller}/{action}/{name}/{id}�A�h��ƹ�����ACTION ( string NAME, int ID)�C
���`�N�A���׬ORouteMap��query strings�A�u�n�r�Ź�A���פj�p�g�ҥi�C


0-2.View
http://www.asp.net/mvc/overview/getting-started/introduction/adding-a-view

* Architecture :
View.XXX.cshtml
- Layout = "~/Views/Shared/_Layout.cshtml"
	- XXX page layout 
	- Navbar : Html.ActionLink, Add <a> element ActionLink( "LinkText", "ActionName", "ControllerName", routeValue = null, htmlAttribute = null )
		Ref : https://msdn.microsoft.com/en-us/library/dd504972(v=vs.108).aspx
	- MainContent : RenderBody is a placeholder where all the view-specific pages you create show up, "wrapped" in the layout page. 
		For example, if you select the About link, the Views\Home\About.cshtml view is rendered inside the RenderBody  method.
	- Script.Render and Styles.Render, Reander link tag for script or style.
		Ref : https://msdn.microsoft.com/en-us/library/system.web.optimization.scripts(v=vs.110).aspx
		Ref : https://msdn.microsoft.com/en-us/library/system.web.optimization.styles(v=vs.110).aspx
*


Ref�GWeb.MVC.Html document, https://msdn.microsoft.com/en-us/library/system.web.mvc.html(v=vs.108).aspx

0.3 Model

1. Create Model
http://www.asp.net/mvc/overview/getting-started/introduction/adding-a-model
Ref�G�إߪ���ҫ�, https://msdn.microsoft.com/zh-tw/library/bb546174(v=vs.110).aspx

���d�ҩһݬ�ASP.NET 5�PEntity Framework 5�A�з�.NET 4.5�èS���A�ݶ}�ұM�׫��sFramework�C
Ref�GEntity Framework, https://msdn.microsoft.com/en-us/library/gg696172(VS.103).aspx
Ref�GEntity Framework Development Workflows, https://msdn.microsoft.com/zh-tw/data/jj590134

�ҫ��ݩʨϥΡG
�Q�μҫ��ݩʨӳ]�w��Ʈw��T������T�A�Ѧp��Ʈw�B��W�١A���]�w�A�w�s�]�w�C
Ref�GLINQ to SQL: .NET Language-Integrated Query for Relational Data #Entity Classes In-Depth , https://msdn.microsoft.com/library/bb425822.aspx#linqtosql_topic22
Ref�Ghttps://msdn.microsoft.com/zh-tw/library/bb386971(v=vs.110).aspx

�B�~�Ѿ\�G
Introducing LocalDB, an improved SQL Express
http://blogs.msdn.com/b/sqlexpress/archive/2011/07/12/introducing-localdb-a-better-sql-express.aspx

2. Create Connection String
http://www.asp.net/mvc/overview/getting-started/introduction/creating-a-connection-string
Ref�G��Ʈw�q�T, https://msdn.microsoft.com/zh-tw/library/bb882660(v=vs.110).aspx

�B�~�Ѿ\�G
SQL Server Connection Strings for ASP.NET Web Applications
https://msdn.microsoft.com/en-us/library/jj653752.aspx

3. Create Controller
http://www.asp.net/mvc/overview/getting-started/introduction/accessing-your-models-data-from-a-controller

���d���y����
Model : [ValidateAntiForgeryToken],  The attribute is used to prevent forgery of a request and is paired up with @Html.AntiForgeryToken() in the edit view 
View : @Html.AntiForgeryToken(), generates a hidden form anti-forgery token that must match in the Edit method of the Movies controller.

As soon as the client side validation determines the values of a field are not valid, an error message is displayed. If you disable JavaScript, you won't have client side validation but the server will detect the posted values are not valid, and the form values will be redisplayed with error messages.

Don��t use Delete Links because they create Security Holes. 
http://stephenwalther.com/archive/2009/01/21/asp-net-mvc-tip-46-ndash-donrsquot-use-delete-links-because

4. Search Data
http://www.asp.net/mvc/overview/getting-started/introduction/adding-search

�����Ʈw�s����ݨϥ�LINQ expressions�PLambda expressions�A��ާ@�d�ҰѦ�0.4 LINQ�B0.5 Lambda

LINQ����ɾ��A�����������(Deferred)�B�ߧY(Immediate)�A���צ�خɾ��A��B�椺�e�|�NLINQ�B�⦡�ഫ��������Ʒ�(���x����(Collections)�ASQL��Ʈw���A�AADO.NET��ƶ��AXML���)�i��ڰ��檺�B�⦡�C

�yLINQ to SQL does not actually execute queries; the relational database does.
LINQ to SQL translates the queries you wrote into equivalent SQL queries and sends them to the server for processing. 
Therefore the queries you write must be translated into equivalent operations and functions that are available inside the SQL environment.�z

Ref�GQuery Execution, https://msdn.microsoft.com/en-us/library/bb738633.aspx

�۹����Ω�SQL Server�ѦҤ��m�p�U�C�G

Ref�GLINQ to SQL: .NET Language-Integrated Query for Relational Data, https://msdn.microsoft.com/library/bb425822.aspx
Ref�GLINQ to SQL [LINQ to SQL], https://msdn.microsoft.com/zh-tw/library/bb386976(v=vs.110).aspx
Ref�G�d�߸�Ʈw, https://msdn.microsoft.com/zh-tw/library/bb882680(v=vs.110).aspx 
Ref�G�w�s�{��, https://msdn.microsoft.com/zh-tw/library/bb386946(v=vs.110).aspx

�B��LINQ�B�⦡�i�H�i���Ʈw�ާ@�A����i�ϥ�ExecuteCommand�BExecuteQuery�����U�FSQL�ΩI�s�w�s�{��(Stored Procedure)�C
���`�N�A�w�s�{�ǨϥΤW�覡�󤣦P������ExecuteCommand�BExecuteMethodCall��ءA��ϥήt���P�覡���ݪ`�N�C

�B�~�Ѿ\�G
Cross-site request :
http://www.asp.net/mvc/overview/security/xsrfcsrf-prevention-in-aspnet-mvc-and-web-pages

5. Adding a New Field
http://www.asp.net/mvc/overview/getting-started/introduction/adding-a-new-field

���Ʈw�g��Model�����A�Y�q���W�[�@���|�ɭP��Ʈw�P�B���~�A�bASP.NET MVC���H�U�覡�G
1. ���ظ�Ʈw�A�g�Ѽзǵ{�ǭ��s���͸�Ʈw�A�����w�g���e�j��ƪ���Ʈw�ä���ڡC
2. �ק��Ʈw�[�c�A���~����Ʈw�����ϥθ�Ʈw�u��W�����A�H�T�O�P�ҫ����e�ۦP�C
3. �u��A�ϥ�Code First Migrations������Ʈw�[�c�C

6. Adding Validation
http://www.asp.net/mvc/overview/getting-started/introduction/adding-validation

�Ѧ�1.�ҫ��ݩʨϥΡA�ϥ��ݩʳ]�w���������w�]�ȡA�Ѧp���i���šB�Ȱ�d�򵥡C

0.4 LINQ

LINQ (Language-Integrated Query)
https://msdn.microsoft.com/en-us/library/bb397926.aspx

LINQ Query Expressions (C# Programming Guide)
https://msdn.microsoft.com/en-us/library/bb397676.aspx

Visual Studio includes LINQ provider assemblies that enable the use of LINQ with .NET Framework collections, SQL Server databases, ADO.NET Datasets, and XML documents.
Visual Studio�]�ALINQY�ե�A��ϥΩ�.NET�ج[�����x����(Collections)�ASQL��Ʈw���A�AADO.NET��ƶ��AXML���C

�ǲΤW�A�w�藍�P��ƨt�Ψ�Query�榡�ä��ۦP�A�惡Visual Studio��2008�ᴣ��LINQ�A���}�o�̥i�H�βΤ@���榡��XML���B��Ʈw�B�~��IEnumerable����i��߰ݡC

�q�����[�I�ӬݡA��Ʒ��Y�����c�P���A�ä����n�A�b�{������Ʒ����O��IEnumerable<T>��IQueryable<T>���õۡC
LINQ�Ω�XML���A��ƫ��A��IEnumerable<XElement>�C
LINQ�Ω��ƶ��A��ƫ��A��IEnumerable<DataRow>�C
LINQ�Ω�SQL�A��ƫ��A���ϥΪ̩w�q��SQL��Ʈw���q���۩w����A�������é�IEnumerable<T>��IQueryable<T>�C

LINQ�B�⦡�w�q�ɨä��|�Q����C
�y���G[Query variable] = [Required][Optional]...[Optional][End]
�w�q�G[IEnumerable<T> expression-name] = [form variable in source-collections][where lambda-expression]...[orderby optional][select or group optional]

LINQ����O��IEnumerable<T>����k�Q����ɡA�~�|�B�@�]�w���B�⦡�F�Ӥ@�몺�ާ@�]�w��foreach���z���ҰʡA�]�����z���|�B��IEnumerator.MoveNext�C
LINQ�w�q�B�⦡�i�Ѭd�߻y�k(Query Syntax)�Τ�k�y�k(Method Syntax)�Ӱ���A��k�y�k�i�ݦ����󴣨Ѫ���k���A�b�ɥRLambda�B�⦡��۰ʲ��ͪ��d�߻y�k�A�]���ಣ�X�����G�����P���󥻨��A���Y�u�O²�榡�i�H���B�@�C

Demo ref : How to: Query an ArrayList with LINQ
https://msdn.microsoft.com/en-us/library/bb397937.aspx
Demo ref : Query Syntax and Method Syntax in LINQ (C#)
https://msdn.microsoft.com/en-us/library/bb397947.aspx
Demo ref : How to: Populate Object Collections from Multiple Sources (LINQ)
https://msdn.microsoft.com/en-us/library/bb513866.aspx

0.5 Lambda
Lambda Expressions (C# Programming Guide)
https://msdn.microsoft.com/en-us/library/bb397687.aspx

�B�⦡ lambda, expression lambda�G(input parameters) => expression
���z�� lambda, statement lambda�G(input parameters) => {statement;}

C# ���O�GExpression Trees
http://huan-lin.blogspot.com/2011/08/csharp-expression-trees.html

0.6 Web API

Getting Started with ASP.NET Web API (Tutorial Sample)
https://code.msdn.microsoft.com/ASP-NET-Web-API-Tutorial-8d2588b1

Getting Started with ASP.NET Web API 2 (C#)
http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api

�yTo find the action, Web API looks at the HTTP method, and then looks for an action whose name begins with that HTTP method name. For example, with a GET request, Web API looks for an action that starts with "Get...", such as "GetContact" or "GetAllContacts".  This convention applies only to GET, POST, PUT, and DELETE methods. You can enable other HTTP methods by using attributes on your controller.�z

Web API�ϥ�HTTP��k����w�۹��Controller������k�A�Ҧp�ϥ�Get�ݨD�A�N�|�M��r����"Get"����k�A"GetContact"��"GetAllContacts"�C���o�ݨD�ȾA��GET�BPOST�BPUT�BDELETE��k�C

�Y���ݭn�i�H�ϥ��ݩʨӳ]�w��k�����C
�Ҧp�G[HttpGet]�A�]�w����k�N��������GET�ݨD
*****
public IEnumerable<User> GetAllHelloWorld()
�ۦP��
[HttpGet]
public IEnumerable<User> ForAll()
*****

�Y���ݭn�W�BAction�A�h�ק�App_Start/RouteConfig.cs�]�w�A�Ϩ�i�B���B�~�覡�B�@�C
���ϥ�RouteConfig�|�]��RouteMap���ǾɭP��������k�������ĩεL�k�Q��M�A�]�p�W���ԷV�A�קK�t���L�j���]�p�C
============

Reference :
Getting started
http://www.asp.net/mvc/overview/getting-started/introduction/getting-started

NerdDinner Step 1: File->New Project
http://nerddinnerbook.s3.amazonaws.com/Part1.htm

MVC Architecture Overview
https://msdn.microsoft.com/en-us/library/dd381412(v=vs.108).aspx
http://www.w3schools.com/aspnet/mvc_intro.asp

ASP.NET Web Deployment using Visual Studio: Deploying to Test
http://www.asp.net/mvc/overview/deployment/visual-studio-web-deployment/deploying-to-iis

MVC Publish - w3school
http://www.w3schools.com/aspnet/mvc_publish.asp

============

1. Web Forms

�Ѿ\�d����ASP.NET���[�c���Q�C
* Architecture :
Site.Master 
- Layout main page
	- Navbar : Link to other page
	- MainContent : Load main content
*


------------------------

�B�~�Ѧ�

Visual Studio ���ϥ� Razor �y�k
https://msdn.microsoft.com/zh-tw/library/gg606533(v=vs.100).aspx

Rzaor����
http://www.asp.net/web-pages/overview/getting-started/introducing-razor-syntax-(c)

ASP.NET MVC�ϥε��O
http://catchtest.pixnet.net/blog/post/29156132-asp.net-mvc%E4%BD%BF%E7%94%A8%E7%AD%86%E8%A8%98

MVC 5 ���P���B
Ref : http://kevintsengtw.blogspot.tw/2013/07/visual-studio-2013-preview-aspnet-mvc-5.html

ASP.NET Web API Self-Host
https://code.msdn.microsoft.com/ASPNET-Web-API-Self-Host-30abca12

Create an ASP.NET web app in Azure App Service
https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-get-started/

�ǲ� ASP.NET MVC
https://www.microsoft.com/taiwan/msdn/aspdotnet/mvc/learn/

