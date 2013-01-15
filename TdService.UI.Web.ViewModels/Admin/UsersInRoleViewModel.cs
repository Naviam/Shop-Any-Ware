﻿namespace TdService.UI.Web.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;

    public class UsersInRoleViewModel:ViewModelBase
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int OrdersCount { get; set; }

        public int PackagesCount { get; set; }

        public string Email { get; set; }

        public DateTime? LastAccessDate { get; set; }

        public List<int> Roles { get; set; }
    }
}
