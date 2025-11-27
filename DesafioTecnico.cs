using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // ===== MODELOS =====

    public class Venda
    {
        public string Vendedor { get; set; } = string.Empty;
        public double Valor { get; set; }
    }

    public class Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Estoque { get; set; }
    }

    public class Movimentacao
    {
        public int Id { get; set; }
        public int CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public string DescricaoMov { get; set; } = string.Empty;
    }

    static void Main()
    {
        Console.WriteLine("===== TESTE TÉCNICO =====\n");

        // ============================================================================
        //                               1. COMISSÕES
        // ============================================================================

        var vendas = new List<Venda>
        {
            new Venda { Vendedor = "João Silva", Valor = 1200.50 },
            new Venda { Vendedor = "João Silva", Valor = 950.75 },
            new Venda { Vendedor = "João Silva", Valor = 1800.00 },
            new Venda { Vendedor = "João Silva", Valor = 1400.30 },
            new Venda { Vendedor = "João Silva", Valor = 1100.90 },
            new Venda { Vendedor = "João Silva", Valor = 1550.00 },
            new Venda { Vendedor = "João Silva", Valor = 1700.80 },
            new Venda { Vendedor = "João Silva", Valor = 250.30 },
            new Venda { Vendedor = "João Silva", Valor = 480.75 },
            new Venda { Vendedor = "João Silva", Valor = 320.40 },

            new Venda { Vendedor = "Maria Souza", Valor = 2100.40 },
            new Venda { Vendedor = "Maria Souza", Valor = 1350.60 },
            new Venda { Vendedor = "Maria Souza", Valor = 950.20 },
            new Venda { Vendedor = "Maria Souza", Valor = 1600.75 },
            new Venda { Vendedor = "Maria Souza", Valor = 1750.00 },
            new Venda { Vendedor = "Maria Souza", Valor = 1450.90 },
            new Venda { Vendedor = "Maria Souza", Valor = 400.50 },
            new Venda { Vendedor = "Maria Souza", Valor = 180.20 },
            new Venda { Vendedor = "Maria Souza", Valor = 90.75 },

            new Venda { Vendedor = "Carlos Oliveira", Valor = 800.50 },
            new Venda { Vendedor = "Carlos Oliveira", Valor = 1200.00 },
            new Venda { Vendedor = "Carlos Oliveira", Valor = 1950.30 },
            new Venda { Vendedor = "Carlos Oliveira", Valor = 1750.80 },
            new Venda { Vendedor = "Carlos Oliveira", Valor = 1300.60 },
            new Venda { Vendedor = "Carlos Oliveira", Valor = 300.40 },
            new Venda { Vendedor = "Carlos Oliveira", Valor = 500.00 },
            new Venda { Vendedor = "Carlos Oliveira", Valor = 125.75 },

            new Venda { Vendedor = "Ana Lima", Valor = 1000.00 },
            new Venda { Vendedor = "Ana Lima", Valor = 1100.50 },
            new Venda { Vendedor = "Ana Lima", Valor = 1250.75 },
            new Venda { Vendedor = "Ana Lima", Valor = 1400.20 },
            new Venda { Vendedor = "Ana Lima", Valor = 1550.90 },
            new Venda { Vendedor = "Ana Lima", Valor = 1650.00 },
            new Venda { Vendedor = "Ana Lima", Valor = 75.30 },
            new Venda { Vendedor = "Ana Lima", Valor = 420.90 },
            new Venda { Vendedor = "Ana Lima", Valor = 315.40 }
        };

        var comissoes = vendas
            .GroupBy(v => v.Vendedor)
            .Select(g => new
            {
                Vendedor = g.Key,
                TotalComissao = g.Sum(v =>
                    v.Valor < 100 ? 0 :
                    v.Valor < 500 ? v.Valor * 0.01 :
                                   v.Valor * 0.05
                )
            });

        Console.WriteLine("=== Comissões Calculadas ===");
        foreach (var c in comissoes)
            Console.WriteLine($"{c.Vendedor}: R$ {c.TotalComissao:F2}");

        // ============================================================================
        //                      2. MOVIMENTAÇÕES DE ESTOQUE
        // ============================================================================

        var produtos = new List<Produto>
        {
            new Produto { Codigo = 101, Descricao = "Caneta Azul", Estoque = 150 },
            new Produto { Codigo = 102, Descricao = "Caderno Universitário", Estoque = 75 },
            new Produto { Codigo = 103, Descricao = "Borracha Branca", Estoque = 200 },
            new Produto { Codigo = 104, Descricao = "Lápis Preto HB", Estoque = 320 },
            new Produto { Codigo = 105, Descricao = "Marcador de Texto Amarelo", Estoque = 90 }
        };

        Console.WriteLine("\n\n=== Movimentações de Estoque ===\n");

        var movimentacoes = new List<Movimentacao>
        {
            new Movimentacao { Id = 1, CodigoProduto = 101, Quantidade = -10, DescricaoMov = "Saída para venda" },
            new Movimentacao { Id = 2, CodigoProduto = 102, Quantidade = +20, DescricaoMov = "Reposição de estoque" },
            new Movimentacao { Id = 3, CodigoProduto = 103, Quantidade = -15, DescricaoMov = "Saída para consumo interno" },
            new Movimentacao { Id = 4, CodigoProduto = 104, Quantidade = +30, DescricaoMov = "Entrada por compra" },
            new Movimentacao { Id = 5, CodigoProduto = 105, Quantidade = -5,  DescricaoMov = "Saída por avaria" }
        };

        foreach (var mov in movimentacoes)
        {
            var produto = produtos.First(p => p.Codigo == mov.CodigoProduto);

            int estoqueInicial = produto.Estoque;
            produto.Estoque += mov.Quantidade;
            int estoqueFinal = produto.Estoque;

            string tipo = mov.Quantidade >= 0 ? "Entrada" : "Saída";
            string qtdFmt = mov.Quantidade >= 0 ? $"+{mov.Quantidade}" : mov.Quantidade.ToString();

            Console.WriteLine($"ID: {mov.Id}");
            Console.WriteLine($"Produto: {produto.Codigo} - {produto.Descricao}");
            Console.WriteLine($"Tipo: {tipo}");
            Console.WriteLine($"Quantidade: {qtdFmt}");
            Console.WriteLine($"Estoque Inicial: {estoqueInicial}");
            Console.WriteLine($"Estoque Final: {estoqueFinal}");
            Console.WriteLine($"Descrição: {mov.DescricaoMov}");
            Console.WriteLine("-----------------------------\n");
        }

        // ============================================================================
        //                                3. JUROS
        // ============================================================================

        Console.WriteLine("=== Cálculo de Juros ===");

        double valor = 1000;
        DateTime vencimento = new DateTime(2024, 1, 10);
        int diasAtraso = (DateTime.Now - vencimento).Days;

        double juros = valor * 0.025 * diasAtraso;
        double final = valor + juros;

        Console.WriteLine($"Dias de atraso: {diasAtraso}");
        Console.WriteLine($"Juros: R$ {juros:F2}");
        Console.WriteLine($"Valor Final: R$ {final:F2}");
    }
}
