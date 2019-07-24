Feature: Login
	In order to swap my skills
	As a skill trader
	I want to be add language, Education, Certifications, Description on my profile


@mytag
Scenario: SignIN
	Given I have entered the url
	And I have entered username and password
	When I press login
	Then I should be on the home page

