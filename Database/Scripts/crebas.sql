/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     11/11/2021 16:59:27                          */
/*==============================================================*/


/*==============================================================*/
/* Table: Customer                                              */
/*==============================================================*/
create table Customer
(
   Id                   int not null auto_increment,
   Name                 varchar(100) not null,
   Email                varchar(50) not null,
   CreatedAt            datetime not null,
   primary key (Id)
);

/*==============================================================*/
/* Table: OrderStatus                                           */
/*==============================================================*/
create table OrderStatus
(
   Id                   smallint not null,
   Name                 varchar(50) not null,
   primary key (Id)
);

/*==============================================================*/
/* Table: OrderStatusHistory                                    */
/*==============================================================*/
create table OrderStatusHistory
(
   Id                   int not null auto_increment,
   OrderId              int not null,
   OrderStatusId        smallint not null,
   CreatedAt            datetime not null,
   primary key (Id)
);

/*==============================================================*/
/* Table: Orders                                                */
/*==============================================================*/
create table Orders
(
   Id                   int not null,
   Price                double not null,
   CreatedAt            datetime not null,
   CustomerId           int not null,
   OrderStatusId        smallint not null,
   primary key (Id)
);

alter table OrderStatusHistory add constraint FK_ORDERSTATUS_ORDERSTATUSHISTORY foreign key (OrderStatusId)
      references OrderStatus (Id) on delete restrict on update restrict;

alter table OrderStatusHistory add constraint FK_ORDER_ORDERSTATUSHISTORY foreign key (OrderId)
      references Orders (Id) on delete restrict on update restrict;

alter table Orders add constraint FK_CUSTOMER_ORDER foreign key (CustomerId)
      references Customer (Id) on delete restrict on update restrict;

alter table Orders add constraint FK_ORDERSTATUS_ORDER foreign key (OrderStatusId)
      references OrderStatus (Id) on delete restrict on update restrict;

