using System.ComponentModel.DataAnnotations;

namespace LibraryWebApplication.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}