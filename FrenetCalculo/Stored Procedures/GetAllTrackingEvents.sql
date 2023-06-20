CREATE PROCEDURE GetAllTrackingEvents
AS
BEGIN
    SELECT Id, EventDateTime, EventDescription, EventLocation, EventType, FreightQuoteId
    FROM TrackingEventModel
END
