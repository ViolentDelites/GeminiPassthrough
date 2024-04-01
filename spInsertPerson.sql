USE [CLWaterDB_02112024]
GO
/****** Object:  StoredProcedure [dbo].[spInsertPerson]    Script Date: 4/1/2024 12:58:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spInsertPerson]
	@p_last_name VARCHAR(35)
	,@p_first_name  VARCHAR(35)
	,@p_middle_name  VARCHAR(1)
	,@p_varstatus  VARCHAR(32)
	,@p_email_address  VARCHAR(128)
	,@p_varstationed  VARCHAR(8)
	,@p_varworked  VARCHAR(8)
	,@p_varreside   VARCHAR(8)
	,@p_varnone  VARCHAR(8)
	,@p_suffix_id  INT
	,@p_primary_phone  NUMERIC(20,0)
	,@p_alternate_phone  NUMERIC(20,0)
	,@p_comments  TEXT
	,@p_hear_about_us_id   INT
	,@p_other_hear_about_us_desc VARCHAR(35)
	,@p_is_staging BIT
	,@p_is_primary BIT
	,@p_primary_id INT = NULL
	,@p_edited_by INT	
	,@p_reg_type_id INT
AS
BEGIN

	SET NOCOUNT ON;
	
	INSERT INTO TBL_PERSON
           (LAST_NAME
           ,FIRST_NAME
           ,MIDDLE_NAME
           ,VARSTATUS
           ,EMAIL_ADDRESS
           ,VARSTATIONED
           ,VARWORKED
           ,VARRESIDE
           ,REGISTRATION_TYPE_ID
           ,VARNONE
           ,CREATED_DATE
           ,SUFFIX_ID
           ,PRIMARY_PHONE
           ,ALTERNATE_PHONE
           ,COMMENTS
           ,CREATED_BY
           ,HEAR_ABOUT_US_ID
           ,OTHER_HEAR_ABOUT_US_DESC
           ,IS_STAGING
           ,IS_PRIMARY
           ,PRIMARY_ID
           ,EDITED_BY
           ,EDITED_DATE)
     VALUES
           (@p_last_name
           ,@p_first_name
           ,@p_middle_name
           ,@p_varstatus
           ,@p_email_address
           ,@p_varstationed
           ,@p_varworked 
           ,@p_varreside 
           ,@p_reg_type_id
           ,@p_varnone
           ,GETDATE()
           ,@p_suffix_id 
           ,@p_primary_phone 
           ,@p_alternate_phone
           ,@p_comments
           ,@p_edited_by
           ,@p_hear_about_us_id
           ,@p_other_hear_about_us_desc
           ,@p_is_staging
           ,@p_is_primary
           ,@p_primary_id
           ,@p_edited_by
           ,GETDATE())
	
	--Return Person PK ID
	SELECT SCOPE_IDENTITY()

   
END