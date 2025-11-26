using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text.Json; 
using System.Text.Json.Serialization;

namespace DesafiosVendasEstoque
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU DE DESAFIOS ===");
                Console.WriteLine("1 - Cálculo de Comissões (Vendas)");
                Console.WriteLine("2 - Controle de Estoque");
                Console.WriteLine("3 - Calculadora de Juros (2.5% a.d.)");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": ExecutarDesafio1(); break;
                    case "2": ExecutarDesafio2(); break;
                    case "3": ExecutarDesafio3(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
        }

        // ==========================================
        // DESAFIO 1: COMISSÃO DE VENDAS
        // ==========================================
        static void ExecutarDesafio1()
        {
            Console.Clear();
            Console.WriteLine("--- Desafio 1: Cálculo de Comissões ---\n");

            
            string jsonVendas = @"
            {
              ""vendas"": [
                { ""vendedor"": ""João Silva"", ""valor"": 1200.50 },
                { ""vendedor"": ""João Silva"", ""valor"": 950.75 },
                { ""vendedor"": ""João Silva"", ""valor"": 1800.00 },
                { ""vendedor"": ""João Silva"", ""valor"": 1400.30 },
                { ""vendedor"": ""João Silva"", ""valor"": 1100.90 },
                { ""vendedor"": ""João Silva"", ""valor"": 1550.00 },
                { ""vendedor"": ""João Silva"", ""valor"": 1700.80 },
                { ""vendedor"": ""João Silva"", ""valor"": 250.30 },
                { ""vendedor"": ""João Silva"", ""valor"": 480.75 },
                { ""vendedor"": ""João Silva"", ""valor"": 320.40 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 2100.40 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 1350.60 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 950.20 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 1600.75 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 1750.00 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 1450.90 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 400.50 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 180.20 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 90.75 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 800.50 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1200.00 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1950.30 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1750.80 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1300.60 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 300.40 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 500.00 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 125.75 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1000.00 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1100.50 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1250.75 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1400.20 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1550.90 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1650.00 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 75.30 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 420.90 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 315.40 }
              ]
            }";

            
            var dados = JsonSerializer.Deserialize<ListaVendas>(jsonVendas, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine($"{"VENDEDOR",-20} | {"VENDA",-10} | {"% COMISSÃO",-12} | {"VALOR COMISSÃO",-15}");
            Console.WriteLine(new string('-', 65));

            decimal totalComissoesGeral = 0;

            
            var vendasAgrupadas = dados.Vendas.GroupBy(v => v.Vendedor);

            foreach (var grupo in vendasAgrupadas)
            {
                decimal totalVendedor = 0;
                
                foreach (var venda in grupo)
                {
                    decimal percentual = 0;
                    if (venda.Valor >= 500) percentual = 0.05m;
                    else if (venda.Valor >= 100) percentual = 0.01m;
                    else percentual = 0;

                    decimal valorComissao = venda.Valor * percentual;
                    totalVendedor += valorComissao;

                    Console.WriteLine($"{venda.Vendedor,-20} | {venda.Valor,10:C2} | {percentual,12:P0} | {valorComissao,15:C2}");
                }
                Console.WriteLine($"   >>> TOTAL {grupo.Key.ToUpper()}: {totalVendedor:C2}");
                Console.WriteLine(new string('-', 65));
                totalComissoesGeral += totalVendedor;
            }
            
            Console.WriteLine($"\nTOTAL GERAL DE COMISSÕES A PAGAR: {totalComissoesGeral:C2}");
        }

        // ==========================================
        // DESAFIO 2: MOVIMENTAÇÃO DE ESTOQUE
        // ==========================================
        static void ExecutarDesafio2()
        {
            Console.Clear();
            Console.WriteLine("--- Desafio 2: Movimentação de Estoque ---\n");

            string jsonEstoque = @"
            {
                ""estoque"": [
                    { ""codigoProduto"": 101, ""descricaoProduto"": ""Caneta Azul"", ""estoque"": 150 },
                    { ""codigoProduto"": 102, ""descricaoProduto"": ""Caderno Universitário"", ""estoque"": 75 },
                    { ""codigoProduto"": 103, ""descricaoProduto"": ""Borracha Branca"", ""estoque"": 200 },
                    { ""codigoProduto"": 104, ""descricaoProduto"": ""Lápis Preto HB"", ""estoque"": 320 },
                    { ""codigoProduto"": 105, ""descricaoProduto"": ""Marcador de Texto Amarelo"", ""estoque"": 90 }
                ]
            }";

            var dadosEstoque = JsonSerializer.Deserialize<ListaEstoque>(jsonEstoque, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\nPRODUTOS DISPONÍVEIS:");
                foreach(var p in dadosEstoque.Estoque)
                {
                    Console.WriteLine($"ID: {p.CodigoProduto} | {p.DescricaoProduto} | Qtd Atual: {p.QtdEstoque}");
                }

                Console.Write("\nDigite o ID do produto para movimentar: ");
                if (!int.TryParse(Console.ReadLine(), out int idBusca)) continue;

                var produto = dadosEstoque.Estoque.FirstOrDefault(p => p.CodigoProduto == idBusca);

                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado!");
                    continue;
                }

                Console.WriteLine($"\nProduto Selecionado: {produto.DescricaoProduto}");
                Console.WriteLine("Tipo de Movimentação: [1] Entrada / [2] Saída");
                string tipo = Console.ReadLine();

                Console.Write("Quantidade: ");
                if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade < 0)
                {
                    Console.WriteLine("Quantidade inválida.");
                    continue;
                }

                
                string descricaoMovimentacao = "";
                
                if (tipo == "1") 
                {
                    produto.QtdEstoque += quantidade;
                    descricaoMovimentacao = $"Entrada de {quantidade} unidades via sistema.";
                }
                else if (tipo == "2") 
                {
                    if (produto.QtdEstoque < quantidade)
                    {
                        Console.WriteLine("Erro: Estoque insuficiente!");
                        continue;
                    }
                    produto.QtdEstoque -= quantidade;
                    descricaoMovimentacao = $"Saída de {quantidade} unidades para venda/uso.";
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                    continue;
                }

                
                Guid idMovimentacao = Guid.NewGuid();

                Console.WriteLine("\n--- RECIBO DA MOVIMENTAÇÃO ---");
                Console.WriteLine($"ID Transação: {idMovimentacao}");
                Console.WriteLine($"Descrição: {descricaoMovimentacao}");
                Console.WriteLine($"Produto: {produto.DescricaoProduto}");
                Console.WriteLine($"Estoque Final: {produto.QtdEstoque}");
                Console.WriteLine("------------------------------");

                Console.Write("\nDeseja realizar outra movimentação? (S/N): ");
                if (Console.ReadLine().ToUpper() != "S") continuar = false;
            }
        }

        // ==========================================
        // DESAFIO 3: CÁLCULO DE JUROS
        // ==========================================
        static void ExecutarDesafio3()
        {
            Console.Clear();
            Console.WriteLine("--- Desafio 3: Calculadora de Juros (2.5% ao dia) ---\n");

            Console.Write("Digite o valor original do boleto/conta (ex: 100,00): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valorOriginal))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            Console.Write("Digite a data de vencimento (dd/mm/aaaa): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataVencimento))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            DateTime dataHoje = DateTime.Now.Date; 
            
            
            TimeSpan diferenca = dataHoje - dataVencimento;
            int diasAtraso = diferenca.Days;

            if (diasAtraso <= 0)
            {
                Console.WriteLine("\nO pagamento está em dia ou adiantado. Não há juros.");
                Console.WriteLine($"Valor a pagar: {valorOriginal:C2}");
            }
            else
            {
                
                decimal taxaDiaria = 0.025m; 
                decimal valorJuros = valorOriginal * (taxaDiaria * diasAtraso);
                decimal valorTotal = valorOriginal + valorJuros;

                Console.WriteLine("\n--- RESULTADO ---");
                Console.WriteLine($"Dias de atraso: {diasAtraso}");
                Console.WriteLine($"Taxa total aplicada: {(taxaDiaria * diasAtraso):P1}");
                Console.WriteLine($"Valor Original: {valorOriginal:C2}");
                Console.WriteLine($"Juros: {valorJuros:C2}");
                Console.WriteLine($"VALOR ATUALIZADO: {valorTotal:C2}");
            }
        }
    }

    // ==========================================
    // CLASSES DE MODELO (DTOs)
    // ==========================================

    // Classes para o Desafio 1
    public class ListaVendas
    {
        public List<Venda> Vendas { get; set; }
    }

    public class Venda
    {
        public string Vendedor { get; set; }
        public decimal Valor { get; set; }
    }

    // Classes para o Desafio 2
    public class ListaEstoque
    {
        public List<Produto> Estoque { get; set; }
    }

    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        
        
        [JsonPropertyName("estoque")] 
        public int QtdEstoque { get; set; }
    }
}