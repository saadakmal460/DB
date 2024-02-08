--Q1
--Select ProductName from Products where UnitPrice > (Select AVG(UnitPrice) from Products);
--***

--Q2
--Select ShippedDate , Count(OrderID) from Orders group by ShippedDate;
--***

--Q3
--Select Country from Suppliers group by Country having COUNT(Country)>2;
--***

--Q4
--Select MONTH(ShippedDate) , COUNT(ShippedDate) from Orders where ShippedDate>RequiredDate  group by MONTH(ShippedDate) Order By MONTH(ShippedDate);
--***

--Q5
--Select OrderId , SUM(Discount) from [Order Details] where Discount>0 Group by OrderID;
--***

--Q6
--Select ShipCity , COUNT(*) from Orders where ShipCountry='USA' AND  YEAR(ShippedDate)=1997 Group by  ShipCity;
--***

--Q7
--Select ShipCountry , COUNT(ShippedDate) from Orders where ShippedDate>RequiredDate  group by ShipCountry;
--***

--Q8
--Select OrderId , SUM(Discount) , SUM(UnitPrice * Quantity) from [Order Details] where Discount>0 Group By OrderID;
--***

--Q9
--Select ShipRegion, ShipCity, COUNT(*) from Orders  where YEAR(ShippedDate) = 1997 AND ShipRegion IS Not NUll group by ShipRegion, ShipCity Order By ShipRegion;
--***
