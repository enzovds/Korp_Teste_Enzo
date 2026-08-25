# 🛒 Sistema de Controle de Estoque e Emissão de Notas Fiscais (Korp)

Aplicação desenvolvida como parte do teste técnico, estruturada em **Arquitetura de Microsserviços**, integrando um microsserviço de Estoque, um de Faturamento e um Front-end moderno construído em Angular.

## 🚀 Tecnologias Utilizadas

- **Backend:** C#, .NET Core, Entity Framework Core, LINQ, ASP.NET Core Web API.
- **Frontend:** Angular (Standalone Components), TypeScript, HTML5, CSS3, RxJS.
- **Banco de Dados:** Relacional (via EF Core).
- **Arquitetura:** Comunicação síncrona entre microsserviços via requisições HTTP (`HttpClient`).

---

## ⚙️ Funcionalidades Implementadas

1. **Gestão de Estoque:** Cadastro de produtos com validações estritas, listagem e remoção de itens.
2. **PDV / Vendas:** Abertura de notas fiscais informando o cliente e os itens desejados.
3. **Baixa Automática (Microsserviços):** Ao solicitar a impressão de uma nota, uma requisição é disparada para o microsserviço de Estoque para abater o saldo do produto correspondente em tempo real.
4. **Resiliência e Tratamento de Erros:** Alertas amigáveis ao usuário em caso de falhas de comunicação.
5. **Atualização Dinâmica de UI:** Uso de `ChangeDetectorRef` para garantir reatividade imediata na interface.

---

## 📥 Como Executar o Projeto

Certifique-se de ter o **.NET SDK** e o **Node.js** instalados na sua máquina.

### 1. Clonar o Repositório

    git clone <https://github.com/enzovds/Korp_Teste_Enzo>
    cd <Korp_Estoque>

### 2. Rodar o Microsserviço de Estoque
Abra um terminal na pasta do serviço de estoque:

    cd EstoqueService
    dotnet ef database update
    dotnet run --urls="http://localhost:5211"

### 3. Rodar o Microsserviço de Faturamento
Abra um segundo terminal na pasta do serviço de faturamento:

    cd FaturamentoService
    dotnet ef database update
    dotnet run --urls="http://localhost:5205"

### 4. Rodar o Frontend (Angular)
Abra um terceiro terminal na pasta do frontend:

    cd frontend
    npm install
    ng serve

Acesse a aplicação no navegador em: `http://localhost:4200`

---
Desenvolvido por **Enzo Vinicius Damião da Silva**.