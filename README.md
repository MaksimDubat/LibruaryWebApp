# LibruaryWebApp

LibruaryWebApp - Приложение для управления библиотекой, включая работу с пользователями, книгами и ролями.

## Требования

.NET SDK 6.0 (https://dotnet.microsoft.com/)
PostgreSQL (https://www.postgresql.org/)
Git (https://git-scm.com/)

## Шаги для запуска

1. Клонирование репозитория:
   git clone https://github.com/MaksimDubat/LibruaryWebApp.git

Переход в папку проекта:
cd LibruaryWebApp

2. Настройка БД:
   Создание контейнера БД.
   docker run -d -p 5432:5432 --name lib-postgres -e POSTGRES_PASSWORD=password -e POSTGRES_USER=admin -e PGDATA=/var/lib/postgresql/data/pgdata -v /var/lib/postgres:/var/lib/postgresql/data postgres:17

Настройка appsettings.json:
"ConnectionStrings": {
"DefaultConnection": "Host=localhost;Port=5432;Database=postgres;Username=admin;Password=password"
}

Выполненение миграций:
dotnet ef database update

3. Сборка проекта:
   dotnet build

4. Запуск проекта:
   dotnet run --project LibruaryAPI

## Использование JWT-токенов

Настройка appsettings.json:

"JwtOptions": {
"Issuer": "Api",
"Audience": "https://localhost:7233",
"Key": "secretsecretsecretsecretsecret0545454545454"
}

## Полезные команды

Запуск проекта:
dotnet run
Обновление БД:
dotnet ef database update
