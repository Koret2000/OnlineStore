# Учебный интернет-магазин (C# + SQL)

Командный учебный проект приложения с реляционной базой данных. Эта версия содержит модуль авторизации: интерфейс на C#, SQL-схему пользователей и подключение к БД. Каталог товаров, корзина и заказы в опубликованную копию пока не входят.

## Стек

C#, Windows Forms, MySQL / SQL, MariaDB, Visual Studio, .NET 10, MySqlConnector.

## Моя роль в команде

- Проектирование реляционной БД и написание SQL-запросов.
- Связывание C#-приложения с базой данных и разработка формы авторизации.
- Координация работы команды, распределение задач и контроль сроков.
- Сборка общих модулей и проверка их совместной работы.

## Структура

```text
Mamaliga Windows.slnx              — решение Visual Studio
Mamaliga Windows/                 — код C#, форма и ресурсы
  Form1.cs                        — обработчик входа и SQL-запрос
  Form1.Designer.cs               — элементы интерфейса
  Program.cs                      — запуск приложения
config/launchSettings.example.json — шаблон локального подключения
database/schema.sql              — создание БД и таблицы пользователей
database/demo-user.sql           — вымышленные тестовые данные
```

## База данных

База `mamliga` содержит таблицу `tbl_users`:

| Поле | Тип | Назначение |
|---|---|---|
| `PK_UserID` | INT, PRIMARY KEY, AUTO_INCREMENT | ID пользователя |
| `Login` | TEXT NOT NULL | Логин |
| `Password` | INT NOT NULL | Числовой пароль в учебной схеме |
| `FullName` | TEXT NOT NULL | Имя пользователя |
| `Role` | TEXT NOT NULL | Роль |

Форма выполняет параметризованный запрос `SELECT COUNT(*)` с параметрами `@I` и `@p`, затем проверяет результат через `ExecuteScalar()`. В этой копии одна таблица, внешние ключи пока отсутствуют. Скрипт `demo-user.sql` создаёт вымышленную запись `demo` / `1234`; реальные пользователи и данные сервера колледжа не публикуются.

## Запуск

Требуются Windows, .NET 10 SDK, Visual Studio с поддержкой Windows Forms и .NET 10, а также запущенный MySQL или MariaDB. Для команд импорта клиент `mysql` должен быть доступен в PATH.

1. Откройте PowerShell в корне проекта и разверните локальную БД:

```powershell
mysql --host=127.0.0.1 --user=root --password --execute="sourcedatabase/schema.sql"
mysql --host=127.0.0.1 --user=root --password --execute="sourcedatabase/demo-user.sql"
```

Клиент запросит пароль локального пользователя БД. Для импорта нужны права на создание базы и таблицы.

2. Создайте локальный профиль подключения:

```powershell
New-Item -ItemType Directory -Path 'Mamaliga Windows/Properties' -Force | Out-Null
Copy-Item 'config/launchSettings.example.json' 'Mamaliga Windows/Properties/launchSettings.json'
```

В созданном `launchSettings.json` замените `YOUR_DB_USER` и `YOUR_PASSWORD` своими значениями. При необходимости измените адрес сервера. Профиль задаёт переменную `ONLINE_STORE_CONNECTION`, которую читает приложение; локальный файл исключён из Git.

3. Откройте `Mamaliga Windows.slnx` в Visual Studio, дождитесь восстановления NuGet-пакетов, выберите профиль `OnlineStore` и нажмите F5. Для проверки входа используйте `demo` / `1234`.

Альтернативный запуск из терминала:

```powershell
dotnet restore 'Mamaliga Windows/Mamaliga Windows.csproj'
dotnet build 'Mamaliga Windows/Mamaliga Windows.csproj' --configuration Release
dotnet run --project 'Mamaliga Windows/Mamaliga Windows.csproj' --launch-profile OnlineStore
```

## Текущий статус

Собран учебный модуль авторизации с сообщениями о результате входа и ошибках подключения. Автоматических тестов пока нет. Пароли в исходной учебной схеме числовые; хеширование ещё не реализовано.
