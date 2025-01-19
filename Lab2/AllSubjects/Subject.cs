using Itmo.ObjectOrientedProgramming.Lab2.AllLaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.AllLectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.AllUsers;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllSubjects;

public class Subject : IPrototype<Subject>
{
    public Subject(Guid id, string name, User author, int points, Enum gradeFormat, Collection<LaboratoryWork> collectionOfLaboratoryWorks, Collection<LectureMaterials> collectionOfLectureMaterials)
    {
        Id = id;
        Name = name;
        Author = author;
        Points = points;
        GradeFormat = gradeFormat;
        foreach (LaboratoryWork labWork in collectionOfLaboratoryWorks)
        {
            _collectionOfLaboratoryWorks.Add(labWork);
        }

        foreach (LectureMaterials material in collectionOfLectureMaterials)
        {
            _collectionOfLectureMaterials.Add(material);
        }
    }

    public Guid Id { get; }

    public Guid? SourceId { get; private set; }

    private string Name { get; set; }

    private User Author { get; }

    private int Points { get; set; }

    private Enum GradeFormat { get; set; }

    private readonly Collection<LaboratoryWork> _collectionOfLaboratoryWorks = [];

    private readonly Collection<LectureMaterials> _collectionOfLectureMaterials = [];

    public SystemResult Change(User author, string? name)
    {
        if (!TryChange(author)) return new SystemResult.Fail();
        if (name is not null)
            Name = name;

        return new SystemResult.Success<Subject>(this);
    }

    public Subject(Subject source, Guid newId, Collection<LaboratoryWork> collectionOfLaboratoryWorks, Collection<LectureMaterials> collectionOfLectureMaterials)
        : this(newId, source.Name, source.Author, source.Points, source.GradeFormat, collectionOfLaboratoryWorks, collectionOfLectureMaterials)
    {
        SourceId = source.Id;
    }

    public Subject DeepCopy(Guid id)
    {
        var clonedLaboratoryWorks = new Collection<LaboratoryWork>();
        foreach (LaboratoryWork lab in _collectionOfLaboratoryWorks)
        {
            clonedLaboratoryWorks.Add(lab.DeepCopy(id));
        }

        var clonedLectureMaterials = new Collection<LectureMaterials>();
        foreach (LectureMaterials lecture in _collectionOfLectureMaterials)
        {
            clonedLectureMaterials.Add(lecture.DeepCopy(id));
        }

        return new Subject(this, id, clonedLaboratoryWorks, clonedLectureMaterials);
    }

    private bool TryChange(User author)
    {
        return Author.Id == author.Id;
    }
}