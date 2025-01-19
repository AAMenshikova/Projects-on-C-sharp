using Itmo.ObjectOrientedProgramming.Lab2.AllSubjects;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllEducationalPrograms;

public class EducationalProgramBuilder
{
    private Guid _id;

    private string? _name;

    private string? _programManager;

    private Dictionary<int, Collection<Subject>>? _collectionOfSubjects;

    public EducationalProgramBuilder SetId(Guid id)
    {
        _id = id;
        return this;
    }

    public EducationalProgramBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public EducationalProgramBuilder SetProgramManager(string programManager)
    {
        _programManager = programManager;
        return this;
    }

    public EducationalProgramBuilder SetCollectionOfSubjects(Dictionary<int, Collection<Subject>> collectionOfSubjects)
    {
        _collectionOfSubjects = collectionOfSubjects;
        return this;
    }

    public EducationalProgram? Build()
    {
        if (_name is null)
        {
            return null;
        }

        if (_programManager is null)
        {
            return null;
        }

        if (_collectionOfSubjects is null)
        {
            return null;
        }

        return new EducationalProgram(_id, _name, _programManager, _collectionOfSubjects);
    }
}