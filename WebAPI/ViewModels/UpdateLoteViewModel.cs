namespace WebAPI.ViewModels
{
    public class UpdateLoteViewModel
    {
        public List<Item> Itens { get; set; } = [];
        
        public class Item
        {
            public string Id { get; set; }
            public bool IsConcluido { get; set; }
        }
    }
}
