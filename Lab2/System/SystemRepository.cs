namespace Itmo.ObjectOrientedProgramming.Lab2.System;

public class SystemRepository<T> : ISystemRepository<T>
{
    public Dictionary<Guid, T> Dictionary { get; } = [];

    public void AddInDictionary(Guid id, T element)
    {
        Dictionary.Add(id, element);
    }

    public T? GetById(Guid id)
    {
        return Dictionary.GetValueOrDefault(id);
    }
}