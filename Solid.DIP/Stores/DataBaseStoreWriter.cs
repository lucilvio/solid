using Solid.DIP.Stores;

namespace Solid.DIP
{
    internal class DataBaseStoreWriter : IStoreWriter
    {
        private readonly EFContext _context;

        public DataBaseStoreWriter(EFContext context)
        {
            this._context = context;
        }

        public void WriteAllText(int id, string message)
        {
            this._context.Messages.Add(new Message { Id = id, Msg = message });
            this._context.SaveChanges();
        }
    }
}