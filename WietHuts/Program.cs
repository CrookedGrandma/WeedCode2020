using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace WietHuts {
    class Program {

        public static int books, libraries, days;
        public static int[] bookScores;
        public static List<Library> libList;

        public static StreamWriter output;

        static void Main(string[] args) {
            output = new StreamWriter("../../../output.txt");

            ReadInput();
            DoThings();
            WriteOutput();
        }

        static void ReadInput() {
            // Get the info
            string[] info = Console.ReadLine().Split(" ");
            books = int.Parse(info[0]);
            libraries = int.Parse(info[1]);
            days = int.Parse(info[2]);

            // Get book scores
            string bookScoreString = Console.ReadLine();
            bookScores = bookScoreString.Split(" ").Select(x => int.Parse(x)).ToArray();

            libList = new List<Library>();

            // Info per library
            for (int i = 0; i < libraries; i++) {
                string[] libInfo = Console.ReadLine().Split(" ");

                int bookAmount = int.Parse(libInfo[0]);
                int signUpProc = int.Parse(libInfo[1]);
                int shipPerDay = int.Parse(libInfo[2]);

                int[] bookInLib = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();

                Library lib = new Library { bookAmount = bookAmount, signUpProc = signUpProc, shipPerDay = shipPerDay, bookInLib = bookInLib };
                libList.Add(lib);
            }
        }

        static void DoThings() {

        }

        static void WriteOutput() {
            // Amount of libraries
            output.WriteLine(libraries);

            for (int i = 0; i < libraries; i++)
            {
                // Library ID + amount of signups
                output.WriteLine();

                // Order of books to be send
                output.WriteLine();
            }
        }

        private Library Score(Library l)
        {
            int scoregetal;
            scoregetal = days - l.signUpProc;
            //Bereken score
            l.score = scoregetal;
            return l;
        }

    }

    struct Library {
        public int bookAmount;
        public int signUpProc;
        public int shipPerDay;
        public int[] bookInLib;
        public int score;
    }

}
