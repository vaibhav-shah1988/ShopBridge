# ShopBridge
<h2>Tools Used</h2>
<ul>
	<li>Visual Studio 2019</li>
	<li>SQL Server 2014</li>
</ul>
<hr/>

<h2>Database Setup</h2>
Use database.sql to create Shopbridge database & related tables in your database. Then change connection string in web.config of Shopbridge.API project

<hr/>

<h2>Run Project</h2>
<ul>
	<li>right Click on "ShopBridge.API" -> Properties -> Web -> Start Action -> Select option "Don't open a page, Wait for a request from external application."</li>
	<li>Set Multiple Startup Projects by going to below path</li>
	 Right click Solution -> Properties -> Common Properties -> Startup Project -> Multiple startp projects -> Mark "Shopbridge.API" & "ShopBridge.UI" as startup projcts	
	<li>Run Project by pressing <b>F5</b>. In case of Error Clean & Rebuild Solution </li>
</ul>

<hr/>

<h2>Screenshots</h2>


<h4>List of Inventory</h4>
![List](https://user-images.githubusercontent.com/6494014/118109042-4e339300-b3fe-11eb-9868-b9473686e228.png)

<h4>Add New Inventory</h4>
![create](https://user-images.githubusercontent.com/6494014/118109036-4c69cf80-b3fe-11eb-81c5-4586da62b9ce.png)

<h4>Edit Inventory</h4>
![edit](https://user-images.githubusercontent.com/6494014/118109040-4d9afc80-b3fe-11eb-9821-d17f796f12b3.png)

<hr/>

<h2>Time Tracking</h2>
<ol>
	<li>Data store design - 1.5 Hours</li>
	<li>API and service logic - 2 Hours</li>
	<li>UI - 2 Hours</li>
	<li>Unit Test Coverage - 1.5 Hour</li>
	</ol>
