USE [CLWaterDB_02112024]
GO
/****** Object:  StoredProcedure [dbo].[spRetrievePerson]    Script Date: 4/1/2024 12:39:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spRetrievePerson]
	@p_person_id INT
AS
BEGIN	
	SET NOCOUNT ON;
	
	SELECT  PERSON_ID, 
			LAST_NAME, 
			FIRST_NAME, 
			MIDDLE_NAME, 
			VARSTATUS, 
			EMAIL_ADDRESS, 
			VARSTATIONED, 
			VARWORKED, 
			VARRESIDE, 
            		REGISTRATION_TYPE_ID, 
			VARNONE, 
			SUFFIX_ID, 
			PRIMARY_PHONE, 
			ALTERNATE_PHONE, 
			HEAR_ABOUT_US_ID, 
			OTHER_HEAR_ABOUT_US_DESC, 
            IS_PRIMARY, 
			IS_STAGING, 
			PRIMARY_ID,
			ADDRESS_NOTE_ID,
			ADDRESS_NOTE_DT
	FROM    TBL_PERSON
	WHERE PERSON_ID = @p_person_id
END

