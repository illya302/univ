using System;
using part1;

namespace part2
{
    internal class CommandHandler
    {
        public static void Help()
        {
            Console.WriteLine("Команди, які ви можете використати:");
            Console.WriteLine(" /help   - виводить команди, які можуть використовуватися у програмі;" +
                "\n /add    - додати новий елемент у список;");
            Console.WriteLine(" /delete - видалити елемент зі списку;" +
                "\n /show   - вивести список у вигляді таблиці;");
            Console.WriteLine(" /search - знайти студентів-відмінників які займаються музикою;"
                + "\n /length - отримати довжину списка;");
            Console.WriteLine(" /sort    - сортувати список за оцінкою студента" +
                "\n /end    - закінчити роботу зі списком.");
        }

        public static void AddStudent(ref DoublyLinkedList<Student> listname)
        {
            Console.WriteLine("Введіть ім'я студента(англ)");
            string _name = Console.ReadLine();
            Console.WriteLine("Введіть так або ні, якщо студент займається музикою");
            string msc = Console.ReadLine();
            if (!(msc == "так" || msc == "нi"))
            {
                throw new Exception("Введіть так або ні!\n------------------------------------------");
            }
            bool music;
            if (msc == "так")
            {music = true;}
            else{music = false;}
            Console.WriteLine("Введіть середній бал студента");
            string temp = Console.ReadLine();
            for (int i = 0; i < temp.Length; i++) 
            {
                if (temp[i] < 48 || temp[i] > 57)
                { 
                    throw new Exception("Введіть число!\n------------------------------------------");
                }
            }
            double avg = Convert.ToDouble(temp);
            Student student = new Student(_name, avg, music);
            listname.AddLast(student);
            Console.WriteLine("Ви успiшно додали студента!");

        }
        public static void ShowList(ref DoublyLinkedList<Student> listname) 
        {
            string temp;
            foreach (Student item in listname)
            {
                if (item.attendingMusicLessons)
                { temp = "так"; }
                else { temp = "ні"; }
                Console.WriteLine("------------------------------------------------------------------------\n" +
                                    "Iм'я - {0}   Середнiй бал - {1}   Вiдвiдування музичних заннять - {2} ",
                    item.name, item.averageMark, temp);
            }
        }
        public static void RemoveStudent(ref DoublyLinkedList<Student> listname)
        {
            listname.DeleteLast();
        }
        public static void SearchStudent(ref DoublyLinkedList<Student> listname)
        {
            string temp;
            foreach (Student item in listname.SearchStudent())
            {
                if (item.attendingMusicLessons)
                { temp = "так"; }
                else { temp = "ні"; }
                Console.WriteLine("------------------------------------------------------------------------\n" +
                    "Iм'я - {0}   Середнiй бал - {1} Вiдвiдування музичних заннять - {2}",
                    item.name, item.averageMark, temp);
            }
        }
        public static void Length(ref DoublyLinkedList<Student> listname)
        {
            Console.WriteLine("Кількість студентів у списку: {0}", listname.LengthOfList());
        }
        public static void SortList(ref DoublyLinkedList<Student> listname)
        {
            listname.SortByInsert();
        }
        public static void UnhandledCommand()
        {
            Console.WriteLine("Такої команди не існує! Спробуйте ввети іншу з переліку.");
            CommandHandler.Help();
        }

    }
}
