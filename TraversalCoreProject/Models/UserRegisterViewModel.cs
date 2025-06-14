﻿using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen Soyadınızı giriniz")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Lütfen mail adresini giriniz")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen tekrar şifrenizi giriniz")]
		[Compare("Password",ErrorMessage ="şifreler uyumlu değil")]
		public string ConfirmPassword { get; set; }

	}
}
