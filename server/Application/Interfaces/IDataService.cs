namespace Application.Interfaces {
    public interface IDataService {
        ITodoGroupsServices TodoGroupsServices { get; }
        ITodoListsServices TodoListsServices { get; }
    }
}
