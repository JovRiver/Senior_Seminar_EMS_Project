# Software_Engineering_EMS_Project

Our project for Software Engineering. In this project, we worked in a group to create a simplistic representation of an electronic medical service.
We used Visual Studio 2019 for this project and Windows Presentation Foundation (WPF). 

This application contains a login screen and four views.

 - Patient View: The patient portal where a patient can view their information.

 - Receptionist View: A view that allows a receptionist to add or remove appointments for patients, and sign in patients who have come for their appointments.

 - Nurse View: A view to allow nurses to quickly view a patients information and make note of any additional information.

 - Doctor View: A view to allow a doctor to view patient information and add to it, including adding new prescriptions.


I personally worked on the receptionist view.

Our first attempt at the project left it in an untenable state, so I have decided to work on refactoring the whole project in order to bring it more in line with an MVC design pattern.

Note: I created a legacy branch to hold the original build for comparison.

I will update this as I make progress.

## Changelog 1.1
[New Classes]
 - Created a Models folder to hold project models
 - Created SqlDatabaseAccess class to handle database access, including an interface mainly used for testing at this time
 - Split up database queries (query string, command parameters) into separate classes
 - Created interfaces for query types to constrain which queries can be used with SqlDatabaseAccess methods
 - Created reader classes to handle reading from the database, these are called from the SqlDatabaseAccess class
 - Created interfaces for the reader classes
 - Created comparer classes to compare Appointment, PatientInfo, and Prescription classes

[Unit Testing]
 - Created Project-2-EMS_Tests project and added to solution
 - Created tests for the SqlDatabaseAccess class using Moq
 - Created tests for the database query classes
 - Created tests for the reader classes
 - Created tests for the comparer classes

