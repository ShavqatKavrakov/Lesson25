using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
namespace Lesson25._3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.Create\n2.Read\n3.Update\n4.Delete\n5.Exist");
                Console.WriteLine("Введите комонду:");
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1: await Insert(); break;
                    case 2: await Read(); break;
                    case 3: await Update(); break;
                    case 4: await Delete(); break;
                    case 5: return;
                }           
            }
        }
        private static async Task Insert()
        {
            try
            {
                Console.WriteLine("Введите имя:");
                string name = Console.ReadLine();
                var user1 = await CRUD.Get(name);
                if (user1 == null)
                {
                    Console.WriteLine("Введите почту:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Введите пароль:");
                    string password = Console.ReadLine();
                    var user = new User();
                    user.Name = name;
                    user.Email = email;
                    user.Password = password;
                    await CRUD.Insert(user);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Пользователь  успешно  добовилься");
                    Console.ResetColor();
                }
                else
                    throw new Exception($"Пользователь  уже есть");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
        private static async Task Read()
        {
            try
            {
                Console.WriteLine("Введите имя:");
                string name = Console.ReadLine();
                var user = await CRUD.Get(name);
                if (user != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Id: {user.Id}|Имя: {user.Name}|Email: {user.Email}");
                    Console.ResetColor();
                }
                else
                    throw new Exception("Пользователь не найден");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
        private static async Task Update()
        {

            try
            {
                Console.WriteLine("Введите имя:");
                string name = Console.ReadLine();
                var user = await CRUD.Get(name);
                if (user != null)
                {
                    Console.WriteLine("Введите новое имя:");
                    user.Name = Console.ReadLine();
                    await CRUD.Update(user);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Пользователь успешно обновилось");
                    Console.ResetColor();
                }
                else
                    throw new Exception("Пользователь не найден");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
        private static async Task Delete()
        {
            try
            {
                Console.WriteLine("Введите имя:");
                string name = Console.ReadLine();
                var user = await CRUD.Get(name);
                if (user != null)
                {
                    await CRUD.Delete(user);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Пользователь успешно удалён");
                    Console.ResetColor();
                }
                else
                    throw new Exception("Пользователь не найден");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }


    }
}
