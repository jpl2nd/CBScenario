-- Add Timestamp Column

Alter Table Orders
Add LastModified DateTime
GO


-- =============================================
-- Author:		Jonathan Leitner
-- Create date: 11/1/2018
-- Description:	Procedure to return a datetime value based on the id of a given table
--				This will be called before submitting changes to a record
--				To ensure the record hasn't changed since data was retrieved for edit.

-- =============================================
CREATE PROCEDURE GetLastModifiedDate
	
	@ID int,
	@tableName varchar(50)

	
AS
BEGIN
	DECLARE @sqlStatement varchar(500)
	DECLARE @paramDefinition varchar(500)
	DECLARE @LastModified DateTime
	Set @sqlStatement = 
		'SELECT @LastModifiedOUT = LastModified From @tableName where ID = @RowID';

	Set @paramDefinition = '@RowID int, @max_titleOUT DateTime OUTPUT';

	EXECUTE sp_executesql @sqlStatement, @paramDefinition,
							@RowID = @ID, @LastModifiedOUT=@LastModified OUTPUT;
	SELECT @LastModified
	

	
END
GO
