using System;
using System.Runtime.InteropServices;

namespace linkedlListExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Flight head = null;
            Flight tail = null;
            
            Passenger[] passengers = new Passenger[2];
            passengers[0] = new Passenger { name = "Selahattin" , surname = "Demirçin",chairId = 1};
            passengers[1] = new Passenger { name = "Alper", surname = "Ateş" , chairId = 2};

            void AddFlight(string from,string to,int flightNo,Passenger[] _passengers)
            {
                if (head != null)
                {
                    Flight flight = new Flight();
                    flight.flightId = flightNo;
                    flight.route = new Route
                    {
                        start = new City
                        {
                            name  = from,next = new City
                            {
                                name = to
                            }
                        },passengers = _passengers
                    };

                    if (tail != null)
                    {
                        tail.next = flight;
                    }
                    flight.prev = tail;

                    tail = flight;
                }
                else
                {
                    Flight flight = new Flight();
                    flight.flightId = flightNo;
                    flight.route = new Route
                    {
                        start = new City
                        {
                            name  = from,next = new City
                            {
                                name = to
                            }
                        },passengers = _passengers
                    };

                    head = flight;
                    tail = flight;
                }
            }
            void FindFlight(int flightId)
            {
                Flight index = head;
                bool bulunduMu = false;
                while (index != null)
                {
                    if (index.flightId == flightId)
                    {
                        Console.WriteLine("Uçuş "+index.route.start.name+" - "+index.route.start.next.name+ " yönündedir.");
                        bulunduMu = true;
                        break;
                    }
                    index = index.next;
                }

                if (bulunduMu == false)
                {
                    Console.WriteLine("Aradığınız uçuş bulunamadı.");
                }
            }
            
            AddFlight("Ankara","İstanbul",10,passengers);
            AddFlight("İzmir","Muğla",20,passengers);
            AddFlight("Antalya","Erzurum",30,passengers);
            AddFlight("Batman","Trabzon",40,passengers);
            AddFlight("Konya","Adana",50,passengers);

            FindFlight(10);
        }
    }

    class Flight
    {
        public int flightId { get; set; }
        public Flight next { get; set; }
        public Flight prev { get; set; }
        public Route route { get; set; }
    }

    class Route
    {
        public Passenger[] passengers { get; set; }
        public City start { get; set; }
    }

    class Passenger
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int chairId { get; set; }
    }

    class City
    {
        public string name { get; set; }
        public City next { get; set; }
    }
}