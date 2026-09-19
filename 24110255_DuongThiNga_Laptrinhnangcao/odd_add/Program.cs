using System;
using System.Collections.Generic;

namespace TachSoChanLe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listSo = new List<int> { 6, 7, 8, 9, 10 };
            List<int> chan = new List<int>();
            List<int> le = new List<int>();

            foreach (int so in listSo)
            {
                if (so % 2 == 0)
                {
                    chan.Add(so);
                }
                else
                {
                    le.Add(so);
                }
            }

            Console.WriteLine("Danh sach so chan: " + string.Join(", ", chan));
            Console.WriteLine("Danh sach so le: " + string.Join(", ", le));
        }
    }
}