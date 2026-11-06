<div align="center">

# Sistema de Estacionamento (Estrutura de Dados - Lista Circular)


<!-- BADGES -->


![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Data Structures](https://img.shields.io/badge/Data_Structures-Circular_List-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Conclu%C3%ADdo-success?style=for-the-badge)



Projeto desenvolvido em C# (.NET) para a disciplina de Estrutura de Dados, com o objetivo de simular o funcionamento operacional de um estacionamento estreito em formato de fila indiana (capacidade máxima de 8 veículos).

</div>

---

##  Sobre o Projeto

O estacionamento possui um formato retangular limitado por duas ruas, o que significa que os veículos entram e saem pelo mesmo lado ou que carros precisam ser manobrados (retirados para a rua e reinseridos no final da fila) para liberar a saída de um veículo que está no fundo. 

Para simular esse comportamento físico real com precisão, a estrutura de dados escolhida foi uma **Lista Encadeada Circular com Ponteiros** (`Início` e `Fim`), onde o último elemento aponta de volta para o primeiro.

---

##  Funcionalidades do Sistema

O programa conta com um menu interativo contendo as seguintes opções:

1. **Registrar Entrada de Veículo:** Insere um novo veículo no estacionamento (caso haja vagas disponíveis, limite de 8) e registra automaticamente o horário de chegada.
2. **Registrar Saída por Placa:** Realiza a busca pelo veículo. Caso haja carros na frente, o sistema simula a manobra girando a lista circular (os veículos saem para a rua e retornam para o final) até que o alvo chegue à saída.
3. **Listagem de Veículos:** Exibe todos os veículos atualmente no pátio, detalhando vaga, placa, modelo, marca e horário de entrada.
4. **Adicionar Veículo Aleatório (Teste Rápido):** Gera dados fictícios de veículos para testes ágeis.
5. **Lotar Estacionamento Automaticamente:** Preenche todas as 8 vagas restantes com veículos aleatórios.
6. **Retirar Todos os Carros:** Esvazia o estacionamento aplicando a lógica de manobra em sequência.
7. **Simular Horário de Entrada:** Permite retroceder o horário de entrada de um veículo específico para testar o cálculo de cobrança.
8. **Visualizar Estado dos Ponteiros:** Mostra visualmente o comportamento dos ponteiros `Início` e `Fim` na estrutura circular.

---

## Regras de Cobrança

* O estacionamento cobra **R$ 12,00 por hora**, inteira ou fracionada.
* O cálculo utiliza `TimeSpan` para capturar a permanência exata e a função `Math.Ceiling` para arredondar frações de tempo sempre para cima. 
* *Exemplo:* Se um veículo permaneceu por 2h e 40m, serão cobradas 3 horas no total (R$ 36,00).

---

## Estrutura do Projeto

O código está organizado seguindo boas práticas de separação de responsabilidades dentro da pasta `src`:

```text
seu-repositorio/
│
├── src/
│   ├── Models/
│   │   ├── Veiculo.cs          # Dados do veículo e registo de horários
│   │   └── Elemento.cs         # Nó da lista circular
│   │
│   ├── Services/
│   │   └── Estacionamento.cs   # Lógica de negócio, ponteiros e manobras
│   │
│   └── Program.cs              # Ponto de entrada e menu interativo
│
├── .gitignore
└── README.md
```
---

## Tecnologias Utilizadas
* Linguagem:  C# (.NET)
#### Conceitos Aplicados:
* Estruturas de Dados Dinâmicas (Listas Encadeadas Circulares)
* Manipulação de Ponteiros e Referências de Objetos
* Gestão de Datas e Horas (DateTime, TimeSpan)

## Como Executar o Projeto
Certifica-te de ter o SDK do .NET instalado na tua máquina.

Clona este repositório ou descarrega os ficheiros:
```bash
git clone https://github.com/lauramorgadobastos/estacionamento-lista-circular/src
```
Abre o terminal na pasta raiz do projeto.

Entra na pasta do código-fonte (se necessário) e executa:

```bash
dotnet run
```
## Sobre Mim

Desenvolvido por *Laura Morgado Bastos Gomes*  
Estudante de *Sistemas de Informação - PUC Minas*. 

### Conecte-se comigo

Você pode me encontrar nos canais abaixo:


[![Linkedin](https://img.shields.io/badge/LinkedIn-4C1D95?style=for-the-badge&logo=linkedin&logoColor=fff)](https://www.linkedin.com/in/laura-morgado-bastos?)
[![GitHub](https://img.shields.io/badge/GitHub-4C1D95?style=for-the-badge&logo=github&logoColor=fff)](https://github.com/lauramorgadobastos) 
[![Email](https://img.shields.io/badge/Email-4C1D95?style=for-the-badge&logo=gmail&logoColor=fff)](mailto:laura.bastosmorgado27@gmail.com)

---

##  Licença 
Este repositório não possui uma licença específica definida, pois tem caráter estritamente educacional e acadêmico para a disciplina de Algoritmos e Estrutura de Dados. 




