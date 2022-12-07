using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /// <summary>
    /// Concrete Observer
    /// </summary>
    public class TicketResellerService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            // update local datastore (datastore omitted in demo implementation)
            Console.WriteLine($"{nameof(TicketResellerService)} notified " +
                $"of ticket change: artist {ticketChange.ArtistId}, amount " +
                $"{ticketChange.Amount}");
        }
    }
}
