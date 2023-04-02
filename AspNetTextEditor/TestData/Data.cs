using AspNetTextEditor.Models;

namespace AspNetTextEditor.TestData
{
    public static class Data
    {
        public static Dictionary<int, TextEditorViewModel> Posts;

        static Data()
        {
            Posts = new Dictionary<int, TextEditorViewModel>();
            TextEditorViewModel defaultPost = new TextEditorViewModel
            {
                Id = 0,
                Title = "Пробное сообщение",
                Message = "Текст простой <b>полужирный</b> <i>курсив</i>",
            };
            Posts.Add(0, defaultPost);
        }
    }
}
