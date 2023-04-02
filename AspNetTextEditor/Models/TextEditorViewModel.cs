using System.ComponentModel.DataAnnotations;

namespace AspNetTextEditor.Models
{
    public class TextEditorViewModel
    {
        [Display(Name = "Текст")]
        public string Message { get; set; } = "Введите текст здесь...";

        [Display(Name = "Заголовок")]
        public string Title { get; set; } = "Укажите заголовок";

        public int Id { get; set; } = -1;
    }
}
