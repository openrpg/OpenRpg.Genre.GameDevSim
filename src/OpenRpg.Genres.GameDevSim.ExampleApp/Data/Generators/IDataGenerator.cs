namespace GameDevStory.ConsoleApp.Data.Generators;

public interface IDataGenerator<out T>
{
    IReadOnlyCollection<T> Data { get; }
}