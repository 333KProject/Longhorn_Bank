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
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            //create a role manager
            AppRoleManager roleManager = new AppRoleManager(new RoleStore<AppRole>(db));

            //create an admin role
            String roleName = "User";
            //check to see if the role exists
            if (roleManager.RoleExists(roleName) == false) //role doesn't exist
            {
                roleManager.Create(new AppRole(roleName));
            }

            String Manager = "Manager";
            if (roleManager.RoleExists(Manager) == false) //role doesn't exist
            {
                roleManager.Create(new AppRole(Manager));
            }
            String Employee = "Employee";
            if (roleManager.RoleExists(Employee) == false) //role doesn't exist
            {
                roleManager.Create(new AppRole(Employee));
            }

            //create users
            String stru1Email = "cbaker@example.com";
            AppUser u1 = new AppUser();
            u1.Email = stru1Email;
            u1.UserName = stru1Email;
            u1.FirstName = "Christopher";
            u1.LastName = "Baker";
            u1.MiddleInitial = "L";
            u1.Address = "1245 Lake Austin Blvd.";
            u1.City = "Austin";
            u1.State = StateAbrv.TX;
            u1.ZipCode = "78733";
            u1.PhoneNumber = "5125571146";
            u1.DOB = DateTime.Parse("2/7/1991");
            //AppUser userToAdd1 = userManager.FindByName(stru1Email);
            //if (userToAdd1 == null) //this user doesn't exist yet	
            //{
            userManager.Create(u1, "grazing123!");
            //userToAdd1 = userManager.FindByName(stru1Email);
            //db.SaveChanges();

            //add the user to the role		
            //    if (userManager.IsInRole(userToAdd1.Id, roleName) == false) //the user isn't in the role
            //    {
            //        userManager.AddToRole(userToAdd1.Id, roleName);
            //    }

           
            String stru2Email = "mb@aool.com"; AppUser u2 = new AppUser(); u2.Email = stru2Email; u2.UserName = stru2Email; u2.FirstName = "Michelle"; u2.LastName = "Banks"; u2.MiddleInitial = ""; u2.Address = "1300 Tall Pine Lane"; u2.City = "San Antonio"; u2.State = StateAbrv.TX; u2.ZipCode = "78261"; u2.PhoneNumber = "2102678873"; u2.DOB = DateTime.Parse("6/23/1990"); userManager.Create(u2, "banquet");
            String stru3Email = "fd@aool.com"; AppUser u3 = new AppUser(); u3.Email = stru3Email; u3.UserName = stru3Email; u3.FirstName = "Franco"; u3.LastName = "Broccolo"; u3.MiddleInitial = "V"; u3.Address = "62 Browning Rd"; u3.City = "Houston"; u3.State = StateAbrv.TX; u3.ZipCode = "77019"; u3.PhoneNumber = "8175659699"; u3.DOB = DateTime.Parse("5/6/1986"); userManager.Create(u3, "666666");
            String stru4Email = "wendy@ggmail.com"; AppUser u4 = new AppUser(); u4.Email = stru4Email; u4.UserName = stru4Email; u4.FirstName = "Wendy"; u4.LastName = "Chang"; u4.MiddleInitial = "L"; u4.Address = "202 Bellmont Hall"; u4.City = "Austin"; u4.State = StateAbrv.TX; u4.ZipCode = "78713"; u4.PhoneNumber = "5125943222"; u4.DOB = DateTime.Parse("12/21/1964"); userManager.Create(u4, "clover");
            String stru5Email = "limchou@yaho.com"; AppUser u5 = new AppUser(); u5.Email = stru5Email; u5.UserName = stru5Email; u5.FirstName = "Lim"; u5.LastName = "Chou"; u5.MiddleInitial = ""; u5.Address = "1600 Teresa Lane"; u5.City = "San Antonio"; u5.State = StateAbrv.TX; u5.ZipCode = "78266"; u5.PhoneNumber = "2107724599"; u5.DOB = DateTime.Parse("6/14/1950"); userManager.Create(u5, "austin");
            String stru6Email = "Dixon@aool.com"; AppUser u6 = new AppUser(); u6.Email = stru6Email; u6.UserName = stru6Email; u6.FirstName = "Shan"; u6.LastName = "Dixon"; u6.MiddleInitial = "D"; u6.Address = "234 Holston Circle"; u6.City = "Dallas"; u6.State = StateAbrv.TX; u6.ZipCode = "75208"; u6.PhoneNumber = "2142643255"; u6.DOB = DateTime.Parse("5/9/1930"); userManager.Create(u6, "mailbox");
            String stru7Email = "louann@ggmail.com"; AppUser u7 = new AppUser(); u7.Email = stru7Email; u7.UserName = stru7Email; u7.FirstName = "Lou Ann"; u7.LastName = "Feeley"; u7.MiddleInitial = "K"; u7.Address = "600 S 8th Street W"; u7.City = "Houston"; u7.State = StateAbrv.TX; u7.ZipCode = "77010"; u7.PhoneNumber = "8172556749"; u7.DOB = DateTime.Parse("2/24/1930"); userManager.Create(u7, "aggies");
            String stru8Email = "tfreeley@minntonka.ci.state.mn.us"; AppUser u8 = new AppUser(); u8.Email = stru8Email; u8.UserName = stru8Email; u8.FirstName = "Tesa"; u8.LastName = "Freeley"; u8.MiddleInitial = "P"; u8.Address = "4448 Fairview Ave."; u8.City = "Houston"; u8.State = StateAbrv.TX; u8.ZipCode = "77009"; u8.PhoneNumber = "8173255687"; u8.DOB = DateTime.Parse("9/1/1935"); userManager.Create(u8, "raiders");
            String stru9Email = "mgar@aool.com"; AppUser u9 = new AppUser(); u9.Email = stru9Email; u9.UserName = stru9Email; u9.FirstName = "Margaret"; u9.LastName = "Garcia"; u9.MiddleInitial = "L"; u9.Address = "594 Longview"; u9.City = "Houston"; u9.State = StateAbrv.TX; u9.ZipCode = "77003"; u9.PhoneNumber = "8176593544"; u9.DOB = DateTime.Parse("7/3/1990"); userManager.Create(u9, "mustangs");
            String stru10Email = "chaley@thug.com"; AppUser u10 = new AppUser(); u10.Email = stru10Email; u10.UserName = stru10Email; u10.FirstName = "Charles"; u10.LastName = "Haley"; u10.MiddleInitial = "E"; u10.Address = "One Cowboy Pkwy"; u10.City = "Dallas"; u10.State = StateAbrv.TX; u10.ZipCode = "75261"; u10.PhoneNumber = "2148475583"; u10.DOB = DateTime.Parse("9/17/1985"); userManager.Create(u10, "region");
            String stru11Email = "jeff@ggmail.com"; AppUser u11 = new AppUser(); u11.Email = stru11Email; u11.UserName = stru11Email; u11.FirstName = "Jeffrey"; u11.LastName = "Hampton"; u11.MiddleInitial = "T"; u11.Address = "337 38th St."; u11.City = "Austin"; u11.State = StateAbrv.TX; u11.ZipCode = "78705"; u11.PhoneNumber = "5126978613"; u11.DOB = DateTime.Parse("1/23/1995"); userManager.Create(u11, "hungry");
            String stru12Email = "wjhearniii@umch.edu"; AppUser u12 = new AppUser(); u12.Email = stru12Email; u12.UserName = stru12Email; u12.FirstName = "John"; u12.LastName = "Hearn"; u12.MiddleInitial = "B"; u12.Address = "4225 North First"; u12.City = "Dallas"; u12.State = StateAbrv.TX; u12.ZipCode = "75237"; u12.PhoneNumber = "2148965621"; u12.DOB = DateTime.Parse("1/8/1994"); userManager.Create(u12, "logicon");
            String stru13Email = "hicks43@ggmail.com"; AppUser u13 = new AppUser(); u13.Email = stru13Email; u13.UserName = stru13Email; u13.FirstName = "Anthony"; u13.LastName = "Hicks"; u13.MiddleInitial = "J"; u13.Address = "32 NE Garden Ln., Ste 910"; u13.City = "San Antonio"; u13.State = StateAbrv.TX; u13.ZipCode = "78239"; u13.PhoneNumber = "2105788965"; u13.DOB = DateTime.Parse("10/6/1990"); userManager.Create(u13, "doofus");
            String stru14Email = "bradsingram@mall.utexas.edu"; AppUser u14 = new AppUser(); u14.Email = stru14Email; u14.UserName = stru14Email; u14.FirstName = "Brad"; u14.LastName = "Ingram"; u14.MiddleInitial = "S"; u14.Address = "8"; u14.City = "Austin"; u14.State = StateAbrv.TX; u14.ZipCode = "78736"; u14.PhoneNumber = "5124678821"; u14.DOB = DateTime.Parse("4/12/1984"); userManager.Create(u14, "mother");
            String stru15Email = "mother.Ingram@aool.com"; AppUser u15 = new AppUser(); u15.Email = stru15Email; u15.UserName = stru15Email; u15.FirstName = "Todd"; u15.LastName = "Jacobs"; u15.MiddleInitial = "L"; u15.Address = "4564 Elm St."; u15.City = "Austin"; u15.State = StateAbrv.TX; u15.ZipCode = "78731"; u15.PhoneNumber = "5124653365"; u15.DOB = DateTime.Parse("4/4/1983"); userManager.Create(u15, "whimsical");
            String stru16Email = "victoria@aool.com"; AppUser u16 = new AppUser(); u16.Email = stru16Email; u16.UserName = stru16Email; u16.FirstName = "Victoria"; u16.LastName = "Lawrence"; u16.MiddleInitial = "M"; u16.Address = "6639 Butterfly Ln."; u16.City = "Austin"; u16.State = StateAbrv.TX; u16.ZipCode = "78761"; u16.PhoneNumber = "5129457399"; u16.DOB = DateTime.Parse("2/3/1961"); userManager.Create(u16, "nothing");
            String stru17Email = "lineback@flush.net"; AppUser u17 = new AppUser(); u17.Email = stru17Email; u17.UserName = stru17Email; u17.FirstName = "Erik"; u17.LastName = "Lineback"; u17.MiddleInitial = "W"; u17.Address = "1300 Netherland St"; u17.City = "San Antonio"; u17.State = StateAbrv.TX; u17.ZipCode = "78293"; u17.PhoneNumber = "2102449976"; u17.DOB = DateTime.Parse("9/3/1946"); userManager.Create(u17, "GoodFellow");
            String stru18Email = "elowe@netscrape.net"; AppUser u18 = new AppUser(); u18.Email = stru18Email; u18.UserName = stru18Email; u18.FirstName = "Ernest"; u18.LastName = "Lowe"; u18.MiddleInitial = "S"; u18.Address = "3201 Pine Drive"; u18.City = "San Antonio"; u18.State = StateAbrv.TX; u18.ZipCode = "78279"; u18.PhoneNumber = "2105344627"; u18.DOB = DateTime.Parse("2/7/1992"); userManager.Create(u18, "impede");
            String stru19Email = "luce_chuck@ggmail.com"; AppUser u19 = new AppUser(); u19.Email = stru19Email; u19.UserName = stru19Email; u19.FirstName = "Chuck"; u19.LastName = "Luce"; u19.MiddleInitial = "B"; u19.Address = "2345 Rolling Clouds"; u19.City = "San Antonio"; u19.State = StateAbrv.TX; u19.ZipCode = "78268"; u19.PhoneNumber = "2106983548"; u19.DOB = DateTime.Parse("10/25/1942"); userManager.Create(u19, "LuceyDucey");
            String stru20Email = "mackcloud@pimpdaddy.com"; AppUser u20 = new AppUser(); u20.Email = stru20Email; u20.UserName = stru20Email; u20.FirstName = "Jennifer"; u20.LastName = "MacLeod"; u20.MiddleInitial = "D"; u20.Address = "2504 Far West Blvd."; u20.City = "Austin"; u20.State = StateAbrv.TX; u20.ZipCode = "78731"; u20.PhoneNumber = "5124748138"; u20.DOB = DateTime.Parse("8/6/1965"); userManager.Create(u20, "cloudyday");
            String stru21Email = "liz@ggmail.com"; AppUser u21 = new AppUser(); u21.Email = stru21Email; u21.UserName = stru21Email; u21.FirstName = "Elizabeth"; u21.LastName = "Markham"; u21.MiddleInitial = "P"; u21.Address = "7861 Chevy Chase"; u21.City = "Austin"; u21.State = StateAbrv.TX; u21.ZipCode = "78732"; u21.PhoneNumber = "5124579845"; u21.DOB = DateTime.Parse("4/13/1959"); userManager.Create(u21, "emarkbark");
            String stru22Email = "mclarence@aool.com"; AppUser u22 = new AppUser(); u22.Email = stru22Email; u22.UserName = stru22Email; u22.FirstName = "Clarence"; u22.LastName = "Martin"; u22.MiddleInitial = "A"; u22.Address = "87 Alcedo St."; u22.City = "Houston"; u22.State = StateAbrv.TX; u22.ZipCode = "77045"; u22.PhoneNumber = "8174955201"; u22.DOB = DateTime.Parse("1/6/1990"); userManager.Create(u22, "smartinmartin");
            String stru23Email = "smartinmartin.Martin@aool.com"; AppUser u23 = new AppUser(); u23.Email = stru23Email; u23.UserName = stru23Email; u23.FirstName = "Gregory"; u23.LastName = "Martinez"; u23.MiddleInitial = "R"; u23.Address = "8295 Sunset Blvd."; u23.City = "Houston"; u23.State = StateAbrv.TX; u23.ZipCode = "77030"; u23.PhoneNumber = "8178746718"; u23.DOB = DateTime.Parse("10/9/1987"); userManager.Create(u23, "looter");
            String stru24Email = "cmiller@mapster.com"; AppUser u24 = new AppUser(); u24.Email = stru24Email; u24.UserName = stru24Email; u24.FirstName = "Charles"; u24.LastName = "Miller"; u24.MiddleInitial = "R"; u24.Address = "8962 Main St."; u24.City = "Houston"; u24.State = StateAbrv.TX; u24.ZipCode = "77031"; u24.PhoneNumber = "8177458615"; u24.DOB = DateTime.Parse("7/21/1984"); userManager.Create(u24, "chucky33");
            String stru25Email = "nelson.Kelly@aool.com"; AppUser u25 = new AppUser(); u25.Email = stru25Email; u25.UserName = stru25Email; u25.FirstName = "Kelly"; u25.LastName = "Nelson"; u25.MiddleInitial = "T"; u25.Address = "2601 Red River"; u25.City = "Austin"; u25.State = StateAbrv.TX; u25.ZipCode = "78703"; u25.PhoneNumber = "5122926966"; u25.DOB = DateTime.Parse("7/4/1956"); userManager.Create(u25, "orange");
            String stru26Email = "jojoe@ggmail.com"; AppUser u26 = new AppUser(); u26.Email = stru26Email; u26.UserName = stru26Email; u26.FirstName = "Joe"; u26.LastName = "Nguyen"; u26.MiddleInitial = "C"; u26.Address = "1249 4th SW St."; u26.City = "Dallas"; u26.State = StateAbrv.TX; u26.ZipCode = "75238"; u26.PhoneNumber = "2143125897"; u26.DOB = DateTime.Parse("1/29/1963"); userManager.Create(u26, "victorious");
            String stru27Email = "orielly@foxnets.com"; AppUser u27 = new AppUser(); u27.Email = stru27Email; u27.UserName = stru27Email; u27.FirstName = "Bill"; u27.LastName = "O'Reilly"; u27.MiddleInitial = "T"; u27.Address = "8800 Gringo Drive"; u27.City = "San Antonio"; u27.State = StateAbrv.TX; u27.ZipCode = "78260"; u27.PhoneNumber = "2103450925"; u27.DOB = DateTime.Parse("1/7/1983"); userManager.Create(u27, "billyboy");
            String stru28Email = "or@aool.com"; AppUser u28 = new AppUser(); u28.Email = stru28Email; u28.UserName = stru28Email; u28.FirstName = "Anka"; u28.LastName = "Radkovich"; u28.MiddleInitial = "L"; u28.Address = "1300 Elliott Pl"; u28.City = "Dallas"; u28.State = StateAbrv.TX; u28.ZipCode = "75260"; u28.PhoneNumber = "2142345566"; u28.DOB = DateTime.Parse("3/31/1980"); userManager.Create(u28, "radicalone");
            String stru29Email = "megrhodes@freezing.co.uk"; AppUser u29 = new AppUser(); u29.Email = stru29Email; u29.UserName = stru29Email; u29.FirstName = "Megan"; u29.LastName = "Rhodes"; u29.MiddleInitial = "C"; u29.Address = "4587 Enfield Rd."; u29.City = "Austin"; u29.State = StateAbrv.TX; u29.ZipCode = "78707"; u29.PhoneNumber = "5123744746"; u29.DOB = DateTime.Parse("8/12/1944"); userManager.Create(u29, "gohorns");
            String stru30Email = "erynrice@aool.com"; AppUser u30 = new AppUser(); u30.Email = stru30Email; u30.UserName = stru30Email; u30.FirstName = "Eryn"; u30.LastName = "Rice"; u30.MiddleInitial = "M"; u30.Address = "3405 Rio Grande"; u30.City = "Austin"; u30.State = StateAbrv.TX; u30.ZipCode = "78705"; u30.PhoneNumber = "5123876657"; u30.DOB = DateTime.Parse("8/2/1934"); userManager.Create(u30, "iloveme");
            String stru31Email = "jorge@hootmail.com"; AppUser u31 = new AppUser(); u31.Email = stru31Email; u31.UserName = stru31Email; u31.FirstName = "Jorge"; u31.LastName = "Rodriguez"; u31.MiddleInitial = ""; u31.Address = "6788 Cotter Street"; u31.City = "Houston"; u31.State = StateAbrv.TX; u31.ZipCode = "77057"; u31.PhoneNumber = "8178904374"; u31.DOB = DateTime.Parse("8/11/1989"); userManager.Create(u31, "greedy");
            String stru32Email = "ra@aoo.com"; AppUser u32 = new AppUser(); u32.Email = stru32Email; u32.UserName = stru32Email; u32.FirstName = "Allen"; u32.LastName = "Rogers"; u32.MiddleInitial = "B"; u32.Address = "4965 Oak Hill"; u32.City = "Austin"; u32.State = StateAbrv.TX; u32.ZipCode = "78732"; u32.PhoneNumber = "5128752943"; u32.DOB = DateTime.Parse("8/27/1967"); userManager.Create(u32, "familiar");
            String stru33Email = "st-jean@home.com"; AppUser u33 = new AppUser(); u33.Email = stru33Email; u33.UserName = stru33Email; u33.FirstName = "Olivier"; u33.LastName = "Saint-Jean"; u33.MiddleInitial = "M"; u33.Address = "255 Toncray Dr."; u33.City = "San Antonio"; u33.State = StateAbrv.TX; u33.ZipCode = "78292"; u33.PhoneNumber = "2104145678"; u33.DOB = DateTime.Parse("7/8/1950"); userManager.Create(u33, "historical");
            String stru34Email = "ss34@ggmail.com"; AppUser u34 = new AppUser(); u34.Email = stru34Email; u34.UserName = stru34Email; u34.FirstName = "Sarah"; u34.LastName = "Saunders"; u34.MiddleInitial = "J"; u34.Address = "332 Avenue C"; u34.City = "Austin"; u34.State = StateAbrv.TX; u34.ZipCode = "78705"; u34.PhoneNumber = "5123497810"; u34.DOB = DateTime.Parse("10/29/1977"); userManager.Create(u34, "guiltless");
            String stru35Email = "willsheff@email.com"; AppUser u35 = new AppUser(); u35.Email = stru35Email; u35.UserName = stru35Email; u35.FirstName = "William"; u35.LastName = "Sewell"; u35.MiddleInitial = "T"; u35.Address = "2365 51st St."; u35.City = "Austin"; u35.State = StateAbrv.TX; u35.ZipCode = "78709"; u35.PhoneNumber = "5124510084"; u35.DOB = DateTime.Parse("4/21/1941"); userManager.Create(u35, "frequent");
            String stru36Email = "sheff44@ggmail.com"; AppUser u36 = new AppUser(); u36.Email = stru36Email; u36.UserName = stru36Email; u36.FirstName = "Martin"; u36.LastName = "Sheffield"; u36.MiddleInitial = "J"; u36.Address = "3886 Avenue A"; u36.City = "Austin"; u36.State = StateAbrv.TX; u36.ZipCode = "78705"; u36.PhoneNumber = "5125479167"; u36.DOB = DateTime.Parse("11/10/1937"); userManager.Create(u36, "history");
            String stru37Email = "johnsmith187@aool.com"; AppUser u37 = new AppUser(); u37.Email = stru37Email; u37.UserName = stru37Email; u37.FirstName = "John"; u37.LastName = "Smith"; u37.MiddleInitial = "A"; u37.Address = "23 Hidden Forge Dr."; u37.City = "San Antonio"; u37.State = StateAbrv.TX; u37.ZipCode = "78280"; u37.PhoneNumber = "2108321888"; u37.DOB = DateTime.Parse("10/26/1954"); userManager.Create(u37, "squirrel");
            String stru38Email = "dustroud@mail.com"; AppUser u38 = new AppUser(); u38.Email = stru38Email; u38.UserName = stru38Email; u38.FirstName = "Dustin"; u38.LastName = "Stroud"; u38.MiddleInitial = "P"; u38.Address = "1212 Rita Rd"; u38.City = "Dallas"; u38.State = StateAbrv.TX; u38.ZipCode = "8"; u38.PhoneNumber = "2142346667"; u38.DOB = DateTime.Parse("9/1/1932"); userManager.Create(u38, "snakes");
            String stru39Email = "ericstuart@aool.com"; AppUser u39 = new AppUser(); u39.Email = stru39Email; u39.UserName = stru39Email; u39.FirstName = "Eric"; u39.LastName = "Stuart"; u39.MiddleInitial = "D"; u39.Address = "5576 Toro Ring"; u39.City = "Austin"; u39.State = StateAbrv.TX; u39.ZipCode = "78746"; u39.PhoneNumber = "5128178335"; u39.DOB = DateTime.Parse("12/28/1930"); userManager.Create(u39, "landus");
            String stru40Email = "peterstump@hootmail.com"; AppUser u40 = new AppUser(); u40.Email = stru40Email; u40.UserName = stru40Email; u40.FirstName = "Peter"; u40.LastName = "Stump"; u40.MiddleInitial = "L"; u40.Address = "1300 Kellen Circle"; u40.City = "Houston"; u40.State = StateAbrv.TX; u40.ZipCode = "77018"; u40.PhoneNumber = "8174560903"; u40.DOB = DateTime.Parse("8/13/1989"); userManager.Create(u40, "rhythm");
            String stru41Email = "tanner@ggmail.com"; AppUser u41 = new AppUser(); u41.Email = stru41Email; u41.UserName = stru41Email; u41.FirstName = "Jeremy"; u41.LastName = "Tanner"; u41.MiddleInitial = "S"; u41.Address = "4347 Almstead"; u41.City = "Houston"; u41.State = StateAbrv.TX; u41.ZipCode = "77044"; u41.PhoneNumber = "8174590929"; u41.DOB = DateTime.Parse("5/21/1982"); userManager.Create(u41, "kindly");
            String stru42Email = "taylordjay@aool.com"; AppUser u42 = new AppUser(); u42.Email = stru42Email; u42.UserName = stru42Email; u42.FirstName = "Allison"; u42.LastName = "Taylor"; u42.MiddleInitial = "R"; u42.Address = "467 Nueces St."; u42.City = "Austin"; u42.State = StateAbrv.TX; u42.ZipCode = "78705"; u42.PhoneNumber = "5124748452"; u42.DOB = DateTime.Parse("1/8/1960"); userManager.Create(u42, "instrument");
            String stru43Email = "TayTaylor@aool.com"; AppUser u43 = new AppUser(); u43.Email = stru43Email; u43.UserName = stru43Email; u43.FirstName = "Rachel"; u43.LastName = "Taylor"; u43.MiddleInitial = "K"; u43.Address = "345 Longview Dr."; u43.City = "Austin"; u43.State = StateAbrv.TX; u43.ZipCode = "78705"; u43.PhoneNumber = "5124512631"; u43.DOB = DateTime.Parse("7/27/1975"); userManager.Create(u43, "arched");
            String stru44Email = "teefrank@hootmail.com"; AppUser u44 = new AppUser(); u44.Email = stru44Email; u44.UserName = stru44Email; u44.FirstName = "Frank"; u44.LastName = "Tee"; u44.MiddleInitial = "J"; u44.Address = "5590 Lavell Dr"; u44.City = "Houston"; u44.State = StateAbrv.TX; u44.ZipCode = "77004"; u44.PhoneNumber = "8178765543"; u44.DOB = DateTime.Parse("4/6/1968"); userManager.Create(u44, "median");
            String stru45Email = "tuck33@ggmail.com"; AppUser u45 = new AppUser(); u45.Email = stru45Email; u45.UserName = stru45Email; u45.FirstName = "Clent"; u45.LastName = "Tucker"; u45.MiddleInitial = "J"; u45.Address = "312 Main St."; u45.City = "Dallas"; u45.State = StateAbrv.TX; u45.ZipCode = "75315"; u45.PhoneNumber = "2148471154"; u45.DOB = DateTime.Parse("5/19/1978"); userManager.Create(u45, "approval");
            String stru46Email = "avelasco@yaho.com"; AppUser u46 = new AppUser(); u46.Email = stru46Email; u46.UserName = stru46Email; u46.FirstName = "Allen"; u46.LastName = "Velasco"; u46.MiddleInitial = "G"; u46.Address = "679 W. 4th"; u46.City = "Dallas"; u46.State = StateAbrv.TX; u46.ZipCode = "75207"; u46.PhoneNumber = "2143985638"; u46.DOB = DateTime.Parse("1/4/1900"); userManager.Create(u46, "decorate");
            String stru47Email = "westj@pioneer.net"; AppUser u47 = new AppUser(); u47.Email = stru47Email; u47.UserName = stru47Email; u47.FirstName = "Jake"; u47.LastName = "West"; u47.MiddleInitial = "T"; u47.Address = "RR 3287"; u47.City = "Dallas"; u47.State = StateAbrv.TX; u47.ZipCode = "75323"; u47.PhoneNumber = "2148475244"; u47.DOB = DateTime.Parse("10/14/1993"); userManager.Create(u47, "grover");
            String stru48Email = "louielouie@aool.com"; AppUser u48 = new AppUser(); u48.Email = stru48Email; u48.UserName = stru48Email; u48.FirstName = "Louis"; u48.LastName = "Winthorpe"; u48.MiddleInitial = "L"; u48.Address = "2500 Padre Blvd"; u48.City = "Dallas"; u48.State = StateAbrv.TX; u48.ZipCode = "75220"; u48.PhoneNumber = "2145650098"; u48.DOB = DateTime.Parse("5/31/1952"); userManager.Create(u48, "sturdy");
            String stru49Email = "rwood@voyager.net"; AppUser u49 = new AppUser(); u49.Email = stru49Email; u49.UserName = stru49Email; u49.FirstName = "Reagan"; u49.LastName = "Wood"; u49.MiddleInitial = "B"; u49.Address = "447 Westlake Dr."; u49.City = "Austin"; u49.State = StateAbrv.TX; u49.ZipCode = "78746"; u49.PhoneNumber = "5124545242"; u49.DOB = DateTime.Parse("4/24/1992"); userManager.Create(u49, "decorous");

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

            //see if the user is already there*/

            String stre1Email = "t.jacobs@longhornbank.neet"; Employee e1 = new Employee(); e1.Email = stre1Email; e1.UserName = stre1Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Todd"; e1.LastName = "Jacobs"; e1.MiddleInitial = "L"; e1.Address = "4564 Elm St."; e1.City = "Houston"; e1.State = StateAbrv.TX; e1.ZipCode = "77003"; e1.PhoneNumber = "8176593544"; e1.SSN = "222222222"; userManager.Create(e1, "society");
            String stre2Email = "e.rice@longhornbank.neet"; Employee e2 = new Employee(); e2.Email = stre2Email; e2.UserName = stre2Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Eryn"; e2.LastName = "Rice"; e2.MiddleInitial = "M"; e2.Address = "3405 Rio Grande"; e2.City = "Dallas"; e2.State = StateAbrv.TX; e2.ZipCode = "75261"; e2.PhoneNumber = "2148475583"; e2.SSN = "111111111"; userManager.Create(e2, "ricearoni");
            String stre3Email = "b.ingram@longhornbank.neet"; Employee e3 = new Employee(); e3.Email = stre3Email; e3.UserName = stre3Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Brad"; e3.LastName = "Ingram"; e3.MiddleInitial = "S"; e3.Address = "6548 La Posada Ct."; e3.City = "Austin"; e3.State = StateAbrv.TX; e3.ZipCode = "78705"; e3.PhoneNumber = "5126978613"; e3.SSN = "545454545"; userManager.Create(e3, "ingram45");
            String stre4Email = "a.taylor@longhornbank.neet"; Employee e4 = new Employee(); e4.Email = stre4Email; e4.UserName = stre4Email; e1.EmpType = EmpType.Manager; e1.FirstName = "Allison"; e4.LastName = "Taylor"; e4.MiddleInitial = "R"; e4.Address = "467 Nueces St."; e4.City = "Dallas"; e4.State = StateAbrv.TX; e4.ZipCode = "75237"; e4.PhoneNumber = "2148965621"; e4.SSN = "645889563"; userManager.Create(e4, "nostalgic");
            String stre5Email = "g.martinez@longhornbank.neet"; Employee e5 = new Employee(); e5.Email = stre5Email; e5.UserName = stre5Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Gregory"; e5.LastName = "Martinez"; e5.MiddleInitial = "R"; e5.Address = "8295 Sunset Blvd."; e5.City = "San Antonio"; e5.State = StateAbrv.TX; e5.ZipCode = "78239"; e5.PhoneNumber = "2105788965"; e5.SSN = "574677829"; userManager.Create(e5, "fungus");
            String stre6Email = "m.sheffield@longhornbank.neet"; Employee e6 = new Employee(); e6.Email = stre6Email; e6.UserName = stre6Email; e1.EmpType = EmpType.Manager; e1.FirstName = "Martin"; e6.LastName = "Sheffield"; e6.MiddleInitial = "J"; e6.Address = "3886 Avenue A"; e6.City = "Austin"; e6.State = StateAbrv.TX; e6.ZipCode = "78736"; e6.PhoneNumber = "5124678821"; e6.SSN = "334557278"; userManager.Create(e6, "longhorns");
            String stre7Email = "j.macleod@longhornbank.neet"; Employee e7 = new Employee(); e7.Email = stre7Email; e7.UserName = stre7Email; e1.EmpType = EmpType.Manager; e1.FirstName = "Jennifer"; e7.LastName = "MacLeod"; e7.MiddleInitial = "D"; e7.Address = "2504 Far West Blvd."; e7.City = "Austin"; e7.State = StateAbrv.TX; e7.ZipCode = "78731"; e7.PhoneNumber = "5124653365"; e7.SSN = "886719249"; userManager.Create(e7, "smitty");
            String stre8Email = "j.tanner@longhornbank.neet"; Employee e8 = new Employee(); e8.Email = stre8Email; e8.UserName = stre8Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Jeremy"; e8.LastName = "Tanner"; e8.MiddleInitial = "S"; e8.Address = "4347 Almstead"; e8.City = "Austin"; e8.State = StateAbrv.TX; e8.ZipCode = "78761"; e8.PhoneNumber = "5129457399"; e8.SSN = "888887878"; userManager.Create(e8, "tanman");
            String stre9Email = "m.rhodes@longhornbank.neet"; Employee e9 = new Employee(); e9.Email = stre9Email; e9.UserName = stre9Email; e1.EmpType = EmpType.Manager; e1.FirstName = "Megan"; e9.LastName = "Rhodes"; e9.MiddleInitial = "C"; e9.Address = "4587 Enfield Rd."; e9.City = "San Antonio"; e9.State = StateAbrv.TX; e9.ZipCode = "78293"; e9.PhoneNumber = "2102449976"; e9.SSN = "999990909"; userManager.Create(e9, "countryrhodes");
            String stre10Email = "e.stuart@longhornbank.neet"; Employee e10 = new Employee(); e10.Email = stre10Email; e10.UserName = stre10Email; e1.EmpType = EmpType.Manager; e1.FirstName = "Eric"; e10.LastName = "Stuart"; e10.MiddleInitial = "F"; e10.Address = "5576 Toro Ring"; e10.City = "San Antonio"; e10.State = StateAbrv.TX; e10.ZipCode = "78279"; e10.PhoneNumber = "2105344627"; e10.SSN = "212121212"; userManager.Create(e10, "stewboy");
            String stre11Email = "l.chung@longhornbank.neet"; Employee e11 = new Employee(); e11.Email = stre11Email; e11.UserName = stre11Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Lisa"; e11.LastName = "Chung"; e11.MiddleInitial = "N"; e11.Address = "234 RR 12"; e11.City = "San Antonio"; e11.State = StateAbrv.TX; e11.ZipCode = "78268"; e11.PhoneNumber = "2106983548"; e11.SSN = "333333333"; userManager.Create(e11, "lisssa");
            String stre12Email = "l.swanson@longhornbank.neet"; Employee e12 = new Employee(); e12.Email = stre12Email; e12.UserName = stre12Email; e1.EmpType = EmpType.Manager; e1.FirstName = "Leon"; e12.LastName = "Swanson"; e12.MiddleInitial = ""; e12.Address = "245 River Rd"; e12.City = "Austin"; e12.State = StateAbrv.TX; e12.ZipCode = "78731"; e12.PhoneNumber = "5124748138"; e12.SSN = "444444444"; userManager.Create(e12, "swansong");
            String stre13Email = "w.loter@longhornbank.neet"; Employee e13 = new Employee(); e13.Email = stre13Email; e13.UserName = stre13Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Wanda"; e13.LastName = "Loter"; e13.MiddleInitial = "K"; e13.Address = "3453 RR 3235"; e13.City = "Austin"; e13.State = StateAbrv.TX; e13.ZipCode = "78732"; e13.PhoneNumber = "5124579845"; e13.SSN = "555555555"; userManager.Create(e13, "lottery");
            String stre14Email = "j.white@longhornbank.neet"; Employee e14 = new Employee(); e14.Email = stre14Email; e14.UserName = stre14Email; e1.EmpType = EmpType.Manager; e1.FirstName = "Jason"; e14.LastName = "White"; e14.MiddleInitial = "M"; e14.Address = "12 Valley View"; e14.City = "Houston"; e14.State = StateAbrv.TX; e14.ZipCode = "77045"; e14.PhoneNumber = "8174955201"; e14.SSN = "666666666"; userManager.Create(e14, "evanescent");
            String stre15Email = "w.montgomery@longhornbank.neet"; Employee e15 = new Employee(); e15.Email = stre15Email; e15.UserName = stre15Email; e1.EmpType = EmpType.Manager; e1.FirstName = "Wilda"; e15.LastName = "Montgomery"; e15.MiddleInitial = "K"; e15.Address = "210 Blanco Dr"; e15.City = "Houston"; e15.State = StateAbrv.TX; e15.ZipCode = "77030"; e15.PhoneNumber = "8178746718"; e15.SSN = "676767676"; userManager.Create(e15, "monty3");
            String stre16Email = "h.morales@longhornbank.neet"; Employee e16 = new Employee(); e16.Email = stre16Email; e16.UserName = stre16Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Hector"; e16.LastName = "Morales"; e16.MiddleInitial = "N"; e16.Address = "4501 RR 140"; e16.City = "Houston"; e16.State = StateAbrv.TX; e16.ZipCode = "77031"; e16.PhoneNumber = "8177458615"; e16.SSN = "898989898"; userManager.Create(e16, "hecktour");
            String stre17Email = "m.rankin@longhornbank.neet"; Employee e17 = new Employee(); e17.Email = stre17Email; e17.UserName = stre17Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Mary"; e17.LastName = "Rankin"; e17.MiddleInitial = "T"; e17.Address = "340 Second St"; e17.City = "Austin"; e17.State = StateAbrv.TX; e17.ZipCode = "78703"; e17.PhoneNumber = "5122926966"; e17.SSN = "999888777"; userManager.Create(e17, "rankmary");
            String stre18Email = "l.walker@longhornbank.neet"; Employee e18 = new Employee(); e18.Email = stre18Email; e18.UserName = stre18Email; e1.EmpType = EmpType.Manager; e1.FirstName = "Larry"; e18.LastName = "Walker"; e18.MiddleInitial = "G"; e18.Address = "9 Bison Circle"; e18.City = "Dallas"; e18.State = StateAbrv.TX; e18.ZipCode = "75238"; e18.PhoneNumber = "2143125897"; e18.SSN = "323232323"; userManager.Create(e18, "walkamile");
            String stre19Email = "g.chang@longhornbank.neet"; Employee e19 = new Employee(); e19.Email = stre19Email; e19.UserName = stre19Email; e1.EmpType = EmpType.Manager; e1.FirstName = "George"; e19.LastName = "Chang"; e19.MiddleInitial = "M"; e19.Address = "9003 Joshua St"; e19.City = "San Antonio"; e19.State = StateAbrv.TX; e19.ZipCode = "78260"; e19.PhoneNumber = "2103450925"; e19.SSN = "111222233"; userManager.Create(e19, "changalang");
            String stre20Email = "g.gonzalez@longhornbank.neet"; Employee e20 = new Employee(); e20.Email = stre20Email; e20.UserName = stre20Email; e1.EmpType = EmpType.Employee; e1.FirstName = "Gwen"; e20.LastName = "Gonzalez"; e20.MiddleInitial = "J"; e20.Address = "103 Manor Rd"; e20.City = "Dallas"; e20.State = StateAbrv.TX; e20.ZipCode = "75260"; e20.PhoneNumber = "2142345566"; e20.SSN = "499551454"; userManager.Create(e20, "offbeat");

        }
    }
}
