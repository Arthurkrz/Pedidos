using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos
{
    class Pedido
    {
        private static int _idPedido;
        public int IDPedido { get; }
        public string Nome { get; set; }
        public DateTime DataPedido { get; set; }
        public TipoPedido Tipo { get; private set; }
        public Pedido(string nome, DateTime date, TipoPedido tipo, int preco)
        {
            this.DataPedido = date;
            this.Nome = nome;
            this.Tipo = tipo;
            this.Preco = preco;
            IDPedido = ++_idPedido;
        }
        public int Preco { get; set; }
        public virtual double CalcularTotal(int preco)
        {
            return 0.0;
        }
    }
}
