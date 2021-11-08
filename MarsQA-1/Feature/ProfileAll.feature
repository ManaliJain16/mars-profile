@profile
Feature: Profile Feature
As a Seller on Mars
I will be able to add Profile details
So I can manage my Profile successfully

@description
Scenario Outline: Adding description (like his hobbies, additional expertise or anything else in max. 600, alphanumeric or special characters) with valid inputs
	Given Seller is on Profile Page
	When he clicks on the Edit icon next to Description
	And enter '<Description>' in the textbox
	Then a success popup message 'Description has been saved successfully' will appear
	And he must be able to see '<Description>' on the Profile Page

	Examples:
		| Description       |
		| I like to Swim12# |
		| I like to Play    |

@description
Scenario: Saving description with invalid inputs
	Given Seller is on Profile Page
	When he clicks on the Edit icon next to Description
	And enter ' ' in the textbox
	Then an error pop up message 'First character can only be digit or letters' will appear

@description
Scenario: Saving description with max 600 characters
	Given Seller is on Profile Page
	When he clicks on the Edit icon next to Description
	And enter string with 601 characters in the textbox
	Then a success popup message 'Description has been saved successfully' will appear
	And he must be able to see description with only 600 characters on the Profile Page

@language
Scenario Outline: Adding Languages with valid inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Languages tab
	And he enters '<Language>' and '<Level>'
	Then a success popup message '<Message>' will appear
	And a new row with '<Language>' and '<Level>' will be added successfully.

	Examples:
		| Language    | Level          | Message                                      |
		| English     | Fluent         | English has been added to your languages     |
		| $#%$%#$%#$% | Conversational | $#%$%#$%#$% has been added to your languages |
		| 324234234   | Basic          | 324234234 has been added to your languages   |

@language
Scenario Outline: Saving Languages with missing inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Languages tab
	And he enters '<Language>' and '<Level>'
	Then an error pop up message '<Message>' will appear
	And a row with '<Language>' and '<Level>' will not be added to the list

	Examples:
		| Language | Level  | Message                         |
		|          |        | Please enter language and level |
		| English  |        | Please enter language and level |
		|          | Fluent | Please enter language and level |

@language
Scenario: Adding upto maximum of four Languages
	Given Seller is on Profile Page
	And no Languages have been added
	When he enters 4 languages successfully
	Then he should not see "Add New" button

@language
Scenario Outline: Adding Languages with duplicate data
	Given Seller is on Profile Page
	When he clicks on Add New button under Languages tab
	And he enters '<Language>' and '<Language Level>'
	And he clicks on Add New button under Languages tab
	And he enters '<Language>' and '<Second Language Level>'
	Then an error pop up message '<Message>' will appear

	Examples:
		| Language | Language Level | Second Language Level | Message                                               |
		| German   | Basic          | Conversational        | Duplicated data                                       |
		| Hindi    | Basic          | Basic                 | This language is already exist in your language list. |

@skills
Scenario Outline: Adding Skills with valid inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Skills tab
	And he enters '<Skill>' in Add Skill textbox, and select '<Level>' from Choose Skill Level dropdown list
	Then a success popup message '<Message>' will appear
	And a new row with '<Skill>' and '<Level>' will be added successfully

	Examples:
		| Skill         | Level        | Message                                                 |
		| Communication | Beginner     | Communication has been added to your skills will appear |
		| Multi12*      | Intermediate | Multi12* has been added to your skills will appear      |

@skills
Scenario Outline: Saving Skills with missing inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Skills tab
	And he enters '<Skill>' in Add Skill textbox, and select '<Level>' from Choose Skill Level dropdown list
	Then an error pop up message '<Message>' will appear
	And a row with '<Skill>' and '<Level>' will not be added to the list

	Examples:
		| Skill         | Level        | Message                                 |
		|               |              | Please enter skill and experience level |
		| Communication |              | Please enter skill and experience level |
		|               | Intermediate | Please enter skill and experience level |

@skills
Scenario Outline: Adding Skills with duplicate data
	Given Seller is on Profile Page
	When he clicks on Add New button under Skills tab
	And he enters '<Skill>' in Add Skill textbox, and select '<Level>' from Choose Skill Level dropdown list
	And he clicks on Add New button under Skills tab
	And he enters '<Skill>' in Add Skill textbox, and select '<Second Level>' from Choose Skill Level dropdown list
	Then an error pop up message '<Message>' will appear

	Examples:
		| Skill        | Level | Second Level | Message                                         |
		| Muli-tasking | Basic | Basic        | This skill is already exist in your skill list. |
		| Muli-tasking | Basic | Intermediate | Duplicated data                                 |

