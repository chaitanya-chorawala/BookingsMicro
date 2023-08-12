-- =============================================
-- Description:	Get Activity List
-- =============================================
CREATE PROCEDURE ActivityGet
AS
BEGIN
	SELECT 
		activityId
		, name
		, description
		, price
	FROM Activity WITH(NOLOCK)
END
