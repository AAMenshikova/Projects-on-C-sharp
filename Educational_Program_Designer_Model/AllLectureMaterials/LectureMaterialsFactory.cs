using Itmo.ObjectOrientedProgramming.Lab2.AllUsers;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllLectureMaterials;

public class LectureMaterialsFactory
{
    public LectureMaterials? Create(Guid id, string name, string description, string content, User author)
    {
        var lectureMaterialsBuilder = new LectureMaterialsBuilder();
        lectureMaterialsBuilder.SetAuthor(author);
        lectureMaterialsBuilder.SetDescription(description);
        lectureMaterialsBuilder.SetName(name);
        lectureMaterialsBuilder.SetId(id);
        lectureMaterialsBuilder.SetContent(content);
        LectureMaterials? lectureMaterials = lectureMaterialsBuilder.Build();
        return lectureMaterials;
    }
}