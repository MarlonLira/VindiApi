# Vindi - SDK C# (Não Oficial)
Integração com a API da [Vindi](https://www.vindi.com.br "Vindi").

# Descrição
Este pacote foi baseado no [SDK Oficial em PHP](https://github.com/vindi/vindi-php "SDK oficial") e consiste em um SDK em C# não oficial para a [API de Recorrência](https://vindi.github.io/api-docs/dist/ "API Vindi") da [Vindi](https://www.vindi.com.br "Vindi") para fins de trabalho e estudo.

# Requisitos
- [.Net CORE 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1 ".Net Core 2.1") Projeto Vindi.
- [.Net Framework 4.5](https://www.microsoft.com/pt-br/download/details.aspx?id=30653 ".Net Framework 4.5") Projeto VindiSdk.
- [Flurl.Http](https://flurl.dev/ "Flurl")
- [Newtonsoft.json](https://www.newtonsoft.com/json "Newtonsoft.Json")
- Conta ativa na [Vindi](https://www.vindi.com.br "Vindi").

# Instalação
- Via Nuget

# Métodos de Autenticação

> Exemplos de código do Autentiacação.

```C#
//Caso Vá utilizar os metodos da classe service.
Configuration Config = new Configuration("https://app.vindi.com.br"(LINK_DA_API), 1(VERSAO_DA_API), "SUA_CHAVE_DA_API_VINDI");
Service Service = new Service(Config);

//Caso Vá utlizar os metodos da classe Vindi
Vindi Vindi = new Vindi(){
  Config = new Configuration("https://app.vindi.com.br"(LINK_DA_API), 1(VERSAO_DA_API), "SUA_CHAVE_DA_API_VINDI")
};

```

## Exemplo de implementação

> Exemplo de código do cadastro de um cliente após autenticação, 
iniciando com a instância da entidade Vindi e populando a entidade Customer, logo após, 
utilizando o metodo CreateAnythingAsync concluimos o cadastro do cliente
e recebemos suas informações no retorno do metodo.

```C#
Vindi Vindi = new Vindi();

Customer NewCustomer = new Customer(){
  Name = "José da Silva",
  RegistryCode = "34403844030",
  Email = "ze@email.com",
  Phone =  new Phone[] { 
    new Phone { Number = "5581988887777", PhoneType = "mobile"}
  }
};

/* Metodo responsavel por criar um novo cliente utilizando os dados armazenados 
 *  na entidade(Customer) retornando todos os dados referente ao cadastro do cliente.
 */
NewCustomer = (Customer)Vindi.CreateAnythingAsync(NewCustomer);

```
## Em Construção...
