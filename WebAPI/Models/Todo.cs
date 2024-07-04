using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAPI.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public DateTime DataConclusao { get; private set; }
        public string Descricao { get; private set; }
        public bool IsConcluido { get; private set; }

        public Todo(string descricao)
        {
            Descricao = descricao;
        }

        public void Update(string descricao, bool isConcluido)
        {
            Descricao = descricao;
            IsConcluido = isConcluido;
        }

        public void SetIsConcluido()
        {
            IsConcluido = true;
            DataConclusao = DateTime.Now;
        }
    }
}
