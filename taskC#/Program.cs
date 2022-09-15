// Написать программу, которая из имеющегося массива строк формирует массив из строк,
// длина которых меньше либо равна 3 символа. Первоночальный массив можно 
// ввести с клавиатуры, либо задать на старте выполнения алгоритма.
// При решении не рекомендуется пользоваться коллекциями, лучше обойтись
// исключительно массивами.

void Task()
{
  Console.Clear();

  int num = GetNumberFromUser("Задаем количество элементов в массиве. Введите целое число: ", "Ошибка ввода!");
  if (num == 0)
  {
    Console.Write("[]  ->  []");
    return;
  }
  Console.WriteLine($"Количество элементов в массиве {num}");
  string[] userArray = GetNewArray(num);
  int lengthResultArray = GetLengthResultArray(userArray);
  string[] resultArray = GetResultArray(userArray, lengthResultArray);
  Console.Clear();
  OutputArraysConsole(userArray, resultArray);
}
Task();

// запрос целых числовых данных от пользователя
int GetNumberFromUser(string message, string errorMessage)
{
  while (true)
  {
    Console.Write(message);
    bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
    if (isCorrect)
      return userNumber;
    Console.WriteLine(errorMessage);
  }
}

// запрос строковых данных от пользователя
string GetStringFromUser(string message, string errorMessage)
{
  while (true)
  {
    Console.Write(message);
    string? userText = Console.ReadLine();
    bool isCorrect = userText!.Length != 0;
    if (isCorrect)
      return userText;
    Console.WriteLine(errorMessage);
  }
}

// заполнение массива пользователем данными
string[] GetNewArray(int lengthNewArray)
{
  string[] newArray = new string[lengthNewArray];
  for (int i = 0; lengthNewArray > i; i++)
    newArray[i] = GetStringFromUser("Введите символы: ", "Ошибка ввода!");
  return newArray;
}

// находим длину нового массива удовлетворяющего заданным условиям
int GetLengthResultArray(string[] newArray)
{
  int count = 0;
  for (int i = 0; i < newArray.Length; i++)
  {
    if (newArray[i].Length < 4)
      count++;
  }
  return count;
}

// создаем новый массив удовлетворяющий заданным условиям
string[] GetResultArray(string[] newArray, int lengthResult)
{
  string[] result = new string[lengthResult];
  int count = 0;
  for (int i = 0; i < newArray.Length; i++)
    if (newArray[i].Length < 4)
    {
      result[count] = newArray[i];
      count++;
    }
  return result;
}

// выводим на экран результат
void OutputArraysConsole(string[] newUserArray, string[] newResultArray)
{
  Console.WriteLine();
  if (newUserArray.Length == 1)
    Console.Write($"[\"{newUserArray[0]}\"]  ->  ");
  else
  {
    for (int i = 0; i < newUserArray.Length; i++)
    {
      if (i == 0)
        Console.Write($"[\"{newUserArray[i]}\", ");
      if (i != newUserArray.Length - 1 && i != 0)
        Console.Write($"\"{newUserArray[i]}\", ");
      if (i == newUserArray.Length - 1)
        Console.Write($"\"{newUserArray[i]}\"]  ->  ");
    }
  }
  if (newResultArray.Length == 0)
    Console.Write("[]");
  if (newResultArray.Length == 1)
    Console.Write($"[\"{newResultArray[0]}\"]");
  else
  {
    for (int j = 0; j < newResultArray.Length; j++)
    {
      if (j == 0)
        Console.Write($"[\"{newResultArray[j]}\", ");
      if (j != newResultArray.Length - 1 && j != 0)
        Console.Write($"\"{newResultArray[j]}\", ");
      if (j == newResultArray.Length - 1)
        Console.Write($"\"{newResultArray[j]}\"]");
    }
  }
}
