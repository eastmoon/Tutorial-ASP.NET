※上傳Git檔案因為容量問題，刪除[project]/packages、[project]/[subproject]/bin、[project]/[subproject]/obj，以上檔案夾會於專案編譯後重建。

0. MVC

MVC stands for model-view-controller.  MVC is a pattern for developing applications that are well architected, testable  and easy to maintain. MVC-based applications contain:

Models: Classes that represent the data of the application  and that use validation logic to enforce business rules for that data.
Views: Template files that your application uses to dynamically  generate HTML responses.
Controllers: Classes that handle incoming browser requests,  retrieve model data, and then specify view templates that return a response  to the browser.

0-1.Controller
http://www.asp.net/mvc/overview/getting-started/introduction/adding-a-controller

※Notice in Solution Explorer that a new file has been created named HelloWorldController.cs and a new folder Views\HelloWorld. The controller is open in the IDE.
當經由IDE產生控制器的同時，會產生對應的View檔案夾。

ASP.NET MVC invokes different controller classes (and different action methods within  them) depending on the incoming URL. The default URL routing logic used by ASP.NET MVC uses a format like this to determine what code to invoke:

/[Controller]/[ActionName]/[Parameters]

Controller 相當於以RESTful WebAPI形式建立了子功能；其URL格式為 /[Controller]/[ActionName]/[Parameters]
例如：HelloWorld Controller Class，其Index method對應http://xxxx/HelloWorld/，Other method對應http://xxx/HelloWorld/Other。

專案預設，當URL未提供任何子段，替換的子段則由App_Start/RouteConfig.cs設定提供；因此，若要修改預設子段則於此設定。
資料傳入上，可以使用query strings，例如：?name=xx&id=yy，則對應的功能的函數輸入 function( string name, int id )即可收到傳入值。
另外可用運WebAPI功能，在RouteMap中設定對應子段為其特定參數，若參數不足則改以query string補足。

假若存在一函數，其名稱Welcome，則
http://xxxx/HelloWorld/Welcome，執行Welcome函數
http://xxxx/HelloWorld/Welcome/5，執行Welcome函數並送入參數5

參數對應參考RouteMap，若設定為{controller}/{action}/{name}/{id}，則函數對應為ACTION ( string NAME, int ID)。
※注意，不論是RouteMap或query strings，只要字符對，不論大小寫皆可。


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


Ref：Web.MVC.Html document, https://msdn.microsoft.com/en-us/library/system.web.mvc.html(v=vs.108).aspx

0.3 Model

1. Create Model
http://www.asp.net/mvc/overview/getting-started/introduction/adding-a-model
Ref：建立物件模型, https://msdn.microsoft.com/zh-tw/library/bb546174(v=vs.110).aspx

※範例所需為ASP.NET 5與Entity Framework 5，標準.NET 4.5並沒有，需開啟專案後更新Framework。
Ref：Entity Framework, https://msdn.microsoft.com/en-us/library/gg696172(VS.103).aspx
Ref：Entity Framework Development Workflows, https://msdn.microsoft.com/zh-tw/data/jj590134

模型屬性使用：
利用模型屬性來設定資料庫資訊對應資訊，諸如資料庫、表名稱，欄位設定，預存設定。
Ref：LINQ to SQL: .NET Language-Integrated Query for Relational Data #Entity Classes In-Depth , https://msdn.microsoft.com/library/bb425822.aspx#linqtosql_topic22
Ref：https://msdn.microsoft.com/zh-tw/library/bb386971(v=vs.110).aspx

額外參閱：
Introducing LocalDB, an improved SQL Express
http://blogs.msdn.com/b/sqlexpress/archive/2011/07/12/introducing-localdb-a-better-sql-express.aspx

2. Create Connection String
http://www.asp.net/mvc/overview/getting-started/introduction/creating-a-connection-string
Ref：資料庫通訊, https://msdn.microsoft.com/zh-tw/library/bb882660(v=vs.110).aspx

額外參閱：
SQL Server Connection Strings for ASP.NET Web Applications
https://msdn.microsoft.com/en-us/library/jj653752.aspx

3. Create Controller
http://www.asp.net/mvc/overview/getting-started/introduction/accessing-your-models-data-from-a-controller

