using Itmo.ObjectOrientedProgramming.Lab2.AllUsers;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllLectureMaterials;

public class LectureMaterials : IPrototype<LectureMaterials>
{
    public LectureMaterials(Guid id, string name, string description, string content, User author)
    {
        Id = id;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
    }

    public Guid Id { get; set; }

    public Guid? SourceId { get; set; }

    private string Name { get; set; }

    private string Description { get; set; }

    private string Content { get; set; }

    private User Author { get; }

    public SystemResult Change(User author, string? name, string? description, string? content)
    {
        if (TryChange(author))
        {
            if (name is not null)
                Name = name;

            if (description is not null)
                Description = description;

            if (content is not null)
                Content = content;

            return new SystemResult.Success<LectureMaterials>(this);
        }

        return new SystemResult.Fail();
    }

    public LectureMaterials(LectureMaterials source, Guid newId)
        : this(newId, source.Name, source.Description, source.Content, source.Author)
    {
        SourceId = source.Id;
    }

    public LectureMaterials DeepCopy(Guid id)
    {
        return new LectureMaterials(this, id);
    }

    private bool TryChange(User author)
    {
        return Author.Id == author.Id;
    }
}