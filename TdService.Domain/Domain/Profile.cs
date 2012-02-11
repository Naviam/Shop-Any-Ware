﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace TdService.Domain
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Profile
	{
		public virtual string FirstName
		{
			get;
			set;
		}

		public virtual string LastName
		{
			get;
			set;
		}

		/// <summary>
		/// Tells whether system should notify user about changes to his orders or parcels.
		/// </summary>
		public virtual bool NotifyByEmail
		{
			get;
			set;
		}

		/// <summary>
		/// Personal user's warehouse address in USA
		/// </summary>
		public virtual Address UsaAddress
		{
			get;
			set;
		}

		public virtual NotificationRules NotificationRules
		{
			get;
			set;
		}

	}
}

