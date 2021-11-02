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
		| India   | Ac         | B.Sc  | xy     | 2020            | Education has been added |

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
