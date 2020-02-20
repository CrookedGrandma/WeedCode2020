using System;

namespace WietHuts {
    class Program {
        static void Main(string[] args) {
            ReadInput();
            DoThings();
            WriteOutput();
        }

        static void ReadInput() {
            // Get the info
            string info = Console.WriteLine();
            int books = int.Parse(info[0]);
            int libraries = int.Parse(info[1]);
            int days = int.Parse(info[2]);

            // Get book scores
            string bookScoreString = Console.WriteLine();
            string[] splitScores = bookScoreString.Split(" ");
            int[] bookScores = new int[books];
            for (int i = 0; i < books; i++)
                bookScores[i] = splitScores[i];

            // Info per library
            for (int i = 0; i < libraries; i++) {
                string[] libInfo = Console.WriteLine().Split(" ");
                int[] bookInLib = Console.WriteLine().Split(" ").Select(x => int.Parse(x));

                int bookAmount = int.Parse(libInfo[0]);
                int signUpProc = int.Parse(libInfo[1]);
                int shipPerDay = int.Parse(libInfo[2]);
            }
        }

        static void DoThings() {

        }

        static void WriteOutput() {

        }

    }
}
