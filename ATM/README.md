## Documentation

### Реализована система банкомата. В качестве многослойной архитектуры используется гексагональная.

---

### Пояснение проекта

- реализован интерактивный консольный интерфейс
- есть возможность выбора режима работы (пользователь, администратор)
  - при выборе пользователя запрашиваются данные счета (номер, пин)
  - при выборе администратора запрашивается системный пароль
    - при некорректном вводе пароля - система прекращает работу
- системный пароль параметризуем
- при попытке выполнения некорректных операций, выводятся сообщения об ошибке
- данные персистентно сохраняются в базу данных (PostgreSQL)
  - используется Docker
