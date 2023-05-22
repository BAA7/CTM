# Документация по проекту
## Controllers
Содержит контроллеры для управления представлениями
### AdminController
Управляет панелью администратора  
Функции:
- добавление, удаление квалификаций
- добавление, удаление языков
### AdminController
Рассмотрим болле подробно сам функционал:
-методы Actionresult index,Actionresult LanguageData,Actionresult QualificationData -это абстрактные классы, которые можно использовать лишь в качестве базового класса
-методы Actionresult LanguageData- реализовывают добавления данных для таблицы "языков", второй метод на вход принимает представление(класс) с параметром
-методы Actionresult QualificationData-реализывывают добавления данных для таблицы "квалификаций" ,второй метод на вход принимает представление(класс) с параметром
-первый метод принимает данные ,выступает в качестве ответчика на запрос
-второй данные добавляет в базу данных и сохраняет их с помощью конструкций:Add-добавления и SaveChanges-сохранения
-метод RedirectToAction,возращает название метода и имя контроллера
-методы Actionresult RemoveLanguage-реализовывают удаления данных для таблицы "языков", первый метод на вход принимает id, с помощью которого будет осуществляться сам функционал, а второй представление(класс) с параметром
-методы Actionresult RemoveLanguage-реализовывают удаления данных для таблицы "квалификаций", на вход принимает id, с помощью которого будет осуществляться сам функционал
-первый метод принимает данные, выступает в качестве ответчика на запрос
-второй удаляет данные из базы данных с помощью конструкций:Remove-удаления и SaveChanges-сохранения
-также во втором методе обязательно нужно удалить по id связи с другими таблицами, в которых присутствует аргумент в методе
P.S в других методах все аналогично,за исключением некотрых изменений
### HomeController
Основной контроллер, "главная страница"  
Функции:
- осуществляет аутентификацию и авторизацию пользователей
- предоставляет пользователям и сторонним лицам информацию о компании
### UsersController
Управляет взаимодействием с пользователями  
Функции:
- просмотр списка пользователей
- просмотр информации о конкретном пользователе
- добавление новых пользователей (для администратора)
### TasksController
Управляет задачами  
Функции:
- просмотр списка задач:
  - свои задачи
  - задачи подчиненных
  - остальные задачи (для администратора)
- добавление новых задач
## Data
Содержит контекст базы данных
## Docs
Содержит документацию (диаграммы, доска задач итд)
## fontawesome
Содержит стили, картинки итд для визуального оформления
## Models
Содержит классы, используемые контекстом БД для чтения и записи
## Views
Содержит папки с представлениями. Представления каждой папки управляются контроллером с соответствующим именем с припиской Controller
## wwwroot
Содержит папку css, в котором файл <a href="wwwroot/css/site.css" target="_blank"> site.css </a> с css кодом для стиля сайта.
  - body стиль для "тела" сайта
  - header стиль для "шапки" сайта
  - footer стиль для "подвала" сайта
  - logo a, logo a:hover, стиль для логотипа сайта
  - tasks button, usres button, login button, login button:hover, btn-primary определяют стили для кнопок
  - links a, links a:last-child определяют стили для ссылок внутри элементов с классом "links"
  - form, label, input[type="text"], input[type="password"], input[type="text"]:focus, input[type="password"]:focus, button[type="submit"], button[type="submit"]:hover стили определяющие вид формы авторизации
  - input:invalid, input:invalid + spani, nput:valid + span стили для ошибки при валидции
  - profile-table, profile-table th,profile-table td, profile-table th, profile-table tr:hover, profile-table td:first-child  стили для таблицы профиля
  - minimalist-dlya-privet, minimalist-dlya-privet-text стили для оформления приветствия  
  ## Стили непосредственно в файлах html
  ### Views
  ### Папка Admin
  #### Файл <a href="Views/Admin/Index.cshtml" target="_blank"> Index.cshtml </a>
  - langu, quali стили для кнопок   
  ### Папка Home
  #### Файл <a href="Views/Home/About.cshtml" target="_blank"> About.cshtml </a>
  - body, go-back, go-back:hover  стили для кнопки "назад";
  #### Файл <a href="Views/Home/Contact.cshtml" target="_blank"> Contact.cshtml </a>
  - body стиль для ссылки
  -  table, th, td, th, tr:hover  стили для таблицы
  -  go-back, go-back:hover стиль для кнопки "назад"
  ### Папка Shared   
  #### Файл <a href="Views/Shared/_Layout.cshtml" target="_blank"> _Layout.cshtml </a>
  - admin-panael стиль для панели администратора
  ### Папка Tasks  
  #### Файл <a href="Views/Tasks/Index.cshtml" target="_blank"> Index.cshtml </a>
  - add-task стиль для кнопки "добавить задачу"
  ### Папка Users  
  #### Файл <a href="Views/Users/Index.cshtml" target="_blank"> Index.cshtml </a>
  - add-worker-btn, body стили для кнопки 
  - table, th td ,tbody, tr:nth-child(even), tbody, tr:nth-child(odd),td:hover стили для таблицы 
  
