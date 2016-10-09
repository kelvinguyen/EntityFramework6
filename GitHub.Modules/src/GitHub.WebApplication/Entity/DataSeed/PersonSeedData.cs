using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHub.WebApplication.Entity.DataContext;
using GitHub.WebApplication.Entity.Models;

namespace GitHub.WebApplication.Entity.DataSeed
{
    public class PersonSeedData
    {
        private PersonContext _contect;

        public PersonSeedData(PersonContext context)
        {
            _contect = context;
        }
        public async Task EnsureSeedData()
        {
            if (!_contect.People.Any())
            {
                var people = new List<Person>();
                var person1 = PersonSeedData
                    .CreatePerson("Kelvin","Nguyen", 
                    PersonSeedData.CreateAddressList(),
                    PersonSeedData.CreateInterestList(), 
                    PersonSeedData.CreateImage("https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwinicT-s87PAhXh7oMKHbzpDSsQjRwIBw&url=http%3A%2F%2Fwww.freegreatdesign.com%2Ficon%2Fim.po-icons-pack-7-cute-icon-png-2453&psig=AFQjCNEkfgdUxTMTlVfEyYRb1RMZYvtUjQ&ust=1476125995671327"));
                var person2 = PersonSeedData
                    .CreatePerson("Tom", "Cruise",
                    PersonSeedData.CreateAddressList(),
                    PersonSeedData.CreateInterestList(),
                    PersonSeedData.CreateImage("https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwinicT-s87PAhXh7oMKHbzpDSsQjRwIBw&url=http%3A%2F%2Fwww.freegreatdesign.com%2Ficon%2Fim.po-icons-pack-7-cute-icon-png-2453&psig=AFQjCNEkfgdUxTMTlVfEyYRb1RMZYvtUjQ&ust=1476125995671327"));
                var person3 = PersonSeedData
                    .CreatePerson("Jackie", "Chan",
                    PersonSeedData.CreateAddressList(),
                    PersonSeedData.CreateInterestList(),
                    PersonSeedData.CreateImage("https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwinicT-s87PAhXh7oMKHbzpDSsQjRwIBw&url=http%3A%2F%2Fwww.freegreatdesign.com%2Ficon%2Fim.po-icons-pack-7-cute-icon-png-2453&psig=AFQjCNEkfgdUxTMTlVfEyYRb1RMZYvtUjQ&ust=1476125995671327"));
                var person4 = PersonSeedData
                    .CreatePerson("Bruce", "Lee",
                    PersonSeedData.CreateAddressList(),
                    PersonSeedData.CreateInterestList(),
                    PersonSeedData.CreateImage("https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwinicT-s87PAhXh7oMKHbzpDSsQjRwIBw&url=http%3A%2F%2Fwww.freegreatdesign.com%2Ficon%2Fim.po-icons-pack-7-cute-icon-png-2453&psig=AFQjCNEkfgdUxTMTlVfEyYRb1RMZYvtUjQ&ust=1476125995671327"));
                var person5 = PersonSeedData
                    .CreatePerson("Michael", "Jackson",
                    PersonSeedData.CreateAddressList(),
                    PersonSeedData.CreateInterestList(),
                    PersonSeedData.CreateImage("https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwinicT-s87PAhXh7oMKHbzpDSsQjRwIBw&url=http%3A%2F%2Fwww.freegreatdesign.com%2Ficon%2Fim.po-icons-pack-7-cute-icon-png-2453&psig=AFQjCNEkfgdUxTMTlVfEyYRb1RMZYvtUjQ&ust=1476125995671327"));

                PersonSeedData.AddToContext(_contect, person1);
                PersonSeedData.AddToContext(_contect, person2);
                PersonSeedData.AddToContext(_contect, person3);
                PersonSeedData.AddToContext(_contect, person4);
                PersonSeedData.AddToContext(_contect, person5);

                await _contect.SaveChangesAsync();
            }
        }
        public static void AddToContext(PersonContext contect, Person person)
        {
            contect.People.Add(person);
            contect.Images.Add(person.Image);
            contect.Addresses.AddRange(person.AddressList);
            contect.Interests.AddRange(person.InterestList);
        }
        public static Person CreatePerson(string firstname, string lastname, List<Address> address,List<Interest> interests, Image img)
        {
            var person = new Person
            {
                FirstName = firstname,
                LastName = lastname,
                AddressList = address,
                InterestList = interests,
                Image = img
            };

            return person;
        }

        public static Address CreateAddress(string address,string city,string state, int zipcode)
        {
            var personAddress = new Address
            {
                StreetAddress = address,
                City = city,
                State = state,
                Zipcode = zipcode
            };
            return personAddress;
        }

        public static Image CreateImage(string img)
        {
            return new Image { ImageUrl = img };
        }

        public static Interest CreateInterest(string content)
        {
            var interest = new Interest
            {
                InterestContent = content
            };
            return interest;
        }

        public static List<Address> CreateAddressList()
        {
            var addresses = new List<Address> {
                PersonSeedData.CreateAddress("123 holow way","salt lake", "utah",84128),
                PersonSeedData.CreateAddress("456 baron road","murray", "Tx",84123),
                PersonSeedData.CreateAddress("798","Cedar", "utah",84158)
            };
            return addresses;
        }
        public static List<Interest> CreateInterestList()
        {
            var intrestList = new List<Interest> {
                PersonSeedData.CreateInterest("I like soccer"),
                PersonSeedData.CreateInterest("I like Footbal"),
                PersonSeedData.CreateInterest("I like Hockey")
            };
            return intrestList;
        }
    }
}
