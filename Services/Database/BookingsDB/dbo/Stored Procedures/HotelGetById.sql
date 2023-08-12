-- =============================================
-- Description:	Get Hotel by Id
-- =============================================
CREATE PROCEDURE HotelGetById
	@hotelId int = 0	
AS
BEGIN
	SELECT 
		hotelId
		, name
		, address
		, city
		, state
		, zip_code
		, phone_number
		, website
	FROM Hotel A WITH(NOLOCK) WHERE A.hotelId = @hotelId
END
