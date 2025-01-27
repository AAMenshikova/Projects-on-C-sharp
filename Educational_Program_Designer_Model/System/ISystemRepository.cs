namespace Itmo.ObjectOrientedProgramming.Lab2.System;

public interface ISystemRepository<T>
{
    public void AddInDictionary(Guid id, T element);

    T? GetById(Guid id);
}