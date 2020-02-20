using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace WietHuts {
    class Program {

        public static int books, libraries, days;
        public static int[] bookScores;
        public static List<Library> libList;
        public static bool[] isLibSigned;
        public static bool[] isBookScanned;

        public static int totalSign, totalBooks, totalFreq;
        public static float avgSign, avgBooks, avgFreq;
        public static float totalBookRatio, avgBookRatio;

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

            totalBookRatio = 0;
            totalSign = 0; totalBooks = 0; totalFreq = 0;
            // Info per library
            for (int i = 0; i < libraries; i++) {
                string[] libInfo = Console.ReadLine().Split(" ");

                int bookAmount = int.Parse(libInfo[0]);
                int signUpProc = int.Parse(libInfo[1]);
                int shipPerDay = int.Parse(libInfo[2]);

                int[] books = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                int[] sortedBooks = books.OrderBy(x => bookScores[x]).ToArray();
                Stack<int> bookInLib = new Stack<int>(sortedBooks);

                Library lib = new Library { index = i, bookAmount = bookAmount, signUpProc = signUpProc, shipPerDay = shipPerDay, bookInLib = bookInLib };
                libList.Add(lib);

                totalSign += signUpProc;
                totalBooks += bookAmount;
                totalFreq += shipPerDay;

                totalBookRatio += bookAmount / shipPerDay;
            }
            avgSign = totalSign / (float)libraries;
            avgBooks = totalBooks / (float)libraries;
            avgFreq = totalFreq / (float)libraries;
            avgBookRatio = totalBookRatio / (float)libraries;
        }

        static void DoThings() {
            for (int i = 0; i < libraries; i++) {
                AddScore(libList[i]);
            }
            libList = libList.OrderBy(x => -x.score).ToList();
            //int breakpoint = 1;
            /*for(int day = 0; day < days; day++)
                foreach (Library lib in libList)
                    CheckBooks(lib, day);*/
        }

        static void WriteOutput() {
            StreamWriter output = new StreamWriter("../../../output.txt");
            // Amount of libraries
            output.WriteLine(libraries);

            for (int i = 0; i < libraries; i++) {
                Library l = libList[i];
                // Library ID + amount of signups
                output.Write(l.index);
                output.Write(" ");
                output.WriteLine(l.bookAmount);

                // Order of books to be send
                for (int j = 0; j < l.bookAmount; j++) {
                    output.Write(l.bookInLib.Pop());
                    output.Write(" ");
                }
                output.WriteLine();
            }
            output.Close();
        }

        static void AddScore(Library l) {
            int DAYSCORESCALE = 10;
            int BOOKAMOUNTSCALE = 10;
            int FREQUENCYSCALE = 5;
            int BOOKRATIOSCALE = 15;

            float dagscore = (days - l.signUpProc) / days;
            //float dagscore = (l.signUpProc - avgSign) / avgSign;
            dagscore *= DAYSCORESCALE;
            float bookscore = (l.bookAmount - avgBooks) / avgBooks;
            bookscore *= BOOKAMOUNTSCALE;
            float freqscore = (l.shipPerDay - avgFreq) / avgFreq;
            freqscore *= FREQUENCYSCALE;
            /*float ratioscore = (l.bookAmount / l.shipPerDay - avgBookRatio) / avgBookRatio;
            ratioscore *= BOOKRATIOSCALE;*/

            float score = dagscore + bookscore + freqscore;
            l.score = score;
        }

        private static void CheckBooks(Library lib, int day)
        {
            if (isLibSigned[lib.index]) {
                // What books can we sign
                for(int i = 0; i < lib.shipPerDay; i++)
                {
                    //if()
                }
            } else {

            }
        }

    }

    class Library {
        public int index;
        public int bookAmount;
        public int signUpProc;
        public int shipPerDay;
        public Stack<int> bookInLib;
        public float score;

        public int[] booksToSend;
    }

}
