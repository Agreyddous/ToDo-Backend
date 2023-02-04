using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Entities;
using ToDo.Domain.Queries;
using ToDo.Domain.Tests.Domain.Entities;

namespace ToDo.Domain.Tests.Domain.Queries;

[TestClass]
public class ToDoItemQueriesTests
{
	private List<string> _users;
	private List<ToDoItem> _items;

	public ToDoItemQueriesTests()
	{
		_users = new List<string>();
		_items = new List<ToDoItem>();

		for (int userIndex = 0; userIndex < 10; userIndex++)
		{
			string user = userIndex.ToString();
			_users.Add(user);

			for (int itemIndex = 0; itemIndex < 5; itemIndex++)
				_items.Add(ToDoItemTests.NewToDoItem(user, itemIndex.ToString(), itemIndex.ToString()));
		}
	}

	[TestMethod("GetAll query should only return to-do items owned by the provided user")]
	[TestCategory("GetAll")]
	public void GetAllShouldOnlyReturnItemsFromTheProvidedUser()
	{
		foreach (string user in _users)
			Assert.IsTrue(_items.AsQueryable().Where(ToDoItemQueries.GetAll(user)).All(toDoItem => toDoItem.User == user));
	}
}