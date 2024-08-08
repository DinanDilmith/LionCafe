This is a simple project developed using c# for academic purposes. This project is not fully developed and there are few unhandled exceptions.

configuring database -

I used "MS SQL Server" as the database for this system. I added the SQL query file named "cafe mgt.sql" along with the project. You can just run the query in SQL server.

user guide-

In the beginning of the application you can login as an admnin and as a customer. Admin is already predifined in the code and you cant add new admins. When logging in as a customer, you can create a new account if you already don't have one. Creating an account is easy and simple. I've already included customer login info below so you can use it if you don't want to create an account.

an admin can basically do 2 major tasks in this system.

1.customize items - insert - update - delete - view

2.customize customers - insert - update - delete - view

to login as an admin, you can use following info.

admin ID = O001 admin pw = admin

There are several already signed in customers and admin can view them. You can use one of those Info or use below info to login as a customer.

customer ID = c001 customer pw= 1234

after logging in as a customer, you can select the quantity you want from each item and see the bill by clicking "display bill" button. click "pay now" button to proceed to payments tab and fill the details to complete the payment.
