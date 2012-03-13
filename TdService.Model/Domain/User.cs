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

	/// <summary>
	/// This class describes user in the system
	/// </summary>
	public class User
	{
		public virtual int Id { get; set; }

		/// <summary>
		/// Unique user identificator
		/// </summary>
		public virtual string Email { get; set; }

		/// <summary>
		/// User's password
		/// </summary>
		public virtual string Password { get; set; }

		public virtual bool IsActive { get; set; }

		public virtual string ActivationGuid { get; set; }

		public virtual Profile Profile { get; set; }

		public virtual IEnumerable<DeliveryAddress> DeliveryAddresses { get; set; }

		public virtual IEnumerable<Order> Orders { get; set; }

	    public virtual Balance Balance { get; set; }

		public virtual IEnumerable<Role> Roles { get; set; }

		public virtual IEnumerable<Parcel> Parcels { get; set; }

		public User()
		{
		}

		public virtual void Activate()
		{
			throw new System.NotImplementedException();
		}

	}
}

