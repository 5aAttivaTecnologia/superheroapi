# APISuperHeroe

## Introdução 
API desenvolvida para uso da 5A Attiva nos testes práticos de novos colaboradores para a equipe de Front End.

## O Que Faz?
Essa API tem a função de simular algumas das atividades prestadas seguindo os mesmos preceitos e configurações para que os candidatos possam ser testados em situação semelhante as atividade diárias da equipe de Front End para onde os candidatos serão alocados.
Possui 4 métodos:

1 - /api/Superheroes/buscarusuario => Busca Usuário => esse método faz a busca do usuário que está efetuando o teste à partir de seu cpf. Uma vez digitado o cpf, a API busca se o mesmo já é cadastrado e caso seja, atualiza o token vinculado ao cpf e a data e hora de alteração atualizada. Caso não encontre o usuário, efetua o cadastro desse usuário e gera um token assim como a data e hora dessa criação. 

2 - /api/Superheroes/BuscarHeroisPorId => Busca Personagem Por Id => Neste método o usuário faz a busca das informações de um personagem cadastrado no Banco de Dados através de 2 parâmetros: Id => Valor inteiro qualquer entre 1 e 264. Qualquer valor fora desse range voltará nulo; Token => expressão alfanumérica de 30 caracteres vinculada ao cpf do usuário logado. Esse token mensalmente perde a validade, sendo necessário atualizar o mesmo para acesso aos dados dos personagens. Assim como, toda vez que o usuário efetua sua autenticação pelo método buscausuario o token é atualizado. Portanto toda vez que receber o retorno 401 : Acesso não autorizado, efetuar a autenticação pelo buscausuario e em seguida com posse do token, refazer a operaçao de busca do personagem com o novo token.

3 - /api/Superheroes/BuscarHeroisPorNome => Busca Personagem Por Nome => Método, onde o usuário efetua a busca de personagens através do nome ou parte do nome do personagem. Os dados de cada personagen serão distribuídos em formato de lista para o usuário. Possui 2 parâmetros: nome => usuário digita o nome ou parte do nome do personagem desejado receber na lista.; Token => expressão alfanumérica de 30 caracteres vinculada ao cpf do usuário logado. Esse token mensalmente perde a validade, sendo necessário atualizar o mesmo para acesso aos dados dos personagens. Assim como, toda vez que o usuário efetua sua autenticação pelo método buscausuario o token é atualizado. Portanto toda vez que receber o retorno 401 : Acesso não autorizado, efetuar a autenticação pelo buscausuario e em seguida com posse do token, refazer a operaçao de busca do personagem com o novo token.

4 - /api/Superheroes/ListaSuperHeroisPorPagina => Busca Lista de Heróis Paginada => Método , onde o usuário efetua a busca de uma lista de personagens de algums formas diferentes. Por parte do nome, página. Também pode definir quantos personagensm no máximo venham na pesquisa, ou quantidade de personagens por página, assim selecionar a página desejada para visualizar a lista de personagens. Possui 4 parâmetros:  nome => usuário digita o nome ou parte do nome do personagem desejado receber na lista.; página => define o número da página que deseja receber a lista de personagens. Opção default é e sempre será a página 1; qtheroispagina => quantidade de herois por página. com esse parâmetro define a forma de paginação da lista. por default a quantidade padrão sempre será 9 personagens por página. ;Token => expressão alfanumérica de 30 caracteres vinculada ao cpf do usuário logado. Esse token mensalmente perde a validade, sendo necessário atualizar o mesmo para acesso aos dados dos personagens. Assim como, toda vez que o usuário efetua sua autenticação pelo método buscausuario o token é atualizado. Portanto toda vez que receber o retorno 401 : Acesso não autorizado, efetuar a autenticação pelo buscausuario e em seguida com posse do token, refazer a operaçao de busca do personagem com o novo token.

## Conexão a API

## Como Utilizar?

## Formato de Retorno da API
