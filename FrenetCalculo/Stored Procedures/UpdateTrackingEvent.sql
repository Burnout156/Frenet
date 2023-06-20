CREATE PROCEDURE UpdateTrackingEvent
    @Id INT,
    @EventDateTime NVARCHAR(50),
    @EventDescription NVARCHAR(100),
    @EventLocation NVARCHAR(100),
    @EventType NVARCHAR(50),
    @FreightQuoteId INT
AS
BEGIN
    UPDATE TrackingEventModel
    SET EventDateTime = @EventDateTime,
        EventDescription = @EventDescription,
        EventLocation = @EventLocation,
        EventType = @EventType,
        FreightQuoteId = @FreightQuoteId
    WHERE Id = @Id
END
