public class MyStack<T>
{
	private List<T> items;

	public MyStack()
	{
		items = new List<T>();
	}

	public int Count()
	{
		return items.Count;
	}

	pulic T Pop()
	{
		if (items.Count != 0)
		{
			T item = items[items.Count - 1];
			items.RemoveAt(items.Count - 1);
			return item;
		}
		return null;
	}

	public void Push(T item)
	{
		items.Add(item);
	}
}