public interface IState<in T>
{
	public void UpdateState(T enemy);
}
