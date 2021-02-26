Feature: Manage Contacts
As an association admin user
I want to create an delete contact on the Manage Contacts page


@add_contact
Scenario: Add Contact
	Given I login as admin in VoterVoice
	And I navigate to the Manage Contacts page
	When I click "New Contact"
	And I enter contact details
	| Key       | Value                       |
	| Prefix    | Mr.                         |
	| Firstname | John                        |
	| Lastname  | Doe                         |
	| Street    | 1201 Pennsylvania Avenue NW |
	| City      | Washington                  |
	| State     | DC                          |
	| Zip       | 20004                       |
	And I verify that zipcode is "20004"
	And I verify that "Group List" is already set to "Default List"
	When I press "Save"
	Then I see that the data was saved correctly


Scenario: Remove Contact
	Given I login as admin in VoterVoice
	And I navigate to the Manage Contacts page
	And I verify that user "" exits
	When I delete user "" from the contacts
	Then I see that the user has been deleted

	
