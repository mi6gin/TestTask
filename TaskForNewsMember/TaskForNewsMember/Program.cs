using System; 

class Program
{
    // Функция для перестановки байтов в 32-битном значении
    static uint SwapBytesInUInt32(uint value)
    {
        // Перестановка байтов с использованием побитовых операций
        // Пример: если значение в hex - 0x12345678, результат будет 0x78563412
        return ((value >> 24) & 0x000000FF) | // Сдвиг на 24 бита вправо и маскирование младших 8 битов (получаем байт 1)
               ((value >> 8) & 0x0000FF00) |  // Сдвиг на 8 бит вправо и маскирование (получаем байт 2)
               ((value << 8) & 0x00FF0000) |  // Сдвиг на 8 бит влево и маскирование (получаем байт 3)
               ((value << 24) & 0xFF000000);  // Сдвиг на 24 бита влево и маскирование (получаем байт 4)
    }

    // Функция для преобразования двух 16-битных значений в 32-битное значение типа float
    static float ConvertToFloat(ushort high, ushort low)
    {
        // Объединение двух 16-битных значений в одно 32-битное
        // high - старшие 16 бит, low - младшие 16 бит
        uint combinedValue = ((uint)high << 16) | low; // Сдвиг high на 16 бит влево и объединение с low с использованием побитового OR

        // Перестановка байтов, если необходимо
        // Это может быть нужно для соответствия порядку байтов системы (Big-endian или Little-endian)
        combinedValue = SwapBytesInUInt32(combinedValue);

        // Преобразование 32-битного значения в тип float
        // BitConverter преобразует массив байт в указанный тип данных
        // BitConverter.GetBytes преобразует число в массив байт
        return BitConverter.ToSingle(BitConverter.GetBytes(combinedValue), 0);
    }

    static void Main()
    {
        // Примеры данных с датчиков, полученные в формате 16 бит (ushort)
        ushort bat1 = 248, bat2 = 26432; // Два 16-битных значения для заряда батареи
        ushort VibroScorostX1 = 44557, VibroScorostX2 = 3648; // Два 16-битных значения для виброскорости по оси X
        ushort VibroScorostY1 = 65, VibroScorostY2 = 63295; // Два 16-битных значения для виброскорости по оси Y
        ushort VibroScorostZ1 = 832, VibroScorostZ2 = 3136; // Два 16-битных значения для виброскорости по оси Z
        ushort VibroPeremX1 = 20164, VibroPeremX2 = 62016; // Два 16-битных значения для виброперемещения по оси X
        ushort VibroPeremY1 = 6449, VibroPeremY2 = 17729; // Два 16-битных значения для виброперемещения по оси Y
        ushort VibroPeremZ1 = 25174, VibroPeremZ2 = 59456; // Два 16-битных значения для виброперемещения по оси Z

        // Преобразование данных с датчиков в значения типа float
        float bat = ConvertToFloat(bat1, bat2); // Заряд батареи
        float VibroScorostX = ConvertToFloat(VibroScorostX1, VibroScorostX2); // Виброскорость по оси X
        float VibroScorostY = ConvertToFloat(VibroScorostY1, VibroScorostY2); // Виброскорость по оси Y
        float VibroScorostZ = ConvertToFloat(VibroScorostZ1, VibroScorostZ2); // Виброскорость по оси Z
        float VibroPeremX = ConvertToFloat(VibroPeremX1, VibroPeremX2); // Виброперемещение по оси X
        float VibroPeremY = ConvertToFloat(VibroPeremY1, VibroPeremY2); // Виброперемещение по оси Y
        float VibroPeremZ = ConvertToFloat(VibroPeremZ1, VibroPeremZ2); // Виброперемещение по оси Z

        // Вывод преобразованных значений на консоль с форматированием
        // {0:F1} означает, что значение будет выведено с одним знаком после запятой
        Console.WriteLine("Wireless sensors.Station Bar Mill.Nap bat: {0:F1} V", bat); // Вывод заряда батареи
        Console.WriteLine("Wireless sensors.Station Bar Mill.VibroScorost X: {0:F1}", VibroScorostX); // Вывод виброскорости по оси X
        Console.WriteLine("Wireless sensors.Station Bar Mill.VibroScorost Y: {0:F1}", VibroScorostY); // Вывод виброскорости по оси Y
        Console.WriteLine("Wireless sensors.Station Bar Mill.VibroScorost Z: {0:F1}", VibroScorostZ); // Вывод виброскорости по оси Z
        Console.WriteLine("Wireless sensors.Station Bar Mill.VibroPerem X: {0:F1}", VibroPeremX); // Вывод виброперемещения по оси X
        Console.WriteLine("Wireless sensors.Station Bar Mill.VibroPerem Y: {0:F1}", VibroPeremY); // Вывод виброперемещения по оси Y
        Console.WriteLine("Wireless sensors.Station Bar Mill.VibroPerem Z: {0:F1}", VibroPeremZ); // Вывод виброперемещения по оси Z
    }
}