@education
Scenario Outline: Adding Education with valid inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Education tab
	And he enters '<University>', '<Country>', '<Title>', '<Degree>' and '<Graduation Year>' in Education
	Then a success popup message '<Message>' will appear
	And a new row with '<Country>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>' will be added successfully

	Examples:
		| Country | University | Title | Degree | Graduation Year | Message                  |
		| India   | Ac         | B.Sc  | xy     | 2020            | Education has been added |

@education
Scenario Outline: Saving Education with missing inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Education tab
	And he enters '<University>', '<Country>', '<Title>', '<Degree>' and '<Graduation Year>' in Education
	Then an error pop up message '<Message>' will appear
	And a row with '<Country>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>' will not be added to the list

	Examples:
		| Country | University | Title | Degree | Graduation Year | Message                     |
		|         | Ac         | B.Sc  |        | 2020            | Please enter all the fields |
		|         |            |       |        |                 | Please enter all the fields |
		| India   |            |       | abc12# | 2020            | Please enter all the fields |

@education
Scenario Outline: Adding Education with duplicate data
	Given Seller is on Profile Page
	And no education is added
	When he clicks on Add New button under Education tab
	And he enters '<University>', '<Country>', '<Title>', '<Degree>' and '<Graduation Year>' in Education
	And he clicks on Add New button under Education tab
	And he enters '<University>', '<Country>', '<Title>', '<Degree>' and '<Second Graduation Year>' in Education
	Then an error pop up message '<Message>' will appear
	And no new row with '<University>', '<Country>', '<Title>', '<Degree>' and '<Second Graduation Year>' will not be added to the list

	Examples:
		| Country     | University | Title     | Degree | Graduation Year | Second Graduation Year | Message                            |
		| Afghanistan | Ac         | Associate | ABC    | 2020            | 2020                   | This information is already exist. |
		| Afghanistan | Ac         | Associate | ABC    | 2020            | 2021                   | Duplicated data                    |

@certifications
Scenario Outline: Adding Certifications with valid inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Certifications tab
	And he enters '<Certificate>', '<From>', '<Year>' in Certifications
	Then a success popup message '<Certificate> has been added to your certification' will appear
	And a new row with '<Certificate>', '<From>', '<Year>' will be added sucessfully

	Examples:
		| Certificate | From | Year |
		| ABC         | xx   | 2000 |

@certifications
Scenario Outline: Saving Certifications with missing inputs
	Given Seller is on Profile Page
	When he clicks on Add New button under Certifications tab
	And he enters '<Certificate>', '<From>', '<Year>' in Certifications
	Then an error pop up message 'Please enter Certification Name, Certification From and Certification Year' will appear
	And a row with '<Certificate>', '<From>', '<Year>' will not be added to the list

	Examples:
		| Certificate | From | Year |
		|             |      |      |
		|             | xy   | 2014 |
		|             |      | 2018 |
		|             | xy   |      |

@certifications
Scenario Outline: Adding Certifications with duplicate data
	Given Seller is on Profile Page
	And no Certification is added
	When he clicks on Add New button under Certifications tab
	And he enters '<Certificate>', '<From>', '<Year>' in Certifications
	And he clicks on Add New button under Certifications tab
	And he enters '<Certificate>', '<From>', '<Second Year>' in Certifications
	Then an error pop up message '<Message>' will appear
	And a row with '<Certificate>', '<From>', '<Second Year>' will not be added to the list

	Examples:
		| Certificate | From | Year | Second Year | Message                            |
		| ABC         | AA   | 2020 | 2020        | This information is already exist. |
		| ABC         | AA   | 2020 | 2021        | Duplicated data                    |

@availability
Scenario Outline: Selecting input for Availabiltiy
	Given Seller is on Profile Page
	When he click on "edit icon" in-front of "Availability"
	And select '<Availability>' from dropdown list
	Then he must be able to see Availability updated as '<Availability>'

	Examples:
		| Availability |
		| Full Time    |
		| Part Time    |

@hours
Scenario Outline: Selecting input for Hours
	Given Seller is on Profile Page
	When he click on "edit icon" in-front of "Hours"
	And select '<Hours>' from dropdown list
	Then he must be able to see Hours updated as '<Hours>'

	Examples:
		| Hours                    |
		| Less than 30hours a week |
		| As needed                |

@earntarget
Scenario Outline: Selecting input for Earn Target
	Given Seller is on Profile Page
	When he click on "edit icon" in-front of "Earn Target"
	And select '<Target>' from dropdown list
	Then he must be able to see Earn Target updated as '<Target>'

	Examples:
		| Target                           |
		| Between $500 and $1000 per month |
		| More than $1000 per month        |

@seller_name
Scenario Outline: Updating Sellers name
	Given Seller is on Profile Page
	When he click on dropdown icon, just before his name
	And updates his '<FirstName>' and '<LastName>'
	Then he must be able to see '<FirstName>' and '<LastName>' updated on the Profile Page

	Examples:
		| FirstName | LastName     |
		| @$##$#$   | 392839283923 |
		| Manali    | Jain         |