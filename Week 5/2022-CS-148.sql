Use[Northwind]

--Q1
--Select Customers.CustomerID , Orders.OrderID , Orders.OrderDate From Customers 
--Left Join Orders ON Customers.CustomerID = Orders.CustomerID;
--***


--Q2
--Select Customers.CustomerID , Orders.OrderID , Orders.OrderDate From Customers 
--Left Join Orders ON Customers.CustomerID = Orders.CustomerID where Orders.CustomerID IS NULL;
--***


--Q3
--Select Customers.CustomerID , Orders.OrderID , Orders.OrderDate From Customers 
--Left Join Orders ON Customers.CustomerID = Orders.CustomerID where YEAR(Orders.OrderDate)=1997 AND MONTH(Orders.OrderDate)=7;
--***


--Q4
--Select Customers.CustomerID , COUNT(Orders.OrderId) as totalorders From Customers 
--Left Join Orders ON Customers.CustomerID = Orders.CustomerID group by Customers.CustomerID;
--***


--Q5
--Select  EmployeeTerritories.EmployeeID , FirstName , LastName From EmployeeTerritories Cross Join Employees;
--***


--Q6
--Select EmployeeID , BirthDate from Employees
--Where (DAY(BirthDate)>=4 AND Month(BirthDate)>=7 AND Year(BirthDate)>=1996) And (DAY(BirthDate)<=4 AND Month(BirthDate)<=8 AND Year(BirthDate)<=1997);
--***


--Q7
--Select Orders.CustomerID , COUNT([Order Details] .OrderId) as Totalorders , Quantity From Orders 
--Left Join [Order Details] ON Orders.OrderID = [Order Details] .OrderID group by Orders.CustomerID , Quantity;
--***


--Q8
--Select Customers.CustomerID , Customers.CompanyName , Orders.OrderID , Orders.OrderDate From Customers 
--Left Join Orders ON Customers.CustomerID = Orders.CustomerID where (DAY(Orders.OrderDate)=4 AND Month(Orders.OrderDate)=7 AND Year(Orders.OrderDate)=1997);
--***


--Q9
--
--***


--Q10
--
--***


--Q11
--Select Products.ProductName , Orders.OrderDate from Products
--Left Join [Order Details] ON [Order Details].ProductID = Products.ProductID
--Left Join Orders ON [Order Details].OrderID = Orders.OrderID
--Where (DAY(Orders.OrderDate)=8 AND Month(Orders.OrderDate)=8 AND Year(Orders.OrderDate)=1997);
--***


--Q12
--Select Orders.ShipAddress , Orders.ShipCity , Orders.ShipCountry From Orders 
--Left Join Employees ON Orders.EmployeeID = Employees.EmployeeID where Employees.FirstName='Anne';
--***


--Q13
--Select Distinct Orders.ShipCountry , Categories.CategoryName From Orders
--Left Join [Order Details] ON Orders.OrderID=[Order Details].OrderID
--Left Join  Products ON [Order Details].ProductID = Products.ProductID
--Left Join Categories ON Categories.CategoryID = Products.CategoryID
--where Categories.CategoryName='Beverages';
--***

