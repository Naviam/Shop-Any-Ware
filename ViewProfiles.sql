SELECT Email, Password, FirstName, LastName, NotifyOnOrderStatusChanged, NotifyOnPackageStatusChanged
FROM dbo.Users LEFT JOIN dbo.Profiles ON dbo.Users.Profile_Id = dbo.Profiles.Id
LEFT JOIN dbo.NotificationRules ON dbo.Profiles.NotificationRule_Id = dbo.NotificationRules.Id
