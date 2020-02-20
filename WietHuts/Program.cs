﻿using System;
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

            // Info per library
            for (int i = 0; i < libraries; i++) {
                string[] libInfo = Console.ReadLine().Split(" ");

                int bookAmount = int.Parse(libInfo[0]);
                int signUpProc = int.Parse(libInfo[1]);
                int shipPerDay = int.Parse(libInfo[2]);

                int[] books = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                int[] sortedBooks = books.OrderBy(x => bookScores[x]).ToArray();
                Stack<int> bookInLib = new Stack<int>(sortedBooks);
                int popped = bookInLib.Pop();

                Library lib = new Library { index = i, bookAmount = bookAmount, signUpProc = signUpProc, shipPerDay = shipPerDay, bookInLib = bookInLib };
                libList.Add(lib);
            }
        }

        static void DoThings() {
            for(int day = 0; day < days; day++)
                foreach (Library lib in libList)
                    CheckBooks(lib, day);
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
                    output.Write(libList[i].bookInLib.Pop());
                    output.Write(" ");
                }
                output.WriteLine();
            }
            output.Close();
        }

        private Library Score(Library l) {
            int scoregetal;
            scoregetal = days - l.signUpProc;
            //Bereken score
            l.score = scoregetal;
            return l;
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
        public int score;

        public int[] booksToSend;
    }

}
