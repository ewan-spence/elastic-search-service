using ElasticSearchService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Helpers {
    public static class DummyDataHelper {

        public static bool FundAlreadyIn(string fundName, List<string> holdings) {

            foreach (var h in holdings) {
                if (h == fundName) return true;
            }
            return false;
        }

        public static List<string> GetAdviserNames() {

            return new List<string>
            {
                "Jeffrey Deans",
                "Callum Gorrie",
                "David Strachan",
                "Lisa Donald",
                "Paul Fincham",
                "Lynsey Fraser",
                "Caitlin Lloynd",
                "Kenny McAlpine",
                "Adrian Turner",
                "Lisa Woods"
            };
            
        }



        public static List<string> GetServiceTypes() {
            return new List<string>
            {
                "Basic",
                "Gold",
                "Platinum",
                "Trial",
                "Family"
            };
        }

        public static List<string> GetDummyFunds() {

            return new List<string>
            {
                "Scottish Life",
                "M&G UK", 
                "Invesco Perpetual Fund Mgrs",
                "Jupiter Unit Trust Mgrs",
                "Standard Life Investments",
                "Scottish Life, European Pn",
                "Schroder UT Managers, Tokyo",
                "Schroder UT Managers, MM Diversity Z Acc",
                "Standard Life Investments, Gl AbsRt",
                "Artemis Fund Managers",
                "JP Morgan Asset Management UK",
                "Scottish Life, Pacific Pn",
                "Scottish Life, UK Equity Pn",
                "LF Lindsell Train UK Equity",
                "TB Wise Multi-Asset Growth B",
                "Artemis SmartGARP Global Equity",
                "Stewart Investors Latin America Fund Class B",
                "Pictet Security I dy GBP",
                "FP Russell Investments ICVC",
                "WS Verbatim 5",
                "SVS Cornelian Managed Growth D Income",
                "Dodge and Cox Worldwide",
                "Polar Capital Funds PLC",
                "TM CRUX UK Core Fund B Acc",
                "Rathbone Ethical Bond",
                "Janus Henderson Fixed Interest",
                "Jupiter Monthly Income Bond Fund I GBP",
                "Jupiter Merian Global Equity Fund I GBP Acc",
                "Allianz Continental European Fund Class C Shares Acc"
            };

        }

        public static List<string> GetFirstNames() {
            return new List<string>
            {
                "Joe",
                "Brian",
                "Robert",
                "William",
                "Richard",
                "Jeffrey",
                "Thomas",
                "Steven",
                "Timothy",
                "Kevin",
                "Scott",
                "Charles",
                "Daniel",
                "Donald",
                "Eric",
                "Edward",
                "Todd",
                "Patrick",
                "George",
                "Keith",
                "Susan",
                "Julie",
                "Karen",
                "Deborah",
                "Tracey",
                "Jane",
                "Helen",
                "Diane",
                "Sharon",
                "Tracy",
                "Angela",
                "Sarah",
                "Alison",
                "Caroline",
                "Amanda",
                "Sandra",
                "Linda",
                "Catherine",
                "Elizabeth",
                "Carol",
                "Joanne",
                "Wendy",
                "Janet",
                "Dawn",
                "Ross",
                "Ewan"
            };
        }

        public static List<string> GetLastNames() {

            return new List<string>
            {
                "Marshall",
                "Stevenson",
                "Wood",
                "Sutherland",
                "Craig",
                "Wright",
                "McKenzie",
                "Kennedy",
                "Jones",
                "Burns",
                "White",
                "Muir",
                "Murphy",
                "Johnstone",
                "Hughes",
                "Watt",
                "McMillan",
                "McIntosh",
                "Lyons",
                "Spence",
                "Hill",
                "Douglas",
                "Donaldson",
                "Alexander",
                "MacLean",
                "Forbes",
                "Williams",
                "Kelly",
                "Bell",
                "Grant",
                "Wallace",
                "Gordon",
                "Russell",
                "Gibson",
                "Smith",
                "Brown",
                "Wilson",
                "Thomson",
                "Thompson",
                "Johnstone",
                "Johnson",
                "Campbell",
                "McDonald",
                "MacDonald",
                "Scott",
                "Reid",
                "Milloy",
                "Paterson",
                "Tinney",
                "Power",
                "O'Neil",
                "Doherty",
                "Clarkson"
            };
        }
    }
}
