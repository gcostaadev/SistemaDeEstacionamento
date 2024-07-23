namespace SistemaDeEstacionamento.Models
{

    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();


        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Pedir para o usuário digitar uma placa e adicionar na lista "veiculos" 

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se a placa já está na lista (se o veículo já está estacionado)

            if (veiculos.Contains(placa))
            {
                Console.WriteLine($"Veículo com placa {placa} já está estacionado.");
            }

            // Se a placa não estiver duplicada, ela é adicionada à lista de veículos com sucesso

            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso!");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Contains(placa))  // Verifica se o veículo existe
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");


                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)  // Verificação: garantindo que a quantidade de horas seja um número válido e não negativo
                {

                    // Cálculo do valor total

                    decimal valorTotal = CalcularValorTotal(horas); // Extração da lógica para o método privado

                    // Remover a placa digitada da lista de veículos

                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        // Método privado para calcular o valor total com a finalidade de deixar o código mais modular 
        private decimal CalcularValorTotal(int horas)
        {
            return precoInicial + (precoPorHora * (horas - 1 ) );
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                // laço de repetição, exibindo os veículos estacionados

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

