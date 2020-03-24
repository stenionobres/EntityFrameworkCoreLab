# Entity Framework Core Lab

Aplicação criada com o principal objetivo de explorar os recursos e características do Entity Framework Core.

Nesta aplicação foram experimentados diversos cenários reais de uso baseados em um mini modelo de dados voltado para ecommerce.

Após os estudos de caso, as principais conclusões foram documentadas neste arquivo e servem como referência de uso e fonte de consulta.

**Versões utilizadas:**

     Net Core 3.1;
     Entity Framework Core 3.1.2;

## Como iniciar?

Instruções para iniciar e executar a aplicação em sua máquina local

## Pré-requisitos

O que precisa ser instalado na máquina para extender e depurar o projeto:

    Visual Studio Community 2019;
    Net Core SDK 3.1;
    SQL Server

## Requisitos do projeto

A fim de experimentar os recursos do Entity Framework Core e estabelecer as melhores e mais eficientes práticas de uso, alguns requisitos foram estabelecidos.

Estes requisitos tem como objetivo aproximar o estudo de caso a um cenário real de uso onde diversas características do framework devem ser exploradas.

Abaixo são listados quais requisitos a solução atende:

    Uso de múltiplos bancos de dados;
    Uso de múltiplos schemas;
    Utilizar Model First e Database First;
    Considerar relacionamento 1 x 1 entre tabelas;
    Considerar relacionamento 1 x N entre tabelas;
    Considerar relacionamento N X N entre tabelas;
    Melhor uso de DataAnnotations;
    Comportamento de inserts;
    Comportamento de updates;
    Comportamento de deletes;
    Uso de transações;
    Uso de views;
    Database seed com uso de migrações;
    Entidades que não utilizam chave auto-incremental;
    Avaliar e otimizar performance para operações com grande volume de dados;

## Modelo do banco de dados

## Estrutura do projeto

## Database First x Model First

## Estratégias no uso de migrações

Nessa seção são descritas as características dos comandos para se fazer uso de migrações e de que forma eles podem ser melhor utilizados.

As migrações podem ser utilizadas tanto na estratégia **Model First** quanto na estratégia **Database First**.

Os comandos listados estão no formato de uso no **Package Manager Console**. É necessário que no projeto tenha a dependência ``Microsoft.EntityFrameworkCore.Tools`` assim como foi descrito na sessão [Estrutura do projeto](#estrutura-do-projeto) 


## Estratégias nos relacionamentos

## Considerações sobre performance

## Dicas rápidas

## Autores

* **Stenio Nobres** - [Github](https://github.com/stenionobres)