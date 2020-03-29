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

### Critérios de geração de migrações

O EF Core estabelece alguns critérios para geração de migrações, que consequentemente geram alterações no banco de dados. Os critérios são:

* Mudança nas propriedades das classes de entidade, por exemplo, o nome da propriedade ou inclusão de uma nova propriedade;

* Mudança nas configurações do EF Core, por exemplo, mudar a configuração de algum relacionamento entre tabelas;

* Mudança nas propriedades **DbSet** em algum **DbContext** da aplicação. Essa mudança pode ser a alteração do nome dessa propriedade ou inclusão de uma nova propriedade.

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

Nessa seção é discutido as formas que os relacionamentos entre tabelas podem ser feitos utilizando o EF Core. Para isso podem ser utilizadas as estratégias: ``By Convention, Data annotation e Fluent API``.

A forma que estes relacionamentos podem ser feitos estão implementados na namespace ``Experiments`` do projeto ``EntityFrameworkCoreLab.Persistence``. Abaixo é apresentada uma imagem com as namespaces em destaque:

![image info](./readme-pictures/relationship-experiments.jpg)

Para entender melhor como os relacionamentos são realizados é preciso descrever os tipos de entidades participantes: ``Principal Entity, Middle Entity and Dependent Entity``.

* **Principal Entity**: Contém a propriedade chave na qual a Dependent Entity faz referência via chave estrangeira.
* **Middle Entity**: Entidade que associa a Principal Entity e Dependent Entity em um relacionamento N para N.
* **Dependent Entity**: Contém a propriedade de chave estrangeira que faz referência para a Principal Entity

As entidades são especificadas nas pastas: ``ManyToManyRelation, OneToManyRelation e OneToOneRelation``. O nome das entidades seguem a seguinte regra de nomenclatura:

    <Tipo da entidade><estratégia de relacionamento><sigla do tipo de relacionamento>.cs

**Tipo da entidade**: Principal Entity, Middle Entity e Dependent Entity;

**Estratégia de relacionamento**: By Convention, Data annotation e Fluent API;

**Sigla do tipo de relacionamento**: OTO (one to one), OTM (one to many), MTM (many to many).

**Exemplo de nome de entidade:** ``PrincipalEntityByConventionOTM.cs``

    A experiência do autor na criação e desenvolvimento deste projeto aponta que a melhor estratégia para criação de relacionamentos entre entidades é a *By Convention*. O projeto se torna mais simples e intuitivo no entendimento.

Abaixo são citadas algumas características importantes de cada tipo de relacionamento.

### Um para Um (1 x 1)

Por padrão o EF Core cria um campo que pode assumir **valores nulos** na base de dados. Esse campo é chave estrangeira para a tabela dependente e assume o padrão de exclusão ``ReferentialAction.Restrict``. Caso seja inserida a ``DataAnnotation [Required]`` assume o padrão de exclusão ``ReferentialAction.Cascade``.

Pode ser feito de duas formas:

1 - Uma propriedade na classe principal referenciando a classe dependente com uma propriedade na classe dependente que representa a chave da principal;

2 - O inverso. Uma propriedade na classe principal que representa a chave da dependente com uma propriedade na classe dependente referenciando a classe principal;

### Um para N (1 x N)

Caso não exista o id da entidade principal na entidade dependente o EF Core a insere como `shadow property`. É recomendado inserir a propriedade id que referencia a entidade principal para fins de maior clareza no modelo de dados.

### N para N (N x N)

Por padrão o EF Core não define as duas chaves estrangeiras na tabela associativa como chave primária composta. Deve ser adicionada uma chave extra ou usada uma configuração para definir os dois campos como chave. Exemplo:
	
	modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });  
	 
Não é necessário incluir a classe que representa a tabela associativa no DbSet para que ela seja criada no banco de dados.


## Considerações sobre performance

## Dicas rápidas

### Índices

**Criar um índice**
    
    modelBuilder.Entity<MyEntity>().HasIndex(p => p.MyProp); 

**Criar índice com múltiplos campos**

    modelBuilder.Entity<MyEntity>().HasIndex(p => new {p.MyProp01, p.MyProp02}); 

**Criar índice nomeado**

    modelBuilder.Entity<MyEntity>().HasIndex(p => p.MyProp).HasName("Index_MyProp");

**Criar índice único (unique key)**

    modelBuilder.Entity<MyEntity>().HasIndex(p => p.MyProp).IsUnique();

### Schemas e Tabelas

**Aplicar schema e nome de tabela (Data Annotation)**

    [Table("TableName", Schema = "SchemaName")]
    public class MyEntity
    {

    }

**Aplicar schema e nome de tabela (Fluent API)**

    modelBuilder.Entity<MyEntity>().ToTable("TableName", "SchemaName");

**Valores padrões em colunas**

    modelBuilder.Entity<MyEntity>().Property(p => p.MyProp).HasDefaultValue(3);

    modelBuilder.Entity<MyEntity>().Property(p => p.MyProp).HasDefaultValueSql("getdate()");

### Chaves primárias

**Criar tabela sem chave primária**

    modelBuilder.Entity<MyEntity>().HasNoKey();

**Criar tabela com chave primária sem autoincremento**

    modelBuilder.Entity<MyEntity>().Property(p => p.MyProp).ValueGeneratedNever();

**Criar tabela com chave primária composta**

    modelBuilder.Entity<MyEntity>().HasKey(p => new { p.MyProp01, p.MyProp02 });



## Autores

* **Stenio Nobres** - [Github](https://github.com/stenionobres)