using System.ComponentModel.DataAnnotations;

namespace VSComMariaDB.Model
{
    public class Produto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(150)]
        public string Descricao { get; set; }

        [MaxLength(20)]
        public string Preco { get; set; }

        [MaxLength(20)]
        public string Disponivel { get; set; }

        [MaxLength(20)]
        public string Novidade { get; set; }

        [MaxLength(100)]
        public string Imagem { get; set; }

    }
}
