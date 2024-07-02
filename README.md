# TaskListApi

TaskListApi é uma API RESTful para gerenciar uma lista de tarefas. Esta aplicação está desenvolvida em .NET 7, utiliza MongoDB para armazenamento de dados e está configurada para rodar em containers Docker.

## Rotas da API

### Tarefas

- `GET /api/tasks`: Retorna todas as tarefas.
- `GET /api/tasks/{id}`: Retorna uma tarefa específica pelo ID.
- `POST /api/tasks`: Cria uma nova tarefa.
  - **Exemplo de Payload JSON**:
    ```json
    {
      "title": "Nova Tarefa",
      "description": "Descrição da tarefa",
      "isCompleted": false
    }
    ```
- `PUT /api/tasks/{id}`: Atualiza uma tarefa específica pelo ID.
  - **Exemplo de Payload JSON**:
    ```json
    {
      "title": "Tarefa Atualizada",
      "description": "Descrição atualizada",
      "isCompleted": true
    }
    ```
- `DELETE /api/tasks/{id}`: Deleta uma tarefa específica pelo ID.

## Subindo a Aplicação

### Pré-requisitos

- [Docker](https://www.docker.com/get-started) instalado na sua máquina.
- [Docker Compose](https://docs.docker.com/compose/install/) instalado na sua máquina.

### Passos para Subir a Aplicação

1. Clone o repositório para sua máquina local:

    ```bash
    git clone https://github.com/seu-usuario/TaskListApi.git
    cd TaskListApi
    ```

2. Construa e suba os containers usando Docker Compose:

    ```bash
    docker-compose up --build
    ```

3. Acesse a aplicação no seu navegador:

    ```
    http://localhost:3000
    ```

    O Swagger UI estará disponível em `http://localhost:3000` para explorar e testar as rotas da API.

### Parando a Aplicação

Para parar a aplicação e remover os containers, execute:

```bash
docker-compose down
