# Entity Framework Core Lab

Aplicação criada com o principal objetivo de explorar os recursos e características do Entity Framework Core.

Nesta aplicação foram experimentados diversos cenários reais de uso baseados em um mini modelo de dados voltado para ecommerce.

Após os estudos de caso, as principais conclusões foram documentadas neste arquivo e servem como referência de uso e fonte de consulta.

**Versões utilizadas:**

     Net Core 3.1;
     Entity Framework Core 3.1.2;
     Entity.Framework.Core.Sql.Server 3.1.2;
     Microsoft.EntityFrameworkCore.Tools 3.1.2;

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

### Arquivo ModelSnapshot

Migrações criam um **snapshot** do schema atual do banco de dados no arquivo ``Migrations/<DbContextName>ModelSnapshot.cs``. Quando uma migração é adicionada, EF Core determina quais mudanças serão aplicadas comparando o modelo de dados com o arquivo de snapshot.

### Principais comandos no uso de migrações

    Add-Migration <MigrationName> -Context <ClassName of context>

O comando acima gera um arquivo na pasta ``Migrations`` com o padrão de nomenclatura ``utc_datetime_<MigrationName>.cs``, onde ``utc_datetime`` é um timestamp gerado com a data, hora minuto e segundos baseados no Coordinated Universal Time (UTC).

Atualiza o arquivo ``ModelSnapshot`` na pasta ``Migrations`` com a diferença entre o modelo de dados e o arquivo ModelSnapshot.

Não se pode usar um ``<MigrationName>`` que já foi utilizado em outro arquivo, mesmo que se altere o ModelSnapshot.

Se todo o modelo de dados já estiver relacionado no arquivo ``ModelSnapshot`` será criado um arquivo de migração com os **métodos Up e Down vazios**.

É possível executar sql puro no arquivo de migração através da chamada ``migrationBuilder.Sql()`` dentro do metodo Up ou Down.

Ao criar uma migração, o conteúdo do arquivo ``design`` da migração anterior é acrescentado no arquivo design na nova migração.

    Remove-Migration -Context <ClassName of context>

O comando acima remove o arquivo de migração gerado pelo comando ``Add-Migration``. O arquivo removido será o de maior timestamp que ainda não tenha sido aplicado ao banco de dados e/ou não esteja na tabela ``__EFMigrationsHistory``. O arquivo ModelSnapshot também é atualizado.

Os arquivos de migração removidos são inseridos no ``arquivo .csproj`` do projeto.

    Update-Database -Context <ClassName of context>

Aplica todos os arquivos de migrações, do menor para o maior timestamp, que ainda não existem na tabela ``__EFMigrationsHistory``.

    Update-Database -Migration <MigrationName> -Context <ClassName of context>

Aplica na base de dados as instruções contidas no arquivo de design da migração passado no parâmetro. Isso ocorre somente se o arquivo de design relacionado a migração, citada no parâmetro, ainda não existir na tabela ``__EFMigrationsHistory``.

É importante ressaltar que todo arquivo **design de migração** possui o código de design de todas as outras migrações de menores timestamp. Isso possibilita que as alterações anteriores sejam aplicadas caso o nome dos arquivos de migrações anteriores ainda não existam na tabela ``__EFMigrationsHistory``.

Esse comando também realiza a **chamada do método Down** de terminada migração. Para isso ocorrer ele deve ser executado com o nome de alguma migração anterior a que se deseja executar o método Down. Todas as migrações com timestamp maior que a migração citada no parâmetro terão seus métodos Down executados do maior para o menor timestamp.

    Update-Database -Context <ClassName of context> -Migration 0

Reverte todas as alterações, do maior para o menor timestamp, aplicadas na base de dados feitas por migrações. Não altera o arquivo ``ModelSnapshot``.

    Script-Migration -From 0

Gera o script sql de todos arquivos de migração independente de estar ou não na tabela ``__EFMigrationsHistory``.

    Script-Migration -From <MigrationName> -To <MigrationName>

Gera o script sql de um determinado arquivo de migração independente de estar ou não na tabela ``__EFMigrationsHistory``.

## Estratégias nos relacionamentos

## Considerações sobre performance

## Dicas rápidas

## Autores

* **Stenio Nobres** - [Github](https://github.com/stenionobres)