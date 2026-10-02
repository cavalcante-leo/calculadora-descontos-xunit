# CalculadoraDescontos

Sistema com regras de desconto para uma loja. A classe `DescontoService` (projeto `CalculadoraDescontos.App`) oferece:

- `ObterCategoriaCliente`: classifica o cliente em BRONZE, PRATA ou OURO conforme o total de compras.
- `CalcularDescontoPorPercentual`: retorna o valor final após aplicar o percentual de desconto (ex: 100 com 10% retorna 90).
- `isValidoParaCupom`: retorna `true` se o cliente tiver 18 anos ou mais **ou** se for a primeira compra.

## Diferença entre `[Fact]` e `[Theory]`

**`[Fact]`** marca um teste que roda uma única vez, sempre com os mesmos valores, escritos dentro do próprio método. Serve para um cenário fixo, sem variação de dados.

```csharp
[Fact]
public void CalcularDesconto_Exemplo()
{
    var service = new DescontoService();
    Assert.Equal(90, service.CalcularDescontoPorPercentual(100, 10));
}
```

**`[Theory]`** marca um teste parametrizado: o mesmo método roda várias vezes, uma para cada `[InlineData(...)]`, e os valores chegam como parâmetros. Serve para validar vários cenários da mesma regra sem duplicar código. Cada `[InlineData]` aparece como um teste separado no resultado, então é possível saber exatamente qual cenário falhou.

```csharp
[Theory]
[InlineData(100, 10, 90)]
[InlineData(200, 20, 160)]
[InlineData(50, 0, 50)]
public void CalcularDescontoPorPercentual_Exemplo(int valorOriginal, int percentual, int esperado)
{
    var service = new DescontoService();
    Assert.Equal(esperado, service.CalcularDescontoPorPercentual(valorOriginal, percentual));
}
```

Neste projeto, todos os testes da classe `DescontoServiceTests` usam `[Theory]` com três `[InlineData]` cada, em vez de um método de teste para cada cenário.

## Como executar os testes

Pré-requisito: [.NET SDK](https://dotnet.microsoft.com/download) instalado. Para conferir:

```bash
dotnet --version
```

Na raiz da solução (pasta que contém `CalculadoraDescontos.App` e `CalculadoraDescontos.Tests`), execute:

```bash
dotnet test
```

Para rodar apenas o projeto de testes:

```bash
dotnet test CalculadoraDescontos.Tests
```

Para ver o nome de cada teste executado:

```bash
dotnet test --logger "console;verbosity=detailed"
```

Ao final, o terminal exibe o resumo com o total de testes aprovados, falhos e ignorados.