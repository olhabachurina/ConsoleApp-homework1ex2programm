using System.Runtime.InteropServices;

namespace ConsoleAppрhomework1ex2programm;

class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBox")]
public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
static void Main()
{
    bool playAgain = true; 
    while (playAgain)
    {
        int minNumber = 1; // Минимальное значение, которое можно загадать
        int maxNumber = 100; // Максимальное значение, которое можно загадать
        int attempts = 0; // Счетчик попыток
        Random random = new Random();
        int guessedNumber = random.Next(minNumber, maxNumber + 1);
        MessageBox(IntPtr.Zero, $"Загадайте число от {minNumber} до {maxNumber} и нажмите ОК.", "Игра 'Угадай число'", 0);
        while (true)
        {
            attempts++; 
            Console.WriteLine($"Попытка {attempts}: Угадайте число от {minNumber} до {maxNumber}:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int guess))
            {
                if (guess == guessedNumber)
                {
                    MessageBox(IntPtr.Zero, $"Вы угадали число {guessedNumber} за {attempts} попыток!", "Поздравляем!", 0);
                    break; 
                }
                else if (guess < guessedNumber)
                {
                    MessageBox(IntPtr.Zero, "Загаданное число больше.", "Подсказка", 0);
                }
                else
                {
                    MessageBox(IntPtr.Zero, "Загаданное число меньше.", "Подсказка", 0);
                }
            }
            else if (string.IsNullOrWhiteSpace(input)) 
            {
                MessageBox(IntPtr.Zero, "Игра завершена пользователем.", "Игра завершена", 0);
                break; 
            }
            else 
            {
                MessageBox(IntPtr.Zero, "Пожалуйста, введите целое число от 1 до 100.", "Ошибка", 0);
            }
        }
        int result = MessageBox(IntPtr.Zero, "Хотите сыграть еще раз?", "Новая игра", 4); // 4 - это значение для кнопок "Yes" и "No"
        if (result != 6) // 6 - это значение для нажатия кнопки "Yes"
        {
            playAgain = false; // Если выбрано "No", завершаем цикл игры
        }
    }
    MessageBox(IntPtr.Zero, "Спасибо за игру! До свидания.", "Завершение программы", 0);
}
}