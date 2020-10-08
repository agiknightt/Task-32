using System;
using System.Collections.Generic;

namespace Task_32
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = true;
            Train train = new Train();

            Direction direction = new Direction();
            Passenger passengers = new Passenger();
            train.CreateTrainCars(passengers.Passengers);

            Console.Clear();

            
            while (isExit)
            {
                train.ShowInfo(direction, passengers);
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("1 - Создать направление поезда\n2 - Отправить поезд\n3 - Выйти из программы");                
                
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        direction = new Direction();
                        passengers = new Passenger();
                        train.CreateTrainCars(passengers.Passengers);
                        break;
                    case 2:
                        train.SendTrain(direction, passengers);
                        break;
                    case 3:
                        isExit = false;
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    
    class Train
    {
        public void ShowInfo(Direction direction, Passenger passenger)
        {
            Console.WriteLine(passenger.Passengers + " пассажиров купили билеты на это направление поезда\n");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"Поезд {direction.DirectionFromWhere} - {direction.DirectionWhere} ");
            Console.SetCursorPosition(10, 0);            
        }
        
        public void SendTrain(Direction direction, Passenger passenger)
        {
            Console.WriteLine($"Поезд отправляется {direction.DirectionWhere}");
            direction.TakeAwayDirection();
            passenger.TakeAwayPassengers();
        }        
        public void CreateTrainCars(int passengers)
        {
            int freePlaces = passengers;
            while (freePlaces > 0)
            {
                TrainCar trainCar = new TrainCar();
                trainCar.FillPassengers(ref freePlaces);
            }
        }
    }
    class Passenger
    {
        private int _passengers;
        public int Passengers
        {
            get
            {
                return _passengers;
            }
        }
        public Passenger()
        {
            Random rand = new Random();
            _passengers = rand.Next(1, 100);
        }
        public void TakeAwayPassengers()
        {
            _passengers = 0;
        }
    }
    class Direction 
    {
        private string _directionFromWhere;
        private string _directionWhere;
        public string DirectionFromWhere
        {
            get
            {
                return _directionFromWhere;
            }
        }
        public string DirectionWhere
        {
            get
            {
                return _directionWhere;
            }
        }
        public Direction()
        {
            Console.Write("Откуда отправляется поезд ? : ");
            _directionFromWhere = Console.ReadLine();
            Console.Write("Куда отправляется поезд ? : ");
            _directionWhere = Console.ReadLine();
        }
        public void TakeAwayDirection()
        {
            _directionFromWhere = "Нет направления";
            _directionWhere = "Нет направления";
        }
    }
    class TrainCar : Train
    {
        private int _places;
        public TrainCar()
        {
            Random rand = new Random();
            _places = rand.Next(1, 21);
        }
        public int FillPassengers(ref int passengers)
        {
            if (passengers >= _places)
            {
                passengers -= _places;                
            }               
            return passengers;
        }
        
    }
    
}
