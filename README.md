# 🚀 Desafio Técnico – C# (.NET Console)

Este repositório contém a implementação completa dos 3 desafios técnicos propostos, utilizando C# e .NET, com código limpo, organizado e totalmente funcional.


## 📌 **1️⃣ Cálculo de Comissão por Vendedor**

O programa lê todas as vendas fornecidas no JSON do desafio e aplica as regras:

* Vendas < **R$100** → **0%**
* Vendas de **R$100 a R$499** → **1%**
* Vendas **≥ R$500** → **5%**

Ao final, exibe a comissão total de cada vendedor:

* João Silva
* Maria Souza
* Carlos Oliveira
* Ana Lima


## 📦 **2️⃣ Movimentação de Estoque**

Com base no JSON de produtos, o sistema:

* Permite registrar **entrada** ou **saída** de produtos
* Cada movimentação possui:

  * ID
  * Tipo (Entrada / Saída)
  * Quantidade
  * Estoque inicial e final
  * Descrição

Movimentações foram criadas para **todos os 5 produtos**.


## 🧮 **3️⃣ Cálculo de Juros (2,5% ao dia)**

Com base em um valor e uma data de vencimento, o sistema calcula:

* Dias em atraso
* Juros totais
* Valor final atualizado

A multa utilizada é de **2,5% ao dia** conforme solicitado.


## ▶️ Como Executar o Projeto

1. Certifique-se de ter o **.NET SDK** instalado.
2. No terminal, navegue até a pasta do projeto.
3. Execute:

dotnet run


## 📤 **Exemplo de Saída no Terminal**


===== TESTE TÉCNICO =====

=== Comissões Calculadas ===
João Silva: R$ 495,68
Maria Souza: R$ 465,95
Carlos Oliveira: R$ 379,37
Ana Lima: R$ 404,98


=== Movimentações de Estoque ===

ID: 1
Produto: 101 - Caneta Azul
Tipo: Saída
Quantidade: -10
Estoque Inicial: 150
Estoque Final: 140
Descrição: Saída para venda
-----------------------------

ID: 2
Produto: 102 - Caderno Universitário
Tipo: Entrada
Quantidade: +20
Estoque Inicial: 75
Estoque Final: 95
Descrição: Reposição de estoque
-----------------------------

ID: 3
Produto: 103 - Borracha Branca
Tipo: Saída
Quantidade: -15
Estoque Inicial: 200
Estoque Final: 185
Descrição: Saída para consumo interno
-----------------------------

ID: 4
Produto: 104 - Lápis Preto HB
Tipo: Entrada
Quantidade: +30
Estoque Inicial: 320
Estoque Final: 350
Descrição: Entrada por compra
-----------------------------

ID: 5
Produto: 105 - Marcador de Texto Amarelo
Tipo: Saída
Quantidade: -5
Estoque Inicial: 90
Estoque Final: 85
Descrição: Saída por avaria
-----------------------------

=== Cálculo de Juros ===
Dias de atraso: 321
Juros: R$ 8025,00
Valor Final: R$ 9025,00

