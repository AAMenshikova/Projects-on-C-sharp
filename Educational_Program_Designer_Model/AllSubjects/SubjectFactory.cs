using Itmo.ObjectOrientedProgramming.Lab2.AllLaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.AllLectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.AllUsers;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllSubjects;

public class SubjectFactory
{
    public Subject? Create(Guid id, string name, int points, Enum gradeFormat, Collection<LaboratoryWork> collectionOfLaboratoryWorks, Collection<LectureMaterials> collectionOfLectureMaterials, User author)
    {
        var subjectBuilder = new SubjectBuilder();
        subjectBuilder.SetId(id);
        subjectBuilder.SetAuthor(author);
        subjectBuilder.SetName(name);
        subjectBuilder.SetPoints(points);
        subjectBuilder.SetGradeFormat(gradeFormat);
        subjectBuilder.SetCollectionOfLaboratoryWorks(collectionOfLaboratoryWorks);
        subjectBuilder.SetCollectionOfLectureMaterials(collectionOfLectureMaterials);
        Subject? subject = subjectBuilder.Build();
        return subject;
    }
}