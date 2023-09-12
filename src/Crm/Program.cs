// 1. Принцип единственной ответственности (Single Responsibility Principle - SRP): 
// Каждый класс должен иметь только одну ответственность, то есть выполнять только одну задачу. 
// Если класс имеет несколько ответственностей, изменения в одной из них могут привести к нежелательным 
// побочным эффектам в других ответственностях. Пример:


class FileManager
{
    public void ReadFile(string filePath)
    {
        // Чтение файла
    }

    public void WriteFile(string filePath, string content)
    {
     

    }
    public void ParseFile(string filePath)
    {
   
    }
}
// В данном примере класс `FileManager` имеет три метода, каждый из которых
// выполняет разную ответственность - чтение файла, запись в файл и парсинг файла. 
// Рекомендуется разделить эти ответственности на отдельные классы, 
// чтобы каждый класс имел только одну ответственность.



// 2. Принцип открытости/закрытости (Open/Closed Principle - OCP): 
// Программные сущности, такие как классы, модули и функции, 
// должны быть открыты для расширения, но закрыты для модификации. 
// Вместо изменения существующих кодовых баз можно добавлять новый 
// код или функциональность через расширение. Пример:

public abstract class AreaCalculator
{
    public virtual double CalculateArea()
    {
        // Расчет площади
        return 0;
    }
}

public sealed class Rectangle : AreaCalculator
{
    public override double CalculateArea()
    {
        return 0;
    }
}

public sealed class Circle : AreaCalculator
{
    public override double CalculateArea()
    {
        return 0;
    }
}
// В данном примере класс `AreaCalculator` определяет виртуальный метод `CalculateArea`, 
// который может быть переопределен в классах-наследниках для расчета площади конкретных фигур. 
// Таким образом, новые фигуры могут быть добавлены, расширяя функциональность базового класса без его изменения.




// 3. Принцип подстановки Лисков (Liskov Substitution Principle - LSP): 
// Объекты одного класса могут быть заменены объектами производного класса 
// без изменения правильности программы. То есть, классы-наследники должны 
// быть полностью совместимы с интерфейсами и поведением, определенными базовым классом. Пример:

public abstract class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

public sealed class Treug : Shape
{
    public override double CalculateArea()
    {
        return 0;
    }
}

class Square : Shape
{
    public override double CalculateArea()
    {
        return 0;
    }
}

// В данном примере классы `Rectangle` и `Square` являются производными от класса `Shape`.
// Они переопределяют метод `CalculateArea()`, чтобы выполнить расчет площади соответствующих 
// фигур. Объекты типа `Rectangle` и `Square` могут заменять объекты типа `Shape`, 
//без нарушения правильности программы.




// 4. Принцип разделения интерфейса (Interface Segregation Principle - ISP): 
// Клиенты не должны зависеть от интерфейсов, которые им не нужны. 
// Интерфейсы должны быть небольшими и специфичными для конкретных клиентов, 
// вместо того, чтобы содержать множество методов, из которых клиент использует только некоторые. Пример:

interface IOrder
{
    void ProcessPayment();
    void CheckStockAvailability();
    void ShipOrder();
}
// В данном примере интерфейс `IOrder` имеет три метода, связанные 
// с обработкой платежа, проверкой наличия товара и доставкой заказа. 
// Если клиенту не требуется проверка наличия товара (например, для электронных товаров), 
// реализация этого метода будет иметь пустое тело. Рекомендуется разделить интерфейс 
// на более специфичные интерфейсы, чтобы клиенты могли реализовать только необходимые методы.



//5. Принцип инверсии зависимостей (Dependency Inversion Principle - DIP): 
// Классы должны зависеть от абстракций, а не от конкретных реализаций. 
// Модули верхнего уровня не должны зависеть от модулей нижнего уровня, оба должны зависеть от абстракций.


interface ILogger
{
    void Log(string message);
}

class FileLogger : ILogger
{
    public void Log(string message)
    {
    }
}

class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
    }
}

class Service
{
    private ILogger _logger;

    public Service(ILogger logger)
    {
        _logger = logger;
    }

    public void DoSomething()
    {
        _logger.Log("Операция выполнена");
    }
}

// В данном примере классы `FileLogger` и `DatabaseLogger` реализуют интерфейс `ILogger`. Класс `Service` зависит от 
// абстракции `ILogger`, а не от конкретной реализации, что позволяет нам легко изменять или 
// добавлять новые логгеры без изменения класса `Service`.