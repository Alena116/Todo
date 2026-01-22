using System;
using System.Collections.Generic;
using System.Linq;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }

    public User(string username, string password, string email)
    {
        Username = username;
        Password = password; 
        Email = email;
        RegistrationDate = DateTime.Now;
    }
}

public static class UserManager
{
    private static List<User> _registeredUsers = new List<User>();

    public static bool RegisterUser(string username, string password, string email)
    {
        if (_registeredUsers.Any(u => u.Username == username))
        {
            Console.WriteLine($"Пользователь с именем '{username}' уже существует.");
            return false;
        }

        if (_registeredUsers.Any(u => u.Email == email))
        {
            Console.WriteLine($"Пользователь с email '{email}' уже зарегистрирован.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Имя пользователя и пароль не могут быть пустыми.");
            return false;
        }

        if (password.Length < 6)
        {
            Console.WriteLine("Пароль должен содержать минимум 6 символов.");
            return false;
        }

        User newUser = new User(username, password, email);
        _registeredUsers.Add(newUser);

        Console.WriteLine($"Пользователь '{username}' успешно зарегистрирован!");
        return true;
    }

    public static bool LoginUser(string username, string password)
    {
        User user = _registeredUsers.FirstOrDefault(u =>
            u.Username == username && u.Password == password);

        if (user != null)
        {
            Console.WriteLine($"Добро пожаловать, {username}!");
            Console.WriteLine($"Дата регистрации: {user.RegistrationDate}");
            return true;
        }
        else
        {
            Console.WriteLine("Неверное имя пользователя или пароль.");
            return false;
        }
    }

    public static User GetUserInfo(string username)
    {
        return _registeredUsers.FirstOrDefault(u => u.Username == username);
    }

    public static int GetUserCount()
    {
        return _registeredUsers.Count;
    }

    public static void DisplayAllUsers()
    {
        Console.WriteLine("\n--- Список зарегистрированных пользователей ---");
        foreach (var user in _registeredUsers)
        {
            Console.WriteLine($"Имя: {user.Username}, Email: {user.Email}, " +
                            $"Зарегистрирован: {user.RegistrationDate:dd.MM.yyyy HH:mm}");
        }
        Console.WriteLine("-----------------------------------------------\n");
    }
}

//public static class Program
//{
//    static void Main(string[] args)
//    {
//        UserManager.RegisterUser("ivanov", "password123", "ivanov@mail.com");
//        UserManager.RegisterUser("petrov", "qwerty789", "petrov@mail.com");
//        UserManager.RegisterUser("sidorova", "secret456", "sidorova@mail.com");

//        UserManager.RegisterUser("ivanov", "newpassword", "new@mail.com");

//        UserManager.LoginUser("ivanov", "password123"); 
//        UserManager.LoginUser("ivanov", "wrongpassword"); 

//        UserManager.DisplayAllUsers();
//        Console.WriteLine($"Всего пользователей: {UserManager.GetUserCount()}");

//        User user = UserManager.GetUserInfo("petrov");
//        if (user != null)
//        {
//            Console.WriteLine($"\nИнформация о пользователе petrov:");
//            Console.WriteLine($"Email: {user.Email}");
//            Console.WriteLine($"Дата регистрации: {user.RegistrationDate}");
//        }
//    }
//}