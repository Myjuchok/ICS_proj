namespace ICS.Project.App.Factories
{
	public interface IFactory<out T>
    {
        T Create();
    }
}