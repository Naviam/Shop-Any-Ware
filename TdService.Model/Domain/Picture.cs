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

	public class Picture
	{
		public virtual string Filename
		{
			get;
			set;
		}

		public virtual string Path
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual PictureType PictureType
		{
			get;
			set;
		}

	}
}

