using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos
{
    class PedidoInternacional : Pedido
    {
        public PedidoInternacional(string nome, DateTime date, TipoPedido tipo, int preco) : base(nome, date, tipo, preco) { }
        public override double CalcularTotal(int preco)
        {
            return preco + (preco * 0.20);
        }
    }
}
