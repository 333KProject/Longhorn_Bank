using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Longhorn_Bank.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Longhorn_Bank.Migrations
{
    public class SeedIdentity
    {
        public static void SeedUsers(AppDbContext db)
        {
            //create a user manager to add users to databases
            UserManager<AppUser> userManager = new UserManager<AppUser>(new UserStore<AppUser>(db));

            //create a role manager
            AppRoleManager roleManager = new AppRoleManager(new RoleStore<AppRole>(db));
                
            //create an admin role
            String roleName = "User";
            //check to see if the role exists
            if (roleManager.RoleExists(roleName) == false) //role doesn't exist
            {
                roleManager.Create(new AppRole(roleName));
            }

            //create users
            String stru1Email = "cbaker@freezing.co.uk"; AppUser u1 = new AppUser() { Email = "cbaker@freezing.co.uk", PasswordHash = "gazing", FirstName = "Christopher", LastName = "Baker", MiddleInitial = "L", Address = "1245 Lake Austin Blvd.", City = "Austin", State = StateAbrv.TX, ZipCode = "78733", PhoneNumber = "5125571146", DOB = "02/07/199" };
            AppUser userToAdd1 = userManager.FindByName(stru1Email);
            if (userToAdd1 == null) //this user doesn't exist yet	
            {
                userManager.Create(u1, "PasswordHash123!");
                userToAdd1 = userManager.FindByName(stru1Email);

                //add the user to the role		
                if (userManager.IsInRole(userToAdd1.Id, roleName) == false) //the user isn't in the role
                {
                    userManager.AddToRole(userToAdd1.Id, roleName);
                }
            }
            /*
            String stru2Email = "mb@aool.com"; AppUser u2 = new AppUser() { Email = "mb@aool.com", PasswordHash = "ban2102678873uet", FirstName = "Michelle", LastName = "Banks", MiddleInitial = "", Address = "1300 Tall Pine Lane", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78261", PhoneNumber = "2102678873", DOB = DateTime.Parse("6/23/1990") };
            AppUser userToAdd = userManager.FindByName(stru2Email);
            if (userToAdd == null) //this user doesn't exist yet	
            {
                userManager.Create(u2, "PasswordHash123!");
                userToAdd = userManager.FindByName(stru2Email);

                //add the user to the role		
                if (userManager.IsInRole(userToAdd.Id, roleName) == false) //the user isn't in the role
                {
                    userManager.AddToRole(userToAdd.Id, roleName);
                }
            }


            String stru3Email = "fd@aool.com"; AppUser u3 = new AppUser() { Email = "fd@aool.com", PasswordHash = "666666", FirstName = "Franco", LastName = "Broccolo", MiddleInitial = "V", Address = "62 Browning Rd", City = "Houston", State = StateAbrv.TX, ZipCode = "77019", PhoneNumber = "8175659699", DOB = DateTime.Parse("5/6/1986") };

            String stru4Email = "wendy@ggmail.com"; AppUser u4 = new AppUser() { Email = "wendy@ggmail.com", PasswordHash = "clover", FirstName = "Wendy", LastName = "Chang", MiddleInitial = "L", Address = "202 Bellmont Hall", City = "Austin", State = StateAbrv.TX, ZipCode = "78713", PhoneNumber = "5125943222", DOB = DateTime.Parse("12/21/1964") };

            String stru5Email = "limchou@yaho.com"; AppUser u5 = new AppUser() { Email = "limchou@yaho.com", PasswordHash = "austin", FirstName = "Lim", LastName = "Chou", MiddleInitial = "", Address = "1600 Teresa Lane", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78266", PhoneNumber = "2107724599", DOB = DateTime.Parse("6/14/1950") };

            String stru6Email = "Dixon@aool.com"; AppUser u6 = new AppUser() { Email = "Dixon@aool.com", PasswordHash = "mailbox", FirstName = "Shan", LastName = "Dixon", MiddleInitial = "D", Address = "234 Holston Circle", City = "Dallas", State = StateAbrv.TX, ZipCode = "75208", PhoneNumber = "2142643255", DOB = DateTime.Parse("5/9/1930") };

            String stru7Email = "louann@ggmail.com"; AppUser u7 = new AppUser() { Email = "louann@ggmail.com", PasswordHash = "aggies", FirstName = "Lou Ann", LastName = "Feeley", MiddleInitial = "K", Address = "600 S 8th Street W", City = "Houston", State = StateAbrv.TX, ZipCode = "77010", PhoneNumber = "8172556749", DOB = DateTime.Parse("2/24/1930") };

            String stru8Email = "tfreeley@minntonka.ci.state.mn.us"; AppUser u8 = new AppUser() { Email = "tfreeley@minntonka.ci.state.mn.us", PasswordHash = "raiders", FirstName = "Tesa", LastName = "Freeley", MiddleInitial = "P", Address = "4448 Fairview Ave.", City = "Houston", State = StateAbrv.TX, ZipCode = "77009", PhoneNumber = "8173255687", DOB = DateTime.Parse("9/1/1935") };

            String stru9Email = "mgar@aool.com"; AppUser u9 = new AppUser() { Email = "mgar@aool.com", PasswordHash = "mustangs", FirstName = "Margaret", LastName = "Garcia", MiddleInitial = "L", Address = "594 Longview", City = "Houston", State = StateAbrv.TX, ZipCode = "77003", PhoneNumber = "8176593544", DOB = DateTime.Parse("7/3/1990") };

            String stru10Email = "chaley@thug.com"; AppUser u10 = new AppUser() { Email = "chaley@thug.com", PasswordHash = "region", FirstName = "Charles", LastName = "Haley", MiddleInitial = "E", Address = "One Cowboy Pkwy", City = "Dallas", State = StateAbrv.TX, ZipCode = "75261", PhoneNumber = "2148475583", DOB = DateTime.Parse("9/17/1985") };

            String stru11Email = "jeff@ggmail.com"; AppUser u11 = new AppUser() { Email = "jeff@ggmail.com", PasswordHash = "hungry", FirstName = "Jeffrey", LastName = "Hampton", MiddleInitial = "T", Address = "337 38th St.", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5126978613", DOB = DateTime.Parse("1/23/1995") };

            String stru12Email = "wjhearniii@umch.edu"; AppUser u12 = new AppUser() { Email = "wjhearniii@umch.edu", PasswordHash = "logicon", FirstName = "John", LastName = "Hearn", MiddleInitial = "B", Address = "4225 North First", City = "Dallas", State = StateAbrv.TX, ZipCode = "75237", PhoneNumber = "2148965621", DOB = DateTime.Parse("1/8/1994") };

            String stru13Email = "hicks43@ggmail.com"; AppUser u13 = new AppUser() { Email = "hicks43@ggmail.com", PasswordHash = "doofus", FirstName = "Anthony", LastName = "Hicks", MiddleInitial = "J", Address = "32 NE Garden Ln., Ste 910", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78239", PhoneNumber = "2105788965", DOB = DateTime.Parse("10/6/1990") };

            String stru14Email = "bradsingram@mall.utexas.edu"; AppUser u14 = new AppUser() { Email = "bradsingram@mall.utexas.edu", PasswordHash = "mother", FirstName = "Brad", LastName = "Ingram", MiddleInitial = "S", Address = "8", City = "Austin", State = StateAbrv.TX, ZipCode = "78736", PhoneNumber = "5124678821", DOB = DateTime.Parse("4/12/1984") };

            String stru15Email = "mother.Ingram@aool.com"; AppUser u15 = new AppUser() { Email = "mother.Ingram@aool.com", PasswordHash = "whimsical", FirstName = "Todd", LastName = "Jacobs", MiddleInitial = "L", Address = "4564 Elm St.", City = "Austin", State = StateAbrv.TX, ZipCode = "78731", PhoneNumber = "5124653365", DOB = DateTime.Parse("4/4/1983") };

            String stru16Email = "victoria@aool.com"; AppUser u16 = new AppUser() { Email = "victoria@aool.com", PasswordHash = "nothing", FirstName = "Victoria", LastName = "Lawrence", MiddleInitial = "M", Address = "6639 Butterfly Ln.", City = "Austin", State = StateAbrv.TX, ZipCode = "78761", PhoneNumber = "5129457399", DOB = DateTime.Parse("2/3/1961") };

            String stru17Email = "lineback@flush.net"; AppUser u17 = new AppUser() { Email = "lineback@flush.net", PasswordHash = "GoodFellow", FirstName = "Erik", LastName = "Lineback", MiddleInitial = "W", Address = "1300 Netherland St", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78293", PhoneNumber = "2102449976", DOB = DateTime.Parse("9/3/1946") };

            String stru18Email = "elowe@netscrape.net"; AppUser u18 = new AppUser() { Email = "elowe@netscrape.net", PasswordHash = "impede", FirstName = "Ernest", LastName = "Lowe", MiddleInitial = "S", Address = "3201 Pine Drive", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78279", PhoneNumber = "2105344627", DOB = DateTime.Parse("2/7/1992") };

            String stru19Email = "luce_chuck@ggmail.com"; AppUser u19 = new AppUser() { Email = "luce_chuck@ggmail.com", PasswordHash = "LuceyDucey", FirstName = "Chuck", LastName = "Luce", MiddleInitial = "B", Address = "2345 Rolling Clouds", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78268", PhoneNumber = "2106983548", DOB = DateTime.Parse("10/25/1942") };

            String stru20Email = "mackcloud@pimpdaddy.com"; AppUser u20 = new AppUser() { Email = "mackcloud@pimpdaddy.com", PasswordHash = "cloudyday", FirstName = "Jennifer", LastName = "MacLeod", MiddleInitial = "D", Address = "2504 Far West Blvd.", City = "Austin", State = StateAbrv.TX, ZipCode = "78731", PhoneNumber = "5124748138", DOB = DateTime.Parse("8/6/1965") };

            String stru21Email = "liz@ggmail.com"; AppUser u21 = new AppUser() { Email = "liz@ggmail.com", PasswordHash = "emarkbark", FirstName = "Elizabeth", LastName = "Markham", MiddleInitial = "P", Address = "7861 Chevy Chase", City = "Austin", State = StateAbrv.TX, ZipCode = "78732", PhoneNumber = "5124579845", DOB = DateTime.Parse("4/13/1959") };

            String stru22Email = "mclarence@aool.com"; AppUser u22 = new AppUser() { Email = "mclarence@aool.com", PasswordHash = "smartinmartin", FirstName = "Clarence", LastName = "Martin", MiddleInitial = "A", Address = "87 Alcedo St.", City = "Houston", State = StateAbrv.TX, ZipCode = "77045", PhoneNumber = "8174955201", DOB = DateTime.Parse("1/6/1990") };

            String stru23Email = "smartinmartin.Martin@aool.com"; AppUser u23 = new AppUser() { Email = "smartinmartin.Martin@aool.com", PasswordHash = "looter", FirstName = "Gregory", LastName = "Martinez", MiddleInitial = "R", Address = "8295 Sunset Blvd.", City = "Houston", State = StateAbrv.TX, ZipCode = "77030", PhoneNumber = "8178746718", DOB = DateTime.Parse("10/9/1987") };

            String stru24Email = "cmiller@mapster.com"; AppUser u24 = new AppUser() { Email = "cmiller@mapster.com", PasswordHash = "chucky33", FirstName = "Charles", LastName = "Miller", MiddleInitial = "R", Address = "8962 Main St.", City = "Houston", State = StateAbrv.TX, ZipCode = "77031", PhoneNumber = "8177458615", DOB = DateTime.Parse("7/21/1984") };

            String stru25Email = "nelson.Kelly@aool.com"; AppUser u25 = new AppUser() { Email = "nelson.Kelly@aool.com", PasswordHash = "orange", FirstName = "Kelly", LastName = "Nelson", MiddleInitial = "T", Address = "2601 Red River", City = "Austin", State = StateAbrv.TX, ZipCode = "78703", PhoneNumber = "5122926966", DOB = DateTime.Parse("7/4/1956") };

            String stru26Email = "jojoe@ggmail.com"; AppUser u26 = new AppUser() { Email = "jojoe@ggmail.com", PasswordHash = "victorious", FirstName = "Joe", LastName = "Nguyen", MiddleInitial = "C", Address = "1249 4th SW St.", City = "Dallas", State = StateAbrv.TX, ZipCode = "75238", PhoneNumber = "2143125897", DOB = DateTime.Parse("1/29/1963") };

            String stru27Email = "orielly@foxnets.com"; AppUser u27 = new AppUser() { Email = "orielly@foxnets.com", PasswordHash = "billyboy", FirstName = "Bill", LastName = "O'Reilly", MiddleInitial = "T", Address = "8800 Gringo Drive", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78260", PhoneNumber = "2103450925", DOB = DateTime.Parse("1/7/1983") };

            String stru28Email = "or@aool.com"; AppUser u28 = new AppUser() { Email = "or@aool.com", PasswordHash = "radicalone", FirstName = "Anka", LastName = "Radkovich", MiddleInitial = "L", Address = "1300 Elliott Pl", City = "Dallas", State = StateAbrv.TX, ZipCode = "75260", PhoneNumber = "2142345566", DOB = DateTime.Parse("3/31/1980") };

            String stru29Email = "megrhodes@freezing.co.uk"; AppUser u29 = new AppUser() { Email = "megrhodes@freezing.co.uk", PasswordHash = "gohorns", FirstName = "Megan", LastName = "Rhodes", MiddleInitial = "C", Address = "4587 Enfield Rd.", City = "Austin", State = StateAbrv.TX, ZipCode = "78707", PhoneNumber = "5123744746", DOB = DateTime.Parse("8/12/1944") };

            String stru30Email = "erynrice@aool.com"; AppUser u30 = new AppUser() { Email = "erynrice@aool.com", PasswordHash = "iloveme", FirstName = "Eryn", LastName = "Rice", MiddleInitial = "M", Address = "3405 Rio Grande", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5123876657", DOB = DateTime.Parse("8/2/1934") };

            String stru31Email = "jorge@hootmail.com"; AppUser u31 = new AppUser() { Email = "jorge@hootmail.com", PasswordHash = "greedy", FirstName = "Jorge", LastName = "Rodriguez", MiddleInitial = "", Address = "6788 Cotter Street", City = "Houston", State = StateAbrv.TX, ZipCode = "77057", PhoneNumber = "8178904374", DOB = DateTime.Parse("8/11/1989") };

            String stru32Email = "ra@aoo.com"; AppUser u32 = new AppUser() { Email = "ra@aoo.com", PasswordHash = "familiar", FirstName = "Allen", LastName = "Rogers", MiddleInitial = "B", Address = "4965 Oak Hill", City = "Austin", State = StateAbrv.TX, ZipCode = "78732", PhoneNumber = "5128752943", DOB = DateTime.Parse("8/27/1967") };

            String stru33Email = "st-jean@home.com"; AppUser u33 = new AppUser() { Email = "st-jean@home.com", PasswordHash = "historical", FirstName = "Olivier", LastName = "Saint-Jean", MiddleInitial = "M", Address = "255 Toncray Dr.", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78292", PhoneNumber = "2104145678", DOB = DateTime.Parse("7/8/1950") };

            String stru34Email = "ss34@ggmail.com"; AppUser u34 = new AppUser() { Email = "ss34@ggmail.com", PasswordHash = "guiltless", FirstName = "Sarah", LastName = "Saunders", MiddleInitial = "J", Address = "332 Avenue C", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5123497810", DOB = DateTime.Parse("10/29/1977") };

            String stru35Email = "willsheff@email.com"; AppUser u35 = new AppUser() { Email = "willsheff@email.com", PasswordHash = "fre5124510084uent", FirstName = "William", LastName = "Sewell", MiddleInitial = "T", Address = "2365 51st St.", City = "Austin", State = StateAbrv.TX, ZipCode = "78709", PhoneNumber = "5124510084", DOB = DateTime.Parse("4/21/1941") };

            String stru36Email = "sheff44@ggmail.com"; AppUser u36 = new AppUser() { Email = "sheff44@ggmail.com", PasswordHash = "history", FirstName = "Martin", LastName = "Sheffield", MiddleInitial = "J", Address = "3886 Avenue A", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5125479167", DOB = DateTime.Parse("11/10/1937") };

            String stru37Email = "johnsmith187@aool.com"; AppUser u37 = new AppUser() { Email = "johnsmith187@aool.com", PasswordHash = "s2108321888uirrel", FirstName = "John", LastName = "Smith", MiddleInitial = "A", Address = "23 Hidden Forge Dr.", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78280", PhoneNumber = "2108321888", DOB = DateTime.Parse("10/26/1954") };

            String stru38Email = "dustroud@mail.com"; AppUser u38 = new AppUser() { Email = "dustroud@mail.com", PasswordHash = "snakes", FirstName = "Dustin", LastName = "Stroud", MiddleInitial = "P", Address = "1212 Rita Rd", City = "Dallas", State = StateAbrv.TX, ZipCode = "8", PhoneNumber = "2142346667", DOB = DateTime.Parse("9/1/1932") };

            String stru39Email = "ericstuart@aool.com"; AppUser u39 = new AppUser() { Email = "ericstuart@aool.com", PasswordHash = "landus", FirstName = "Eric", LastName = "Stuart", MiddleInitial = "D", Address = "5576 Toro Ring", City = "Austin", State = StateAbrv.TX, ZipCode = "78746", PhoneNumber = "5128178335", DOB = DateTime.Parse("12/28/1930") };

            String stru40Email = "peterstump@hootmail.com"; AppUser u40 = new AppUser() { Email = "peterstump@hootmail.com", PasswordHash = "rhythm", FirstName = "Peter", LastName = "Stump", MiddleInitial = "L", Address = "1300 Kellen Circle", City = "Houston", State = StateAbrv.TX, ZipCode = "77018", PhoneNumber = "8174560903", DOB = DateTime.Parse("8/13/1989") };

            String stru41Email = "tanner@ggmail.com"; AppUser u41 = new AppUser() { Email = "tanner@ggmail.com", PasswordHash = "kindly", FirstName = "Jeremy", LastName = "Tanner", MiddleInitial = "S", Address = "4347 Almstead", City = "Houston", State = StateAbrv.TX, ZipCode = "77044", PhoneNumber = "8174590929", DOB = DateTime.Parse("5/21/1982") };

            String stru42Email = "taylordjay@aool.com"; AppUser u42 = new AppUser() { Email = "taylordjay@aool.com", PasswordHash = "instrument", FirstName = "Allison", LastName = "Taylor", MiddleInitial = "R", Address = "467 Nueces St.", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5124748452", DOB = DateTime.Parse("1/8/1960") };

            String stru43Email = "TayTaylor@aool.com"; AppUser u43 = new AppUser() { Email = "TayTaylor@aool.com", PasswordHash = "arched", FirstName = "Rachel", LastName = "Taylor", MiddleInitial = "K", Address = "345 Longview Dr.", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5124512631", DOB = DateTime.Parse("7/27/1975") };

            String stru44Email = "teefrank@hootmail.com"; AppUser u44 = new AppUser() { Email = "teefrank@hootmail.com", PasswordHash = "median", FirstName = "Frank", LastName = "Tee", MiddleInitial = "J", Address = "5590 Lavell Dr", City = "Houston", State = StateAbrv.TX, ZipCode = "77004", PhoneNumber = "8178765543", DOB = DateTime.Parse("4/6/1968") };

            String stru45Email = "tuck33@ggmail.com"; AppUser u45 = new AppUser() { Email = "tuck33@ggmail.com", PasswordHash = "approval", FirstName = "Clent", LastName = "Tucker", MiddleInitial = "J", Address = "312 Main St.", City = "Dallas", State = StateAbrv.TX, ZipCode = "75315", PhoneNumber = "2148471154", DOB = DateTime.Parse("5/19/1978") };

            String stru46Email = "avelasco@yaho.com"; AppUser u46 = new AppUser() { Email = "avelasco@yaho.com", PasswordHash = "decorate", FirstName = "Allen", LastName = "Velasco", MiddleInitial = "G", Address = "679 W. 4th", City = "Dallas", State = StateAbrv.TX, ZipCode = "75207", PhoneNumber = "2143985638", DOB = DateTime.Parse("1/4/1900") };

            String stru47Email = "westj@pioneer.net"; AppUser u47 = new AppUser() { Email = "westj@pioneer.net", PasswordHash = "grover", FirstName = "Jake", LastName = "West", MiddleInitial = "T", Address = "RR 3287", City = "Dallas", State = StateAbrv.TX, ZipCode = "75323", PhoneNumber = "2148475244", DOB = DateTime.Parse("10/14/1993") };

            String stru48Email = "louielouie@aool.com"; AppUser u48 = new AppUser() { Email = "louielouie@aool.com", PasswordHash = "sturdy", FirstName = "Louis", LastName = "Winthorpe", MiddleInitial = "L", Address = "2500 Padre Blvd", City = "Dallas", State = StateAbrv.TX, ZipCode = "75220", PhoneNumber = "2145650098", DOB = DateTime.Parse("5/31/1952") };

            String stru49Email = "rwood@voyager.net"; AppUser u49 = new AppUser() { Email = "rwood@voyager.net", PasswordHash = "decorous", FirstName = "Reagan", LastName = "Wood", MiddleInitial = "B", Address = "447 Westlake Dr.", City = "Austin", State = "StateAbrv.TX", ZipCode = "78746", PhoneNumber = "5124545242", DOB = DateTime.Parse("4/24/1992") };


            //see if the user is already there*/

        }
    }
}