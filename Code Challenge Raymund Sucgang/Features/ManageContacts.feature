Feature: Manage Contacts
As an association admin user
I want to create and delete contact on the Manage Contacts page


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
	Then I see the text "Created contact successfully"

@remove_contact
Scenario: Remove Contact
	Given I login as admin in VoterVoice
	And I navigate to the Manage Contacts page
	And I click "Default List"
	And I see the text "Doe, John"
	When I delete user "Doe, John" from the contacts
	Then I do not see the text "Doe, John"

	
