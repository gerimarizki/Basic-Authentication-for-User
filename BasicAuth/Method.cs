using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAuth
{
    public class Method
    {
        public Dictionary<string, User> Users = new Dictionary<string, User>();
        public Helper helper = new Helper();

        public void CreateUsers()
        {
            string firstname, lastname, password, username;
            int id = Users.Count + 1;
            Console.WriteLine("Masukkan Nama dan Password");
            Console.WriteLine("Firstname: ");
            Console.Write("> ");
            firstname = helper.ValidasiString(1, 50);
            Console.WriteLine("Lastname: ");
            Console.Write("> ");
            lastname = helper.ValidasiString(1, 50);
            Console.WriteLine("Password input: ");
            password = Console.ReadLine();

            if (helper.HasUppercase(password) && helper.HasLowercase(password) && helper.HasDigit(password))
            {
            }
            else
            {
                Console.WriteLine("Password Minimal 8, Memiliki 1 Huruf besar, kecil serta angka");
                password = Console.ReadLine();
            }
        

            username = firstname.Substring(0, 2) + lastname.Substring(0, 2);



            Users.Add(username, new User(id, firstname, lastname, username, password));
            Console.WriteLine();
            Console.WriteLine("Berhasil Menambahkan Users");
            Console.WriteLine();
        }


        public void UpdateUsers()
        {
            if (Users.Count >= 1)
            {
                ShowUserByUsername();
                string firstname, lastname, password, username;
                Console.WriteLine("Input Username yang akan di Update");
                Console.Write("> ");
                string input = helper.ValidasiString(1, 50);
                if (Users.ContainsKey(input))
                {
                    Console.WriteLine("Masukan Data Users: ");
                    Console.WriteLine("Nama Depan: ");
                    Console.Write("> ");
                    firstname = helper.ValidasiString(1, 50);
                    Console.WriteLine("Nama Belakang: ");
                    Console.Write("> ");
                    lastname = helper.ValidasiString(1, 50);
                    Console.WriteLine("Password: ");
                    Console.Write("> ");
                    password = helper.ValidasiString(8, 50);
                    username = firstname.Substring(0, 2) + lastname.Substring(0, 2);

                    Users[input].Firstname = firstname;
                    Users[input].Lastname = lastname;
                    Users[input].Password = password;
                    Users[input].Username = username;
                    Console.WriteLine();
                    Console.WriteLine("User Berhasil diupdate");

                }
                else
                {
                    Console.WriteLine("User Tidak Ditemukan !");
                }

            }
            else
            {
                Console.WriteLine("User Tidak Ditemukan !!");
            }
        }

        public void DeleteUser()
        {
            if (Users.Count >= 1)
            {
                ShowUserByUsername();
                Console.WriteLine("Input Username Yang ingin di delete");
                Console.Write("> ");
                string input = helper.ValidasiString(1, 50);
                if (Users.ContainsKey(input))
                {
                    Users.Remove(input);
                    Console.WriteLine();
                    Console.WriteLine("Akun Berhasil Di Hapus");
                }
                else
                {
                    Console.WriteLine("Username Salah");
                }
            }
            else
            {
                Console.WriteLine("Tidak ada data yang ditemukan");
            }
        }

        public void ShowUserByUsername()
        {
            string input;
            foreach (var i in Users.Values)
            {
                i.PrintUserInfo();
            }
        }



        public void Login()
        {
            string username, password;
            Console.WriteLine("===== Login =====");
            Console.WriteLine("Username: ");
            Console.Write("> ");
            username = helper.ValidasiString(1, 50);
            Console.WriteLine("Password: ");
            Console.Write("> ");
            password = helper.ValidasiString(1, 50);
            if (Users.ContainsKey(username) && Users[username].Password == password)
            {
                Console.WriteLine("Login Berhasil");
            }
            else
            {
                Console.WriteLine("Username Atau Password Salah \n COBA LAGI!");
                Login();
            }
        }


        public void SearchByName()
        {

            Console.Write("Cari Akun:  ");
            string searchName = Console.ReadLine().ToUpper().ToLower();

            List<User> searchResults = SearchByName(Users, searchName);

            if (searchResults.Count > 0)
            {
                Console.WriteLine("Hasil pencarian:");
                foreach (User user in searchResults)
                {
                    Console.WriteLine($"ID: {user.Id} \n First Name: {user.Firstname} \n Last Name: {user.Lastname} \n Username: {user.Username} \n Password: {user.Password}");
                }
            }
            else
            {
                Console.WriteLine("tidak ada datanya.");
            }
        }

        static List<User> SearchByName(Dictionary<string, User> usersDictionary, string searchName)
        {
            List<User> results = new List<User>();


            foreach (KeyValuePair<string, User> user in usersDictionary)
            {
                if (user.Value.Firstname.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(user.Value);
                }
            }

            return results;

        }

    public void MainMenu()
        {
            Console.WriteLine("Basic Authentication Geri Marizki");
            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Pilih: ");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. Create User");
                        Console.Clear();
                        CreateUsers();
                        MainMenu();
                        break;
                    case 2:
                        Console.WriteLine("2. Show User");
                        Console.Clear();
                        ShowUser();
                        MainMenu();
                        break;
                    case 3:
                        Console.WriteLine("3. Search User");
                        Console.Clear();
                        SearchByName();
                        MainMenu();
                        break;
                    case 4:
                        Console.WriteLine("4. Login User");
                        Console.Clear();
                        Login();
                        MainMenu();
                        break;
                    case 5:
                        Console.WriteLine("5. Exit");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-5");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-5!");
                MainMenu();
            }
        }

        public void ShowUser()
        {
            ShowUserByUsername();

            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            Console.WriteLine("Pilih: ");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. Edit User");
                        Console.Clear();
                        UpdateUsers();
                        ShowUser();
                        break;
                    case 2:
                        Console.WriteLine("2. Delete User");
                        Console.Clear();
                        DeleteUser();
                        MainMenu();
                        break;
                    case 3:
                        Console.WriteLine("3. Back");
                        Console.Clear();
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-3");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-3!");
                MainMenu();
            }
        }

    }

}
