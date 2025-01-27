using Itmo.ObjectOrientedProgramming.Lab2.AllSubjects;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllEducationalPrograms;

public class EducationalProgram
{
    public EducationalProgram(Guid id, string name, string programManager, Dictionary<int, Collection<Subject>> subjectsAndSemesters)
    {
        Id = id;
        Name = name;
        ProgramManager = programManager;
        _subjectsAndSemesters = subjectsAndSemesters;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string ProgramManager { get; }

    private readonly Dictionary<int, Collection<Subject>> _subjectsAndSemesters;

    public void Append(int semester, Collection<Subject> subjects)
    {
        _subjectsAndSemesters.Add(semester, subjects);
    }
}