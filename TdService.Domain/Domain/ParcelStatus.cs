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

	public enum ParcelStatus : int
	{
		PendingPayment = 0,
		Processing = 3,
		Paid = 1,
		Collected,
		Dispatched,
	}
}