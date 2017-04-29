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
            AppUser u1 = new AppUser() { Email = "cbaker@freezing.co.uk", PasswordHash = "gazing", FirstName = "Christopher", LastName = "Baker", MiddleInitial = "L", Address = "1245 Lake Austin Blvd.", City = "Austin", State = StateAbrv.TX, ZipCode = "78733", PhoneNumber = "5125571146", DOB = "33276" };
            AppUser u2 = new AppUser() { Email = "mb@aool.com", PasswordHash = "ban2102678873uet", FirstName = "Michelle", LastName = "Banks", MiddleInitial = "", Address = "1300 Tall Pine Lane", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78261", PhoneNumber = "2102678873", DOB = "33047" };
            AppUser u3 = new AppUser() { Email = "fd@aool.com", PasswordHash = "666666", FirstName = "Franco", LastName = "Broccolo", MiddleInitial = "V", Address = "62 Browning Rd", City = "Houston", State = StateAbrv.TX, ZipCode = "77019", PhoneNumber = "8175659699", DOB = "31538" };
            AppUser u4 = new AppUser() { Email = "wendy@ggmail.com", PasswordHash = "clover", FirstName = "Wendy", LastName = "Chang", MiddleInitial = "L", Address = "202 Bellmont Hall", City = "Austin", State = StateAbrv.TX, ZipCode = "78713", PhoneNumber = "5125943222", DOB = "23732" };
            AppUser u5 = new AppUser() { Email = "limchou@yaho.com", PasswordHash = "austin", FirstName = "Lim", LastName = "Chou", MiddleInitial = "", Address = "1600 Teresa Lane", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78266", PhoneNumber = "2107724599", DOB = "18428" };
            AppUser u6 = new AppUser() { Email = "Dixon@aool.com", PasswordHash = "mailbox", FirstName = "Shan", LastName = "Dixon", MiddleInitial = "D", Address = "234 Holston Circle", City = "Dallas", State = StateAbrv.TX, ZipCode = "75208", PhoneNumber = "2142643255", DOB = "11087" };
            AppUser u7 = new AppUser() { Email = "louann@ggmail.com", PasswordHash = "aggies", FirstName = "Lou Ann", LastName = "Feeley", MiddleInitial = "K", Address = "600 S 8th Street W", City = "Houston", State = StateAbrv.TX, ZipCode = "77010", PhoneNumber = "8172556749", DOB = "11013" };
            AppUser u8 = new AppUser() { Email = "tfreeley@minntonka.ci.state.mn.us", PasswordHash = "raiders", FirstName = "Tesa", LastName = "Freeley", MiddleInitial = "P", Address = "4448 Fairview Ave.", City = "Houston", State = StateAbrv.TX, ZipCode = "77009", PhoneNumber = "8173255687", DOB = "13028" };
            AppUser u9 = new AppUser() { Email = "mgar@aool.com", PasswordHash = "mustangs", FirstName = "Margaret", LastName = "Garcia", MiddleInitial = "L", Address = "594 Longview", City = "Houston", State = StateAbrv.TX, ZipCode = "77003", PhoneNumber = "8176593544", DOB = "33057" };
            AppUser u10 = new AppUser() { Email = "chaley@thug.com", PasswordHash = "region", FirstName = "Charles", LastName = "Haley", MiddleInitial = "E", Address = "One Cowboy Pkwy", City = "Dallas", State = StateAbrv.TX, ZipCode = "75261", PhoneNumber = "2148475583", DOB = "31307" };
            AppUser u11 = new AppUser() { Email = "34722eff@ggmail.com", PasswordHash = "hungry", FirstName = "Jeffrey", LastName = "Hampton", MiddleInitial = "T", Address = "337 38th St.", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5126978613", DOB = "34722" };
            AppUser u12 = new AppUser() { Email = "w34342hearniii@umch.edu", PasswordHash = "logicon", FirstName = "John", LastName = "Hearn", MiddleInitial = "B", Address = "4225 North First", City = "Dallas", State = StateAbrv.TX, ZipCode = "75237", PhoneNumber = "2148965621", DOB = "34342" };
            AppUser u13 = new AppUser() { Email = "hicks43@ggmail.com", PasswordHash = "doofus", FirstName = "Anthony", LastName = "Hicks", MiddleInitial = "J", Address = "32 NE Garden Ln., Ste 910", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78239", PhoneNumber = "2105788965", DOB = "33152" };
            AppUser u14 = new AppUser() { Email = "bradsingram@mall.utexas.edu", PasswordHash = "mother", FirstName = "Brad", LastName = "Ingram", MiddleInitial = "S", Address = "6548 La Posada Ct.", City = "Austin", State = StateAbrv.TX, ZipCode = "78736", PhoneNumber = "5124678821", DOB = "30784" };
            AppUser u15 = new AppUser() { Email = "mother.Ingram@aool.com", PasswordHash = "whimsical", FirstName = "Todd", LastName = "Jacobs", MiddleInitial = "L", Address = "4564 Elm St.", City = "Austin", State = StateAbrv.TX, ZipCode = "78731", PhoneNumber = "5124653365", DOB = "30410" };
            AppUser u16 = new AppUser() { Email = "victoria@aool.com", PasswordHash = "nothing", FirstName = "Victoria", LastName = "Lawrence", MiddleInitial = "M", Address = "6639 Butterfly Ln.", City = "Austin", State = StateAbrv.TX, ZipCode = "78761", PhoneNumber = "5129457399", DOB = "22315" };
            AppUser u17 = new AppUser() { Email = "lineback@flush.net", PasswordHash = "GoodFellow", FirstName = "Erik", LastName = "Lineback", MiddleInitial = "W", Address = "1300 Netherland St", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78293", PhoneNumber = "2102449976", DOB = "17048" };
            AppUser u18 = new AppUser() { Email = "elowe@netscrape.net", PasswordHash = "impede", FirstName = "Ernest", LastName = "Lowe", MiddleInitial = "S", Address = "3201 Pine Drive", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78279", PhoneNumber = "2105344627", DOB = "33641" };
            AppUser u19 = new AppUser() { Email = "luce_chuck@ggmail.com", PasswordHash = "LuceyDucey", FirstName = "Chuck", LastName = "Luce", MiddleInitial = "B", Address = "2345 Rolling Clouds", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78268", PhoneNumber = "2106983548", DOB = "15639" };
            AppUser u20 = new AppUser() { Email = "mackcloud@pimpdaddy.com", PasswordHash = "cloudyday", FirstName = "Jennifer", LastName = "MacLeod", MiddleInitial = "D", Address = "2504 Far West Blvd.", City = "Austin", State = StateAbrv.TX, ZipCode = "78731", PhoneNumber = "5124748138", DOB = "23960" };
            AppUser u21 = new AppUser() { Email = "liz@ggmail.com", PasswordHash = "emarkbark", FirstName = "Elizabeth", LastName = "Markham", MiddleInitial = "P", Address = "7861 Chevy Chase", City = "Austin", State = StateAbrv.TX, ZipCode = "78732", PhoneNumber = "5124579845", DOB = "21653" };
            AppUser u22 = new AppUser() { Email = "mclarence@aool.com", PasswordHash = "smartinmartin", FirstName = "Clarence", LastName = "Martin", MiddleInitial = "A", Address = "87 Alcedo St.", City = "Houston", State = StateAbrv.TX, ZipCode = "77045", PhoneNumber = "8174955201", DOB = "32879" };
            AppUser u23 = new AppUser() { Email = "smartinmartin.Martin@aool.com", PasswordHash = "looter", FirstName = "Gregory", LastName = "Martinez", MiddleInitial = "R", Address = "8295 Sunset Blvd.", City = "Houston", State = StateAbrv.TX, ZipCode = "77030", PhoneNumber = "8178746718", DOB = "32059" };
            AppUser u24 = new AppUser() { Email = "cmiller@mapster.com", PasswordHash = "chucky33", FirstName = "Charles", LastName = "Miller", MiddleInitial = "R", Address = "8962 Main St.", City = "Houston", State = StateAbrv.TX, ZipCode = "77031", PhoneNumber = "8177458615", DOB = "30884" };
            AppUser u25 = new AppUser() { Email = "nelson.Kelly@aool.com", PasswordHash = "orange", FirstName = "Kelly", LastName = "Nelson", MiddleInitial = "T", Address = "2601 Red River", City = "Austin", State = StateAbrv.TX, ZipCode = "78703", PhoneNumber = "5122926966", DOB = "20640" };
            AppUser u26 = new AppUser() { Email = "23040o23040oe@ggmail.com", PasswordHash = "victorious", FirstName = "Joe", LastName = "Nguyen", MiddleInitial = "C", Address = "1249 4th SW St.", City = "Dallas", State = StateAbrv.TX, ZipCode = "75238", PhoneNumber = "2143125897", DOB = "23040" };
            AppUser u27 = new AppUser() { Email = "orielly@foxnets.com", PasswordHash = "billyboy", FirstName = "Bill", LastName = "O'Reilly", MiddleInitial = "T", Address = "8800 Gringo Drive", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78260", PhoneNumber = "2103450925", DOB = "30323" };
            AppUser u28 = new AppUser() { Email = "or@aool.com", PasswordHash = "radicalone", FirstName = "Anka", LastName = "Radkovich", MiddleInitial = "L", Address = "1300 Elliott Pl", City = "Dallas", State = StateAbrv.TX, ZipCode = "75260", PhoneNumber = "2142345566", DOB = "29311" };
            AppUser u29 = new AppUser() { Email = "megrhodes@freezing.co.uk", PasswordHash = "gohorns", FirstName = "Megan", LastName = "Rhodes", MiddleInitial = "C", Address = "4587 Enfield Rd.", City = "Austin", State = StateAbrv.TX, ZipCode = "78707", PhoneNumber = "5123744746", DOB = "16296" };
            AppUser u30 = new AppUser() { Email = "erynrice@aool.com", PasswordHash = "iloveme", FirstName = "Eryn", LastName = "Rice", MiddleInitial = "M", Address = "3405 Rio Grande", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5123876657", DOB = "12633" };
            AppUser u31 = new AppUser() { Email = "32731orge@hootmail.com", PasswordHash = "greedy", FirstName = "Jorge", LastName = "Rodriguez", MiddleInitial = "", Address = "6788 Cotter Street", City = "Houston", State = StateAbrv.TX, ZipCode = "77057", PhoneNumber = "8178904374", DOB = "32731" };
            AppUser u32 = new AppUser() { Email = "ra@aoo.com", PasswordHash = "familiar", FirstName = "Allen", LastName = "Rogers", MiddleInitial = "B", Address = "4965 Oak Hill", City = "Austin", State = StateAbrv.TX, ZipCode = "78732", PhoneNumber = "5128752943", DOB = "24711" };
            AppUser u33 = new AppUser() { Email = "st-18452ean@home.com", PasswordHash = "historical", FirstName = "Olivier", LastName = "Saint-Jean", MiddleInitial = "M", Address = "255 Toncray Dr.", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78292", PhoneNumber = "2104145678", DOB = "18452" };
            AppUser u34 = new AppUser() { Email = "ss34@ggmail.com", PasswordHash = "guiltless", FirstName = "Sarah", LastName = "Saunders", MiddleInitial = "J", Address = "332 Avenue C", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5123497810", DOB = "28427" };
            AppUser u35 = new AppUser() { Email = "willsheff@email.com", PasswordHash = "fre5124510084uent", FirstName = "William", LastName = "Sewell", MiddleInitial = "T", Address = "2365 51st St.", City = "Austin", State = StateAbrv.TX, ZipCode = "78709", PhoneNumber = "5124510084", DOB = "15087" };
            AppUser u36 = new AppUser() { Email = "sheff44@ggmail.com", PasswordHash = "history", FirstName = "Martin", LastName = "Sheffield", MiddleInitial = "J", Address = "3886 Avenue A", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5125479167", DOB = "13829" };
            AppUser u37 = new AppUser() { Email = "20023ohnsmith187@aool.com", PasswordHash = "s2108321888uirrel", FirstName = "John", LastName = "Smith", MiddleInitial = "A", Address = "23 Hidden Forge Dr.", City = "San Antonio", State = StateAbrv.TX, ZipCode = "78280", PhoneNumber = "2108321888", DOB = "20023" };
            AppUser u38 = new AppUser() { Email = "dustroud@mail.com", PasswordHash = "snakes", FirstName = "Dustin", LastName = "Stroud", MiddleInitial = "P", Address = "1212 Rita Rd", City = "Dallas", State = StateAbrv.TX, ZipCode = "75221", PhoneNumber = "2142346667", DOB = "11933" };
            AppUser u39 = new AppUser() { Email = "ericstuart@aool.com", PasswordHash = "landus", FirstName = "Eric", LastName = "Stuart", MiddleInitial = "D", Address = "5576 Toro Ring", City = "Austin", State = StateAbrv.TX, ZipCode = "78746", PhoneNumber = "5128178335", DOB = "11320" };
            AppUser u40 = new AppUser() { Email = "peterstump@hootmail.com", PasswordHash = "rhythm", FirstName = "Peter", LastName = "Stump", MiddleInitial = "L", Address = "1300 Kellen Circle", City = "Houston", State = StateAbrv.TX, ZipCode = "77018", PhoneNumber = "8174560903", DOB = "32733" };
            AppUser u41 = new AppUser() { Email = "tanner@ggmail.com", PasswordHash = "kindly", FirstName = "Jeremy", LastName = "Tanner", MiddleInitial = "S", Address = "4347 Almstead", City = "Houston", State = StateAbrv.TX, ZipCode = "77044", PhoneNumber = "8174590929", DOB = "30092" };
            AppUser u42 = new AppUser() { Email = "taylord21923ay@aool.com", PasswordHash = "instrument", FirstName = "Allison", LastName = "Taylor", MiddleInitial = "R", Address = "467 Nueces St.", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5124748452", DOB = "21923" };
            AppUser u43 = new AppUser() { Email = "TayTaylor@aool.com", PasswordHash = "arched", FirstName = "Rachel", LastName = "Taylor", MiddleInitial = "K", Address = "345 Longview Dr.", City = "Austin", State = StateAbrv.TX, ZipCode = "78705", PhoneNumber = "5124512631", DOB = "27602" };
            AppUser u44 = new AppUser() { Email = "teefrank@hootmail.com", PasswordHash = "median", FirstName = "Frank", LastName = "Tee", MiddleInitial = "J", Address = "5590 Lavell Dr", City = "Houston", State = StateAbrv.TX, ZipCode = "77004", PhoneNumber = "8178765543", DOB = "24934" };
            AppUser u45 = new AppUser() { Email = "tuck33@ggmail.com", PasswordHash = "approval", FirstName = "Clent", LastName = "Tucker", MiddleInitial = "J", Address = "312 Main St.", City = "Dallas", State = StateAbrv.TX, ZipCode = "75315", PhoneNumber = "2148471154", DOB = "28629" };
            AppUser u46 = new AppUser() { Email = "avelasco@yaho.com", PasswordHash = "decorate", FirstName = "Allen", LastName = "Velasco", MiddleInitial = "G", Address = "679 W. 4th", City = "Dallas", State = StateAbrv.TX, ZipCode = "75207", PhoneNumber = "2143985638", DOB = "23290" };
            AppUser u47 = new AppUser() { Email = "west34256@pioneer.net", PasswordHash = "grover", FirstName = "Jake", LastName = "West", MiddleInitial = "T", Address = "RR 3287", City = "Dallas", State = StateAbrv.TX, ZipCode = "75323", PhoneNumber = "2148475244", DOB = "34256" };
            AppUser u48 = new AppUser() { Email = "louielouie@aool.com", PasswordHash = "sturdy", FirstName = "Louis", LastName = "Winthorpe", MiddleInitial = "L", Address = "2500 Padre Blvd", City = "Dallas", State = StateAbrv.TX, ZipCode = "75220", PhoneNumber = "2145650098", DOB = "19145" };
            AppUser u49 = new AppUser() { Email = "rwood@voyager.net", PasswordHash = "decorous", FirstName = "Reagan", LastName = "Wood", MiddleInitial = "B", Address = "447 Westlake Dr.", City = "Austin", State = StateAbrv.TX, ZipCode = "78746", PhoneNumber = "5124545242", DOB = "33718" };

            /*
            //see if the user is already there
            AppUser userToAdd = userManager.FindByName(Email);
            if (userToAdd == null) //this user doesn't exist yet
            {
                userManager.Create(user, "Password123!");
                userToAdd = userManager.FindByName(Email);

                //add the user to the role
                if (userManager.IsInRole(userToAdd.Id, roleName) == false) //the user isn't in the role
                {
                    userManager.AddToRole(userToAdd.Id, roleName);
                }
            }*/
        }
    }
}