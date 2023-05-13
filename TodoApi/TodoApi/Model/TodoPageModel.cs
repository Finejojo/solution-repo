namespace TodoApi.Model
{
    public class TodoPageModel
    {
        public List<TodoModel> Todo { get; set; } = new List<TodoModel>();
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
    }
}
