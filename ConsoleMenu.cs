using System;

namespace ConsoleMenu
{
	internal class ConsoleMenu
	{
		static void Main(string[] args)
		{
			const string CommandSetName = "SetName";
			const string CommandChangeConsoleColor = "ChangeConsoleColor";
			const string CommandSetPassword = "SetPassword";
			const string CommandWriteName = "WriteName";
			const string CommandExit = "Esc";

			string name = "";
			string password = "12345"; // Здесь устанавливаем пароль
			bool loggedIn = false;
			bool isProgramActive = true;

			Console.WriteLine("Добро пожаловать в приложение команд!");

			while (isProgramActive)
			{
				Console.WriteLine("Список команд:\n" +
					$"1. {CommandSetName} - установить имя\n" +
					$"2. {CommandChangeConsoleColor} - изменить цвет консоли\n" +
					$"3. {CommandSetPassword} - установить пароль\n" +
					$"4. {CommandWriteName} - вывести имя (требуется ввод пароля)\n" +
					$"5. {CommandExit} - выход из программы");
				Console.Write("Введите команду: ");
				string input = Console.ReadLine();

				switch (input)
				{
					case CommandSetName:
						Console.Write("Введите ваше имя: ");
						name = Console.ReadLine();
						break;

					case CommandChangeConsoleColor:
						Console.Write("Выберите цвет консоли (Black, Red, Green, Yellow, " +
						"Blue, Magenta, Cyan, White): ");
						string colorInput = Console.ReadLine();
						ConsoleColor consoleColor;

						if (Enum.TryParse(colorInput, true, out consoleColor))
							Console.ForegroundColor = consoleColor;
						else
							Console.WriteLine("Недопустимый цвет");
						break;

					case CommandSetPassword:
						Console.Write("Введите новый пароль: ");
						password = Console.ReadLine();
						break;

					case CommandWriteName:

						if (loggedIn)
						{
							Console.WriteLine($"Ваше имя: {name}");
						}
						else
						{
							Console.Write("Введите пароль: ");
							string enteredPassword = Console.ReadLine();

							if (enteredPassword == password)
							{
								loggedIn = true;
								Console.WriteLine($"Вход выполнен, ваше имя: {name}");
							}
							else
							{
								Console.WriteLine("Неправильный пароль!");
							}
						}
						break;

					case CommandExit:
						isProgramActive = false;
						break;

					default:
						Console.WriteLine("Неизвестная команда!");
						break;
				}
			}
			Console.WriteLine("Программа завершена.");
		}
	}
}
