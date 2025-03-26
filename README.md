# Sistema de Cadastro de Contatos

Este é um sistema de cadastro de contatos simples desenvolvido em C# com Windows Forms e banco de dados Access. O sistema permite realizar operações básicas de CRUD (Criar, Ler, Atualizar e Excluir) de contatos, como nome, telefone, e-mail, cidade e estado (UF).

## Funcionalidades

### 1. **Consultar Contatos**
   O sistema permite consultar um contato pelo seu ID. Ao realizar a busca, os dados do contato (nome, telefone, e-mail, cidade e UF) são carregados nos campos do formulário. Caso o registro não seja encontrado, uma mensagem de erro será exibida.

### 2. **Inserir Novo Contato**
   O sistema permite inserir novos contatos no banco de dados. O nome, telefone, e-mail, cidade e estado (UF) precisam ser preenchidos para que o registro seja inserido corretamente. Se um contato com o mesmo nome já existir, será exibida uma mensagem de alerta.

### 3. **Alterar Contato**
   Após consultar um contato, é possível editar suas informações. O sistema permite alterar os dados e atualizar o registro no banco de dados.

### 4. **Excluir Contato**
   O sistema também permite excluir um contato. Após consultar um contato, o botão de exclusão é habilitado, permitindo a remoção do registro do banco de dados.

## Banco de Dados

Este sistema utiliza o banco de dados **Microsoft Access**. Para o funcionamento correto, é necessário configurar o caminho do banco de dados Access no código. No exemplo do código, o caminho do banco de dados é:

```csharp
string strCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\joão\bd_22_banco.mdb";
```
Nota: Modifique o caminho do banco de dados de acordo com a sua configuração local.
## Estrutura do Código
O sistema é composto pela classe Form2, que implementa as funcionalidades de CRUD para o gerenciamento dos contatos. As operações de banco de dados são realizadas utilizando a biblioteca OleDb para acessar o banco de dados Access.

### Principais Métodos:
btn_consultar_Click: Realiza a consulta de um contato pelo ID e exibe as informações nos campos de texto.

Btn_inserir_Click: Insere um novo contato no banco de dados após verificar se o nome não está duplicado.

LimparDados: Limpa todos os campos de entrada após uma operação (consultar, inserir ou editar).

Form2_Load: Configura o formulário, desabilitando os botões de alteração e exclusão ao iniciar.

## Instruções de Uso
Abra o sistema: Ao iniciar o sistema, a tela de cadastro será exibida.

Consultar: Preencha o campo de ID e clique em "Consultar" para buscar um contato. Se encontrado, os dados serão carregados nos campos correspondentes.

Inserir: Para adicionar um novo contato, preencha os campos de nome, telefone, e-mail, cidade e estado, e clique em "Inserir".

Alterar: Após consultar um contato, você pode editar os dados e clicar em "Alterar" para atualizar o registro.

Excluir: Após consultar um contato, você pode excluir o registro clicando em "Excluir".

## Dependências
Microsoft.Jet.OLEDB.4.0: Usado para acessar o banco de dados Access.

## Considerações Finais
Este projeto é um exemplo simples de como utilizar o Windows Forms para criar uma interface gráfica em C# que interage com um banco de dados Access. Ele é útil para aprender sobre operações de banco de dados e manipulação de dados em sistemas Windows.
