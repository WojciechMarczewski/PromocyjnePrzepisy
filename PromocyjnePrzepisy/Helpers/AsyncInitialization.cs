using PromocyjnePrzepisy.Services.Interfaces;
namespace PromocyjnePrzepisy.Helpers
{
    public static class AsyncInitialization
    {
        public static List<Task> Tasks = new List<Task>();
        public static Task
          EnsureInitializedAsync(IEnumerable<object> instances)
        {
            return Task.WhenAll(
              instances.OfType<IAsyncInitialization>()
                .Select(x => x.Initialization));
        }
        public static Task EnsureInitializedAsync(params object[] instances)
        {
            return EnsureInitializedAsync(instances.AsEnumerable());
        }
        public static Task EnsureInitializedAsync()
        {
            return Task.WhenAll(
              Tasks.OfType<IAsyncInitialization>()
                .Select(x => x.Initialization));
        }
    }
}
