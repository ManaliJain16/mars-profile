@profile
Feature: Profile Feature
As a Seller on Mars
I will be able to add Profile details
So I can manage my Profile successfully

@education
Scenario Outline: Adding Education with valid inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Education tab
	And he enters '<University>', '<Country>', '<Title>', '<Degree>' and '<Graduation Year>' in Education
	Then a popup message '<Message>' will appear
	And a new row with '<University>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>' will be added successfully

	Examples:
		| Country | University | Title | Degree | Graduation Year | Message                  |
		| India   | Ac         | B.Sc  | xy     | 2021            | Education has been added |

@seller_name
Scenario Outline: Updating Sellers name
	Given Seller is on Profile Page
	When he click on dropdown icon, just before his name
	And updates his '<FirstName>' and '<LastName>'
	Then he must be able to see '<FirstName>' and '<LastName>' updated on the Profile Page

	Examples:
		| FirstName | LastName     |
		| Manali    | Jain         |
		| @$##$#$   | 392839283923 |


@description
Scenario Outline: Adding description (like his hobbies, additional expertise or anything else in max. 600, alphanumeric or special characters) with valid inputs
	Given Seller is on Profile Page
	When he clicks on the Edit icon next to Description
	And enter '<Description>' in the textbox
	Then a popup message 'Description has been saved successfully' will appear
	And he must be able to see '<Description>' on the Profile Page

	Examples:
		| Description       |
		| I like to Play    |
		| I like to Swim12# |



@certifications
Scenario Outline: Adding Certifications with valid inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Certifications tab
	And he enters '<Certificate>', '<From>', '<Year>' in Certifications
	Then a popup message '<Certificate> has been added to your certification' will appear
	And a new row with '<Certificate>', '<From>', '<Year>' will be added sucessfully

	Examples:
		| Certificate | From | Year |
		| ABC         | xx   | 2006 |




