 CREATE DATABASE LICAFE;

CREATE TABLE ADMIN(
ADMIN_ID Varchar(50)Not Null check(ADMIN_ID like 'O%')primary key,
AD_PASSWORD Varchar(15)
);


CREATE TABLE CUSTOMER(
CUSTOMER_ID Varchar(50) Not Null check(CUSTOMER_ID like'C%')primary key,
CUSTOMER_NAME varchar(100),
CUSTOMER_ADD Varchar(300),
CUSTOMER_TP int,
CU_PASSWORD Varchar(15),
);

CREATE TABLE ITEM(
ITEM_ID Varchar(50)Not Null check(ITEM_ID like 'I%')primary key,
ITEM_NAME Varchar(200),
PRICE decimal,
ADMIN_ID varchar(50)foreign key references ADMIN(ADMIN_ID)
);

CREATE TABLE ORDER_DETAILS(
ORDER_ID Varchar(50)Not Null check(ORDER_ID like 'O%')primary key,
BILL_AMOUNT decimal,
ORDER_DATE date default GETDate(),
PAYMENT decimal,
CUSTOMER_ID Varchar(50)foreign key references CUSTOMER(CUSTOMER_ID)
);


CREATE TABLE CUST_ITEM(
CUSTOMER_ID Varchar(50)Not Null,
ITEM_ID Varchar(50)Not Null,
primary key(CUSTOMER_ID,ITEM_ID)
);

ALTER TABLE ITEM
DROP ADMIN_ID

