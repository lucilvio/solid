/*
 * Open Closed Principle
 * 
 * O principio do aberto e fechado
 * Objetos precisam ser abertos para extensão, mas fechados para alteração
 * 
 * 
 * 
 */

using System.IO;

namespace Solid.OCP
{
    public class MessageStoreOCP
    {
        private readonly Store _store;
        private readonly Logger _logger;

        public MessageStoreOCP(Store store, Logger logger)
        {
            this._store = store;
            this._logger = logger;
        }

        public void Save(int id, string message)
        {
            this._logger.Log($"Saving the message.... {id}");

            this._store.WriteAllText(id, message);
            this._logger.Log("File saved");
        }

        public string Read(int id)
        {
            this._logger.Log($"Reading message.... {id}, id");

            var msg = this._store.ReadAllText(id);

            this._logger.Log("File readed");

            return msg;
        }
    }
}