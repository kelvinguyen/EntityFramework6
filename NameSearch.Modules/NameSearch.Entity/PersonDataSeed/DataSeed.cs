using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameSearch.Classes.Models;

namespace NameSearch.Entity.PersonDataSeed
{
    public class DataSeed
    {
        public static List<Person> CreateMultiplePerson()
        {
            string imgurl = "https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwinicT-s87PAhXh7oMKHbzpDSsQjRwIBw&url=http%3A%2F%2Fwww.freegreatdesign.com%2Ficon%2Fim.po-icons-pack-7-cute-icon-png-2453&psig=AFQjCNEkfgdUxTMTlVfEyYRb1RMZYvtUjQ&ust=1476125995671327";
            var list = new List<Person>
            {
                DataSeed.CreatePerson("Micheal","Jackson",imgurl,
                     DataSeed.CreateAddressList(),DataSeed.CreateInterestList()),
                DataSeed.CreatePerson("Bruce","Lee",imgurl,
                        DataSeed.CreateAddressList(),DataSeed.CreateInterestList()),
                DataSeed.CreatePerson("Bon","Jovi",imgurl,
                        DataSeed.CreateAddressList(),DataSeed.CreateInterestList()),
                DataSeed.CreatePerson("Jackie","Chan",imgurl,
                        DataSeed.CreateAddressList(),DataSeed.CreateInterestList()),
                DataSeed.CreatePerson("Tom","Cruise",imgurl,
                        DataSeed.CreateAddressList(),DataSeed.CreateInterestList()),
            };
            return list;
        }
        public static Person CreatePerson(string first, string last,
                string img, List<Address> addresses, List<Interest> interests)
        {
            var person = new Person()
            {
                FirstName = first,
                LastName = last,
                ImgUrl = img,
                Address = addresses,
                Interests = interests

            };
            return person;
        }

        public static List<Address> CreateAddressList()
        {
            var list = new List<Address> {
                new Address() {
                    StreetAddress = "123 Land Rover",
                    City = "Salt lake city",
                    State = "Utah",
                    Zipcode = 12345

                },
                 new Address() {
                    StreetAddress = "456 bon jovi",
                    City = "valerie city",
                    State = "Texas",
                    Zipcode = 84346

                },
                  new Address() {
                    StreetAddress = "789 Land Rover",
                    City = "las vegas",
                    State = "nevada",
                    Zipcode = 84999

                }
            };
            return list;
        }

        public static List<Interest> CreateInterestList()
        {
            var interests = new List<Interest>
            {
                new Interest {Content = "I love Football" },
                new Interest {Content = "I love video Game" },
                new Interest {Content = "I love coding" }
            };

            return interests;
        }
    }
}
