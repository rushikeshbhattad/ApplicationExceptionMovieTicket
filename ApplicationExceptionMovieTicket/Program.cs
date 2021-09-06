using System;

namespace ApplicationExceptionMovieTicket
{
    class Ticket
    {
        static int availableTickets = 50;
        public void BuyTicket(int buyNum)
        {
            availableTickets -= buyNum;
            if (buyNum > availableTickets || availableTickets < 0)
            {
                throw (new TicketsFinishedException("Sorry tickets are now over"));
            }
            Console.WriteLine("You Purchased {0} tickets, available tickets are {1}", buyNum, availableTickets);
        }
    }
    public class TicketsFinishedException : ApplicationException
    {
        public TicketsFinishedException(string message) : base(message)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int buyNum;
            string response;
            try
            {
                do
                {
                    Console.Write("How many tickets would you like to book: ");
                    buyNum = Convert.ToInt32(Console.ReadLine());
                    Ticket t = new Ticket();
                    t.BuyTicket(buyNum);
                    Console.Write("Would you like to book more tickets: ");
                    response = Console.ReadLine();
                } while (response == "Y" || response == "y");
            }
            catch (TicketsFinishedException tfe)
            {
                Console.WriteLine(tfe.Message);
            }
                Console.ReadKey();
        }
    }
}