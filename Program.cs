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

            train.CreateDirection();
            train.CreatePassenger();
            train.CreateTrainCars();

            Console.Clear();

            
            while (isExit)
            {
                train.ShowInfo();
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("1 - Создать направление поезда\n2 - Отправить поезд\n3 - Выйти из программы");                
                
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        train.CreateDirection();
                        train.CreatePassenger();
                        train.CreateTrainCars();
                        break;
                    case 2:
                        train.SendTrain();
                        break;
                    case 3:
                        isExit = false;
                        break;
                }                
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    
    class Train
    {
        private int _passengers;
        private string _directionFromWhere;
        private string _directionWhere;
        private int _countTrain;
        public void CreateDirection()
        {
            Console.Write("Откуда отправляется поезд ? : ");
            _directionFromWhere = Console.ReadLine();
            Console.Write("Куда отправляется поезд ? : ");
            _directionWhere = Console.ReadLine();
        }

        public void ShowInfo()
        {
            Console.WriteLine( + _passengers + " пассажиров купили билеты на это направление поезда\n");

            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"Поезд {_directionFromWhere} - {_directionWhere} ");
            Console.SetCursorPosition(10, 0);
        }

        public void CreatePassenger()
        {
            Random rand = new Random();
            _passengers = rand.Next(1,100);
        }
        public void CreateTrainCars()
        {
            int freePlaces = _passengers;
            while (freePlaces > 0)
            {
                TrainCar trainCar = new TrainCar();
                freePlaces = trainCar.CreateTrainCar(freePlaces);
            }
            Console.WriteLine("\n\n" + _passengers + "\n\n");
        }
        public void SendTrain()
        {
            Console.WriteLine($"Поезд отправляется {_directionWhere}");
            _directionFromWhere = "Нет направления";
            _directionWhere = "Нет направления";
            _passengers = 0;
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
        public int CreateTrainCar(int passengers)
        {
            if (passengers >= _places)
            {
                passengers -= _places;                
            }               
            return passengers;
        }
    }
    
}
