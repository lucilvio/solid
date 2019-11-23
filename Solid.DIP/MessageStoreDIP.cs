/*
 * Dependency Inversion Principle
 * 
 * Módulos de alto nível de abstração não devem depender de modos de baixo nível e vice e versa, 
 * ambos devem depender de abstrações.
 * 
 */

using System.IO;

namespace Solid.DIP
{
    public class MessageStoreDIP
    {
        private readonly IStoreReader _storeReader;
        private readonly IStoreWriter _storeWriter;
        private readonly ILogger _logger;

        public MessageStoreDIP(IStoreReader storeReader, IStoreWriter storeWriter, ILogger logger)
        {
            this._storeReader = storeReader;
            this._storeWriter = storeWriter;
            this._logger = logger;
        }

        public void Save(int id, string message)
        {
            this._logger.Log($"Saving the message.... {id}");

            this._storeWriter.WriteAllText(id, message);

            this._logger.Log("File saved");
        }

        public string Read(int id)
        {
            this._logger.Log($"Reading message.... {id}, id");

            var msg = this._storeReader.ReadAllText(id);

            this._logger.Log("File readed");

            return msg;
        }
    }
}