using CalculadoraDescontos.App;

namespace CalculadoraDescontos.Tests;

public class DescontoServiceTests
{
    [Theory]
    [InlineData(2, "BRONZE")]
    [InlineData(7, "PRATA")]
    [InlineData(15, "OURO")]
    public void ObterCategoriaCliente_DeveRetornarCategoria_ConformeTotalDeCompras(int totalCompras, string categoriaEsperada)
    {
        // Arrange
        var service = new DescontoService();
        // Act
        var resultado = service.ObterCategoriaCliente(totalCompras);
        // Assert
        Assert.Equal(categoriaEsperada, resultado);
    }

    [Theory]
    [InlineData(100, 10, 90)]
    [InlineData(200, 20, 160)]
    [InlineData(50, 0, 50)]
    public void CalcularDescontoPorPercentual_DeveRetornarValorFinal_ComDescontoAplicado(int valorOriginal, int percentualDesconto, int valorEsperado)
    {
        // Arrange
        var service = new DescontoService();
        // Act
        var resultado = service.CalcularDescontoPorPercentual(valorOriginal, percentualDesconto);
        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    [Theory]
    [InlineData(20, false, true)]
    [InlineData(16, true, true)]
    [InlineData(17, false, false)]
    public void IsValidoParaCupom_DeveValidar_ElegibilidadeAoCupom(int idade, bool primeiraCompra, bool esperado)
    {
        // Arrange
        var service = new DescontoService();
        // Act
        var resultado = service.isValidoParaCupom(idade, primeiraCompra);
        // Assert
        Assert.Equal(esperado, resultado);
    }
}