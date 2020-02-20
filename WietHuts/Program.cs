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

        // singing libs
        public static int signingLib;
        public static int signingDaysRemaining;
        public static Stack<Library> signinglist;

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
            // xxx
            signingLib = -1;
            signingDaysRemaining = 0;
            isLibSigned = new bool[libraries];
            isBookScanned = new bool[books];

            // Info per library
            for (int i = 0; i < libraries; i++) {
                string[] libInfo = Console.ReadLine().Split(" ");

                int bookAmount = int.Parse(libInfo[0]);
                int signUpProc = int.Parse(libInfo[1]);
                int shipPerDay = int.Parse(libInfo[2]);

                int[] books = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                int[] sortedBooks = books.OrderBy(x => bookScores[x]).ToArray();
                Stack<int> bookInLib = new Stack<int>(sortedBooks);

                Library lib = new Library { index = i, bookAmount = bookAmount, signUpProc = signUpProc, shipPerDay = shipPerDay, bookInLib = bookInLib, booksToSend = new List<int>() };
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

            signinglist = new Stack<Library>();
            for (int i = libList.Count - 1; i >= 0; i--) {
                signinglist.Push(libList[i]);
            }
            for (int day = 0; day < days; day++)
            {
                SignLibraries();

                foreach (Library lib in libList)
                {
                    CheckBooks(lib, day);
                }
            }
                
        }

        static void WriteOutput() {
            StreamWriter output = new StreamWriter("../../../output.txt");
            // Amount of libraries
            int counter = 0;
            foreach (Library lib in libList) {
                if (lib.booksToSend.Count > 0) counter++;
            }
            output.WriteLine(counter);

            for (int i = 0; i < libraries; i++) {
                Library l = libList[i];
                if (l.booksToSend.Count == 0) continue;
                // Library ID + amount of signups
                output.Write(l.index);
                output.Write(" ");
                output.WriteLine(l.booksToSend.Count);

                // Order of books to be send
                for (int j = 0; j < l.booksToSend.Count; j++) {
                    output.Write(l.booksToSend[j]);
                    output.Write(" ");
                }
                output.WriteLine();
            }
            output.Close();
        }

        static void AddScore(Library l) {
            int DAYSCORESCALE = 40;
            int BOOKAMOUNTSCALE = 10;
            int FREQUENCYSCALE = 10;
            int BOOKRATIOSCALE = 15;

            //float dagscore = (days - l.signUpProc) / days;
            float dagscore = (avgSign - l.signUpProc) / avgSign;
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
                for(int i = 0; i < lib.shipPerDay && lib.bookInLib.Count > 0; )
                {
                    int book = lib.bookInLib.Pop();
                    if (!isBookScanned[book]) {
                        isBookScanned[book] = true;
                        i++;
                        lib.booksToSend.Add(book);
                    }
                }
            }
        }

        private static void SignLibraries()
        {
            if (signingDaysRemaining == 0) {
                if (signingLib >= 0)
                    isLibSigned[signingLib] = true;

                if (signinglist.Count > 0)
                {
                    Library lib = signinglist.Pop();
                    signingLib = lib.index;
                    signingDaysRemaining = lib.signUpProc;
                }
            }

            signingDaysRemaining--;
        }
    }

    class Library {
        public int index;
        public int bookAmount;
        public int signUpProc;
        public int shipPerDay;
        public Stack<int> bookInLib;
        public float score;

        public List<int> booksToSend;
    }

}
