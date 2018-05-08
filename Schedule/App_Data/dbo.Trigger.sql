CREATE TRIGGER [Trigger]
	ON [dbo].[RegularStudyDayLoadSubjects]
	FOR DELETE
	AS
	BEGIN
		DELETE FROM [dbo].Subjects
		WHERE [dbo].Subjects.Id = deleted.Subject_Id
	END
