# Software Engineering for Service Computing Coursework
A microservices-based web application which provides courses online. This application was developed as part of the Winter 2023 SESC course at Leeds Beckett University. 

## Microservices
###1. Student Microservice
Required Features:
Register/Log in - create a portal user and log in.
View Courses - view all the courses offered.
Enrol in Course - enrol in course. If this is your first enrolment, a student account is created at this point.
View Enrolments - view all the courses you are enrolled in.
View/Update Student Profile - view profile (includes student ID), update name and surname.
Graduation - view eligibility to graduate (must not have any outstanding invoices).
###2. Finance Microservice
Required Features:
Create Account - create a finance account by passing a student ID.
Query Account - find a finance account by passing a student ID. The response shows whether the account has an outstanding balance.
View Invoice - view all invoices or a single invoice, by invoice ID.
Create Invoice - create a new outstanding invoice by passing a student ID.
Pay Invoice - pay an outstanding invoice.
Cancel Invoice - cancel an outstanding invoice.
###3. Library Microservice
Required Features - Student User:
Login - secure password-verified login.
Books - display all books in the library.
Borrow - borrow a book using barcode scanner.
Return - return a book using thebarcode scanner.
Account - display the user's borrowng history.
Required Features - Library Admin User:
Add Title - add new books to the database using the barcode scanner.
Books - display all books in the library.
Students - dispay all students, and the number of books each has on loan/overdue.
Current Loans - display all books currently on loan.
Overdue - display all books that are overdue.
