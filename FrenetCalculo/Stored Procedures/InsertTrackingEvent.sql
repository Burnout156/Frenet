CREATE PROCEDURE InsertTrackingEvent
    @EventDateTime DATETIME = GETDATE(),
    @EventDescription NVARCHAR(100),
    @EventLocation NVARCHAR(100),
    @EventType NVARCHAR(50),
    @FreightQuoteId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO TrackingEvent (EventDateTime, EventDescription, EventLocation, EventType, FreightQuoteId)
    VALUES (@EventDateTime, @EventDescription, @EventLocation, @EventType, @FreightQuoteId)
END
