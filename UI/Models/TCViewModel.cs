using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
	public class TCViewModel
	{
		[Required(ErrorMessage = "Ad Alanı zorunludur!")]
		[Display(Name = "Adınız *")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Soyad Alanı zorunludur!")]
		[Display(Name = "Soyadınız *")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Doğum Tarihi Alanı zorunludur!")]
		[Display(Name = "Doğum yılınız *")]
		[Range(1900, 9999, ErrorMessage = "Doğum yılı 4 haneli olmalıdır!")]
		[RegularExpression(@"^[0-9]*$", ErrorMessage = "Doğum yılı sadece sayı içermelidir!")]
		public int BirthDate { get; set; }


		[Required(ErrorMessage = "T.C. Kimlik Numarası Alanı zorunludur!")]
		[Display(Name = "T.C. Kimlik Numarası *")]
		[RegularExpression(@"^[0-9]*$", ErrorMessage = "T.C. Kimlik Numarası alanı sadece sayı içermelidir!")]
		[Range(10000000000, 99999999999, ErrorMessage = "T.C. Kimlik Numarası 11 haneli olmalıdır!")]
		public long CitizenId { get; set; }
    }
}
