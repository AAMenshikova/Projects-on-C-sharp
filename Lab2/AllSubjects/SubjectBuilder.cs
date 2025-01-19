using Itmo.ObjectOrientedProgramming.Lab2.AllLaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.AllLectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.AllUsers;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllSubjects;

public class SubjectBuilder
{
    private Guid _id;
    private string? _name;
    private User? _author;
    private int _points;
    private Enum? _gradeFormat;
    private Collection<LaboratoryWork> _collectionOfLaboratoryWorks = [];
    private Collection<LectureMaterials>? _collectionOfLectureMaterials = [];

    public SubjectBuilder SetId(Guid id)
    {
        _id = id;
        return this;
    }

    public SubjectBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public SubjectBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public SubjectBuilder SetPoints(int points)
    {
        _points = points;
        return this;
    }

    public SubjectBuilder SetGradeFormat(Enum gradeFormat)
    {
        _gradeFormat = gradeFormat;
        return this;
    }

    public SubjectBuilder SetCollectionOfLaboratoryWorks(Collection<LaboratoryWork> collectionOfLaboratoryWorks)
    {
        _collectionOfLaboratoryWorks = collectionOfLaboratoryWorks;
        return this;
    }

    public SubjectBuilder SetCollectionOfLectureMaterials(Collection<LectureMaterials> collectionOfLectureMaterials)
    {
        _collectionOfLectureMaterials = collectionOfLectureMaterials;
        return this;
    }

    public Subject? Build()
    {
        if (_name is null)
        {
            return null;
        }

        if (_gradeFormat is null)
        {
            return null;
        }

        if (_author is null)
        {
            return null;
        }

        if (_collectionOfLectureMaterials is null)
        {
            return null;
        }

        int allSum = _collectionOfLaboratoryWorks.Sum(laboratoryWork => laboratoryWork.Points);

        allSum += _points;
        if (allSum != 100)
        {
            return null;
        }

        return new Subject(_id, _name, _author, _points, _gradeFormat, _collectionOfLaboratoryWorks, _collectionOfLectureMaterials);
    }
}