# Документация по проекту
## Controllers
Содержит контроллеры для управления представлениями
### AdminController
Управляет панелью администратора  
Функции:
- добавление, удаление квалификаций
- добавление, удаление языков
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
Содержит папку wwwroot, в котором файл site.css с css кодом для стиля сайта.
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
  ### Папка Views
  ### Папка Admin
  #### Файл Index.cshtml
  -langu, quali стили для кнопок   
  ### Папка Home
  #### Файл About.cshtml
  - body, go-back, go-back:hover  стили для кнопки "назад";
  #### Файл Contact.cshtml
  - body стиль для ссылки
  -  table, th, td, th, tr:hover  стили для таблицы
  -  go-back, go-back:hover стиль для кнопки "назад"
  ### Папка Shared   
  #### Файл _Layout.cshtml 
  - admin-panael стиль для панели администратора
  ### Папка Tasks  
  #### Файл Index.cshtml
  - add-task стиль для кнопки "добавить задачу"
  ### Папка Users  
  #### Файл Index.cshtml
  - add-worker-btn, body стили для кнопки 
  - table, th td ,tbody, tr:nth-child(even), tbody, tr:nth-child(odd),td:hover стили для таблицы 