防範偽造驗證
Model : [ValidateAntiForgeryToken],  The attribute is used to prevent forgery of a request and is paired up with @Html.AntiForgeryToken() in the edit view 
View : @Html.AntiForgeryToken(), generates a hidden form anti-forgery token that must match in the Edit method of the Movies controller.

As soon as the client side validation determines the values of a field are not valid, an error message is displayed. If you disable JavaScript, you won't have client side validation but the server will detect the posted values are not valid, and the form values will be redisplayed with error messages.

Don’t use Delete Links because they create Security Holes. 
http://stephenwalther.com/archive/2009/01/21/asp-net-mvc-tip-46-ndash-donrsquot-use-delete-links-because

4. Search Data
http://www.asp.net/mvc/overview/getting-started/introduction/adding-search

※對資料庫存取資需使用LINQ expressions與Lambda expressions，其操作範例參考0.4 LINQ、0.5 Lambda

LINQ執行時機，分為延後執行(Deferred)、立即(Immediate)，不論何種時機，其運行內容會將LINQ運算式轉換成對應資料源(倉儲元件(Collections)，SQL資料庫伺服，ADO.NET資料集，XML文件)可實際執行的運算式。

『LINQ to SQL does not actually execute queries; the relational database does.
LINQ to SQL translates the queries you wrote into equivalent SQL queries and sends them to the server for processing. 
Therefore the queries you write must be translated into equivalent operations and functions that are available inside the SQL environment.』

Ref：Query Execution, https://msdn.microsoft.com/en-us/library/bb738633.aspx

相對應用於SQL Server參考文獻如下列：

Ref：LINQ to SQL: .NET Language-Integrated Query for Relational Data, https://msdn.microsoft.com/library/bb425822.aspx
Ref：LINQ to SQL [LINQ to SQL], https://msdn.microsoft.com/zh-tw/library/bb386976(v=vs.110).aspx
Ref：查詢資料庫, https://msdn.microsoft.com/zh-tw/library/bb882680(v=vs.110).aspx 
Ref：預存程序, https://msdn.microsoft.com/zh-tw/library/bb386946(v=vs.110).aspx

運用LINQ運算式可以進行資料庫操作，但亦可使用ExecuteCommand、ExecuteQuery直接下達SQL或呼叫預存程序(Stored Procedure)。
※注意，預存程序使用上方式於不同文件分為ExecuteCommand、ExecuteMethodCall兩種，其使用差異與方式仍需注意。

額外參閱：
Cross-site request :
http://www.asp.net/mvc/overview/security/xsrfcsrf-prevention-in-aspnet-mvc-and-web-pages

5. Adding a New Field
http://www.asp.net/mvc/overview/getting-started/introduction/adding-a-new-field

當資料庫經由Model完成，若從中增加一欄位會導致資料庫同步錯誤，在ASP.NET MVC有以下方式：
1. 重建資料庫，經由標準程序重新產生資料庫，但對於已經有龐大資料的資料庫並不實際。
2. 修改資料庫架構，對於外部資料庫直接使用資料庫工具增減欄位，以確保與模型內容相同。
3. 工具，使用Code First Migrations替換資料庫架構。

6. Adding Validation
http://www.asp.net/mvc/overview/getting-started/introduction/adding-validation

參考1.模型屬性使用，使用屬性設定欄位對應的預設值，諸如不可為空、值域範圍等。

0.4 LINQ

LINQ (Language-Integrated Query)
https://msdn.microsoft.com/en-us/library/bb397926.aspx

