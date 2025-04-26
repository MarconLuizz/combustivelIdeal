using System;

class Program
{
  static void Main()
  {
    Console.WriteLine("|__| Descubra se deve abastecer com álcool ou gasolina |__|\n");

    Console.WriteLine("Digite os valores em reais (R$).\n");

    // Entrada de dados
    Console.WriteLine("Digite qual o valor do etanol: ");
    if (!double.TryParse(Console.ReadLine(), out double precoEtanol))
    {
      Console.WriteLine("Preço inválido.");
      return;
    }

    Console.WriteLine("Digite qual o valor da gasolina: ");
    if (!double.TryParse(Console.ReadLine(), out double precoGasolina))
    {
      Console.WriteLine("Preço inválido.");
      return;
    }

    Console.WriteLine("Digite a capacidade em litros do tanque do seu carro:");
    if (!int.TryParse(Console.ReadLine(), out int capacidadeTanque))
    {
      Console.WriteLine("Valor inválido.");
      return;
    }

    Console.WriteLine("Digite quantos km/L seu carro faz no etanol:");
    if (!double.TryParse(Console.ReadLine(), out double kmlEtanol))
    {
      Console.WriteLine("Valor inválido.");
      return;
    }

    Console.WriteLine("Digite quantos km/L seu carro faz na gasolina:");
    if (!double.TryParse(Console.ReadLine(), out double kmlGasolina))
    {
      Console.WriteLine("Valor inválido.");
      return;
    }

    // Cálculos
    double precoTanqueEtanol = CalcPrecoTanque(precoEtanol, capacidadeTanque);
    double precoTanqueGasolina = CalcPrecoTanque(precoGasolina, capacidadeTanque);

    double autonomiaEtanol = CalcAutonomia(capacidadeTanque, kmlEtanol);
    double autonomiaGasolina = CalcAutonomia(capacidadeTanque, kmlGasolina);

    double cpkEtanol = CalcCpkCombustivel(precoTanqueEtanol, autonomiaEtanol);
    double cpkGasolina = CalcCpkCombustivel(precoTanqueGasolina, autonomiaGasolina);

    string melhorOpcao = DefMelhorOpcao(cpkEtanol, cpkGasolina);

    // Saída de dados
    Console.WriteLine($"\n🔋 Valores para completar o tanque:");
    Console.WriteLine($"Etanol: R$ {precoTanqueEtanol:F2}");
    Console.WriteLine($"Gasolina: R$ {precoTanqueGasolina:F2}");

    Console.WriteLine($"\n📏 Autonomia:");
    Console.WriteLine($"Etanol: {autonomiaEtanol:F2} km");
    Console.WriteLine($"Gasolina: {autonomiaGasolina:F2} km");

    Console.WriteLine($"\n💰 Custo por km rodado:");
    Console.WriteLine($"Etanol: R$ {cpkEtanol:F2}/km");
    Console.WriteLine($"Gasolina: R$ {cpkGasolina:F2}/km");

    Console.WriteLine($"\n🚦 Melhor opção de abastecimento: {melhorOpcao}");
  }

  static double CalcPrecoTanque(double precoCombustivel, int capacidadeTanque)
  {
    return precoCombustivel * capacidadeTanque;
  }

  static double CalcAutonomia(int capacidadeTanque, double kmlCombustivel)
  {
    return capacidadeTanque * kmlCombustivel;
  }

  static double CalcCpkCombustivel(double precoTotal, double autonomiaTotal)
  {
    return precoTotal / autonomiaTotal;
  }

  static string DefMelhorOpcao(double cpkEtanol, double cpkGasolina)
  {
    return (cpkEtanol < cpkGasolina) ? "Etanol" : "Gasolina";
  }
}
