# Проект для демонстрации кода

REST API для сайта фонда капитального ремонта.
Используется для:
- Получение информации из БД(Информация заполнялась из админки, ею я не занимался);
- Отравка обращений(с уведомлением на Email отправителя).

В проекте используются:
- N-Layer архитектура;
- Dapper с raw sql запросами к БД PostgreSQL;
- Swagger;
- Тесты с использованием Xunit;
- Dockerfile для создания образа;