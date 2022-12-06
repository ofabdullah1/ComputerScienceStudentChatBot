USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE quotes (
	quote_id int IDENTITY(1,1) NOT NULL,
	motivational_quote varchar(500) NOT NULL,
	author varchar(50)
)

INSERT INTO quotes (motivational_quote, author) VALUES ('You don’t lose if you get knocked down, you lose if you stay down', 'Muhammad Ali');
INSERT INTO quotes (motivational_quote, author) VALUES ('Do the difficult things while they are easy and do the great things while they are small. A journey of a thousand miles must begin with a single step', 'Lao Tzu');
INSERT INTO quotes (motivational_quote, author) VALUES ('Standard programming answer number one: ''it depends''', 'John Fulton');
INSERT INTO quotes (motivational_quote, author) VALUES ('It''s not that I''m so smart, it''s just that I stay with problems longer', 'Albert Einstein');
INSERT INTO quotes (motivational_quote, author) VALUES ('Aim above morality. Be not simply good, be good for something', 'Henry David Thoreau');
INSERT INTO quotes (motivational_quote, author) VALUES ('Do not go where the path may lead, go instead where there is no path and leave a trail.', 'Ralph Waldo Emerson');
INSERT INTO quotes (motivational_quote, author) VALUES ('The only way to do great work is to love what you do. If you haven’t found it yet, keep looking. Don’t settle', 'Steve Jobs');
INSERT INTO quotes (motivational_quote, author) VALUES ('The future belongs to those who believe in the beauty of their dreams', 'Eleanor Roosevelt');


--populate default data

-- Robert/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Robert','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

--Nancy/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Nancy','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO
