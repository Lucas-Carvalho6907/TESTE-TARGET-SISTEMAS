using System;
using System.Collections.Generic;
using System.Linq;

//////////////////////////////////////////////////////////////
// 1) CÁLCULO DE COMISSÃO POR VENDEDOR
//////////////////////////////////////////////////////////////

public class CalculoComissao
{
    public class Venda
    {
        public string Vendedor { get; set; }
        public double Valor { get; set; }
    }

    public Dictionary<string, double> Calcular(List<Venda> vendas)
    {
        Dictionary<string, double> totalPorVendedor = new Dictionary<string, double>();

        foreach (var venda in vendas)
        {
            double comissao = 0;

            if (venda.Valor >= 500)
                comissao = venda.Valor * 0.05;
            else if (venda.Valor >= 100)
                comissao = venda.Valor * 0.01;

            if (!totalPorVendedor.ContainsKey(venda.Vendedor))
                totalPorVendedor[venda.Vendedor] = 0;

            totalPorVendedor[venda.Vendedor] += comissao;
        }

        return totalPorVendedor;
    }
}

//////////////////////////////////////////////////////////////
// 2) SISTEMA DE MOVIMENTAÇÃO DE ESTOQUE
//////////////////////////////////////////////////////////////

public class Produto
{
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public int Estoque { get; set; }
}

public class Movimentacao
{
    public int Id { get; set; }
    public int CodigoProduto { get; set; }
    public int Quantidade { get; set; }
    public string DescricaoMov { get; set; }
    public int EstoqueFinal { get; set; }
}

public class ControleEstoque
{
    private List<Produto> Produtos;
    private int contadorId = 1;

    public ControleEstoque(List<Produto> produtos)
    {
        Produtos = produtos;
    }

    public Movimentacao Movimentar(int codigo, int quantidade, string descricao)
    {
        var produto = Produtos.FirstOrDefault(p => p.Codigo == codigo);
        if (produto == null)
            throw new Exception("Produto não encontrado");

        produto.Estoque += quantidade;

        var mov = new Movimentacao
        {
            Id = contadorId++,
            CodigoProduto = codigo,
            Quantidade = quantidade,
            DescricaoMov = descricao,
            EstoqueFinal = produto.Estoque
        };

        return mov;
    }
}

//////////////////////////////////////////////////////////////
// 3) CÁLCULO DE JUROS COM MULTA DE 2,5% AO DIA
//////////////////////////////////////////////////////////////

public class CalculoJuros
{
    public (double juros, double valorFinal, int diasAtraso) Calcular(double valor, DateTime vencimento)
    {
        var hoje = DateTime.Now;
        int diasAtraso = (hoje - vencimento).Days;

        if (diasAtraso <= 0)
            return (0, valor, 0);

        double juros = valor * 0.025 * diasAtraso;
        double valorFinal = valor + juros;

        return (juros, valorFinal, diasAtraso);
    }
}

//////////////////////////////////////////////////////////////
// 4) EXECUÇÃO PARA EXEMPLO
//////////////////////////////////////////////////////////////

public class Program
{
    public static void Main()
    {
        Console.WriteLine("===== TESTE TÉCNICO =====\n");

        // -------------------------------
        // EXEMPLO 1 - COMISSÕES
        // -------------------------------
        var comissao = new CalculoComissao();

        var vendasExemplo = new List<CalculoComissao.Venda>
        {
            new CalculoComissao.Venda { Vendedor = "João", Valor = 1200 },
            new CalculoComissao.Venda { Vendedor = "Maria", Valor = 300 },
            new CalculoComissao.Venda { Vendedor = "João", Valor = 80 }
        };

        var resultado = comissao.Calcular(vendasExemplo);

        Console.WriteLine("=== Comissão ===");
        foreach (var r in resultado)
            Console.WriteLine($"{r.Key}: R$ {r.Value:F2}");

        Console.WriteLine("\n");

        // -------------------------------
        // EXEMPLO 2 - ESTOQUE
        // -------------------------------

        var listaProdutos = new List<Produto>
        {
            new Produto { Codigo = 101, Descricao = "Caneta Azul", Estoque = 150 },
            new Produto { Codigo = 102, Descricao = "Caderno", Estoque = 75 }
        };

        var estoque = new ControleEstoque(listaProdutos);

        var mov = estoque.Movimentar(101, -10, "Saída para venda");
        Console.WriteLine("=== Movimentação Estoque ===");
        Console.WriteLine($"ID: {mov.Id}, Produto: {mov.CodigoProduto}, Estoque Final: {mov.EstoqueFinal}");

        Console.WriteLine("\n");

        // -------------------------------
        // EXEMPLO 3 - JUROS
        // -------------------------------

        var juros = new CalculoJuros();
        var calc = juros.Calcular(1000, new DateTime(2025, 1, 10));

        Console.WriteLine("=== Juros ===");
        Console.WriteLine($"Dias atraso: {calc.diasAtraso}");
        Console.WriteLine($"Juros: R$ {calc.juros:F2}");
        Console.WriteLine($"Valor Final: R$ {calc.valorFinal:F2}");
    }
}
