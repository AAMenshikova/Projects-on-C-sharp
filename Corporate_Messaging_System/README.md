## Documentation
### Данный проект представляет собой корпоративную систему распределения сообщений.
### Широко используются порождающие и структурные паттерны, соблюдаются основные принципы ООП, GRASP, SOLID, для тестирования используется mocking.
---
### Структурные паттерны, используемые в проекте:

### **1. Декоратор (Decorator)**

### **Где используется:**
- `AddresseeDecorator` и его производные:
  - `FilterAddressesDecorator` – фильтрует сообщения по уровню важности.
  - `LoggingAddresseeDecorator` – добавляет функциональность логирования.
- `MessageDecorator` и его производный класс:
  - `ReadStatusDecorator` – добавляет статус прочитанности сообщения.

### **Зачем используется:**
- Позволяет динамически добавлять новые обязанности объектам без изменения их кода.
- Пример:
  - Фильтрация и логирование сообщений на основе уровня важности или статуса прочтения.

---

### **2. Компоновщик (Composite)**

### **Где используется:**
- `AddresseeGroup` – содержит коллекцию `IAddressee` и позволяет отправлять сообщения всем вложенным адресатам.

### **Зачем используется:**
- Позволяет работать с группой объектов так же, как с единичным объектом.
- Пример:
  - Отправка одного сообщения сразу всем участникам группы.

---

### **3. Адаптер (Adapter)**

### **Где используется:**
- `AddresseeDisplay` и `AddresseeMessenger`, которые адаптируют классы `Display` и `Messenger` к интерфейсу `IAddressee`.

### **Зачем используется:**
- Предоставляет общий интерфейс (`IAddressee`) для различных типов адресатов (например, дисплеи и мессенджеры), адаптируя их под нужды основного кода.

---

### **4. Мост (Bridge)**

### **Где используется:**
- `Display` и `IDisplayDriver`.
- Классы `FileDisplayDriver` и `ConsoleDisplayDriver` реализуют интерфейс `IDisplayDriver`.

#### **Зачем используется:**
- Разделяет абстракцию (`Display`) и реализацию (`IDisplayDriver`), позволяя изменять их независимо.
- Пример:
  - `Display` может использовать разные драйверы для вывода информации (на консоль или в файл).

---

### Порождающие паттерны, используемые в проекте:

### **1. Строитель (Builder)**

### **Где используется:**
- `UserBuilder` и `UserBuilderDirector`.

### **Зачем используется:**
- Упрощает создание сложных объектов (например, `User`), разделяя процесс создания и представление объекта.
- Пример:
  - `UserBuilderDirector` используется для упрощения вызова методов `UserBuilder`.

---

### **2. Фабричный метод (Factory Method)**

### **Где используется:**
- В методе `UserBuilder.Build`.

### **Зачем используется:**
- Обеспечивает создание экземпляров `User` только в случае наличия всех необходимых данных (например, имени). Если данные неполные, метод возвращает `null`.

---

### Пояснение моделей:
- **Сообщение**
  - *заголовок*
  - *тело*
  - *уровень важности*
- **Топик**
  - *название*
  - *список адресатов*
  - *его цель - передать сообщение адресату*
- **Адресат**
  - *сюда передаются сообщения*
  - *адресаты бывают нескольких видов*
    - Адресат-пользователь передает сообщение пользователю корпоративной системы
    - Адресат-мессенджер отправляет сообщение используя сторонний мессенджер
    - Адресат-дисплей выводит сообщение на какое-либо физическое устройство отображения
    - Адресат-группа содержит в себе несколько адресатов, передаёт каждому из них полученные сообщения
  - *добавлена возможность фильтровать сообщения для конкретных адресатов по их уровню важности*
  - *добавлена возможность логгировать сообщения, получаемые конкретным адресатом*
- **Пользователь**
  - *конечная точка сообщения*
  - *может менять статус сообщения на "прочитанно"*
- **Мессенджер**
  - *конечная точка сообщения*
  - *на консоль выводится текст сообщения*
- **Дисплей**
  - *конечная точка сообщения*
  - *на консоль выводится текст сообщения соответствующего цвета*
- **Дисплей-драйвер**
  - *имеет возможность очистки вывода*
  - *имеет возможность задания цвета текста*
  - *имеет возможность вывода текста на консоль*
