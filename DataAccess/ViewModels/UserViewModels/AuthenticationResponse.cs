﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.UserViewModels
{
	public class AuthenticationResponse
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
	}
}
