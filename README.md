# InterviewSolution

## Проект

Проект представляет собой небольшое REST API приложение, обрабатывающее заказы на доставку (откуда-куда). Выполнялось для прохождения тестового задания в компанию [Верста](https://versta24.ru). 

Работает на основе технологий:
- backend: ASP.NET Core
- frontend: React.JS
- ORM: Entity Framework Core
- База данных: Postgres

## Установка

Для установки потребуется только [docker](https://www.docker.com/products/docker-desktop/) 🐳

1) Клонируем репозиторий:

```bash
git clone https://github.com/AlimKugot/InterviewSolution
```

2) Заходим в скаченную папку:

```bash
cd InterviewSolution/
```

3) Запускаем проект:

```bash
docker-compose up
```

4) В браузере открываем страницу:

```
localhost
```

<br>


> Примечание: возможны проблемы с проектом, если вы используете те же порты, что и моё приложение: 3000 (frontend), 8085 (backend), 80 (nginx proxy).