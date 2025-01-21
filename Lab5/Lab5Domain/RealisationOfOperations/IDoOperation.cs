using Lab5Domain.ResultTypes;

namespace Lab5Domain.RealisationOfOperations;

public interface IDoOperation
{
    TypesOfResult Doing(decimal amount);
}