namespace Itmo.ObjectOrientedProgramming.Lab2.Prototype;

public interface IPrototype<T>
{
    T DeepCopy(Guid id);
}