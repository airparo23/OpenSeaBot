using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSeaBot.Offer
{
    public class Offer
    {
        public double Value { get; set; }
        public OfferType Type { get; set; }
    }

    public enum OfferType
    {
        VividLimited,
        TheLobstars,
        MutantGrandpaCountryClub
    }


}
