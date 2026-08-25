# Korp ERP - Teste Técnico (Estoque e Faturamento)

Este projeto foi desenvolvido como parte do teste técnico para a vaga de Desenvolvimento da Korp.

## 🚀 Tecnologias Utilizadas

**Frontend:**
* Angular 
* RxJS (Uso de Observables para chamadas assíncronas sem travar a UI)
* Ciclos de Vida: Utilização do `ngOnInit` para carregar dados iniciais de Notas e Produtos.

**Backend:**
* C# / .NET 
* Entity Framework Core (ORM para persistência física com banco de dados)
* LINQ: Utilizado para consultas ao banco (ex: `ToListAsync()`, `FirstOrDefaultAsync()`).

## ⚙️ Arquitetura e Funcionalidades
* **Microsserviços:** O sistema é dividido em dois serviços principais (Estoque e Faturamento) que se comunicam via HTTP.
* **Resiliência:** Tratamento de falhas implementado. Caso o serviço de estoque fique indisponível, o sistema impede a impressão da nota e alerta o usuário.
* **Funcionalidades:** Cadastro de produtos, PDV para emissão de notas fiscais com múltiplos itens, simulação de impressão com feedback visual e baixa automática de estoque.