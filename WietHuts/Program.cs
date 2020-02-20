using System;
using System.Linq;

namespace WietHuts {
    class Program {
        static void Main(string[] args) {
            ReadInput();
            DoThings();
            WriteOutput();
        }

        static void ReadInput() {
            // Get the info
            string[] info = Console.ReadLine().Split(" ");
            int books = int.Parse(info[0]);
            int libraries = int.Parse(info[1]);
            int days = int.Parse(info[2]);

            // Get book scores
            string bookScoreString = Console.ReadLine();
            string[] splitScores = bookScoreString.Split(" ");
            int[] bookScores = new int[books];
            for (int i = 0; i < books; i++)
                bookScores[i] = int.Parse(splitScores[i]);

            // Info per library
            for (int i = 0; i < libraries; i++) {
                string[] libInfo = Console.ReadLine().Split(" ");
                int[] bookInLib = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();

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
