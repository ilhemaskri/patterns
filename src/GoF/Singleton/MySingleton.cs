using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("GoF.Tests")]

namespace GoF.Singleton
{
    public class MySingleton
    {
        private static MySingleton _instance;
        private bool _newState;

        private MySingleton()
        {
        }

        public void Shout()
        {
            Console.WriteLine("Hello");
        }

        public void SetState(bool newState)
        {
            _newState = newState;
        }

        public static MySingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MySingleton();
            }

            return _instance;
        }
    }
}