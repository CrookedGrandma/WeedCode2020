using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace WietHuts {
    class Program {

        public static int books, libraries, days;
        public static int[] bookScores;
        public static List<Library> libList;

        public static int totalBooks, avgBooks;

        static void Main(string[] args) {
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

            totalBooks = 0;
            // Info per library
            for (int i = 0; i < libraries; i++) {
                string[] libInfo = Console.ReadLine().Split(" ");

                int bookAmount = int.Parse(libInfo[0]);
                int signUpProc = int.Parse(libInfo[1]);
                int shipPerDay = int.Parse(libInfo[2]);

                int[] bookInLib = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();

                Library lib = new Library { bookAmount = bookAmount, signUpProc = signUpProc, shipPerDay = shipPerDay, bookInLib = bookInLib };
                libList.Add(lib);

                totalBooks += bookAmount;
            }
            avgBooks = totalBooks / libraries;
        }

        static void DoThings() {
            for (int i = 0; i < libraries; i++) {
                
            }
        }

        static void WriteOutput() {
            StreamWriter output = new StreamWriter("../../../output.txt");
            // Amount of libraries
            output.WriteLine(libraries);

            for (int i = 0; i < libraries; i++) {
                // Library ID + amount of signups
                output.Write(i);
                output.Write(" ");
                output.WriteLine(libList[i].bookAmount);

                // Order of books to be send
                for (int j = 0; j < libList[i].bookAmount; j++) {
                    output.Write(libList[i].bookInLib[j]);
                    output.Write(" ");
                }
                output.WriteLine();
            }
            output.Close();
        }

        static void AddScore(Library l) {
            int DAYSCORESCALE = 10;
            int BOOKAMOUNTSCALE = 10;

            float dagscore = (days - l.signUpProc) / days;
            dagscore *= DAYSCORESCALE;
            float bookscore = (l.bookAmount - avgBooks) / avgBooks;
            bookscore *= BOOKAMOUNTSCALE;

            float score = dagscore + bookscore;
            l.score = score;
        }

    }

    struct Library {
        public int bookAmount;
        public int signUpProc;
        public int shipPerDay;
        public int[] bookInLib;
        public float score;
    }

}
