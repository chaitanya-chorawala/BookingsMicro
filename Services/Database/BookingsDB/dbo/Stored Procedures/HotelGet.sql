-- =============================================
-- Description:	Get Hotel List
-- =============================================
CREATE PROCEDURE HotelGet
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
	FROM Hotel WITH(NOLOCK)
END