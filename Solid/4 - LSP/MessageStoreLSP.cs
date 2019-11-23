/*
 * Liskov Substitution principle
 * 
 * O principio de substituição de Liskov
 * Seja q(x) uma propriedade que se pode provar do objeto x do tipo T. Então, q(y) também é possível provar para o objeto y do tipo S, sendo S um subtipo de T
 * 
 * Em resumo, a relação "É UM" não justifica herança, o que justifica herança é a relação "É SUBSTITUÍVEL POR". Um objeto, quando substituído por outro 
 * dentro de uma relação de herança, precisa garantir que o sistema continue funciona de maneira integra.
 * Uma das maiores violações institucionalizadas do princípio da substituição de Liskov é o NULL
 * 
 * 
 */


using System.IO;

namespace Solid.LSP
{
    public class MessageStoreLSP
    {
        private readonly Store _store;
        private readonly Logger _logger;

        public MessageStoreLSP(Store store, Logger logger)
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