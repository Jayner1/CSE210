using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("4 Private Dr", "Sacramento", "CA", "94203");
        Address address2 = new Address("221c Baker St", "Salt Lake City", "UT", "84044");
        Address address3 = new Address("0001 Cemetery Ln", "Seattle", "WA", "98039");

        Event lecture = new Lecture("Tech Talk", "A talk on the latest in tech", new DateTime(2024, 6, 3), "10:00 AM", address1, "Dr. Smith", 100);
        Event reception = new Reception("Networking Event", "An event to network with professionals", new DateTime(2024, 11, 15), "6:00 PM", address2, "rsvp@networking.com");
        Event outdoorGathering = new OutdoorGathering("Spring Festival", "A festival with live music and food", new DateTime(2024, 5, 10), "2:00 PM", address3, "Springy");

        Event[] events = { lecture, reception, outdoorGathering };

        foreach (var e in events)
        {
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine();
            Console.WriteLine("--------------------------");
        }
    }
}