LINQ Query Expressions (C# Programming Guide)
https://msdn.microsoft.com/en-us/library/bb397676.aspx

Visual Studio includes LINQ provider assemblies that enable the use of LINQ with .NET Framework collections, SQL Server databases, ADO.NET Datasets, and XML documents.
Visual Studio包括LINQY組件，其使用於.NET框架的倉儲元件(Collections)，SQL資料庫伺服，ADO.NET資料集，XML文件。

傳統上，針對不同資料系統其Query格式並不相同，對此Visual Studio於2008後提供LINQ，讓開發者可以用統一的格式對XML文件、資料庫、繼承IEnumerable物件進行詢問。

從應用觀點來看，資料源頭的結構與型態並不重要，在程式內資料源都是由IEnumerable<T>或IQueryable<T>收藏著。
LINQ用於XML文件，資料型態為IEnumerable<XElement>。
LINQ用於資料集，資料型態為IEnumerable<DataRow>。
LINQ用於SQL，資料型態為使用者定義於SQL資料庫溝通的自定物件，但仍收藏於IEnumerable<T>或IQueryable<T>。

LINQ運算式定義時並不會被執行。
句型：[Query variable] = [Required][Optional]...[Optional][End]
定義：[IEnumerable<T> expression-name] = [form variable in source-collections][where lambda-expression]...[orderby optional][select or group optional]

LINQ執行是當IEnumerable<T>的方法被執行時，才會運作設定的運算式；而一般的操作設定由foreach陳述式啟動，因為陳述式會運行IEnumerator.MoveNext。
LINQ定義運算式可由查詢語法(Query Syntax)或方法語法(Method Syntax)來執行，方法語法可看成物件提供的方法中，在補充Lambda運算式後自動產生的查詢語法，因此能產出的結果受限與物件本身，但若只是簡單式可以此運作。

Demo ref : How to: Query an ArrayList with LINQ
https://msdn.microsoft.com/en-us/library/bb397937.aspx
Demo ref : Query Syntax and Method Syntax in LINQ (C#)
https://msdn.microsoft.com/en-us/library/bb397947.aspx
Demo ref : How to: Populate Object Collections from Multiple Sources (LINQ)
https://msdn.microsoft.com/en-us/library/bb513866.aspx

0.5 Lambda
Lambda Expressions (C# Programming Guide)
https://msdn.microsoft.com/en-us/library/bb397687.aspx

運算式 lambda, expression lambda：(input parameters) => expression
陳述式 lambda, statement lambda：(input parameters) => {statement;}

C# 筆記：Expression Trees
http://huan-lin.blogspot.com/2011/08/csharp-expression-trees.html

0.6 Web API

Getting Started with ASP.NET Web API (Tutorial Sample)
https://code.msdn.microsoft.com/ASP-NET-Web-API-Tutorial-8d2588b1

Getting Started with ASP.NET Web API 2 (C#)
http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api

『To find the action, Web API looks at the HTTP method, and then looks for an action whose name begins with that HTTP method name. For example, with a GET request, Web API looks for an action that starts with "Get...", such as "GetContact" or "GetAllContacts".  This convention applies only to GET, POST, PUT, and DELETE methods. You can enable other HTTP methods by using attributes on your controller.』

Web API使用HTTP方法來鎖定相對於Controller內的方法，例如使用Get需求，就會尋找字首有"Get"的方法，"GetContact"或"GetAllContacts"。但這需求僅適用GET、POST、PUT、DELETE方法。

若有需要可以使用屬性來設定方法對應。
例如：[HttpGet]，設定的方法將直接對應GET需求
*****
public IEnumerable<User> GetAllHelloWorld()
相同於
[HttpGet]
public IEnumerable<User> ForAll()
*****

若有需要增額Action，則修改App_Start/RouteConfig.cs設定，使其可運用額外方式運作。
※使用RouteConfig會因為RouteMap順序導致部份的方法對應失效或無法被找尋，設計上應謹慎，避免差異過大的設計。
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

參閱範本對ASP.NET的架構推想。
* Architecture :
Site.Master 
- Layout main page
	- Navbar : Link to other page
	- MainContent : Load main content
*


------------------------

額外參考

Visual Studio 中使用 Razor 語法
https://msdn.microsoft.com/zh-tw/library/gg606533(v=vs.100).aspx

Rzaor說明
http://www.asp.net/web-pages/overview/getting-started/introducing-razor-syntax-(c)

ASP.NET MVC使用筆記
http://catchtest.pixnet.net/blog/post/29156132-asp.net-mvc%E4%BD%BF%E7%94%A8%E7%AD%86%E8%A8%98

MVC 5 不同之處
Ref : http://kevintsengtw.blogspot.tw/2013/07/visual-studio-2013-preview-aspnet-mvc-5.html

ASP.NET Web API Self-Host
https://code.msdn.microsoft.com/ASPNET-Web-API-Self-Host-30abca12

Create an ASP.NET web app in Azure App Service
https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-get-started/

學習 ASP.NET MVC
https://www.microsoft.com/taiwan/msdn/aspdotnet/mvc/learn/

