using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace Dziekanat.UI
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}


//Program do rejestracji studentów. Ma mieć możliwość rejestracji studenta 
//(imię, nazwisko, pesel, data urodzenia). Ma mieć możliwość rejestracji przedmiotu 
//(nazwa przedmiotu, semestr studiów, imię i nazwisko prowadzącego)
//Ma być możliwość rejestracji dla studenta przedmiotu, oraz rejestracji studentów dla wybranego przedmiotu.
//    Program ma również umożliwiać wyszukiwanie studentów dla wskazanego przedmiotu i przedmiotu dla wskazanego studenta.
//    Program powinien być napisany z użyciem MVVM (albo WinForms, albo Wpf). Mają być unit testy.
//    Powinien używać EF.CORE w najnowszej wersji ze wsparciem tworzenia bazy przez migrację.
//    Oceniana będzie walidacja danych, układ GUI, nazewnictwo klas, komponentów.
//    Oceniana będzie modułowość i separacja warstw. Oceniany będzie styl i komentarze.

