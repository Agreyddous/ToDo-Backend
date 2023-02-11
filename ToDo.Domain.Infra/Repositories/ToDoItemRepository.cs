using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Infra.Contexts;
using ToDo.Domain.Orderings;
using ToDo.Domain.Queries;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Infra.Repositories;

/// <summary>
/// Implementation of IToDoItemRepository with Entity Framework
/// </summary>
public class ToDoItemRepository : IToDoItemRepository
{
	private readonly ToDoDataContext DataContext;
	private readonly DbSet<ToDoItem> Table;

	public ToDoItemRepository(ToDoDataContext dataContext)
	{
		DataContext = dataContext;
		Table = DataContext.ToDoItems!;
	}

	public void Create(ToDoItem toDoItem)
	{
		Table.Add(toDoItem);
		DataContext.SaveChanges();
	}

	public ToDoItem? Get(string user, Guid id) => Table.FirstOrDefault(ToDoItemQueries.Get(user, id));

	public IEnumerable<ToDoItem> GetAll(string user) => Table.AsNoTracking()
														  .Where(ToDoItemQueries.GetAll(user))
														  .OrderBy(ToDoItemOrdering.LastUpdate);

	public IEnumerable<ToDoItem> GetAllDueBetween(string user, DateTime startDate, DateTime endDate, bool? isComplete = null) => Table.AsNoTracking()
																																   .Where(ToDoItemQueries.GetAllDueBetween(user, startDate, endDate, isComplete))
																																   .OrderBy(ToDoItemOrdering.LastUpdate);

	public IEnumerable<ToDoItem> GetAllComplete(string user) => Table.AsNoTracking()
																  .Where(ToDoItemQueries.GetAllComplete(user))
																  .OrderBy(ToDoItemOrdering.LastUpdate);

	public IEnumerable<ToDoItem> GetAllIncomplete(string user) => Table.AsNoTracking()
																	.Where(ToDoItemQueries.GetAllIncomplete(user))
																	.OrderBy(ToDoItemOrdering.LastUpdate);

	public IEnumerable<ToDoItem> GetCreatedBetween(string user, DateTime startDate, DateTime endDate) => Table.AsNoTracking()
																										   .Where(ToDoItemQueries.GetCreatedBetween(user, startDate, endDate))
																										   .OrderBy(ToDoItemOrdering.CreateDate);

	public IEnumerable<ToDoItem> GetLastUpdatedBetween(string user, DateTime startDate, DateTime endDate, bool? isComplete = null) => Table.AsNoTracking()
																																		.Where(ToDoItemQueries.GetLastUpdatedBetween(user, startDate, endDate, isComplete))
																																		.OrderBy(ToDoItemOrdering.LastUpdate);

	public void Update(ToDoItem toDoItem)
	{
		Table.Update(toDoItem);
		DataContext.SaveChanges();
	}
}