# BoatWebApi
WebApi для Базы данных

Пример POST запроса:

POST /api/GpsData HTTP/1.1
Host: localhost:44354
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: 25b16369-e1c3-89d9-4e70-8aff48ecf184

{"Latitude":180.0,"Lontitude":8.0,"Satellite":8}

Требования к ПК:
 ОС Windows 7/8/8.1/10
 IP в локальной сети 192.168.0.2(IP который выдает роутер). Это необходимо для того, чтобы не прошивать радиомаяки. По умолчанию они отправляют запросы на адрес https://192.168.0.2//api/GpsData
 

Запуск сервера
1) Скачать архив по ссылке https://github.com/Averill-kk/BoatWebApi/realese/ распаковать его.
2) Установить dotnet-hosting-2.2.0-win.exe
3) Запустить сервер файлом BoatWebApi.exe в папке BoatWebApi