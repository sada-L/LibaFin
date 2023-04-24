namespace LibaFin
{
    public static class Finskay
    {
        public static void Call1 ()
        {
            Console.WriteLine("Введите число:");
            int num = Convert.ToInt32(Console.ReadLine());  // Ввод числа
            int remainder = num % 2;                        // Остаток

            if (num != 0)                                   // Проверка на Маслова
            {
                switch (remainder)
                {
                    case 0: Console.Write("Ваше число четное"); break;
                    case 1: Console.Write("Ваше число не четное"); break;
                    case -1: Console.Write("Ваше число не четное"); break;
                }
            }
            else
            {
                Console.WriteLine("Вы маслов?");
            }
        }
        public static void Call2 ()
        {
            Console.Write("Ввидите год: ");
            int year = Convert.ToInt32(Console.ReadLine());                                      // Ввод года
            if (year > 0)                                                                        // Проверка на Маслова
            {
                string[,] sign =                                                                 // Массив {Знак года,окончиние}
                {
                    { "Обезьяны", "й " },{ "Петуха", "го " },{ "Собоки", "й " },{ "Свиньи", "й " },{ "Крысы", "й " },{ "Быка", "го " },
                    { "Тигра", "го " },{ "Кролика", "го " },{ "Дракона", "го " },{ "Змеи", "й " },{ "Лошади", "й " }, { "Овцы", "й " }
                };
                string[] skin = { "металлическо", "водно", "деревянно", "огняно", "земляно" };   // Массив с окраской  
                int signPoint = year % 12, skinPoint = year % 10 / 2;                            // Поиск идокса знака года / окраски
                Console.WriteLine("Год " + year + " является годом " + skin[skinPoint] + sign[signPoint, 1] + sign[signPoint, 0]);   // Вывод предложения 
            }
            else
            {
                Console.WriteLine("Вы маслов?");
            }

        }
        public static void Call3 ()
        {
            Console.Write("Ввидите дату вашего рождения: ");
            string[] date = Console.ReadLine().Split(' ', '.', ',', '-', '/');  // Ввод массив с датой рождения
            string? resote;
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };  // кол.дней в месяце с января

            if (Convert.ToInt32(date[2]) % 4 == 0) months[1] = 29;              // в случае высокосного года

            string[] sing =              // массив с знаками
            {"Водолей","Рыбы","Овен","Телец","Близнецы","Рак","Лев","Дева","Весы","Скорпион","Стрелец","Козерог"};

            int[,] singDate =            // массив с датами знакам
            {{ 18,1},{ 20,2},{ 19,3},{ 20,4},{ 20,5},{ 22,6},{ 22,7},{ 22,8},{ 22,9},{ 21,10},{ 21,11},{ 19,0}};

            int month = Convert.ToInt32(date[1]) - 2; // месяц рождения
            if (month < 13 && Convert.ToInt32(date[0]) <= months[month + 1])
            {
                if (singDate[month, 0] < 20 && month == 1)
                { resote = "Козерог"; }
                else if (singDate[month, 0] > Convert.ToInt32(date[0]))
                { resote = sing[month]; }
                else
                { resote = sing[month + 1]; }
            }
            else
            { resote = "Маслов?"; }

            Console.WriteLine("Вы " + resote);
        }
        public static void Call4 ()
        {
            int determinant = 0;      //определитель для выбора единицы массива
            string? temp, revNum = "", resote = "";
            string[] single = { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            string[] dozens = { "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шесдесят", "семдесят", "восемдесят", "девяносто" };
            string[] binomial = { "одиннадцать", "двеннадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семьмяндцать", "восемьнадцать", "девятнадцать" };
            string[] hundrs = { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "десятьсот" };

            Console.WriteLine("Ввидите число от 0 до 9999");//ввод числа
            string? num = Console.ReadLine();
            int trynum = Convert.ToInt32(num);
            if (0 < trynum && trynum < 10000)
            {
                foreach (char i in num) // инвертирование массива(типа)
                    revNum = i + revNum;

                foreach (char item in revNum)
                {
                    ++determinant;
                    if (item - '0' != 0) //проверка на нуль
                    {
                        temp = determinant switch           //выборка единицы массивов
                        {
                            1 => single[(item - '0') - 1],
                            2 => dozens[(item - '0') - 1],
                            3 => hundrs[(item - '0') - 1],
                            4 => single[(item - '0') - 1],
                            _ => "Вы маслов?"
                        };

                        if (revNum[0] != 0 && item - '0' == 1 && determinant == 2)   //двучисленные числа
                            resote = binomial[(revNum[0] - '0') - 1];
                        else if (determinant == 4)
                        {
                            temp = (item - '0') switch           //выборка единицы массивов
                            {
                                1 => "одна тысяча ",
                                2 => "две тысячи ",
                                _ => temp + " тысячь "
                            };
                            resote = temp + resote;
                        }
                        else
                            resote = temp + " " + resote;
                    }
                }
                Console.WriteLine(resote);
            }
            else
            {
                Console.WriteLine("Вы маслов?");
            }
        }
    }
}