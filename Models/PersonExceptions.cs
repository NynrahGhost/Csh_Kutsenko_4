using System;
using System.Windows;

namespace Csh_Kutsenko_01.Models
{
    class PersonNotBornException : Exception
    {
        public PersonNotBornException(string message) : base(message)
        {
            MessageBox.Show(message);
        }
    }

    class PersonTooOldException : Exception
    {
        public PersonTooOldException(string message) : base(message)
        {
            MessageBox.Show(message);
        }
    }

    class PersonEmailException : Exception
    {
        public PersonEmailException(string message) : base(message)
        {
            MessageBox.Show(message);
        }
    }
}
