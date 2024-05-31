# Regras de implementação do projeto
Padrões do projeto para a nomenclatura de variaveis, propriedades, constantes, commits, endpoints, branches

## Variáveis e propriedades
Para a nomenclatura de váriveis e propriedades, utilizar o modelo "Camel case"
```
var valorGenerico || var ValorGenerico;
```
## Constantes e enums
Para a nomenclatura de constantes e enums, utilizar o modelo "Snake case" e sempre com letras maiúsculas
```
const VALOR_GENERICO;
```
## Commits
Para a nomenclatura de commits, utilizar um prefixo, seguido de " : " e a descrição da implementação feita

### Prefixos
- Fix : Utilizar para indicar a correção de erros
```
git commit -m "fix: Ajuste no retorno do método listarDocumentos() na DocumentoController"
```
- Feat : Utilizar para indicar novas funcionalidades
```
git commit -m "feat: Implementação crud de pedidos"
```
- Refactor : Utilizar para indicar uma refatoração
```
git commit -m "refactor: Refatoração da tela de laudos indeferidos"
```
- Revert : Utilizar para indicar a reversão de um commit ou funcionalidade
```
git commit -m "revert: retorno do método listarPedidosPendentes() na PedidosController"
```
- Config: Utilizar para indicar a configuração do ambiente de desenvolvimento ou teste;
```
git commit -m "config: Inclusão de novas variáveis de ambiente"
```

## Endpoints
Para a nomenclatura de endpoints, utilizar um verbo, sempre com letras minúsculas e separar as palavras com " - "
```
GET: listar-pedidos-pendentes
```
## Branches
Para a nomenclatura de branches, observar cada caso

- Branch principal da sprint : seguir o formato [ squad ] / [ sprint + número da sprint ] - [ trimestre ] [ ano ]
```
git checkout -b "squad23/sprint2-3t2024"
```

- Branch de implementação de HU's da sprint : seguir o formato [ squad ] / [ sprint + número da sprint ] - [ trimestre ] [ ano ] - [ hu ] - [ número hu ] - [ descrição hu ]
```
git checkout -b "squad23/sprint2-3t2024-hu-21483285-consulta-pedidos-pagos"
```

- Branch de defeito : seguir o formato [ hotfix ] - [ número defeito] - [ descrição defeito ]
```
git checkout -b "hotfix-24483831-ajuste-edicao-relatorio"
```

- Branch de implantacao : seguir o formato [ implantacao ] - [ squad ] / [ sprint + número da sprint ] - [ trimestre ] [ ano ] - [ descrição funcionalidades da implantação ]
```
git checkout -b "implantacao-squad48/sprint4-2t2024-funcionalidades-contrato-pericia"
```