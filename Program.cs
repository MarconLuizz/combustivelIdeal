using System;

class Program
{
  static void Main()
  {
    // Initial presentation
    Console.WriteLine("|__| Descubra se deve abastecer com álcool ou gasolina |__|\n");

    Console.WriteLine("Digite os valores em reais (R$).\n");

    // Data input: ethanol price
    Console.WriteLine("Digite qual o valor do etanol: ");
    if (!double.TryParse(Console.ReadLine(), out double precoEtanol))
    {
      Console.WriteLine("Preço inválido.");
      return;
    }

    // Data input: gasoline price
    Console.WriteLine("Digite qual o valor da gasolina: ");
    if (!double.TryParse(Console.ReadLine(), out double precoGasolina))
    {
      Console.WriteLine("Preço inválido.");
      return;
    }

    // Data input: tank capacity in liters
    Console.WriteLine("Digite a capacidade em litros do tanque do seu carro:");
    if (!int.TryParse(Console.ReadLine(), out int capacidadeTanque))
    {
      Console.WriteLine("Valor inválido.");
      return;
    }

    // Data input: fuel efficiency with ethanol (km/L)
    Console.WriteLine("Digite quantos km/L seu carro faz no etanol:");
    if (!double.TryParse(Console.ReadLine(), out double kmlEtanol))
    {
      Console.WriteLine("Valor inválido.");
      return;
    }

    // Data input: fuel efficiency with gasoline (km/L)
    Console.WriteLine("Digite quantos km/L seu carro faz na gasolina:");
    if (!double.TryParse(Console.ReadLine(), out double kmlGasolina))
    {
      Console.WriteLine("Valor inválido.");
      return;
    }

    // Calculations
    double precoTanqueEtanol = CalcPrecoTanque(precoEtanol, capacidadeTanque); // Price to fill the tank with ethanol
    double precoTanqueGasolina = CalcPrecoTanque(precoGasolina, capacidadeTanque); // Price to fill the tank with gasoline

    double autonomiaEtanol = CalcAutonomia(capacidadeTanque, kmlEtanol); // Range with ethanol
    double autonomiaGasolina = CalcAutonomia(capacidadeTanque, kmlGasolina); // Range with gasoline

    double cpkEtanol = CalcCpkCombustivel(precoTanqueEtanol, autonomiaEtanol); // Cost per km driven with ethanol
    double cpkGasolina = CalcCpkCombustivel(precoTanqueGasolina, autonomiaGasolina); // Cost per km driven with gasoline

    string melhorOpcao = DefMelhorOpcao(cpkEtanol, cpkGasolina); // Determine the best refueling option

    // Output
    Console.WriteLine($"\n Valores para completar o tanque:");
    Console.WriteLine($"Etanol: R$ {precoTanqueEtanol:F2}");
    Console.WriteLine($"Gasolina: R$ {precoTanqueGasolina:F2}");

    Console.WriteLine($"\n Autonomia:");
    Console.WriteLine($"Etanol: {autonomiaEtanol:F2} km");
    Console.WriteLine($"Gasolina: {autonomiaGasolina:F2} km");

    Console.WriteLine($"\n Custo por km rodado:");
    Console.WriteLine($"Etanol: R$ {cpkEtanol:F2}/km");
    Console.WriteLine($"Gasolina: R$ {cpkGasolina:F2}/km");

    Console.WriteLine($"\n🚦 Melhor opção de abastecimento: {melhorOpcao}");
  }

  // Function to calculate the amount needed to fill the tank
  static double CalcPrecoTanque(double precoCombustivel, int capacidadeTanque)
  {
    return precoCombustivel * capacidadeTanque;
  }

  // Function to calculate total range with a specific fuel
  static double CalcAutonomia(int capacidadeTanque, double kmlCombustivel)
  {
    return capacidadeTanque * kmlCombustivel;
  }

  // Function to calculate cost per kilometer driven
  static double CalcCpkCombustivel(double precoTotal, double autonomiaTotal)
  {
    return precoTotal / autonomiaTotal;
  }

  // Function to determine which fuel offers the lowest cost per km
  static string DefMelhorOpcao(double cpkEtanol, double cpkGasolina)
  {
    return (cpkEtanol < cpkGasolina) ? "Etanol" : "Gasolina";
  }
}
