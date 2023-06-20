CREATE PROCEDURE UpdateFreightQuote
    @Id INT,
    @OriginZipCode NVARCHAR(50),
    @DestinationZipCode NVARCHAR(50),
    @FreightPrice DECIMAL(18, 2),
    @QuoteDate DATETIME
AS
BEGIN
    UPDATE FreightQuote
    SET OriginZipCode = @OriginZipCode,
        DestinationZipCode = @DestinationZipCode,
        FreightPrice = @FreightPrice,
        QuoteDate = @QuoteDate
    WHERE Id = @Id
END
