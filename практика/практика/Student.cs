namespace part1
{
    public class Student 
    {
        public string name { get; set; }
        public double averageMark { get; set; }
        public bool attendingMusicLessons { get; set; }
        public Student() 
        {
            name = null;
            averageMark = 0;
            attendingMusicLessons = false;
        }
        public Student(string a, double b, bool c)
        {
            name = a;
            averageMark = b;
            attendingMusicLessons = c;
        }
    }
}
