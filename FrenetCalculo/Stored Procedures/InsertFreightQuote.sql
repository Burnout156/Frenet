USE [FrenetDB]
GO

DECLARE @return_value int

DECLARE @OriginZipCode NVARCHAR(50) = '12345'
DECLARE @DestinationZipCode NVARCHAR(50) = '67890'
DECLARE @FreightPrice DECIMAL(18, 2) = 100.00
DECLARE @QuoteDate DATETIME = '2023-06-20'

EXEC @return_value = [dbo].[InsertFreightQuote]
    @OriginZipCode,
    @DestinationZipCode,
    @FreightPrice,
    @QuoteDate

SELECT 'Return Value' = @return_value
GO
