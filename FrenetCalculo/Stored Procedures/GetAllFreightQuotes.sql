CREATE PROCEDURE GetAllFreightQuotes
AS
BEGIN
    SELECT Id, OriginZipCode, DestinationZipCode, FreightPrice, QuoteDate
    FROM FreightQuote
END
