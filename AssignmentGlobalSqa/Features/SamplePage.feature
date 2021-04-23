﻿Feature: Sample Page test
	This includes sceanrion related to form filling
	mandatory field
	validation 

Scenario Outline: Verify user adble to enter data in the respoective files..
Default Data will get generated by faker library, if there is no data present in the example table
	Given Access Sample Page Test from menu
	When Choose File
		| FileLocation   |
		| <FileLocation> |
	And Enter Name
		| EnterName   |
		| <EnterName> |
	And Enter Email
		| EnterEmail   |
		| <EnterEmail> |
	And Enter WebSite
		| EnterWebSite   |
		| <EnterWebSite> |
	And Select Experience
		| Experiences   |
		| <Experiences> |
	And Choose Expertise
		| Expertise   |
		| <Expertise> |
	And Select Education
		| Education   |
		| <Education> |
	And Enter Comment
		| Comment   |
		| <Comment> |
	And Click on Submit
	Then Navigate to message sent
	And Click on Link GO BACK

	Examples:
		| FileLocation | EnterName | EnterEmail         | EnterWebSite           | Experiences | Expertise                         | Education | Comment     |
		| D:\2.txt     | Deepak    | deepakv@winjit.com | https://www.google.com | 10+         | Functional Testing,Manual Testing | Other     | Hello World |
		#| D:\3.txt     | Mrunal    | mrunal@winjit.com  | https://www.google.com | 3-5         | Manual Testing                    | Other     | Hello World |
		#| D:\3.txt     | Mrunal    | rakesh@winjit.com  | https://www.google.com | 5-7         |                                   | Other     | Hello World |
		#|              |           |                    |                        |             |                                   |           |             |