using Itmo.ObjectOrientedProgramming.Lab2.AllSubjects;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllEducationalPrograms;

public class EducationalProgramFactory
{
    public EducationalProgram? Create(Guid id, string name, string programManager, Dictionary<int, Collection<Subject>> collectionOfSubjects)
    {
        var educationalProgramBuilder = new EducationalProgramBuilder();
        educationalProgramBuilder.SetId(id);
        educationalProgramBuilder.SetName(name);
        educationalProgramBuilder.SetProgramManager(programManager);
        educationalProgramBuilder.SetCollectionOfSubjects(collectionOfSubjects);
        EducationalProgram? educationalProgram = educationalProgramBuilder.Build();
        return educationalProgram;
    }
}