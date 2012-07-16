using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD.Website.DbModels
{
	public partial class SubmittedDeveloper
	{
		public SubmittedDeveloper()
		{
			SubmittedDate = DateTime.UtcNow;
		}
	}
}