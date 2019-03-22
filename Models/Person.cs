using System;
using System.Linq;

namespace Csh_Kutsenko_01.Models
{
    [Serializable]
    class Person
    {
        #region Properties

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        #endregion


        #region Constructors

        public Person(string name, string surname, string email, DateTime birthDate)
        {
            if(((System.DateTime.Today - birthDate).Days / 365) > 135)
            {
                throw new PersonTooOldException("Обрана дата пізніше сьогоднішньої!");
            }
            if(birthDate > System.DateTime.Today)
            {
                throw new PersonNotBornException("Обрана дата занадто стара, тільки живі користувачі приймаються!");
            }
            if (!email.Contains<char>('@')) //   ¯\_(ツ)_ /¯
            {
                throw new PersonEmailException("Некорректна електронна пошта!");
            }

            this._name = name;
            this._surname = surname;
            this._email = email;
            this._birthDate = birthDate;

            IsAdult = ((System.DateTime.Today - birthDate).Days / 365) >= 18;
            switch (birthDate.Date.Month)
            {
                case 1:
                    SunSign = birthDate.Date.Day < 20 ? "Стрілець" : "Козоріг";
                    break;
                case 2:
                    SunSign = birthDate.Date.Day < 16 ? "Козоріг" : "Водолій";
                    break;
                case 3:
                    SunSign = birthDate.Date.Day < 11 ? "Водолій" : "Риби";
                    break;
                case 4:
                    SunSign = birthDate.Date.Day < 18 ? "Риби" : "Овен";
                    break;
                case 5:
                    SunSign = birthDate.Date.Day < 13 ? "Овен" : "Телець";
                    break;
                case 6:
                    SunSign = birthDate.Date.Day < 21 ? "Телець" : "Близнюки";
                    break;
                case 7:
                    SunSign = birthDate.Date.Day < 20 ? "Близнюки" : "Рак";
                    break;
                case 8:
                    SunSign = birthDate.Date.Day < 10 ? "Рак" : "Лев";
                    break;
                case 9:
                    SunSign = birthDate.Date.Day < 16 ? "Лев" : "Діва";
                    break;
                case 10:
                    SunSign = birthDate.Date.Day < 30 ? "Діва" : "Терези";
                    break;
                case 11:
                    SunSign = birthDate.Date.Day < 23 ? "Терези" : birthDate.Date.Day < 29 ? "Скорпіон" : "Змієносець";
                    break;
                case 12:
                    SunSign = birthDate.Date.Day < 17 ? "Змієносець" : "Стрілець";
                    break;
            }
            switch (birthDate.Date.Year % 12)
            {
                case 0:
                    ChineeseSign = "Мавпа";
                    break;
                case 1:
                    ChineeseSign = "Півень";
                    break;
                case 2:
                    ChineeseSign = "Собака";
                    break;
                case 3:
                    ChineeseSign = "Свиня";
                    break;
                case 4:
                    ChineeseSign = "Пацюк";
                    break;
                case 5:
                    ChineeseSign = "Бик";
                    break;
                case 6:
                    ChineeseSign = "Тигр";
                    break;
                case 7:
                    ChineeseSign = "Кролик";
                    break;
                case 8:
                    ChineeseSign = "Дракон";
                    break;
                case 9:
                    ChineeseSign = "Змія";
                    break;
                case 10:
                    ChineeseSign = "Кінь";
                    break;
                case 11:
                    ChineeseSign = "Коза";
                    break;
            }
            IsBirthday = birthDate.Date.Month == System.DateTime.Today.Month && birthDate.Date.Day == System.DateTime.Today.Day;
        }

        Person(string name, string surname, string email)
        {
            this._name = name;
            this._surname = surname;
            this._email = email;
        }

        Person(string name, string surname, DateTime birthDate)
        {
            this._name = name;
            this._surname = surname;
            this._birthDate = birthDate;

            IsAdult = ((System.DateTime.Today - birthDate).Days / 365) < 18;
            switch (birthDate.Date.Month)
            {
                case 1:
                    SunSign = birthDate.Date.Day < 20 ? "Стрілець" : "Козоріг";
                    break;
                case 2:
                    SunSign = birthDate.Date.Day < 16 ? "Козоріг" : "Водолій";
                    break;
                case 3:
                    SunSign = birthDate.Date.Day < 11 ? "Водолій" : "Риби";
                    break;
                case 4:
                    SunSign = birthDate.Date.Day < 18 ? "Риби" : "Овен";
                    break;
                case 5:
                    SunSign = birthDate.Date.Day < 13 ? "Овен" : "Телець";
                    break;
                case 6:
                    SunSign = birthDate.Date.Day < 21 ? "Телець" : "Близнюки";
                    break;
                case 7:
                    SunSign = birthDate.Date.Day < 20 ? "Близнюки" : "Рак";
                    break;
                case 8:
                    SunSign = birthDate.Date.Day < 10 ? "Рак" : "Лев";
                    break;
                case 9:
                    SunSign = birthDate.Date.Day < 16 ? "Лев" : "Діва";
                    break;
                case 10:
                    SunSign = birthDate.Date.Day < 30 ? "Діва" : "Терези";
                    break;
                case 11:
                    SunSign = birthDate.Date.Day < 23 ? "Терези" : birthDate.Date.Day < 29 ? "Скорпіон" : "Змієносець";
                    break;
                case 12:
                    SunSign = birthDate.Date.Day < 17 ? "Змієносець" : "Стрілець";
                    break;
            }
            switch (birthDate.Date.Year % 12)
            {
                case 0:
                    ChineeseSign = "Мавпа";
                    break;
                case 1:
                    ChineeseSign = "Півень";
                    break;
                case 2:
                    ChineeseSign = "Собака";
                    break;
                case 3:
                    ChineeseSign = "Свиня";
                    break;
                case 4:
                    ChineeseSign = "Пацюк";
                    break;
                case 5:
                    ChineeseSign = "Бик";
                    break;
                case 6:
                    ChineeseSign = "Тигр";
                    break;
                case 7:
                    ChineeseSign = "Кролик";
                    break;
                case 8:
                    ChineeseSign = "Дракон";
                    break;
                case 9:
                    ChineeseSign = "Змія";
                    break;
                case 10:
                    ChineeseSign = "Кінь";
                    break;
                case 11:
                    ChineeseSign = "Коза";
                    break;
            }
            IsBirthday = birthDate.Date.Month == System.DateTime.Today.Month && birthDate.Date.Day == System.DateTime.Today.Day;
        }

        #endregion


        #region Read-only

        public readonly bool IsAdult;
        public readonly string SunSign;
        public readonly string ChineeseSign;
        public readonly bool IsBirthday;

        #endregion

    }
}
