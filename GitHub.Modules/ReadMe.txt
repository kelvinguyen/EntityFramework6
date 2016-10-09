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

	PersonInterest
	- As personInterset, I will have Id
	- As personInterest, I will have InterestContent

	PersonImage
	- As personImage, I will have Id
	- As personImage, I will have image






	The application accepts search input in a text box and then displays in a 
	pleasing style a list of people where any part of their first or last name matches 
	what was typed in the search box (displaying at least name, address, age, interests, 
	and a picture). 
Solution should either seed data or provide a way to enter new users or both
Simulate search being slow and have the UI gracefully handle the delay