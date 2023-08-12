-- =============================================
-- Description:	Get Activity by Id
-- =============================================
CREATE PROCEDURE ActivityGetById
	@activityId int = 0	
AS
BEGIN
	SELECT 
		activityId
		, name
		, description
		, price
	FROM Activity A WITH(NOLOCK) WHERE A.activityId = @activityId
END
