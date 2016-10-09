GitHub Name Search

User stories
	Person
	- As person, I will have personId
	- As person, I will have firstname and lastname
	- As person, I will have an age
	- As person, I will have a AddressId
	- As person, I will have an interestId
	- As person, I will have an ImageId

	Address
	- As address, I will have AddressId
	- As address, I will have StreetAddress
	- As address, I will have City
	- As address, I will have State
	- As Address, I will have ZipCode
	- As Address, I will have a person

	PersonInterest
	- As personInterset, I will have Id
	- As personInterest, I will have InterestContent
	- As PersonInterset, I will have a person

	PersonImage
	- As personImage, I will have Id
	- As personImage, I will have image
	- As personImage, I will have person



Github Architecture layout
	- GitHub.Models.dll : this will contain all model classes
	- GitHub.Context.dll : This will contain contextdb
	- GitHub.Repository.dll : this will contain repo interface and repo
	- GitHub.WebApplication : the main application
		


	