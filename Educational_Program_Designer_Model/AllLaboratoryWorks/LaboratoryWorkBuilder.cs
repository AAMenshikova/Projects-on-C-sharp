using Itmo.ObjectOrientedProgramming.Lab2.AllUsers;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllLaboratoryWorks;

public class LaboratoryWorkBuilder
{
    private Guid _id;

    private int _points;

    private string? _name;

    private string? _description;

    private string? _evaluationCriteria;

    private User? _author;

    public LaboratoryWorkBuilder SetId(Guid id)
    {
        _id = id;
        return this;
    }

    public LaboratoryWorkBuilder SetPoints(int points)
    {
        _points = points;
        return this;
    }

    public LaboratoryWorkBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LaboratoryWorkBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LaboratoryWorkBuilder SetEvaluationCriteria(string evaluationCriteria)
    {
        _evaluationCriteria = evaluationCriteria;
        return this;
    }

    public LaboratoryWorkBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public LaboratoryWork? Build()
    {
        if (_name is null)
        {
            return null;
        }

        if (_description is null)
        {
            return null;
        }

        if (_evaluationCriteria is null)
        {
            return null;
        }

        if (_author is null)
        {
            return null;
        }

        return new LaboratoryWork(_id, _name, _description, _evaluationCriteria, _points, _author);
    }
}