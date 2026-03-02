using CinemaTicketSystem;

namespace prakt3_okfks
{
    public class UnitTest1
    {
        //Блок 1 - проверка корректных вычислений
        
        // проверка на базовую стоимость билета
        [Fact]
        public void CalculatePrice_DefaultPrice()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 26;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(300, otvet);
        }

        // проверка на скидку в среду
        [Fact]
        public void CalculatePrice_Discount_InWednesday()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Wednesday;
            req.Age = 26;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(210, otvet);
        }

        // проверка на скидку для детей до 6 лет
        [Fact]
        public void CalculatePrice_Discount_IsBaby()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 2;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(0, otvet);
        }

        // проверка на скидку для студента
        [Fact]
        public void CalculatePrice_IsStudent()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = true;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 19;
            req.IsVip = false;

            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(240, otvet);
        }

        // проверка на утреннюю скидку
        [Fact]
        public void CalculatePrice_MorningDiscount()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 11, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 26;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(255, otvet);
        }

        // проверка на VIP наценку для билета
        [Fact]
        public void CalculatePrice_VIP_ticket()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 26;
            req.IsVip = true;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(600, otvet);
        }

        // проверка на несколько скидок, примняется только наибольшая (для студентов 20%)
        [Fact]
        public void CalculatePrice_SomeDiacounts()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 11, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 19;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(255, otvet);
        }


        // Блок 2 - проверка граничных вычислений
        
        // проверка минимального возраста для детей (БАГ-репорт ID 001)
        /* [Fact]
        public void CalculatePrice_MinimumAge_forChild()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 6;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(180, otvet);
        }

        // проверка максимального возраста для детей (БАГ-репорт ID 001)
        [Fact]
        public void CalculatePrice_MaximumAge_forChild()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 17;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(180, otvet);
        } */

        // проверка минимального возраста для студента
        [Fact]
        public void CalculatePrice_MinimumAge_forStudent()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = true;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 18;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(240, otvet);
        }

        // проверка максимального возраста для студента
        [Fact]
        public void CalculatePrice_MaximumAge_forStudent()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = true;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 25;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(240, otvet);
        }

        // проверка минимального возраста для пенсионеров (БАГ-репорт ID 002)
        /* [Fact]
        public void CalculatePrice_MinimumAge_forOld()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 65;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(150, otvet);
        }

        // проверка максимального возраста для пенсионеров (БАГ-репорт ID 002)
        [Fact]
        public void CalculatePrice_MaxmimumAge_forOld()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 120;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(150, otvet);
        } */

        // проверка на пограничность между обычным и пенсионным возрастом
        [Fact]
        public void CalculatePrice_DefaultPrice_OldPrice()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 64;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(300, otvet);
        }

        // проверка на пограничность между детским до 6 лет и детским от 6 лет
        [Fact]
        public void CalculatePrice_BabyPrice_ChildPrice()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 5;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(0, otvet);
        }

        // проверка на пограничность между детским и студенческим
        [Fact]
        public void CalculatePrice_ChildPrice_StudentPrice()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = true;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 18;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(240, otvet);
        }

        // проверка на пограничность между обычным и студенческим
        [Fact]
        public void CalculatePrice_DefaultPrice_StudentPrice()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = true;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 25;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();
            var otvet = calc.CalculatePrice(req);

            Assert.Equal(240, otvet);
        }


        //Блок 3 - проверка исключений

        // проверка на пустой TicketRequest
        [Fact]
        public void CalculatePrice_Request_Null()
        {
            var calc = new TicketPriceCalculator();
            Assert.Throws<ArgumentNullException>(() => calc.CalculatePrice(null));
        }

        // проверка на возраст < 0
        [Fact]
        public void CalculatePrice_Age_Less_Zero()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = -1;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(() => calc.CalculatePrice(req));
        }

        // проверка на возраст > 120
        [Fact]
        public void CalculatePrice_Age_More_120()
        {
            TicketRequest req = new TicketRequest();
            req.IsStudent = false;
            req.SessionTime = new TimeSpan(0, 13, 0, 0);
            req.Day = DayOfWeek.Tuesday;
            req.Age = 121;
            req.IsVip = false;
            var calc = new TicketPriceCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(() => calc.CalculatePrice(req));
        }
    }
}