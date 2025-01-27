using Itmo.ObjectOrientedProgramming.Lab2.AllUsers;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllLectureMaterials;

public class LectureMaterialsBuilder
{
    private Guid _id;
    private string? _name;
    private string? _description;
    private string? _content;
    private User? _author;

    public LectureMaterialsBuilder SetId(Guid id)
    {
        _id = id;
        return this;
    }

    public LectureMaterialsBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LectureMaterialsBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LectureMaterialsBuilder SetContent(string content)
    {
        _content = content;
        return this;
    }

    public LectureMaterialsBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public LectureMaterials? Build()
    {
        if (_name is null)
        {
            return null;
        }

        if (_description is null)
        {
            return null;
        }

        if (_content is null)
        {
            return null;
        }

        if (_author is null)
        {
            return null;
        }

        return new LectureMaterials(_id, _name, _description, _content, _author);
    }
}