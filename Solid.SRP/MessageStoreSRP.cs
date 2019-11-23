/*
 * Single Responsibilty Principle
 * 
 * O principio da responsabilidade única
 * Objetos só podem ter uma razão para mudar, responsabilidade são separadas pelos atores do sistema, sempre
 * 
 * 
 * 
 */

using System.IO;

namespace Solid.SRP
{
    public class MessageStoreSRP
    {
        private readonly Logger _logger;
        private readonly FileStore _fileStore;

        public MessageStoreSRP(DirectoryInfo directory)
        {
            this._logger = new Logger();
            this._fileStore = new FileStore(directory);
        }

        public void Save(int id, string message)
        {
            this._logger.Log($"Saving the message.... {id}");

            this._fileStore.WriteAllText(id, message);

            this._logger.Log("File saved");
        }

        public string Read(int id)
        {
            this._logger.Log($"Reading message.... {id}, id");

            var msg = this._fileStore.ReadAllText(id);

            this._logger.Log("File readed");

            return msg;
        }
    }
}