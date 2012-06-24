SELECT Email, Password, FirstName, LastName, NotifyOnOrderStatusChanged, NotifyOnPackageStatusChanged, Amount
FROM dbo.Users LEFT JOIN dbo.Profiles ON dbo.Users.Profile_Id = dbo.Profiles.Id
LEFT JOIN dbo.Wallets ON dbo.Users.Wallet_Id = dbo.Wallets.Id
