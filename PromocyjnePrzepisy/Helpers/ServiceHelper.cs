namespace PromocyjnePrzepisy.Helpers
{
    public static class ServiceHelper
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static void Initialize(IServiceProvider service)
        {
            ServiceProvider = service;
        }
        public static T? GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
