using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAPI.Models
{
    public class Todo(string descricao)
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public DateTime DataConclusao { get; private set; }
        public string Descricao { get; private set; } = descricao;
        public bool IsConcluido { get; private set; }

        public Todo Update(string descricao)
        {
            Descricao = descricao;

            return this;
        }

        public Todo SetIsConcluido(bool isConcluido)
        {
            IsConcluido = isConcluido;
            DataConclusao = DateTime.Now;

            return this;
        }
    }
}
