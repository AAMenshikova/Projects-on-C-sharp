using Itmo.ObjectOrientedProgramming.Lab2.AllUsers;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllLaboratoryWorks;

public class LaboratoryWork : IPrototype<LaboratoryWork>
{
    public LaboratoryWork(Guid id, string name, string description, string evaluationCriteria, int points, User author)
    {
        Id = id;
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        Points = points;
        Author = author;
    }

    public Guid Id { get; }

    public int Points { get; }

    public Guid? SourceId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string EvaluationCriteria { get; set; }

    public User Author { get; }

    public SystemResult Change(User author, string? name, string? description, string? evaluationCriteria)
    {
        if (TryChange(author))
        {
            if (name is not null)
                Name = name;

            if (description is not null)
                Description = description;

            if (evaluationCriteria is not null)
                EvaluationCriteria = evaluationCriteria;

            return new SystemResult.Success<LaboratoryWork>(this);
        }

        return new SystemResult.Fail();
    }

    public LaboratoryWork(LaboratoryWork source, Guid newId) : this(newId, source.Name, source.Description, source.EvaluationCriteria, source.Points, source.Author)
    {
        SourceId = source.Id;
    }

    public LaboratoryWork DeepCopy(Guid id)
    {
        return new LaboratoryWork(this, id);
    }

    public bool TryChange(User author)
    {
        return Author.Id == author.Id;
    }
}