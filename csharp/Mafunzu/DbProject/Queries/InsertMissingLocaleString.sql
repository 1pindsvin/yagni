INSERT INTO LocaleString (LocaleID, KeyWordID, String)
	SELECT     Locale.ID , KeyWord.ID, KeyWord.[Key]
	FROM         KeyWord CROSS JOIN Locale 
	where not exists
	(
		SELECT     LocaleID, KeyWordID
		FROM         LocaleString
		where (LocaleID = Locale.ID and KeyWordID = KeyWord.ID)
	) 