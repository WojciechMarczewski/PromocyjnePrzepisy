using SQLite;

namespace PromocyjnePrzepisy.DB
{
    public class ShoppingListDatabase
    {
        SQLiteAsyncConnection? Database;
        async Task Init()
        {
            if (Database is not null)
                return;
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<ProductEntity>();
        }
        public async Task<List<ProductEntity>> GetItemsAsync()
        {

            await Init();
            if (Database is null)
                throw new InvalidOperationException("Couldn't find database.");
            return await Database.Table<ProductEntity>().ToListAsync();
        }
        public async Task<int> SaveItemAsync(ProductEntity productEntity)
        {
            await Init();
            return await Database.InsertAsync(productEntity);
        }
        public async Task<int> DeleteItemAsync(ProductEntity productEntity)
        {
            await Init();
            return await Database.DeleteAsync(productEntity);
        }


    }
}
