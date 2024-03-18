namespace WebApp.ServiceInterfaces {
    public interface IDataService {
        public ITodoGroupsService TodoGroupsService { get; }
        public ITodosService TodosService { get; }
    }
}
