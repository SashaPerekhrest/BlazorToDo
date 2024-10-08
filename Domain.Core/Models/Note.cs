namespace Domain.Core.Models
{
    public class Note
    {
        public const int MAX_TITLE_LENGTH = 250;
        public Note(Guid id, string title, string description, DateTime createdDate)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedDate = createdDate;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public static (Note Note, string Error) Create(Guid id, string title, string description, DateTime createdDate)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
                error = "Title not correct";

            var note =  new Note(id, title, description, createdDate);
            return (note, error);
        }
    }
}
