USE [CLWaterDB_02112024]
GO
/****** Object:  StoredProcedure [dbo].[spUpdatePerson]    Script Date: 4/1/2024 9:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spUpdatePerson]
	@p_person_id INT
	,@p_last_name VARCHAR(35)
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
	,@p_address_note_id INT	
AS
BEGIN	
	SET NOCOUNT ON;

	--Set edit date variable to current system time
	DECLARE @edit_date AS DATETIME
	SET @edit_date = GETDATE()

	--Grab Pre-Update variables for update logic
	DECLARE @validate_date DATETIME
	DECLARE @address_note_date DATETIME
	DECLARE @address_note_id INT
	DECLARE @is_primary INT
	DECLARE @primary_id INT
	DECLARE @is_staging INT


	SELECT @is_primary = is_primary,
		   @primary_id = primary_id,
		   @validate_date = validate_date,
		   @address_note_id = address_note_id,
		   @address_note_date = address_note_dt,
		   @is_staging = is_staging
	FROM TBL_PERSON
	WHERE person_id = @p_person_id

	--Set Address Note Logic
	IF (@address_note_id <> @p_address_note_id)
		BEGIN
			SET @address_note_date = GETDATE()
		END

	--Raise erros if bad logic sent 
	DECLARE @param_error_exist INT
	SET @param_error_exist = 0
	IF (@is_primary = 1 AND @p_is_primary = 0)
		BEGIN
			RAISERROR ('ERROR: Attempt to change primary record to duplicate.',18,1)
			SET @param_error_exist = 1
		END
	IF (@p_is_staging = 1 AND @p_is_primary = 1)
		BEGIN
			RAISERROR ('ERROR: Attempt to set record as primary & staged.',18,1)
			SET @param_error_exist = 1
		END
	IF (@primary_id IS NOT NULL) AND (@primary_id <> @p_primary_id )
		BEGIN
			RAISERROR ('ERROR: Attempt to change primary id of duplicate to new primary id.',18,1)
			SET @param_error_exist = 1
		END		
	
	--If record is being set to primary set validation datetime stamp, 
	--otherwise take whats currently available
	IF (@is_staging = 1) AND (@p_is_staging = 0)
		SET @validate_date = GETDATE()	
	
	-- If no errors have occured updated person
	IF @param_error_exist = 0
		BEGIN						
			UPDATE TBL_PERSON
			SET LAST_NAME = @p_last_name
			  ,FIRST_NAME = @p_first_name
			  ,MIDDLE_NAME = @p_middle_name
			  ,VARSTATUS = @p_varstatus
			  ,EMAIL_ADDRESS = @p_email_address
			  ,VARSTATIONED = @p_varstationed
			  ,VARWORKED = @p_varworked
			  ,VARRESIDE = @p_varreside
			  ,VARNONE = @p_varnone
			  ,SUFFIX_ID = @p_suffix_id
			  ,PRIMARY_PHONE = @p_primary_phone
			  ,ALTERNATE_PHONE = @p_alternate_phone
			  ,COMMENTS = @p_comments
			  ,HEAR_ABOUT_US_ID = @p_hear_about_us_id
			  ,OTHER_HEAR_ABOUT_US_DESC = @p_other_hear_about_us_desc
			  ,IS_STAGING = @p_is_staging
			  ,IS_PRIMARY = @p_is_primary				
			  ,PRIMARY_ID = @p_primary_id					
			  ,EDITED_BY = @p_edited_by
			  ,EDITED_DATE = @edit_date    
			  ,VALIDATE_DATE = @validate_date 
			  ,ADDRESS_NOTE_ID = @p_address_note_id
			  ,ADDRESS_NOTE_DT = @address_note_date
			WHERE person_id = @p_person_id
		END
    
END

