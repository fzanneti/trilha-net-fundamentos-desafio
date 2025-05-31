// Projeto finalizado do curso de Fundamentos de Programação C#
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        // Preço fixo cobrado na entrada
        private decimal precoInicial = 0.00M;
        // Preço por hora adicional de permanência
        private decimal precoPorHora = 0.00M;
        // Lista que armazena as placas dos veículos atualmente estacionados
        private List<string> veiculos = new List<string>();


        // Construtor para inicializar o estacionamento com os preços definidos
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }


        // Métodos para adicionar um veículo à lista
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            /*
                - Usa List.Exists() com um lambda para verificar se já existe uma placa igual na lista.
                - Compara ignorando diferença entre maiúsculas/minúsculas (StringComparison.OrdinalIgnoreCase), então ABC1234 e abc1234 são considerados iguais.
                - Se encontrar a placa, exibe uma mensagem de aviso, caso contrário, adiciona a placa à lista.
            */
            if (veiculos.Exists(veiculo => veiculo.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Esse veículo já está estacionado!");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine("Veículo adicionado com sucesso!");
            }
        }


        // Método para remover um veículo do estacionamento e calcular o valor a pagar
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se a placa existe na lista de veículos estacionados
            if (veiculos.Any(veiculo => veiculo.ToUpper() == placa.ToUpper()))
            {
                // Se a placa existir, solicita a quantidade de horas que o veículo permaneceu estacionado
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int horas = int.Parse(Console.ReadLine());

                // Calcula o valor total a ser cobrado
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // Remove o veículo da lista
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de R$ {valorTotal}");
            }
            else
            {
                // Se a placa não existir, exibe uma mensagem de erro
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }

        }


        // Método para listar todos os veículos atualmente estacionados
        public void ListarVeiculos()
        {
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var placa in veiculos)
                {
                    Console.WriteLine("- " + placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}