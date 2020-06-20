USE [AmazonCodeFirst]
GO

/****** Object:  View [sales].[SalesInsights]    Script Date: 20/06/2020 09:01:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [sales].[SalesInsights] AS
SELECT common.Customer.Id,
	   common.Customer.Name,
	   common.Customer.Birthday,
	   common.Customer.Email,
	   common.Customer.Cpf,
	   common.Address.Street,
	   common.Address.ZipPostCode,
	   common.Address.City,
	   SalesStatistics.PurchaseQuantity,
	   SalesStatistics.PurchaseValueMax,
	   SalesStatistics.PurchaseValueAverage,
	   SalesStatistics.TotalItemsQuantity,
	   SalesStatistics.ItemsQuantityAverage,
	   SalesStatistics.ShippingRateMax,
	   SalesStatistics.ShippingRateAverage
FROM common.Customer
INNER JOIN common.Address ON common.Customer.AddressId = common.Address.Id
INNER JOIN (
SELECT sales.Cart.CustomerId,
	   COUNT(SalesData.CartId) AS PurchaseQuantity,
	   MAX(SalesData.PurchaseValue) AS PurchaseValueMax,
	   CONVERT(decimal(5,2), AVG(SalesData.PurchaseValue)) AS PurchaseValueAverage,
	   SUM(SalesData.ItemsQuantity) AS TotalItemsQuantity,
	   CONVERT(decimal(5,2), AVG(CONVERT(decimal(5,2), SalesData.ItemsQuantity))) AS ItemsQuantityAverage,
	   MAX(SalesData.ShippingRate) ShippingRateMax,
	   CONVERT(decimal(5,2), AVG(SalesData.ShippingRate)) AS ShippingRateAverage
FROM sales.Cart
INNER JOIN
	(SELECT sales.Cart.CustomerId,
			sales.CartProduct.CartId,
			sales.Cart.PurchaseDate,
			COUNT(*) ItemsQuantity,
			SUM(common.Product.Price) PurchaseValue,
			SUM(common.ShippingRate.Rate) ShippingRate
	 FROM sales.Cart
	 INNER JOIN common.Customer ON sales.Cart.CustomerId = common.Customer.Id
	 INNER JOIN sales.CartProduct ON sales.Cart.Id = sales.CartProduct.CartId
	 INNER JOIN common.Product ON sales.CartProduct.ProductId = common.Product.Id
	 INNER JOIN common.ProductShippingRate ON common.Product.Id = common.ProductShippingRate.ProductId
	 INNER JOIN common.ShippingRate ON common.ProductShippingRate.ShippingRateId = common.ShippingRate.Id
	 WHERE common.ShippingRate.FirstDay <= DAY(sales.Cart.PurchaseDate) AND common.ShippingRate.SecondDay >= DAY(sales.Cart.PurchaseDate)
	 GROUP BY sales.Cart.CustomerId, sales.CartProduct.CartId, sales.Cart.PurchaseDate
	) SalesData ON sales.Cart.CustomerId = SalesData.CustomerId AND sales.Cart.Id = SalesData.CartId
GROUP BY sales.Cart.CustomerId
) SalesStatistics ON common.Customer.Id = SalesStatistics.CustomerId
GO