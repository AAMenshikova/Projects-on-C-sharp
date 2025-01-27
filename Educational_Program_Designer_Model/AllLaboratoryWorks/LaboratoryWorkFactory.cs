using Itmo.ObjectOrientedProgramming.Lab2.AllUsers;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllLaboratoryWorks;

public class LaboratoryWorkFactory
{
    public LaboratoryWork? Create(Guid id, string name, string description, string evaluationCriteria, int points, User author)
    {
        var laboratoryWorkBuilder = new LaboratoryWorkBuilder();
        laboratoryWorkBuilder.SetId(Guid.NewGuid());
        laboratoryWorkBuilder.SetName(name);
        laboratoryWorkBuilder.SetDescription(description);
        laboratoryWorkBuilder.SetEvaluationCriteria(evaluationCriteria);
        laboratoryWorkBuilder.SetPoints(points);
        laboratoryWorkBuilder.SetId(id);
        laboratoryWorkBuilder.SetAuthor(author);
        LaboratoryWork? laboratoryWork = laboratoryWorkBuilder.Build();
        return laboratoryWork;
    }
}