INSERT INTO User (UserID, UserName, Email, Account)
VALUES ('A1236456789', '王o明', 'test@email.com', '1111999666');

INSERT INTO Product (ProductName, Price, FeeRate)
VALUES 
('基金', 1000.00, 0.01),
('股票', 2000.00, 0.01),
('外匯', 3000.00, 0.02);

INSERT INTO LikeList (UserID, Quantity, Account, TotalFee, TotalAmount)
VALUES 
('A1236456789', 2, '1111999666', 3.00, 20200.00),
('A1236456789', 1, '1111999666', 5.5, 6666.00);