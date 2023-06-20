CREATE PROCEDURE DeleteFreightQuote
    @Id INT
AS
BEGIN
    DELETE FROM FreightQuote
    WHERE Id = @Id
END
