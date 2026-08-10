using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Görsel Url boş bırakılamaz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Proje Adı boş bırakılamaz")]
        [MinLength(3, ErrorMessage = "Proje Adı En az 3 Karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz")]
        [MaxLength(100, ErrorMessage = "Açıklama en fazla 100 karakter olmalıdır.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Github Url boş bırakılamaz")]
        public string GithupUrl { get; set; }

        public List<ProjectTechStack>? ProjectTexhStacks { get; set; }
    }
}
