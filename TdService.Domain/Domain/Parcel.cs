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

	public class Parcel
	{
		public virtual string Name
		{
			get;
			set;
		}

		public virtual Address Address
		{
			get;
			set;
		}

		public virtual IEnumerable<Order> Orders
		{
			get;
			set;
		}

		public virtual DispatchMethod DispatchMethod
		{
			get;
			set;
		}

		public virtual IEnumerable<Service> Services
		{
			get;
			set;
		}

	}
}
