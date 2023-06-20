CREATE PROCEDURE DeleteTrackingEvent
    @Id INT
AS
BEGIN
    DELETE FROM TrackingEventModel
    WHERE Id = @Id
END
