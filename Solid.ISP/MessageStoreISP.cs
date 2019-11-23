/*
 * Interface Segregation Principle
 * 
 * O principio da segregação de interfaces
 * Um objeto não deve depender de mais métodos do que ele relamente precisa
 * As interfaces precisam ser coesas pra permitir e flexibilidade de composição
 * 
 * É importante mudar um pouco o conceito de criação e uso de abstrações(interfaces), quem define a abstração SEMPRE é o cliente.
 * A abstração existe do lado do cliente e não do lado de quem consome
 * 
 */

using System.IO;

namespace Solid.ISP
{
    public class MessageStoreISP
    {
        private readonly IStoreReader _storeReader;
        private readonly IStoreWriter _storeWriter;
        private readonly ILogger _logger;

        public MessageStoreISP(IStoreReader storeReader, IStoreWriter storeWriter, ILogger logger)
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