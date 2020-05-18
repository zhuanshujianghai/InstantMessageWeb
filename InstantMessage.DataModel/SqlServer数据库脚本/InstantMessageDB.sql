CREATE TABLE Members
(
	Id BIGINT PRIMARY KEY NOT NULL,
	UserName NVARCHAR(20) NOT NULL,--�û���
	ImageUrl NVARCHAR(100) NULL,--ͷ��
	ConnectionID VARCHAR(50) NOT NULL,--����ID
	CreateTime DATETIME NOT NULL,--����ʱ��
	UpdateTime DATETIME NULL--�޸�ʱ��
)

CREATE TABLE Messages
(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	FromMemberId BIGINT NOT NULL,--������ID
	ToMemberId BIGINT NOT NULL,--������ID
	Message NVARCHAR(500) NOT NULL,--��Ϣ
	CreateTime DATETIME NOT NULL --����ʱ��
)








