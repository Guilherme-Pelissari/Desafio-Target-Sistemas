# Desafio Técnico - Lógica de Programação e C#

Este repositório contém uma aplicação Console em .NET desenvolvida para resolver três desafios de lógica de programação, envolvendo manipulação de JSON, cálculos financeiros e controle de fluxo.

## 🚀 Desafios Implementados

O projeto consiste em um menu interativo com as seguintes funcionalidades:

### 1. Cálculo de Comissões de Vendas
Processa um arquivo JSON contendo registros de vendas e calcula a comissão individual de cada vendedor com base nas seguintes regras de negócio:
- **Venda < R$ 100,00:** Sem comissão.
- **Venda >= R$ 100,00 e < R$ 500,00:** 1% do valor.
- **Venda >= R$ 500,00:** 5% do valor.
*Exibe o total detalhado por vendedor e o total geral de comissões.*

### 2. Controle de Estoque (Entrada/Saída)
Sistema simples de gerenciamento de inventário que lê um JSON inicial de produtos e permite:
- Dar entrada em mercadorias.
- Dar saída em mercadorias (com validação de saldo insuficiente).
- Gerar um ID único de transação (GUID) para cada movimentação.

### 3. Calculadora de Juros (Boleto em Atraso)
Calcula o valor atualizado de uma conta com base na data de vencimento e na data atual.
- **Regra:** Multa de 2,5% ao dia corrido de atraso.
- Utiliza a classe `DateTime` para cálculo preciso da diferença de dias.

---

## 🛠️ Tecnologias Utilizadas

- **C#** (Linguagem principal)
- **.NET SDK** (Plataforma de desenvolvimento)
- **System.Text.Json** (Biblioteca nativa para serialização/deserialização de dados)
- **Git** (Controle de versão)

## ⚙️ Como Rodar o Projeto

### Pré-requisitos
Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.

### Passo a passo

1. **Clone o repositório:**
   ```bash
   git clone
   ```

### Acesse a pasta do projeto:
```bash
cd Desafio-Target-Sistemas
```

### Execute a aplicação:
```bash
dotnet run
```

---

## 🧩 Estrutura do Código

Para fins de simplicidade e facilidade de teste (**Single-File Application**), todo o código reside em `Program.cs`, mas organizado logicamente em:

- **Menu Principal:** Loop de interação com o usuário.
- **Métodos Estáticos:** Separação da lógica de cada desafio (`ExecutarDesafio1`, `ExecutarDesafio2`, etc.).
- **Classes de Modelo (DTOs):** Classes usadas para mapear os objetos JSON (`Venda`, `Produto`).

---

## 👨‍💻 Autor

Desenvolvido por **Guilherme Pelissari** como parte de um desafio técnico.
